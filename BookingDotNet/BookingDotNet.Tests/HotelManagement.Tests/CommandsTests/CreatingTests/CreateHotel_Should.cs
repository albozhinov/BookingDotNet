using Hotel.Commands.Creating;
using Hotel.Core.Contracts;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class CreateHotel_Should
    {
        [TestMethod]
        public void ThrowsArgumentException_WhenFailedToParseParameters()
        {
            // Arrange
            var factoryMock = new Mock<IHotelFactory>();
            var dataMock = new Mock<IData>();
            var writerMock = new Mock<IWriter>();

            var parameters = new List<string>() { "Invalid", "Params" };

            var command = new CreateHotelCommand(factoryMock.Object, dataMock.Object, writerMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute(parameters));
        }

        [TestMethod]
        public void ReturnsSuccessMessage_WhenTheParametersAreValid()
        {
            // Arrange
            var factoryMock = new Mock<IHotelFactory>();
            var dataMock = new Mock<IData>();
            var writerMock = new Mock<IWriter>();
            var hotelMock = new Mock<IHotel>();

            factoryMock.Setup(x => x.CreateHotel("Campus X", 5, 5)).Returns(hotelMock.Object);
            var roomOne = new Mock<IAccomodationProperty>();
            var roomTwo = new Mock<IAccomodationProperty>();
            var roomThree = new Mock<IAccomodationProperty>();

            var roomsMock = new List<IAccomodationProperty>() { roomOne.Object, roomTwo.Object, roomThree.Object };
            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);

            var listOfRoomsInHotel = new List<IAccomodationProperty>();
            hotelMock.SetupGet(x => x.Rooms).Returns(listOfRoomsInHotel);
            hotelMock.Setup(x => x.AddRoom(roomOne.Object)).Callback(() => listOfRoomsInHotel.Add(roomOne.Object));

            var hotelsInData = new List<IHotel>();
            dataMock.Setup(x => x.Hotels.Add(hotelMock.Object)).Callback(() => hotelsInData.Add(hotelMock.Object));

            var parameters = new List<string>() { "Campus X", "5", "5", "0,1,2" };

            var command = new CreateHotelCommand(factoryMock.Object, dataMock.Object, writerMock.Object);

            // Act
            var result = command.Execute(parameters);

            // Assert
            StringAssert.Contains(result, "was created.");
        }

        [TestMethod]
        public void CreateHotel_WhenTheParametersAreValid()
        {
            // Arrange
            var factoryMock = new Mock<IHotelFactory>();
            var dataMock = new Mock<IData>();
            var writerMock = new Mock<IWriter>();
            var hotelMock = new Mock<IHotel>();

            factoryMock.Setup(x => x.CreateHotel("Campus X", 5, 5)).Returns(hotelMock.Object);
            var roomOne = new Mock<IAccomodationProperty>();
            var roomTwo = new Mock<IAccomodationProperty>();
            var roomThree = new Mock<IAccomodationProperty>();

            var roomsMock = new List<IAccomodationProperty>() { roomOne.Object, roomTwo.Object, roomThree.Object };
            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);

            var listOfRoomsInHotel = new List<IAccomodationProperty>();
            hotelMock.SetupGet(x => x.Rooms).Returns(listOfRoomsInHotel);
            hotelMock.Setup(x => x.AddRoom(roomOne.Object)).Callback(() => listOfRoomsInHotel.Add(roomOne.Object));

            var hotelsInData = new List<IHotel>();
            dataMock.Setup(x => x.Hotels.Add(hotelMock.Object)).Callback(() => hotelsInData.Add(hotelMock.Object));

            var parameters = new List<string>() { "Campus X", "5", "5", "0,1,2" };

            var command = new CreateHotelCommand(factoryMock.Object, dataMock.Object, writerMock.Object);

            // Act
            var result = command.Execute(parameters);

            // Assert
            factoryMock.Verify(x => x.CreateHotel(parameters[0], 5, 5), Times.Once);
        }
    }
}
