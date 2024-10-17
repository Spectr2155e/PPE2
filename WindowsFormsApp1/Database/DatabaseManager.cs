using MySql.Data.MySqlClient;
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
        private String _user;
        private String _password;
        private String _uri;
        private MySqlConnection _connection;

        public DatabaseManager(String databaseName, String user, String password)
        {
            this._databaseName = databaseName;
            this._user = user;
            this._password = password;
            this._uri = @"Server=localhost;Database="+ this._databaseName +";Uid="+ this._user +";Pwd="+this._password+";";
            startConnection();
        }

        private void startConnection()
        {
            this._connection = new MySqlConnection(this._uri);
            this._connection.Open();
        }

        public void stopConnection()
        {
            this._connection.Close();
        }

        public MySqlDataReader getResultOfRequest(String sql)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sql, this._connection);
            return sqlCommand.ExecuteReader();
        }

        public void executeRequest(String sql)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sql, this._connection);
            sqlCommand.ExecuteNonQueryAsync();
        }
    }
}
