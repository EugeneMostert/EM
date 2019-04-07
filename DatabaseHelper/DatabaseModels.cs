using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public interface ITableSchema
    {
        string Name { get; set; }
        Columns Columns { get; set; }
        PrimaryKeys PrimaryKeys { get; set; }
    }

    public class TableSchema : ITableSchema
    {
        public string Name { get; set; }
        public Columns Columns { get; set; }
        public PrimaryKeys PrimaryKeys { get; set; }
    }

    public class TableDefinition
    {
        public string TableName { get; set; }
        public Columns Columns { get; set; }
        public PrimaryKeys PrimaryKeys { get; set; }
        public ForeignKeys ForeighnKeys { get; set; }
    }

    public class ForeignKeys : List<ForeignKey>
    {
    }

    public class ForeignKey
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string TargetTable { get; set; }
        public string TargetColumn { get; set; }
        public string Name { get; set; }
    }

    public class PrimaryKeys : List<PrimaryKey>
    {
    }

    public class PrimaryKey
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }

    }

    public class Columns : List<ColumnDefinition>
    {

    }

    public class ColumnDefinition
    {
        public int Ordinal { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public int MaxLength { get; set; }
        public bool IsNullable { get; set; }
        public ColumnContraints Constraints { get; set; }
    }

    public class ColumnContraints : List<ColumnConstraints>
    {
        public override string ToString()
        {
            var items = new StringBuilder();
            int iter = 0;
            foreach(ColumnConstraints item in this)
            {
                items.AppendFormat("{0}{1}", item.ToString(), this.Count > iter ? " " : "");
            }
            return items.ToString();
        }
    }

    public enum ColumnConstraints
    {
        [Description("not null")]
        NotNull,
        [Description("unique")]
        Unique,
        [Description("check")]
        Check,
        [Description("default")]
        Default,
        [Description("auto_increment")]
        AutoIncrement
    }
}
