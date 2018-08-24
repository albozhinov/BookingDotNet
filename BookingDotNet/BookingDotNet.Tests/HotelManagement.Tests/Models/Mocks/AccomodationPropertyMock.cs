using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks
{
    public class AccomodationPropertyMock : AccomodationProperty
    {
        public AccomodationPropertyMock(int capacity, int beds, bool forSmokers, string view, decimal basePrice) 
            : base(capacity, beds, forSmokers, view, basePrice)
        {
        }
    }
}
