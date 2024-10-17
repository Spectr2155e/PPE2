using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Database
{
    internal class DatabaseManager
    {

        private String _databaseName;
        private String _uri;
        private SqlConnection _connection;

        public DatabaseManager(String databaseName)
        {
            this._databaseName = databaseName;
            this._uri = @"Server=.\SQLEXPRESS;Database="+databaseName+";Trusted_Connection=True;";
            startConnection();
        }

        private void startConnection()
        {
            this._connection = new SqlConnection(this._uri);
            this._connection.Open();
        }

        public void stopConnection()
        {
            this._connection.Close();
        }

        public SqlDataReader getResultOfRequest(String sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this._connection);
            return sqlCommand.ExecuteReader();
        }

        public void executeRequest(String sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, this._connection);
            sqlCommand.ExecuteNonQueryAsync();
        }
    }
}
