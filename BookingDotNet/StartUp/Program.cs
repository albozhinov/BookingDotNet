using HotelManagement.Contracts;
using HotelManagement.Models;
using System;
using System.Globalization;
using Utility;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var before = new DateTime(2016, 5, 1);
            Console.WriteLine(Math.Round((now - before).TotalDays / 365));
        }
    }
}
