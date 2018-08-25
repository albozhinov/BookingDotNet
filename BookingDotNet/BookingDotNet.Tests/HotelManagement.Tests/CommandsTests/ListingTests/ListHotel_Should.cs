using Hotel.Commands.Listing;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;


namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.ListingTests
{
    [TestClass]
    public class ListHotel_Should
    {
        [TestMethod]
        public void ListHotel_Should_Return_ToStrings_IfNotEmpty()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockHotel = new Mock<IHotel>();
            mockHotel.Setup(mock => mock.ToString());

            var mockHotelList = new List<IHotel> { mockHotel.Object };

            mockData.SetupGet(mock => mock.Hotels).Returns(mockHotelList);

            var command = new ListHotelCommand(mockFactory.Object, mockData.Object);

            //Act
            var results = command.Execute(new List<string>());

            //Assert
            mockHotel.Verify(mock => mock.ToString(), Times.Once);

        }

        [TestMethod]
        public void ListHotel_Should_Return_String_When_NoClients_InList()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockHotelList = new List<IHotel>();

            mockData.SetupGet(mock => mock.Hotels).Returns(mockHotelList);

            var command = new ListHotelCommand(mockFactory.Object, mockData.Object);

            //Act
            var results = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(results.Contains("There are no registered hotel."));
        }
    }
}
