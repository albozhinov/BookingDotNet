using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Utility;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.ClientTests
{
    [TestClass]
    public class ReserveRoom_Should
    {
        [TestMethod]
        public void Reserve_When_Room_Is_Found()
        {
            //Arrange
            var client = new ClientMock(1, "0887585858", "pesho_losta@abv.bg");

            var hotelMock = new Mock<IHotel>();

            var roomMock = new Mock<IAccomodationProperty>();

            hotelMock.Setup(mock => mock.checkAvailability(3, "Shampoo", DateTime.Now.AddDays(2).Date)).Returns(roomMock.Object);

            //Act 

            client.ReserveRoom(hotelMock.Object, 3, "Shampoo", DateTime.Now.AddDays(2).Date);

            //Assert
            Assert.AreEqual(1, client.Reservations.Count);


        }

        [TestMethod]
        public void Throw_Custom_Error_When_Room_NotFound()
        {
            //Arrange
            var client = new ClientMock(1, "0887585858", "pesho_losta@abv.bg");

            var hotelMock = new Mock<IHotel>();


            hotelMock.Setup(mock => mock.checkAvailability(3, "Shampoo", DateTime.Now.AddDays(2).Date)).Returns(() => null);

            //Assert
            Assert.ThrowsException<RoomNullException>(() => client.ReserveRoom(hotelMock.Object, 3, "Shampoo", DateTime.Now.AddDays(2).Date));


        }
    }
}
