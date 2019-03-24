using JsonUtil;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections.Generic;

public class JsonFieldsCollector
{
    private readonly Dictionary<string, JValue> fields;

    public JsonFieldsCollector(JToken token, AccessModifier accessModifier)
    {
        fields = new Dictionary<string, JValue>();
        FileHierArchy = new FileHierArchy();
        FileHierArchy.Classes = new List<Class>();
        FileHierArchy.Classes.Add(new Class("IntialClass", AccessModifier));
        CollectFields(token);
        JObject jObject = JObject.Parse(token.ToString());

        ParseFields(fields, jObject);
        AccessModifier = accessModifier;
    }

    private void ParseFields(Dictionary<string, JValue> fields, JObject jObject)
    {

        

        foreach (var field in fields)
        {
            var test = jObject.SelectToken(field.Key);
            ParseKey(field.Key);

            Console.WriteLine($"{field.Key}: '{field.Value}'");
        }
    }

    private void ParseKey(string key)
    {
        var path = key;
    }

    public FileHierArchy FileHierArchy { get; set; }
    public AccessModifier AccessModifier { get; private set; }

    private void CollectFields(JToken jToken)
    {
        switch (jToken.Type)
        {
            case JTokenType.Object:
                HandleJObject(jToken);
                //foreach (var child in jToken.Children<JProperty>())
                //    CollectFields(child);
                break;
            case JTokenType.Array:
                foreach (var child in jToken.Children())
                    CollectFields(child);
                break;
            case JTokenType.Property:
                HandleJProperty(jToken);
                ///CollectFields(((JProperty)jToken).Value);
                break;
            default:
                fields.Add(jToken.Path, (JValue)jToken);
                break;
        }
    }

    private void HandleJObject(JToken jToken)
    {

        string parent = string.Empty;

        parent = jToken.Parent == null ? "IntialClass" : ((JProperty)jToken.Parent).Name;

        if (!ParentExists(parent.StripChars()))
            FileHierArchy.Classes.Add(new Class(parent, AccessModifier));

        foreach (var child in jToken.Children<JProperty>())
        {
            CollectFields(child);
        }
    }

    private bool ParentExists(string parenName)
    {
        return FileHierArchy.Classes
                        .Exists(x => x.Name == parenName);
        //if (parentClass != null)
        //    return true;

        //return false;
    }

    private void HandleJProperty(JToken jToken)
    {

        string parent = string.Empty;
        if (jToken.Parent.Parent == null)
        {
            //jToken.Parent.Parent
            parent = "IntialClass";
        }
        else
        {
            parent = ((JProperty)jToken.Parent.Parent).Name;
        }

        var jpropKey = ((JProperty)jToken).Name;

        
        var parentClass = FileHierArchy.Classes
                        .Find(x => x.Name == parent.StripChars());

        if (parentClass != null)
        {
            var isClass = (((JProperty)jToken).Value.Type == JTokenType.Object);
            parentClass.Properties.Add(new ClassProperty(((JProperty)jToken).Name, AccessModifier, "", isClass));
        }

        //must happen
        var jPropValue = ((JProperty)jToken).Value;
        CollectFields(jPropValue);
    }

    public IEnumerable<KeyValuePair<string, JValue>> GetAllFields() => fields;
}