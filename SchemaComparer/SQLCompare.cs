using Microsoft.SqlServer.Dac.Compare;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaComparer
{
    public class SQLCompare
    {
        private readonly string sourceConnectionString;
        private readonly string targetConnectionString;

        public SQLCompare(string sourceEndPoint, string targetEndPOint)
        {
            this.sourceConnectionString = sourceEndPoint;
            this.targetConnectionString = targetEndPOint;
        }

        public SchemaComparison Initialize()
        {
            SourceEndPoint = GetEndPoint(sourceConnectionString);
            TargetEndPoint = GetEndPoint(targetConnectionString);
            SchemaComparison = new SchemaComparison(SourceEndPoint, TargetEndPoint);
            return SchemaComparison;
        }

        private SchemaComparison SchemaComparison { get; set; }
        private SchemaComparisonResult SchemaComparisonResult { get; set; }
        private SchemaCompareEndpoint SourceEndPoint { get; set; }
        private SchemaCompareEndpoint TargetEndPoint { get; set; }
        private SchemaComparisonResult ComparisonResults { get; set; }
        private SchemaCompareScriptGenerationResult ScriptGenerationResult { get; set; }

        public SchemaComparisonResult Compare()
        {
            SchemaComparisonResult = SchemaComparison.Compare();
            
            return SchemaComparisonResult;
        }

        public SchemaCompareScriptGenerationResult GenerateScript()
        {
            ScriptGenerationResult = SchemaComparisonResult.GenerateScript("Testing");
            return ScriptGenerationResult;
        }

        public void SaveCompare(string filename, bool overWrite = true)
        {
            if(SchemaComparison !=null)
            {
                SchemaComparison.SaveToFile(filename, overWrite);
            }
        }

        public void SaveToStream(Stream srteam)
        {
            if (SchemaComparison != null)
            {
                SchemaComparison.SaveToStream(srteam);
            }
        }

        public string GetUpdateScript()
        {
            string script = "";
            script = ScriptGenerationResult.Script;
            return script;

        }

        //public string GetResults()
        //{


            
        //    //ComparisonResults = 
        //    //ScriptGenerationResult = ComparisonResults.GenerateScript("TestingNow");
        //    //var changeScript = ScriptGenerationResult.Script;
        //    //return changeScript;

        //}

        public SchemaCompareEndpoint GetEndPoint(string endPoint)
        {
            if (File.Exists(endPoint))
                return new SchemaCompareDacpacEndpoint(endPoint);

            if (!string.IsNullOrEmpty(endPoint) && endPoint.Contains("Data Source"))
                return new SchemaCompareDatabaseEndpoint(endPoint);

            return null;
        }
    }
}
