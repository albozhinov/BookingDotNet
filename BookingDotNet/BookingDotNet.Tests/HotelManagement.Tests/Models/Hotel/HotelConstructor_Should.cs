using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Hotel
{
    [TestClass]
    public class HotelConstructor_Should
    {
        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var hotel = new HotelProperty("telerik",5,4);
            //Assert
            Assert.AreEqual("telerik", hotel.Name);
        }
        [TestMethod]
        public void SetProperFloors_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var hotel = new HotelProperty("telerik", 5, 4);
            //Assert
            Assert.AreEqual(5, hotel.Floors);
        }
        [TestMethod]
        public void SetProperStars_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var hotel = new HotelProperty("telerik", 5, 4);
            //Assert
            Assert.AreEqual(4, hotel.Stars);
        }
    }
}
