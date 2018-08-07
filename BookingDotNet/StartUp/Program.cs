using HotelManagement.Common;
using HotelManagement.Contracts;
using HotelManagement.Models;
using System;
using System.Globalization;
using System.Linq;
using UserManagement.Models;
using Utility;
using Hotel;


namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = Engine.Instance;
            engine.Start();

            //var hotel = new HotelProperty("Pesho", 12);
            //var room1 = new DeluxeRoom(3, 3, true, "Sea", 55, 5);
            //var extra1 = new Extra(1,AvailableExtras.BigTV,2);
            //var extra2 = new Extra(2, AvailableExtras.Dishwasher, 2);
            //var extra3 = new Extra(2, AvailableExtras.Garden, 2);
            //var extra4 = new Extra(2, AvailableExtras.MiniBar, 2);
            //room1.AddExtra(extra1);
            //room1.AddExtra(extra2);
            //room1.AddExtra(extra3);
            //room1.AddExtra(extra4);
            //hotel.AddRoom(room1);
            //var user = new NaturalLoyal(3, "0887999019", "pichovete@abv.bg", "Teo", "Peev", DateTime.Now.AddYears(-24), 0.2M);
            //user.ReserveRoom(hotel, 2, "BigTV Dishwasher Garden", DateTime.Now.AddDays(5));
            //user.ReserveRoom(hotel, 2, "BigTV Dishwasher Garden", DateTime.Now.AddDays(2));
            //user.ReserveRoom(hotel, 2, "BigTV Dishwasher Garden", DateTime.Now.AddDays(1));
            //user.ReserveRoom(hotel, 2, "BigTV Dishwasher Garden", DateTime.Now.AddDays(3));
            //Console.WriteLine(user.ToString());
            //Console.WriteLine(room1.ToString());

            //Console.WriteLine(hotel.checkAvailability(2, "", DateTime.Now));

            //Console.WriteLine(hotel.checkAvailability(4, "BigTV Dishwasher", DateTime.Now));
            //Console.WriteLine(hotel.checkAvailability(2, "BigTV Dishwasher Garden", DateTime.Now));
            //Console.WriteLine(hotel.checkAvailability(2, "MiniBar", DateTime.Now));

            //var dateOfBirth = DateTime.ParseExact("7.8.1982", "d.M.yyyy", CultureInfo.InvariantCulture);
            //var registeredOn = DateTime.Now;
            //var yearsOld = Math.Floor((DateTime.Now - dateOfBirth).TotalDays / 365);

            //Console.WriteLine(dateOfBirth.ToString("dd.MM.yyyy"));
            //Console.WriteLine(registeredOn.ToString("dd.MM.yyyy"));
            //Console.WriteLine(yearsOld);


        }
    }
}
