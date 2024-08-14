using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hl_practicando
{
    //public class BeerDB : DB
    //{
    //    #region Propiedades
    //    #endregion

    //    #region Constructor

    //    public BeerDB(string server, string db, string user, string password) : base(server, db, user, password) { }
    //    #endregion

    //    #region Metodos

    //    public List<Beer> GetAll()
    //    {
    //        Connect();
    //        List<Beer> Beers = new List<Beer>();
    //        string query = "SELECT Id, Name, BrandId FROM BEER";
    //        MySqlCommand command = new MySqlCommand(query, _connection);
    //        MySqlDataReader reader = command.ExecuteReader();
    //        while (reader.Read()) 
    //        {
    //            int id = reader.GetInt32(0);
    //            string name = reader.GetString(1);
    //            int brandId = reader.GetInt32(2);
    //            Beers.Add(new Beer(id, name, brandId));
    //        }
    //        Disconnect();
    //        return Beers;
    //    }

    //    public void Add(Beer beer)
    //    {
    //        Connect();
    //        string query = "INSERT INTO beer(name, brandId) values(@name, @brandId)";
    //        MySqlCommand command = new MySqlCommand(query, _connection);
    //        command.Parameters.AddWithValue("@name", beer.Name);
    //        command.Parameters.AddWithValue("@brandId", beer.BrandId);
    //        command.ExecuteNonQuery();
    //        Disconnect();
    //    }

    //    public Beer Get(int id) 
    //    {
    //        Connect();
    //        Beer beer = null;
    //        string query = "SELECT Id, Name, BrandId FROM beer WHERE id = @id";
    //        MySqlCommand command = new MySqlCommand(query, _connection);
    //        command.Parameters.AddWithValue("@id", id);
    //        MySqlDataReader reader = command.ExecuteReader();
    //        while (reader.Read())
    //        {
    //            string name = reader.GetString(1);
    //            int brandId = reader.GetInt32(2);
    //            beer = new Beer(id, name, brandId);
    //        }
    //        Disconnect();
    //        return beer;
    //    }

    //    public void Edit(Beer beer)
    //    {
    //        Connect();
    //        string query = "UPDATE Beer SET Name=@name, BrandId=@brandId WHERE id=@id";
    //        MySqlCommand command = new MySqlCommand(query, _connection);
    //        command.Parameters.AddWithValue("@id", beer.Id);
    //        command.Parameters.AddWithValue("@name", beer.Name);
    //        command.Parameters.AddWithValue("@brandId", beer.BrandId);
    //        command.ExecuteNonQuery();
    //        Disconnect();
    //    }

    //    public void Delete(int id) 
    //    {   
    //        Connect();
    //        string query = "DELETE FROM beer WHERE id = @id";
    //        MySqlCommand command = new MySqlCommand(query, _connection);
    //        command.Parameters.AddWithValue("@id", id);
    //        command.ExecuteNonQuery();
    //        Disconnect();
    //    }
    //    #endregion
    //}
}
