using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
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
        public void Initialize_ListOfRooms()
        {
            //Act + Arrange
            var hotel = new HotelMock("Telerik",5,5);

            //Assert
            Assert.IsNotNull(hotel.Rooms);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(17)]
        public void Set_NumberOfFloors_ShouldThrow_If_Not_Valid(int floors)
        {
            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new HotelMock("Telerik", floors,5));
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("abc..................................................")]
        public void Set_Name_ShouldThrow_If_Not_Valid(string name)
        {
            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new HotelMock(name, 2, 5));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(8)]
        public void Set_Stars_ShouldThrow_If_Not_Valid(int stars)
        {
            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new HotelMock("Telerik", 2, stars));
        }

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
