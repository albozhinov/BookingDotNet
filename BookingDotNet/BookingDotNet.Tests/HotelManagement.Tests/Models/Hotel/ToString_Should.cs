using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Hotel
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void Hotel_Should_Return_ToString()
        {
            var hotel = new HotelProperty("Telerik", 4, 5);

            Assert.IsTrue(hotel.ToString().Contains("=== Information for hotel"));
        }
    }
}
