using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CarDealership.Models
{
  public class Car
  {
    public string MakeModel { get; set; }
    public int Price { get; set; }
    public int Miles { get; set; }
    public string Message { get; set; }
    public int Id { get; set; }
    public static List<Car> CarsMatchingSearch { get; set; } = new List<Car>() {};
    
    public Car(string makeModel,  int price, int miles, string message)
    {
      MakeModel = makeModel;
      Price = price;
      Miles = miles;
      Message = message;
    }
    public Car(string makeModel,  int price, int miles, string message, int id)
    {
      MakeModel = makeModel;
      Price = price;
      Miles = miles;
      Message = message;
      Id = id;
    }

    public static List<Car> GetAll()
    {
      List<Car> allCars = new List<Car> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cars;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int carId = rdr.GetInt32(0);
          string makeModel = rdr.GetString(1);
          int price = rdr.GetInt32(2);
          int miles = rdr.GetInt32(3);
          string message = rdr.GetString(4);
          Car newCar = new Car(makeModel, price, miles, message, carId);
          allCars.Add(newCar);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allCars;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cars;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static string MakeSound(string sound)
    {
      return "Our cars sound like " + sound;
    }

    public bool WorthBuying(int maxPrice, int maxMileage)
    {
      return (Price <= maxPrice && Miles <= maxMileage);
    }

    // public static void SearchCars(string maxCash, string maxDistance)
    // {
    //   int maxPrice = int.Parse(maxCash);
    //   int maxMileage = int.Parse(maxDistance);
    //   foreach (Car automobile in allCars)
    //   {
    //     if (automobile.WorthBuying(maxPrice, maxMileage))
    //     {
    //       CarsMatchingSearch.Add(automobile);
    //     }
    //   }
    // }
  }
}