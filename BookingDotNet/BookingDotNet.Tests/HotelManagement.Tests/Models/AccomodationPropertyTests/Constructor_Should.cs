using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetProperCapacity_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.AreEqual(2, accomodationProperty.Capacity);
        }

        [TestMethod]
        public void SetProperBeds_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.AreEqual(3, accomodationProperty.Beds);
        }

        [TestMethod]
        public void SetProperForSmokers_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.AreEqual(true, accomodationProperty.ForSmokers);
        }

        [TestMethod]
        public void SetProperView_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.AreEqual(ViewType.City, accomodationProperty.View);
        }

        [TestMethod]
        public void SetProperBasePrice_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.AreEqual(55M, accomodationProperty.BasePrice);
        }

        [TestMethod]
        public void InitializeListOfExtras_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.IsNotNull(accomodationProperty.ListOfExtras);
        }

        [TestMethod]
        public void InitializeNotAvailableCollection_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var accomodationProperty = new AccomodationPropertyMock(2, 3, true, "City", 55);

            // Assert
            Assert.IsNotNull(accomodationProperty.NotAvailable);
        }
    }
}
