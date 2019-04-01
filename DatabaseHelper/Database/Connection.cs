using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Database
{
    class Connection : IDisposable
    {
        private SqlConnection connection;
        public Connection(string connectionString)
        {
            this.Connectionstring = connectionString;
        }

        public string Connectionstring { get; private set; }

        public SqlConnection Open()
        {
            connection = new SqlConnection(this.Connectionstring);
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            if(connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
