using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Hotel.Commands.Creating;
using System.Collections.Generic;
using System;
using HotelManagement.Contracts;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class AddRoomToHotel_Should
    {
        [TestMethod]
        public void AddRoomToHotel_Should_Throw_When_Invalid_Number_Params()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var command = new AddRoomToHotelCommand(mockFactory.Object, mockData.Object);

            var parameters = new List<string> { "1" };

            //Act + Assert

            Assert.ThrowsException<ArgumentException>(() => command.Execute(parameters));
        }

        [TestMethod]
        public void AddRoomToHotel_Should_Return_Correct_String()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockHotel = new Mock<IHotel>();
            var mockRoom = new Mock<IAccomodationProperty>();

            var mockedHotelList = new List<IHotel> { mockHotel.Object };
            var mockedRoomList = new List<IAccomodationProperty> { mockRoom.Object };

            mockData.Setup(x=>x.Hotels).Returns(mockedHotelList);
            mockData.Setup(x => x.Rooms).Returns(mockedRoomList);

            var command = new AddRoomToHotelCommand(mockFactory.Object, mockData.Object);

            var parameters = new List<string> { "0", "0" };

            //Act 

            var commandResult = command.Execute(parameters);

            //Assert

            Assert.IsTrue(commandResult.Contains("Rooms with IDs 0 added to hotel with ID: 0"));

        }

        [TestMethod]
        public void AddRoomToHotel_Should_Add_To_List()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockHotel = new Mock<IHotel>();
            var mockRoom = new Mock<IAccomodationProperty>();

            var mockedHotelList = new List<IHotel> { mockHotel.Object };
            var mockedRoomList = new List<IAccomodationProperty> { mockRoom.Object };

            mockData.Setup(x => x.Hotels).Returns(mockedHotelList);
            mockData.Setup(x => x.Rooms).Returns(mockedRoomList);

            var listofRooms = new List<IAccomodationProperty>();
            mockHotel.Setup(x => x.Rooms).Returns(listofRooms);
            mockHotel.Setup(x => x.AddRoom(mockRoom.Object)).Callback(() => listofRooms.Add(mockRoom.Object));

            var command = new AddRoomToHotelCommand(mockFactory.Object, mockData.Object);

            var parameters = new List<string> { "0", "0" };

            //Act 

            var commandResult = command.Execute(parameters);

            //Assert

            Assert.IsTrue(listofRooms.Count == 1);
        }
    }
}
