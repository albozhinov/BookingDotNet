using Hotel.Commands.Listing;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.ListingTests
{
    [TestClass]
    public class ListClients_Should
    {
        [TestMethod]
        public void ListClients_Should_Return_ToStrings_IfNotEmpty()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockClient = new Mock<IClient>();
            mockClient.Setup(mock => mock.ToString());

            var mockClientList = new List<IClient> { mockClient.Object };

            mockData.SetupGet(mock => mock.Clients).Returns(mockClientList);

            var command = new ListClientsCommand(mockFactory.Object, mockData.Object);

            //Act
            var results = command.Execute(new List<string>());

            //Assert
            mockClient.Verify(mock => mock.ToString(), Times.Once);

        }

        [TestMethod]
        public void ListClients_Should_Return_String_When_NoClients_InList()
        {
            //Arrange
            var mockFactory = new Mock<IHotelFactory>();
            var mockData = new Mock<IData>();

            var mockClientList = new List<IClient>();

            mockData.SetupGet(mock => mock.Clients).Returns(mockClientList);

            var command = new ListClientsCommand(mockFactory.Object, mockData.Object);

            //Act
            var results = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(results.Contains("There are no registered client."));
        }
    }
}
