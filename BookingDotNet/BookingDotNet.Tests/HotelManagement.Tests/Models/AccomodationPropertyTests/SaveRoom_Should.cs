using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class SaveRoom_Should
    {
        [DataTestMethod]
        [DataRow("5/8/2018")]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(string date)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            var parsedDate = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.SaveRoom(parsedDate));
        }

        [DataTestMethod]
        [DataRow("30/8/2018")]
        public void ThrowsArgumentException_WhenTheReservationDateAlreadyExists(string date)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);
            
            var parsedDate = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);

            accomodationProperty.NotAvailable.Add(parsedDate);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.SaveRoom(parsedDate));
        }

        [DataTestMethod]
        [DataRow("15/9/2018")]
        public void ReturnExtendedCollection_WhenTheReservationDateDoesNotExist(string date)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            var firstDate = "20/12/2018";
            var parsedFirstDate = DateTime.ParseExact(firstDate, "d/M/yyyy", CultureInfo.InvariantCulture);
            accomodationProperty.NotAvailable.Add(parsedFirstDate);

            var parsedDate = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);
            accomodationProperty.NotAvailable.Add(parsedDate);

            // Act & Assert
            Assert.AreEqual(2, accomodationProperty.NotAvailable.Count);
        }
    }
}
