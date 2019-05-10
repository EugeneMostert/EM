using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {

            var tablegen = new TableGenerator();
            tablegen.GenerateFromBinary("EM.Entities.dll");
            
        }

        //private void Gen()
        //{
        //    List<TableClass> tables = new List<TableClass>();
        //    var file = new FileInfo("EM.Entities.dll");

        //    // Pass assembly name via argument
        //    Assembly a = Assembly.LoadFile(file.FullName);
        //    //Assembly a = Assembly.LoadFile(args[0]);

        //    Type[] types = a.GetTypes();

        //    // Get Types in the assembly.
        //    foreach (Type t in types)
        //    {
        //        TableClass tc = new TableClass(t);
        //        tables.Add(tc);
        //    }

        //    // Create SQL for each table
        //    foreach (TableClass table in tables)
        //    {
        //        Console.WriteLine(table.CreateTableScript());
        //        Console.WriteLine();
        //    }

        //    // Total Hacked way to find FK relationships! Too lazy to fix right now
        //    foreach (TableClass table in tables)
        //    {
        //        foreach (KeyValuePair<String, Type> field in table.Fields)
        //        {
        //            foreach (TableClass t2 in tables)
        //            {
        //                if (field.Value.Name == t2.ClassName)
        //                {
        //                    // We have a FK Relationship!
        //                    Console.WriteLine("GO");
        //                    Console.WriteLine("ALTER TABLE " + table.ClassName + " WITH NOCHECK");
        //                    Console.WriteLine("ADD CONSTRAINT FK_" + field.Key + " FOREIGN KEY (" + field.Key + ") REFERENCES " + t2.ClassName + "(ID)");
        //                    Console.WriteLine("GO");

        //                }
        //            }
        //        }
        //    }
        //    Console.Read();
        //}
    }
}
