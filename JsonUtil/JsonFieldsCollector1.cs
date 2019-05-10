using JsonUtil;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

public class JsonFieldsCollector1
{
    private readonly Dictionary<string, JValue> fields;

    public JsonFieldsCollector1(JToken token, AccessModifier accessModifier)
    {
        fields = new Dictionary<string, JValue>();
        CollectFields(token);
    }

    public AccessModifier AccessModifier { get; private set; }

    private void CollectFields(JToken jToken)
    {
        
        switch (jToken.Type)
        {
            case JTokenType.Object:
                HandleJObject(jToken);
                break;
            case JTokenType.Array:
                foreach (var child in jToken.Children())
                    CollectFields(child);
                break;
            case JTokenType.Property:
                HandleJProperty(jToken);
                break;
            default:
                HandleField(jToken);
                break;
        }
    }

    private void HandleJObject(JToken jToken)
    {
        
        foreach (var child in jToken.Children<JProperty>())
        {
            if (jToken.Children().Count() > 1)
                //"";

            CollectFields(child);
        }
    }

    private void HandleJProperty(JToken jToken)
    {
        //must happen
        var jPropValue = ((JProperty)jToken).Value;
        CollectFields(jPropValue);
    }

    private void HandleField(JToken jToken)
    {
        Console.WriteLine(jToken.Path);
        fields.Add(jToken.Path, (JValue)jToken);
    }

    public IEnumerable<KeyValuePair<string, JValue>> GetAllFields() => fields;
}