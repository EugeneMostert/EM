using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EM.Portal.Functions
{
    public class Connection: IDisposable
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public Connection()
        {
            connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = EMDb; Integrated Security = True; Pooling = False; Connect Timeout = 30";
        }

        public SqlConnection open
        {
            get
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection.Close();
            }

        }
    }
}