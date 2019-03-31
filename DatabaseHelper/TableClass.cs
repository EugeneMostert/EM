using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public class TableClass
    {
        #region Private Properties
        private List<KeyValuePair<string, Type>> _fieldInfo = new List<KeyValuePair<string, Type>>();
        private string _className = string.Empty;
        private IDictionary<Type, string> dataMapper { get; set; }// = new Dictionary<Type, string>();
        #endregion

        #region CTOR
        public TableClass(Type t, IDictionary<Type, string> dataMapper)
        {
            this.dataMapper = dataMapper;
            this._className = t.Name;

            foreach (PropertyInfo p in t.GetProperties())
            {
                if (p.MemberType == MemberTypes.Property)
                {
                    KeyValuePair<string, Type> field = new KeyValuePair<string, Type>(p.Name, p.PropertyType);

                    this.Fields.Add(field);
                }
            }
        }
        #endregion

        #region Public Properties
        public List<KeyValuePair<string, Type>> Fields
        {
            get { return this._fieldInfo; }
            set { this._fieldInfo = value; }
        }

        public string ClassName
        {
            get { return this._className; }
            set { this._className = value; }
        }
        #endregion

        #region public Methods
        public string CreateTableScript()
        {
            System.Text.StringBuilder script = new StringBuilder();

            script.AppendLine("CREATE TABLE " + this.ClassName);
            script.AppendLine("(");
            script.AppendLine("\t ID BIGINT,");
            for (int i = 0; i < this.Fields.Count; i++)
            {
                KeyValuePair<string, Type> field = this.Fields[i];

                if (dataMapper.ContainsKey(field.Value))
                {
                    script.Append("\t " + field.Key + " " + dataMapper[field.Value]);
                }
                else
                {
                    // Complex Type? 
                    script.Append("\t " + field.Key + " BIGINT");
                }

                if (i != this.Fields.Count - 1)
                {
                    script.Append(",");
                }

                script.Append(Environment.NewLine);
            }

            script.AppendLine(")");

            return script.ToString();
        }
        #endregion
    }

    //public class 
}
