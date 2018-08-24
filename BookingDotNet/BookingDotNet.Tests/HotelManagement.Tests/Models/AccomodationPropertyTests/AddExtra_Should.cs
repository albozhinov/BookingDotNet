using BookingDotNet.Tests.HotelManagement.Tests.Models.Mocks;
using HotelManagement.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingDotNet.Tests.HotelManagement.Tests.Models.AccomodationPropertyTests
{
    [TestClass]
    public class AddExtra_Should
    {
        [DataTestMethod]
        [DataRow(null)]
        public void ThrowsArgumentException_WhenNullValueIsPassed(IExtra extra)
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.AddExtra(extra));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenTheValueExistsIsPassed()
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            var extra = new Mock<IExtra>();                    
            extra.Setup(x => x.Name).Returns(AvailableExtras.TV);     
            
            // Act
            accomodationProperty.AddExtra(extra.Object);            

            // Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.AddExtra(extra.Object));
        }

        [TestMethod]
        public void ReturnExtendedCollection_WhenTheValueDoesNotExistIsPassed()
        {
            // Arrange
            var accomodationProperty = new AccomodationPropertyMock(1, 2, false, "Sea", 222);

            var extra = new Mock<IExtra>();
            extra.Setup(x => x.Name).Returns(AvailableExtras.TV);

            // Act
            accomodationProperty.AddExtra(extra.Object);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => accomodationProperty.AddExtra(extra.Object));
        }
    }
}
