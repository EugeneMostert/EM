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

        #region Constructor
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

        public TableSchema GetTableSchema()
        {
            var tableSchema = new TableSchema();
            tableSchema.Name = this.ClassName;
            foreach (var column in Fields)
            {
                if(dataMapper.ContainsKey(column.Value))
                {
                    tableSchema.Columns.Add(new ColumnDefinition
                    {
                        Name = column.Key,
                        DataType = dataMapper[column.Value],
                        Length = GetDefaultDataLength(dataMapper[column.Value]),
                        Constraints = GetDefaultConstraints(dataMapper[column.Value])

                    });
                }
            }
        }

        private List<string> GetDefaultConstraints(string v)
        {
            throw new NotImplementedException();
        }

        private int GetDefaultDataLength(string v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public class TableSchema
    {
        public string Name { get; set; }
        public Columns Columns { get; set; }
        public PrimaryKeys PrimaryKeys { get; set; }
    }

    public class PrimaryKeys: List<PrimaryKey>
    {
    }

    public class PrimaryKey
    {
    }

    public class Columns : List<ColumnDefinition>
    {

    }

    public class ColumnDefinition
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public int Length { get; set; }
        public List<string> Constraints { get; set; }
    }
}
