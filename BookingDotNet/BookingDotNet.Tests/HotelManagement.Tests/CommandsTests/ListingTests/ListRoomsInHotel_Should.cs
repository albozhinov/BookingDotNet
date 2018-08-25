using Hotel.Commands.Listing;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.ListingTests
{
    [TestClass]
    public class ListRoomsInHotel_Should
    {
        [TestMethod]
        public void ListRoomsInHotel_Should_Return_ToString_IfNotEmpty()
        {
            //Arrange
            var factoryMock = new Mock <IHotelFactory>();
            var dataMock = new Mock<IData>();

            var mockHotel = new Mock<IHotel>();
            var mockHotelList = new List<IHotel>() { mockHotel.Object };
            dataMock.Setup(x => x.Hotels).Returns(mockHotelList);

            var mockRoom = new Mock<IAccomodationProperty>();
            
            var mockRoomList = new List<IAccomodationProperty>() {mockRoom.Object};
            dataMock.SetupGet(mock => mock.Rooms).Returns(mockRoomList);

            mockHotel.Setup(x => x.Rooms).Returns(mockRoomList);

            var command = new ListRoomsInHotelCommand(factoryMock.Object, dataMock.Object);

            //Act
            var result = command.Execute(new List<string>() { "0" });

            //Assert
            Assert.IsTrue(result.Contains("Rooms in hotel:"));
        }
        [TestMethod]
        public void ListRoomsInHotel_Should_Return_ToString_IfEmpty()
        {
            //Arrange
            var factoryMock = new Mock<IHotelFactory>();
            var dataMock = new Mock<IData>();

            var mockHotel = new Mock<IHotel>();
            var mockHotelList = new List<IHotel>() { mockHotel.Object };
            dataMock.Setup(x => x.Hotels).Returns(mockHotelList);

            var mockRoom = new Mock<IAccomodationProperty>();

            var mockRoomList = new List<IAccomodationProperty>();
            dataMock.SetupGet(mock => mock.Rooms).Returns(mockRoomList);

            mockHotel.Setup(x => x.Rooms).Returns(mockRoomList);

            var command = new ListRoomsInHotelCommand(factoryMock.Object, dataMock.Object);

            //Act
            var result = command.Execute(new List<string>() { "0" });

            //Assert
            Assert.IsTrue(result.Contains("There are no registered rooms in this hotel."));
        }
    }
}
