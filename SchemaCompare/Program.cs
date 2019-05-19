using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Dac.Compare;
using System.IO;
using Microsoft.SqlServer.Dac;
using System.Data;
using System.Data.Sql;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SchemaCompare
{
    class Program
    {

        public static SchemaCompareEndpoint SourceEndPoint { get; set; }
        public static SchemaCompareEndpoint TargetEndPoint { get; set; }
        public static string Testing { get; set; }
        static void Main(string[] args)
        {
            var type = Testing.GetType();
            var propertyInfo = type.GetProperty(Testing);
            var propName = propertyInfo.Name;

            //string file = "dacOptions.json";
            //var json = JsonConvert.SerializeObject(new DacDeployOptions());
            //File.WriteAllText("dacOptions.json", json);
            //Process.Start(file);
            //Console.WriteLine(json);
            //Console.Read();
            //var dacOptions = new DacDeployOptions();
            //var options = dacOptions.GetType().GetProperties();
            //var diclist = new Dictionary<string, string>();
            //var list = new List<string>();

            //foreach (var option in options)
            //{
            //    var name = option.Name;
            //    var type = option.PropertyType.Name.ToLower();
            //    var value = option.GetValue(dacOptions);
            //    Console.WriteLine($"public {type} {name} {{ get; set; }}");
            //    list.Add($"public {type} {name} {{ get; set; }}");
            //    //list.Add(name, string.IsNullOrEmpty(value));
            //}
            //{ }
            //var conBuilder = new SqlConnectionStringBuilder();
            //conBuilder.DataSource = "localhost";
            //conBuilder.UserID = "sa";
            //conBuilder.Password = "sa";

            //using (var con = new SqlConnection(conBuilder.ToString()))
            //{
            //    con.Open();

            //}


            //string myServer = Environment.MachineName;
            //var instance = SqlDataSourceEnumerator.Instance;
            //var dt = instance.GetDataSources();
            //DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            //for (int i = 0; i < servers.Rows.Count; i++)
            //{
            //    if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
            //    {
            //        if ((servers.Rows[i]["InstanceName"] as string) != null)
            //            Console.WriteLine(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
            //        //CmbServerName.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
            //        else
            //            Console.WriteLine(servers.Rows[i]["ServerName"]);
            //    }
            //}


            //var sourceconn = @"data source=(localdb)\mssqllocaldb;initial catalog=identity;integrated security=true;connect timeout=30;encrypt=false;trustservercertificate=false;applicationintent=readwrite;multisubnetfailover=false";
            //var targetconn = @"data source=(localdb)\mssqllocaldb;initial catalog=aspdatadb;integrated security=true;connect timeout=30;encrypt=false;trustservercertificate=false;applicationintent=readwrite;multisubnetfailover=false";

            //SourceEndPoint = GetEndPoint(sourceconn);
            //TargetEndPoint = GetEndPoint(targetconn);

    


            //var comparison = new SchemaComparison(SourceEndPoint, TargetEndPoint);
            //var result = comparison.Compare();
            //var differences = result.GenerateScript("testing");
            //var changescript = differences.Script;
            //var masterScript = differences.MasterScript;
            //Console.WriteLine(masterScript);
            //Console.WriteLine(changescript);
        }

        public static SchemaCompareEndpoint GetEndPoint(string endPoint)
        {
            if(File.Exists(endPoint))
                return new SchemaCompareDacpacEndpoint(endPoint);

            if(!string.IsNullOrEmpty(endPoint) && endPoint.Contains("Data Source"))
                return new SchemaCompareDatabaseEndpoint(endPoint);

            return null;
        }

        public static void OldCode()
        {
            //if (!string.IsNullOrEmpty(sourceConn))
            //    SourceEndPoint = new SchemaCompareDatabaseEndpoint(sourceConn);

            //if (!string.IsNullOrEmpty(sourceConn))
            //    TargetEndPoint = new SchemaCompareDatabaseEndpoint(targetConn);

            //if (File.Exists(sourceDacFile))
            //    SourceEndPoint = new SchemaCompareDacpacEndpoint(sourceDacFile);

            //if (File.Exists(sourceDacFile))
            //    TargetEndPoint = new SchemaCompareDacpacEndpoint(targetDacFile);
        }

        public DacDeployOptions Options
        {
            get
            {
                return new DacDeployOptions
                {

                };
            }
        }
    }
}
