using HotelManagement.Contracts;
using HotelManagement.Models;
using System;
using Utility;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = new RegularRoom(3, 3, true, "Sea", 55, 2);
        }
    }
}
