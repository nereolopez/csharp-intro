using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalAgency.Model;
using CarRentalAgency.Logic;
using Moq;
using CarRentalAgency.Services;

namespace CarRentalAgency.Tests.Logic
{
    [TestClass]
    public class RentalsManagerTests
    {
        Rental ongoingRental;
        Car car;
        const decimal depositFee = 500;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car("Mercedes", "C Klasse", EnergyType.Gas, 0, 200, 400, 0.06m, depositFee);
            this.ongoingRental = new Rental(this.car, "customerId", DateTime.Now, DateTime.Now.AddDays(2), 12345);
        }

        [TestMethod]
        public void DepositUnblockedIfCarHasNoDamageTest()
        {
            // Arrange
            bool carIsDamaged = false;
            var mockCustomersManager = new Mock<ICustomersManager>();
            var mockCarsManager = new Mock<ICarsManager>();
            var mockRentalService = new Mock<IRentalService>();
            var testee = new RentalsManager(mockCustomersManager.Object, mockCarsManager.Object, mockRentalService.Object);

            // Act
            var closedRental = testee.CloseRental(this.ongoingRental, carIsDamaged);

            // Assert
            Assert.Equals(closedRental.DepositFee, 0);
        }

        [TestMethod]
        public void DepositKeptIfCarHasDamageTest()
        {
            // Arrange
            bool carIsDamaged = false;
            var mockCustomersManager = new Mock<ICustomersManager>();
            var mockCarsManager = new Mock<ICarsManager>();
            var mockRentalService = new Mock<IRentalService>();
            var testee = new RentalsManager(mockCustomersManager.Object, mockCarsManager.Object, mockRentalService.Object);

            // Act
            var closedRental = testee.CloseRental(this.ongoingRental, carIsDamaged);

            // Assert
            Assert.Equals(closedRental.DepositFee, depositFee);
        }

        [TestMethod]
        public void ChargeExtraKmsTest()
        {
        }

        [TestMethod]
        public void RentalStatusSetToCloseTest()
        {
        }

        // Things we could test in integration
        // Car is unblocked
    }
}
