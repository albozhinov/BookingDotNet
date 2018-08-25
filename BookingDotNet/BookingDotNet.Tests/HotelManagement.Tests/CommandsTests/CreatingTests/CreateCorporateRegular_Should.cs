using Hotel.Commands.Creating;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Contracts;
using UserManagement.Models;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class CreateCorporateRegular_Should
    {
        [TestMethod]
        public void Should_Throw_When_Invalid_Number_Params()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var command = new CreateCorporateRegularCommand(factory.Object, data.Object);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute(new List<string>()
            { "Telerik", "3", "10", "08886553564"}));
            
        }
        [TestMethod]
        public void Should_Return_Valid_Params()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var command = new CreateCorporateRegularCommand(factory.Object, data.Object);
            var mockedClients = new List<IClient>();
            factory.Setup(x => x.CreateCorporateRegular(2, "088676788", "@info.bg", "Telerik", 6))
                .Returns(new CorporateRegular(2, "088676788", "@info.bg", "Telerik", 6));
            data.Setup(x => x.Clients).Returns(mockedClients);

            var parameters = new List<string>() { "Telerik","3","4","0834384","@info.bg" };
            var result = command.Execute(parameters);

            //Act & Assert
            Assert.IsTrue(result.Contains("Corporate Regular client with ID 0 was created."));
        }
        [TestMethod]
        public void Should_Add_Client_ToList_When_Valid_Params()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var command = new CreateCorporateRegularCommand(factory.Object, data.Object);
            var mockedClients = new List<IClient>();
            factory.Setup(x => x.CreateCorporateRegular(2, "088676788", "@info.bg", "Telerik", 6))
                .Returns(new CorporateRegular(2, "088676788", "@info.bg", "Telerik", 6));
            data.Setup(x => x.Clients).Returns(mockedClients);

            var parameters = new List<string>() { "Telerik", "3", "4", "0834384", "@info.bg" };
            var result = command.Execute(parameters);

            //Act & Assert
            Assert.IsTrue(mockedClients.Count==1);
        }
    }
}
