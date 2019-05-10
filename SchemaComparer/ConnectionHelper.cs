using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaComparer
{
    public class ConnectionHelper : IDisposable
    {
        private readonly string server;
        private readonly string userName;
        private readonly string password;
        private readonly string databaseName;
        private SqlConnection con;

        public ConnectionHelper(string server, string userName, string password)
        {
            this.server = server;
            this.userName = userName;
            this.password = password;
        }

        public ConnectionHelper(string server, string userName, string password, string databaseName)
        {
            this.server = server;
            this.userName = userName;
            this.password = password;
            this.databaseName = databaseName;
        }


        public SqlConnection GetConnection()
        {
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = server;
            conBuilder.UserID = userName;
            conBuilder.Password = password;

            con = new SqlConnection(conBuilder.ToString());
            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
                return con;

            return null;
        }

        public SqlConnectionStringBuilder GetSqlConnectionString()
        {
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = server;
            conBuilder.UserID = userName;
            conBuilder.Password = password;
            conBuilder.InitialCatalog = databaseName;

            return conBuilder;            
        }

        public void Dispose()
        {
            if (con != null)
                con.Dispose();
        }
    }
}
