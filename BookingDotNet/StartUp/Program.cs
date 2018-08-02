using HotelManagement.Common;
using HotelManagement.Contracts;
using HotelManagement.Models;
using System;
using System.Globalization;
using System.Linq;
using Utility;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotel = new HotelProperty("Pesho", 12);
            var room1 = new DeluxeRoom(3, 3, false, "Sea", 55, 5);
            var extra1 = new Extra(1,AvailableExtras.BigTV,2);
            var extra2 = new Extra(2, AvailableExtras.Dishwasher, 2);
            var extra3 = new Extra(2, AvailableExtras.Garden, 2);
            var extra4 = new Extra(2, AvailableExtras.MiniBar, 2);
            room1.AddExtra(extra1);
            room1.AddExtra(extra2);
            room1.AddExtra(extra3);
            room1.AddExtra(extra4);
            hotel.addRoom(room1);
            Console.WriteLine(hotel.checkAvailability(2, "", DateTime.Now));
            Console.WriteLine(hotel.checkAvailability(4, "BigTV Dishwasher", DateTime.Now));
            Console.WriteLine(hotel.checkAvailability(2, "BigTV Dishwasher Garden", DateTime.Now));
            Console.WriteLine(hotel.checkAvailability(2, "MiniBar", DateTime.Now));
        }
    }
}
