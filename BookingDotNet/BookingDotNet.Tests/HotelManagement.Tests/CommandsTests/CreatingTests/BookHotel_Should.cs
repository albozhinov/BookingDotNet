using Hotel.Commands.Creating;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;
using UserManagement.ReservationLogic;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class BookHotel_Should
    {
        [TestMethod]
        public void ThrowsArgumentException_WhenFailedToParseParameters()
        {
            // Arrane
            var dataMock = new Mock<IData>();
            var factoryMock = new Mock<IHotelFactory>();

            var bookHotel = new BookHotelCommand(factoryMock.Object, dataMock.Object);
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => bookHotel.Execute(
                new List<string>() { "Invalid", "Parameters", "3", "15/9/2018", "Tv, MiniBar, WiFi" }));            
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenTheParametersAreValid()
        {
            // Arrange
            var dataMock = new Mock<IData>();
            var factoryMock = new Mock<IHotelFactory>();

            // Create list of clients in dataMock
            var clientMock = new Mock<IClient>();
            var dataClients = new List<IClient>() { clientMock.Object };
            dataMock.SetupGet(x => x.Clients).Returns(dataClients);

            // Create list ot hotels in dataMock
            var hotelMock = new Mock<IHotel>();
            var dataHotels = new List<IHotel>() { hotelMock.Object };
            dataMock.SetupGet(x => x.Hotels).Returns(dataHotels);

            var bookHotel = new BookHotelCommand(factoryMock.Object, dataMock.Object);

            // Act
            var executeCommand = bookHotel.Execute(
                                new List<string>() { "0", "0", "3", "15/9/2018", "Tv, MiniBar, WiFi" });

            // Assert
            StringAssert.Contains(executeCommand, "successfully");
        }


        //[TestMethod]
        //public void ReserveRoom_WhenTheParametersIsValid()
        //{
        //    // Arrange
        //    var dataMock = new Mock<IData>();
        //    var factoryMock = new Mock<IHotelFactory>();


        //    // Create list of reservetion in client
        //    var clientMock = new Mock<IClient>();
        //    var reservetionsMock = new List<IReservation>();
        //    clientMock.Setup(x => x.Reservations).Returns(reservetionsMock);

        //    // Create list of clients in dataMock
        //    var dataClients = new List<IClient>() { clientMock.Object };
        //    dataMock.SetupGet(x => x.Clients).Returns(dataClients);


        //    // Create list ot hotels in dataMock
        //    var hotelMock = new Mock<IHotel>();
        //    var dataHotels = new List<IHotel>() { hotelMock.Object };
        //    dataMock.SetupGet(x => x.Hotels).Returns(dataHotels);
        //    var reservetion = new Mock<IReservation>();

        //    clientMock.Setup(x => x.ReserveRoom(hotelMock.Object, 3, "Tv, MiniBar, WiFi", new DateTime(15 / 9 / 2018).Date)).Callback(() => reservetionsMock.Add(reservetion.Object));

        //    var bookHotel = new BookHotelCommand(factoryMock.Object, dataMock.Object);

        //    // Act
        //    var executeCommand = bookHotel.Execute(
        //                        new List<string>() { "0", "0", "3", "20/9/2018", "Tv, MiniBar, WiFi" });

        //    // Assert
        //    Assert.IsTrue(clientMock.Object.Reservations.Count == 1);
        //}
    }
}
