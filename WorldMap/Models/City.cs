using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WorldMap.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _countrycode;
    private string _district;
    private int _population;

    public City (int id, string name, string countrycode, string district, int population)
    {
      _id = id;
      _name = name;
      _countrycode = countrycode;
      _district = district;
      _population = population;
    }  

    public int GetId()
    {
      return _id;
    } 

    public string GetName()
    {
      return _name;
    }

    public string GetCountryCode()
    {
      return _countrycode;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public static City GetByName (string byName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"select * from city where byName = @thisName;";
      MySqlParameter thisName = new MySqlParameter();
      thisName.ParameterName = "@thisName";
      thisName.Value = byName;
      cmd.Parameters.Add(thisName);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int id = 0;
      string name = "";
      string countrycode = "";
      string district = "";
      int population = 0;   
      while (rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        countrycode = rdr.GetString(2);
        district = rdr.GetString(3);
        population = rdr.GetInt32(4);

        City city = new City(id, name, countrycode, district, population); 
        allCities.Add(city);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }   

    public static List<City> FilterByDistrict()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"select * from city where district = @thisDistrict;";
      MySqlParameter thisDistrict = new MySqlParameter();
      thisDistrict.ParameterName = "@thisDistrict";
      thisDistrict.Value = thisDistrict;
      cmd.Parameters.Add(thisDistrict);
      
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int id = 0;
      string name = "";
      string countrycode = "";
      string district = "";
      int population = 0;
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        countrycode = rdr.GetString(2);
        district = rdr.GetString(3);
        population = rdr.GetInt32(4);
        City city = new City(id, name, countrycode, district, population); 
        allCities.Add(city);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};     
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city order by countrycode, district, name;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string countrycode = rdr.GetString(2);
        string district = rdr.GetString(3);
        int population = rdr.GetInt32(4);
        City city = new City(cityId, cityName, countrycode, district, population);
        allCities.Add(city);
      }
      conn.Close();
      if (conn !=null)
      {
        conn.Dispose();
      }
      return allCities;
    }
    
  }
}