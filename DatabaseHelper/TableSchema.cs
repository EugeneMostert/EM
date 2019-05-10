using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public class TableSchema
    {
        #region Private Properties
        private string className;
        private Type type;
        private TableDefinition tableDefinition;


        private DataMapper dataMapper { get; set; }// = new Dictionary<Type, string>();
        #endregion

        #region Constructor
        public TableSchema(Type t, IDictionary<Type, string> dataMapper)
        {
            this.dataMapper = dataMapper;
            this.className = t.Name;


            Initialize();
            
        }

        public TableDefinition Initialize()
        {
            TableDefinition.Columns = new Columns();

            TableDefinition.TableName = this.className;


            foreach (PropertyInfo p in Type.GetProperties())
            {
                if (p.MemberType == MemberTypes.Property)
                {
                    //if(
                    //    dataMapper.ContainsKey[p.PropertyType];
                    //TableDefinition.Columns.Add(new ColumnDefinition { ColumnName = p.Name, DataType = p.PropertyType } )
                    
                    //    KeyValuePair<string, Type> field = new KeyValuePair<string, Type>(p.Name, p.PropertyType);

                    //this.Fields.Add(field);
                }
            }
            return TableDefinition;
        }

        public TableSchema(Type t, DataMapper dataMapper1)
        {
            this.type = t;
            this.dataMapper = dataMapper1;
        }
        #endregion

        #region Public Properties

        //public List<KeyValuePair<string, Type>> Fields
        //{
        //    get { return this._fieldInfo; }
        //    set { this._fieldInfo = value; }
        //}

        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }

        public TableDefinition TableDefinition
        {
            get => tableDefinition;
            set
            {
                if (tableDefinition == null)
                    tableDefinition = new TableDefinition();
                

                tableDefinition = value;
            }
        }

        public Type Type { get => type; set => type = value; }
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

        public TableDefinition GetTableDefinition()
        {
            var tableSchema = new TableDefinition();
            tableSchema.TableName = this.ClassName;
            foreach (var column in Fields)
            {
                if(dataMapper.ContainsKey(column.Value))
                {
                    tableSchema.Columns.Add(new ColumnDefinition
                    {
                        ColumnName = column.Key,
                        DataType = dataMapper[column.Value],
                        MaxLength = GetDefaultDataLength(dataMapper[column.Value]),
                        //Constraints = GetDefaultConstraints(dataMapper[column.Value])

                    });
                }
            }
            return tableSchema;
        }

        private List<ColumnConstraints> GetDefaultConstraints(string v)
        {
            throw new NotImplementedException();
        }

        private int GetDefaultDataLength(string v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    //public static class PropertyExtension
    //{
    //    public static object InitializeNull(this object t)
    //    {
    //        //if(t == null)
    //        //{
    //            var type = t.GetType();
    //        type.
    //            var instance = Activator.CreateInstance<t.GetType()>(t);

    //            return instance;
    //        //}
    //        //return typeof(T);
    //    }
    //}
    
}
