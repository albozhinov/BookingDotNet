using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.ClientTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Initialize_ListOfReservations()
        {
            //Act + Arrange
            var client = new ClientMock(1, "0887999129", "t.pe23ev1@gmail.com");

            //Assert
            Assert.IsNotNull(client.Reservations);
        }

        [TestMethod]
        [DataRow(-1)]
        public void Set_NumberOfVisits_ShouldThrow_If_Not_Valid(int visits)
        {
            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new ClientMock(visits, "0887999129", "t.pe23ev1@gmail.com"));
        }

        [TestMethod]
        public void Set_NumberOfVisits_WhenValid()
        {
            //Act + Arrange
            var client = new ClientMock(1, "0887999129", "t.pe23ev1@gmail.com");

            //Assert
            Assert.AreEqual(1, client.NumberOfVisits);
        }

        [TestMethod]
        [DataRow("goshko")]
        [DataRow("1")]
        [DataRow("12345678910111213141516")]
        public void Set_TelephoneNumber_ShouldThrow_If_Not_Valid(string phone)
        {

            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new ClientMock(1, phone, "t.pe23ev1@gmail.com"));
        }

        [TestMethod]
        public void Set_TelephoneNumber_WhenValid()
        {
            //Act + Arrange
            var client = new ClientMock(1, "0887999129", "t.pe23ev1@gmail.com");

            //Assert
            Assert.AreEqual("0887999129", client.TelephoneNumber);
        }

        [TestMethod]
        public void Set_Email_WhenValid()
        {
            //Act + Arrange
            var client = new ClientMock(1, "0887999129", "t.pe23ev1@gmail.com");

            //Assert
            Assert.AreEqual("t.pe23ev1@gmail.com", client.Email);
        }

        [TestMethod]
        [DataRow("goshko")]
        [DataRow("1t.pe23ev1@gmail.comt.pe23ev1@gmail.comt.pe23ev1@gmail.comt.pe23ev1@gmail.comt.pe23ev1@gmail.comt.pe23ev1@gmail.com")]
        public void Set_Email_ShouldThrow_If_Not_Valid(string email)
        {

            //Arrange + Assert + Act
            Assert.ThrowsException<ArgumentException>(() => new ClientMock(1, "087887172134" , email));
        }

    }

}
