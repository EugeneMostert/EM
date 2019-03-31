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
        private Dictionary<Type, string> DataMapper
        {
            get
            {
                // Add the rest of your CLR Types to SQL Types mapping here
                Dictionary<Type, string> dataMapper = new Dictionary<Type, string>();
                dataMapper.Add(typeof(int), "BIGINT");
                dataMapper.Add(typeof(string), "NVARCHAR(500)");
                dataMapper.Add(typeof(bool), "BIT");
                dataMapper.Add(typeof(DateTime), "DATETIME");
                dataMapper.Add(typeof(float), "FLOAT");
                dataMapper.Add(typeof(decimal), "DECIMAL(18,0)");
                dataMapper.Add(typeof(Guid), "UNIQUEIDENTIFIER");

                return dataMapper;
            }
        }

        public List<TableClass> Tables { get; set; } = new List<TableClass>();
        #endregion

        #region Public Methods
        public void GenerateFromBinary(string filename)
        {
            if (File.Exists(filename))
            {
                var file = new FileInfo(filename);
                GenerateFromBinary(file);
            }
            else
                Console.WriteLine("File Doesn't exist");
        }

        public void GenerateFromBinary(FileInfo file)
        {
           
            if(File.Exists(file.FullName))
            {
                try
                {
                    Assembly a = Assembly.LoadFile(file.FullName);
                    Type[] types = a.GetTypes();
                    Generate(types);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                Console.WriteLine("File Doesn't exist");

        }
        #endregion

        #region Private Methods
        private void Generate(Type[] types)
        {
            // Get Types in the assembly.
            foreach (Type t in types)
            {
                TableClass tc = new TableClass(t, DataMapper);
                Tables.Add(tc);
            }

            // Create SQL for each table
            foreach (TableClass table in Tables)
            {
                Console.WriteLine(table.CreateTableScript());
                Console.WriteLine();
            }

            // Total Hacked way to find FK relationships! Too lazy to fix right now
            foreach (TableClass table in Tables)
            {
                foreach (KeyValuePair<string, Type> field in table.Fields)
                {
                    foreach (TableClass t2 in Tables)
                    {
                        if (field.Value.Name == t2.ClassName)
                        {
                            // We have a FK Relationship!
                            Console.WriteLine("GO");
                            Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
                            Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
                            Console.WriteLine("GO");

                        }
                    }
                }
            }
            Console.Read();
        }
        #endregion
    }
}
