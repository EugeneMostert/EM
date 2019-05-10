using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    class TableGenerator
    {
        #region CTOR
        public TableGenerator()
        {

        }

        #endregion

        #region Private Properties
        public Dictionary<Type, string> _dataMapper
        {
            get
            {
                var dataMapper = new DataMapper
            {
                { MapperDataType.Int, "INT" },
                { MapperDataType.String, "NVARCHAR(500)" },
                { MapperDataType.Bool, "BIT" },
                { MapperDataType.DateTime, "DATETIME" },
                { MapperDataType.Float, "FLOAT" },
                { MapperDataType.Decimal, "DECIMAL(18,0)" },
                { MapperDataType.Guid, "UNIQUEIDENTIFIER" },
                { MapperDataType.Long, "BIGINT" },
                { MapperDataType.DateTimeOffset, "DATETIMEOFFSET" }
            };
                var mapper = new DataMapper();
                return mapper.ToDictionary(dataMapper);
            }

        }


        public Tables Tables { get; set; } = new Tables();
        #endregion

        #region Public Methods
        public List<string> GenerateFromBinary(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File Doesn't exist");
                return null;
            }

            var file = new FileInfo(filename);
            return GenerateFromBinary(file);
        }

        public List<string> GenerateFromBinary(FileInfo file)
        {

            if (!File.Exists(file.FullName))
            {
                Console.WriteLine("File Doesn't exist");
                return null;
            }

            try
            {
                Assembly a = Assembly.LoadFile(file.FullName);
                Type[] types = a.GetTypes();
                var tables = GetTables(types);
                var createScripts = GetCreateTableScripts(tables);
                return createScripts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                return null;
            }
        }
        #endregion

        #region Private Methods
        private Tables GetTables(Type[] types)
        {
            Tables = new Tables();
            
            // Get Types in the assembly.
            foreach (Type t in types)
            {
                var tableDefinition = new TableDefinition();
                tableDefinition.TableName = t.Name;

                var columns = new Columns();
                var foreignKeys = new ForeignKeys();
                var props = t.GetProperties();

                foreach(var prop in props)
                {
                    var column = new ColumnDefinition();
                    
                    try
                    {
                        //complex type
                        if(!_dataMapper.ContainsKey(prop.PropertyType))
                        {
                            column.ColumnName = $"{prop.Name}ID";
                            column.DataType = $"INT";

                            var foreighKey = new ForeignKey
                            {
                                ColumnName = column.ColumnName,
                                TableName = tableDefinition.TableName,
                                TargetTable = prop.Name,
                                TargetColumn = "ID"
                            };
                            foreignKeys.Add(foreighKey);
                        }
                        else
                        {
                            column.ColumnName = prop.Name;
                            column.DataType = _dataMapper[prop.PropertyType];
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Key: {prop.PropertyType} " + ex.Message);
                        Console.Read();
                    }

                    columns.Add(column);
                }

                tableDefinition.Columns = columns;
                tableDefinition.ForeighnKeys = foreignKeys;
                Tables.Add(tableDefinition);
                //TableSchema tc = new TableSchema(t, DataMapper());
                //Tables.Add(tc);
            }


            return Tables;
            //Create SQL for each table
            //foreach (var table in Tables)
            //{
            //    var scriptGenerator = new ScriptGenerator(table);
            //    Console.WriteLine(scriptGenerator.GetCreateTable());
                
            //}

            // Total Hacked way to find FK relationships! Too lazy to fix right now
            //foreach (TableSchema table in Tables)
            //{
            //    foreach (KeyValuePair<string, Type> field in table.Fields)
            //    {
            //        foreach (TableSchema t2 in Tables)
            //        {
            //            if (field.Value.Name == t2.ClassName)
            //            {
            //                // We have a FK Relationship!
            //                Console.WriteLine("GO");
            //                Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
            //                Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
            //                Console.WriteLine("GO");

            //            }
            //        }
            //    }
            //}
        }

        public List<string> GetCreateTableScripts(Tables tables)
        {
            var tableScripts = new List<string>();
            foreach (var table in Tables)
            {
                var scriptGenerator = new ScriptGenerator(table);
                var createScript = scriptGenerator.GetCreateTable();
                Console.WriteLine(createScript);
                tableScripts.Add(createScript);
            }
            return tableScripts;
        }
      
        #endregion
    }
}
