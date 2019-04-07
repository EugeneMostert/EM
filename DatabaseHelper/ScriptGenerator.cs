using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    class ScriptGenerator
    {
        public ScriptGenerator(ITableSchema tableSchema)
        {
            TableSchema = tableSchema;
        }

        public ITableSchema TableSchema { get; set; }

        public string GetCreateTable()
        {
            System.Text.StringBuilder script = new StringBuilder();

            if (TableSchema == null)
                throw new Exception("Table schema cannot be null");

            if (TableSchema.Columns == null)
                throw new Exception("Table Columns cannot be null");

            script.AppendLine("CREATE TABLE " + TableSchema.Name);
            script.Append(Environment.NewLine);
            script.AppendLine("(");
            script.Append(Environment.NewLine);

            var columns = TableSchema.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                
                script.AppendFormat("\t {0} {1} {2} {3}", columns[i].ColumnName, 
                                                          columns[i].DataType,
                                                          columns[i].Constraints.Count > 0 ? columns[i].Constraints.ToString() : "",
                                                          i > (columns.Count-1) ? "," : FormatPrimaryKeys());

                script.Append(Environment.NewLine);
            }
            script.Append(Environment.NewLine);
            script.AppendLine(")");

            return script.ToString();
        }

        private string FormatPrimaryKeys()
        {
            var keys = TableSchema.PrimaryKeys;
            if (keys == null)
                return "";

            var pks = new StringBuilder("Primary Keys (");
            int iter = 0;
            foreach(var key in keys)
            {
                pks.AppendFormat("{0}{1}", key.ColumnName, keys.Count > iter ? "," : "");
            }
            pks.Append(")");
            return pks.ToString();
        }
    }
}
