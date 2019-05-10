using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Database
{
    public class Connection : DbConnection
    {
        public Connection()
        {

        }
        public Connection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public Connection(string connectionString, string providerName)
        {
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }

        private DbConnection connection = null;
        private DbProviderFactory factory;

        public override string ConnectionString { get => this.ConnectionString; set => ConnectionString = value; }

        public string ProviderName { get; set; }

        public override string Database => throw new NotImplementedException();

        public override string DataSource { get; }

        public override string ServerVersion => throw new NotImplementedException();

        public override ConnectionState State => throw new NotImplementedException();

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            this.connection.Close();
        }

        public override void Open()
        {
            try
            {
                if (string.IsNullOrEmpty(ProviderName))
                    throw new Exception("Provider cant be null or empty");

                if (string.IsNullOrEmpty(this.ConnectionString))
                    throw new Exception("ConnectionString cant be null or empty");


                factory = DbProviderFactories.GetFactory(ProviderName);
                connection = factory.CreateConnection();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on connection open: " + ex.Message);
            }
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }
    }
}
