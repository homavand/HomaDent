using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using Dapper;

namespace Dentistry
{
    public class DapperManager
    {

        public static SQLiteConnection Connection(bool mars = false)
        {
            var cs = Dentistry.AppConfigs.ConnectionString;
            
            var connection = new SQLiteConnection(cs);
            connection.Open();
            return connection;
        }

    }
}


