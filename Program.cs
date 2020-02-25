﻿using System;
using System.Collections.Generic;

public class Car
{
  public string MakeModel;
  public int Price;
  public int Miles;
  public string Message;

  public Car(string makeModel, int price, int miles, string message)
  {
    MakeModel = makeModel;
    Price = price;
    Miles = miles;
    Message = message;
  }

  public bool WorthBuying(int maxPrice, int maxMileage)
  {
    return (Price < maxPrice && Miles < maxMileage);
  }
}

public class Program
{
  public static void Main()
  {
    Car volkswagen = new Car("1974 Volkswagen Thing", 1100, 368792, "avoid this car");
    Car yugo = new Car("1980 Yugo Koral", 700, 56000, "not your best choice");
    Car ford = new Car("1988 Ford Country Squire", 1400, 239001, "an OK vehicle");
    Car amc = new Car("1976 AMC Pacer", 400, 198000, "the budget choice");
    
    List<Car> Cars = new List<Car>() { volkswagen, yugo, ford, amc };

    Console.WriteLine("Enter maximum price: ");
    string stringMaxPrice = Console.ReadLine();
    int maxPrice = int.Parse(stringMaxPrice);

    Console.WriteLine("Enter a maximum mileage for a vehicle:");
    string stringMaxMileage = Console.ReadLine();
    int maxMileage = int.Parse(stringMaxMileage);

    List<Car> CarsMatchingSearch = new List<Car>(0);

    foreach (Car automobile in Cars)
    {
      if (automobile.WorthBuying(maxPrice, maxMileage))
      {
        CarsMatchingSearch.Add(automobile);
      }
    }

    foreach(Car automobile in CarsMatchingSearch)
    {
        Console.WriteLine(automobile.MakeModel);
    }
  }
}