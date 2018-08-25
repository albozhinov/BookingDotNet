using Hotel.Commands.Creating;
using Hotel.Core.DataStorage;
using Hotel.Core.Factories;
using HotelManagement.Common;
using HotelManagement.Contracts;
using HotelManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.CommandsTests.CreatingTests
{
    [TestClass]
    public class CreateApartment_Should
    {
        [TestMethod]
        public void CreateApartment_Should_Throw_When_Invalid_Number_Params()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var command = new CreateApartmentCommand(factory.Object, data.Object);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute(new List<string>()
            { "2", "3", "true", "120", "true", "2", "1","2" }));
        }
        [TestMethod]
        public void CreateApartment_Should_Return_When_Valid_Params()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var mockedRoomsList = new List<IAccomodationProperty>();
            var mockedExtra = new Mock<IExtra>();
            mockedExtra.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra2 = new Mock<IExtra>();
            mockedExtra2.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra3 = new Mock<IExtra>();
            mockedExtra3.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra4 = new Mock<IExtra>();
            mockedExtra4.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra5 = new Mock<IExtra>();
            mockedExtra5.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra6 = new Mock<IExtra>();
            mockedExtra6.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra7 = new Mock<IExtra>();
            mockedExtra7.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra8 = new Mock<IExtra>();
            mockedExtra8.SetupGet(x => x.Tier).Returns(3);
            var mockedExtrasList = new List<IExtra>() {mockedExtra.Object, mockedExtra2.Object , mockedExtra3.Object ,
                mockedExtra4.Object,mockedExtra5.Object,mockedExtra6.Object,mockedExtra7.Object,mockedExtra8.Object};

            var parameters = new List<string>() { "2", "3", "true", "Sea", "120", "true", "2", "1", "2" };

            data.Setup(x => x.Rooms).Returns(mockedRoomsList);
            data.Setup(x => x.Extras).Returns(mockedExtrasList);
            factory.Setup(x => x.CreateApartment(2, 3, true, "Sea", 120, true, 2, 1, 2))
                .Returns(new Apartment(2, 3, true, "Sea", 120, true, 2, 1, 2));

            var command = new CreateApartmentCommand(factory.Object, data.Object);
            var result = command.Execute(parameters);

            //Act & Assert
            Assert.IsTrue(result.Contains("Apartment with ID 0 was created."));
        }
        [TestMethod]
        public void CreateApartment_Should_Add_Room_ToList()
        {
            //Arrange
            var factory = new Mock<IHotelFactory>();
            var data = new Mock<IData>();

            var mockedRoomsList = new List<IAccomodationProperty>();
            var mockedExtra = new Mock<IExtra>();
            mockedExtra.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra2 = new Mock<IExtra>();
            mockedExtra2.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra3 = new Mock<IExtra>();
            mockedExtra3.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra4 = new Mock<IExtra>();
            mockedExtra4.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra5 = new Mock<IExtra>();
            mockedExtra5.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra6 = new Mock<IExtra>();
            mockedExtra6.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra7 = new Mock<IExtra>();
            mockedExtra7.SetupGet(x => x.Tier).Returns(3);
            var mockedExtra8 = new Mock<IExtra>();
            mockedExtra8.SetupGet(x => x.Tier).Returns(3);
            var mockedExtrasList = new List<IExtra>() {mockedExtra.Object, mockedExtra2.Object , mockedExtra3.Object ,
                mockedExtra4.Object,mockedExtra5.Object,mockedExtra6.Object,mockedExtra7.Object,mockedExtra8.Object};

            var parameters = new List<string>() { "2", "3", "true", "Sea", "120", "true", "2", "1", "2" };

            data.Setup(x => x.Rooms).Returns(mockedRoomsList);
            data.Setup(x => x.Extras).Returns(mockedExtrasList);
            factory.Setup(x => x.CreateApartment(2, 3, true, "Sea", 120, true, 2, 1, 2))
                .Returns(new Apartment(2, 3, true, "Sea", 120, true, 2, 1, 2));

            var command = new CreateApartmentCommand(factory.Object, data.Object);
            var result = command.Execute(parameters);

            //Act & Assert
            Assert.IsTrue(mockedRoomsList.Count==1);
        }
    }
}
