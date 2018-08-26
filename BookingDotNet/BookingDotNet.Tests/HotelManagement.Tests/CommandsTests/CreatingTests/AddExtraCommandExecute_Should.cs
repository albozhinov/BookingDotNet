using Hotel.Commands.Creating;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Common;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class AddExtraCommandExecute_Should
    {
        [TestMethod]
        public void ThrowsArgumentException_WhenFailedToParseParameters()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();
            var dataMock = new Mock<IData>();            
            
            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);                       

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => addExtra.Execute(new List<string>() { "Invalid", "Parameters" }));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenTheRoomIndexIsInvalid()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();

            var dataMock = new Mock<IData>();
            var roomsMock = new List<IAccomodationProperty>();
            var room1 = new Mock<IAccomodationProperty>();
            var room2 = new Mock<IAccomodationProperty>();
            var room3 = new Mock<IAccomodationProperty>();

            var listExtrasMock = new List<IExtra>() { new Extra(1, AvailableExtras.MiniBar, 10.00M) };
            var listExtrasMock1 = new List<IExtra>() { new Extra(1, AvailableExtras.Iron, 10.00M) };
            var listExtrasMock2 = new List<IExtra>() { new Extra(1, AvailableExtras.TV, 15.00M) };

            room1.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock);
            room2.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock1);
            room3.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock2);

            roomsMock.Add(room1.Object);
            roomsMock.Add(room2.Object);
            roomsMock.Add(room3.Object);

            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);
            dataMock.SetupGet(x => x.Extras).Returns(listExtrasMock);

            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => addExtra.Execute(new List<string>() { "0", "-1" }));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenTheIDExtraIsInvalid()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();

            var dataMock = new Mock<IData>();
            var roomsMock = new List<IAccomodationProperty>();
            var room1 = new Mock<IAccomodationProperty>();
            var room2 = new Mock<IAccomodationProperty>();
            var room3 = new Mock<IAccomodationProperty>();

            var listExtrasMock = new List<IExtra>() { new Extra(1, AvailableExtras.MiniBar, 10.00M) };
            var listExtrasMock1 = new List<IExtra>() { new Extra(1, AvailableExtras.Iron, 10.00M) };
            var listExtrasMock2 = new List<IExtra>() { new Extra(1, AvailableExtras.TV, 15.00M) };

            room1.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock);
            room2.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock1);
            room3.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock2);

            roomsMock.Add(room1.Object);
            roomsMock.Add(room2.Object);
            roomsMock.Add(room3.Object);

            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);
            dataMock.SetupGet(x => x.Extras).Returns(listExtrasMock);

            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => addExtra.Execute(new List<string>() { "-1", "1" }));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenTheIDExtraAlreadyExists()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();

            var dataMock = new Mock<IData>();
            var roomsMock = new List<IAccomodationProperty>();
            var room1 = new Mock<IAccomodationProperty>();
            var room2 = new Mock<IAccomodationProperty>();
            var room3 = new Mock<IAccomodationProperty>();

            var listExtrasMock = new List<IExtra>() { new Extra(1, AvailableExtras.MiniBar, 10.00M) };
            var listExtrasMock1 = new List<IExtra>() { new Extra(1, AvailableExtras.Iron, 10.00M) };
            var listExtrasMock2 = new List<IExtra>() { new Extra(1, AvailableExtras.TV, 15.00M) };

            room1.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock);
            room2.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock1);
            room3.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock2);

            roomsMock.Add(room1.Object);
            roomsMock.Add(room2.Object);
            roomsMock.Add(room3.Object);

            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);
            dataMock.SetupGet(x => x.Extras).Returns(listExtrasMock);

            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => addExtra.Execute(new List<string>() { "0", "0" }));
        }

        [TestMethod]
        public void AddExtraToRoom_WhenTheExtraDoesNotExist()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();

            var dataMock = new Mock<IData>();
            var roomsMock = new List<IAccomodationProperty>();
            var room1 = new Mock<IAccomodationProperty>();
            var room2 = new Mock<IAccomodationProperty>();
            var room3 = new Mock<IAccomodationProperty>();

            var listExtrasMock = new List<IExtra>() { new Extra(1, AvailableExtras.MiniBar, 10.00M) };
            var listExtrasMock1 = new List<IExtra>() { new Extra(1, AvailableExtras.Iron, 10.00M) };
            var listExtrasMock2 = new List<IExtra>() { new Extra(1, AvailableExtras.TV, 15.00M) };

            room1.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock);
            room2.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock1);
            room3.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock2);

            roomsMock.Add(room1.Object);
            roomsMock.Add(room2.Object);
            roomsMock.Add(room3.Object);

            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);
            dataMock.SetupGet(x => x.Extras).Returns(listExtrasMock);

            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);

            // Act
            var executeCommand = addExtra.Execute(new List<string>() { "0", "1" });
            // Assert
            Assert.IsTrue(addExtra.Data.Rooms[1].ListOfExtras.Count == 2);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenTheParametersIsValid()
        {
            // Arrange
            var hotelFactoryMock = new Mock<IHotelFactory>();

            var dataMock = new Mock<IData>();
            var roomsMock = new List<IAccomodationProperty>();
            var room1 = new Mock<IAccomodationProperty>();
            var room2 = new Mock<IAccomodationProperty>();
            var room3 = new Mock<IAccomodationProperty>();

            var listExtrasMock = new List<IExtra>() { new Extra(1, AvailableExtras.MiniBar, 10.00M) };
            var listExtrasMock1 = new List<IExtra>() { new Extra(1, AvailableExtras.Iron, 10.00M) };
            var listExtrasMock2 = new List<IExtra>() { new Extra(1, AvailableExtras.TV, 15.00M) };

            room1.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock);
            room2.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock1);
            room3.SetupGet(x => x.ListOfExtras).Returns(listExtrasMock2);

            roomsMock.Add(room1.Object);
            roomsMock.Add(room2.Object);
            roomsMock.Add(room3.Object);

            dataMock.SetupGet(x => x.Rooms).Returns(roomsMock);
            dataMock.SetupGet(x => x.Extras).Returns(listExtrasMock);

            var addExtra = new AddExtraCommand(hotelFactoryMock.Object, dataMock.Object);

            // Act
            var result = addExtra.Execute(new List<string>() { "0", "1" });
            // Assert
            StringAssert.Contains(result, "added to room with ID: 1");
        }
    }
}
