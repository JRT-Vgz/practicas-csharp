using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hl_practicando
{
    public abstract class DB
    {
        #region Propiedades

        private string _connectionstring;
        protected MySqlConnection _connection;
        #endregion

        #region Constructor

        public DB(string server, string db, string user, string password)
        {
            _connectionstring = $"server={server}; uid={user}; pwd={password}; database={db}";
        }
        #endregion

        #region Metodos

        public void Connect()
        {
            _connection = new MySqlConnection(_connectionstring);
            _connection.Open();
        }

        public void Disconnect()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open) 
                _connection.Close(); 
        }
        #endregion
    }
}
