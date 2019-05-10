using Microsoft.SqlServer.Dac.Compare;
using Microsoft.SqlServer.Dac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.SchemaComparer
{
    class CompareEngine
    {
        private readonly string sourceEndpoint;
        private readonly string targetEndpoint;

        public CompareEngine(string sourceEndpoint, string targetEndpoint)
        {
            this.sourceEndpoint = sourceEndpoint;
            this.targetEndpoint = targetEndpoint;
            Initialize();
        }

        private void Initialize()
        {
            
        }
        public Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint SourceEndPoint { get; set; }
        public Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint TargetEndPoint { get; set; }

        public Microsoft.SqlServer.Dac.Compare.SchemaCompareEndpoint GetEndPoint(string endPoint)
        {
            if (File.Exists(endPoint))
                return new Microsoft.SqlServer.Dac.Compare.SchemaCompareDacpacEndpoint(endPoint);

            if (!string.IsNullOrEmpty(endPoint) && endPoint.Contains("Data Source"))
                return new Microsoft.SqlServer.Dac.Compare.SchemaCompareDatabaseEndpoint(endPoint);

            return null;
        }


        public void Compare()
        {
            var sourceConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Identity;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var targetConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspDataDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string sourceDacFile = "";
            //string targetDacFile = "";
            string TargetDataBaseName = "";

            SourceEndPoint = GetEndPoint(sourceConn);
            TargetEndPoint = GetEndPoint(targetConn);

         


            var comparison = new SchemaComparison(SourceEndPoint, TargetEndPoint);
            var result = comparison.Compare();
            var differences = result.GenerateScript(TargetDataBaseName);
            var changeScript = differences.Script;
        }
    }
}
