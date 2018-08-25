using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks
{
    public class HotelMock: HotelProperty
    {
        public HotelMock(string name, int floors, int stars) : base(name, floors, stars)
        {

        }
    }
}
