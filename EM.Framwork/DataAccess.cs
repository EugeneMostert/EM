using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Framwork
{
    class DataAccess
    {
        public int Insert<T>(IEnumerable<T> collection)
        {
            string sql = "";
            Type type = typeof(T);
            using (IDbConnection connection = new SqlConnection(""))
            {
                var affectedRows = connection.Execute(sql, collection);
                return affectedRows;
            }
        }

    }
}
