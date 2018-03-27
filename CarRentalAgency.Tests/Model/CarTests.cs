using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalAgency.Model;

namespace CarRentalAgency.Tests.Model
{
    [TestClass]
    public class CarTests
    {
        Car car;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car("Mercedes", "C Klasse", EnergyType.Gas, 0, 200, 400, 0.06m, 500);
        }

        [TestMethod]
        public void CarDefaultInitializationTest()
        {
            // Arrange
            int expectedKms = 0;

            // Act
            // Done in the Setup

            // Assert
            Assert.AreEqual(this.car.Kms, expectedKms);            
        }

        [TestMethod]
        public void BlockCarTest()
        {
            // Arrange

            // Act
            this.car.Block();

            // Assert
            Assert.IsFalse(car.IsAvailable);
        }
    }
}
