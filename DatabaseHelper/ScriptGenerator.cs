using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    class ScriptGenerator
    {
        public ScriptGenerator(TableDefinition tableDefinition)
        {
            TableDefinition = tableDefinition;
        }

        public TableDefinition TableDefinition { get; set; }

        public string GetCreateTable()
        {
            System.Text.StringBuilder script = new StringBuilder();

            if (TableDefinition == null)
                throw new Exception("Table definition cannot be null");

            if (TableDefinition.Columns == null)
                throw new Exception("Table Columns cannot be null");

            script.Append($"CREATE TABLE {TableDefinition.TableName}\r\n");
            script.Append("(\r\n");

            var columns = ConstructColumns(TableDefinition.Columns);
            script.Append(columns);

            var primaryKeys = ConstructPrimaryKeys(TableDefinition.PrimaryKeys);
            script.Append(primaryKeys);

            var foreignKeys = FormatForeignKeys(TableDefinition);
            script.Append(foreignKeys);
            script.Append(")\r\n");

            return script.ToString();
        }

        private string ConstructPrimaryKeys(PrimaryKeys primaryKeys)
        {
            if(primaryKeys != null)
                throw new NotImplementedException();

            return "";
        }

        private string ConstructColumns(Columns columns)
        {
            var columnBuilder = new StringBuilder();
            for (int i = 0; i < columns.Count; i++)
            {
                var test = i > (columns.Count - 1);
                //string columnName = "";
                if (i == 0 && !columns[i].ColumnName.ToUpper().Equals("ID"))
                {
                    var idCol = $"\t {"ID".ToSqlColumn()} {"INT"}{""}{""},\r\n";
                    columnBuilder.AppendFormat(idCol);
                }

                var columnName = columns[i].ColumnName;
                var dataType = columns[i].DataType.LeftPad();
                var constraints = FormatConstraints(columns[i]).LeftPad();
                var pks = i < (columns.Count - 1) ? "," : FormatPrimaryKeys().LeftPad();

                var col = $"\t {columnName.ToSqlColumn()}{dataType}{constraints}{pks}\r\n";


                columnBuilder.AppendFormat(col);

            }
            return columnBuilder.ToString();

        }

        private string FormatPrimaryKeys()
        {
            var keys = TableDefinition.PrimaryKeys;
            if (keys == null)
                return "";

            var pks = new StringBuilder("Primary Keys (");
            int iter = 0;
            foreach(var key in keys)
            {
                pks.AppendFormat("{0}{1}", key.ColumnName, keys.Count > iter ? "," : "");
            }
            pks.Append(")\r\n");
            return pks.ToString();
        }
        private string FormatConstraints(ColumnDefinition columnDefinition)
        {
            if (columnDefinition.Constraints == null)
                return "";

            return "";
        }
        private string FormatForeignKeys(TableDefinition tableDef)
        {
            var keybuilder = new StringBuilder();
            keybuilder.Append("");
            foreach (var key in tableDef.ForeighnKeys)
            {
                keybuilder.Append($"CONSTRAINT FK_{key.TargetTable}{tableDef.TableName} FOREIGN KEY {key.ColumnName} REFERENCES {key.TableName}({key.TargetColumn})\r\n");
            }

            return keybuilder.ToString();
        }
        
    }

    public static class Extensions
    {
        public static string LeftPad(this string unpadded)
        {

            return string.IsNullOrEmpty(unpadded)? "" : $" {unpadded}";
        }

        public static string ToSqlColumn(this string col)
        {
            return string.IsNullOrEmpty(col) ? "" : $"[{col}]";
        }
    }
}
