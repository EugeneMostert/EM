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
        private readonly AuthenticationType authenticationType;
        private SqlConnection con;

        public ConnectionHelper(string server, string userName, string password, AuthenticationType authenticationType)
        {
            this.server = server;
            this.userName = userName;
            this.password = password;
            this.authenticationType = authenticationType;
        }

        public ConnectionHelper(string server, string userName, string password, string databaseName, AuthenticationType authenticationType)
        {
            this.server = server;
            this.userName = userName;
            this.password = password;
            this.databaseName = databaseName;
            this.authenticationType = authenticationType;
        }

        public SqlConnection GetConnection()
        {
            if(authenticationType == AuthenticationType.SQLServerAuthentication)
            {
                return SqlAuthentication();
            }

            if(authenticationType == AuthenticationType.WindowsAuthentication)
            {
                return WindowsAuthentication();
            }

            return null;
        }

        private SqlConnection SqlAuthentication()
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

        private SqlConnection WindowsAuthentication()
        {
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = server;
            conBuilder.IntegratedSecurity = true;

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
