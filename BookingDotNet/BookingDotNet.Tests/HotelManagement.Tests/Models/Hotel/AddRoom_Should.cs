using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.Hotel
{
    [TestClass]
    public class AddRoom_Should
    {
        [TestMethod]
        public void AddRoom_Should_AddRoom_To_RoomsList()
        {
            var hotel = new HotelMock("Telerik",5,4);
            var mockedRoom = new Mock <IAccomodationProperty>();
            hotel.AddRoom(mockedRoom.Object);

            Assert.IsTrue(hotel.Rooms.Count == 1);
        }
        //[TestMethod]
        //public void AddRoom_Should_AddRoom_To_RoomsList_Mock()
        //{
        //    var mockHotel = new Mock<IHotel>();
        //    var mockedRoom = new Mock<IAccomodationProperty>();
        //    var mockedRooms = new List<IAccomodationProperty>();
        //    mockHotel.Setup(x => x.Rooms).Returns(mockedRooms);
        //    mockHotel.Setup(x => x.AddRoom(mockedRoom.Object));

        //    Assert.IsTrue(mockHotel.Rooms.Count == 1);
        //}
        [TestMethod]
        public void AddRoom_Should_ReturnException_When_NullIsPassed()
        {
            var hotel = new HotelMock("Telerik", 5, 4);
            IAccomodationProperty mockedRoom = null;
            
            Assert.ThrowsException<ArgumentException>(()=>hotel.AddRoom(mockedRoom));
        }
    }
}
