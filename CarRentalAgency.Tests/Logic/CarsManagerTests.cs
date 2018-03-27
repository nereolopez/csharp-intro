using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalAgency.Services;
using Moq;
using CarRentalAgency.Logic;
using System.Collections.Generic;
using CarRentalAgency.Model;
using System.Linq;

namespace CarRentalAgency.Tests.Logic
{
    [TestClass]
    public class CarsManagerTests
    {
        List<Car> stubbedCars;

        [TestInitialize]
        public void Setup()
        {
            this.stubbedCars = new List<Car>();
            this.stubbedCars.Add(new Car("Seat", "Ibiza", EnergyType.Gas, 0, 50, 300, 0.006m, 200));
            this.stubbedCars.Add(new Car("VW", "Golf", EnergyType.Electric, 0, 70, 300, 0.006m, 250));
            this.stubbedCars.Add(new Car("Peugeot", "3008", EnergyType.Diesel, 0, 90, 300, 0.006m, 300));
            this.stubbedCars.Add(new Car("Audi", "A4", EnergyType.Diesel, 0, 120, 300, 0.006m, 400));
            this.stubbedCars.Add(new Car("Mercedes", "GLE Coupe", EnergyType.Hybrid, 0, 160, 300, 0.006m, 600));

            // The two lines go along with the region below
            this.carService = new CarFileService();
            this.carsManager = new CarsManager(this.carService);
        }

        // IMPORTANT!!
        // Keep in mind that the region of code below is before reaching the session
        // on how to unit test when there are dependencies as below.
        // Here we are using the actual dependencies and using the File System (which makes it resemble
        // more to Integration testing), which could cause the tests to fail if someone modifies the expected state of the data in the tests
        #region before discussing handling dependencies
        CarsManager carsManager;
        ICarService carService;

        [TestMethod]
        public void CheckNumberOfAllOwnedCarsTest()
        {
            // Arrange
            // If the file is new and app was not used, expected cars is 5.
            const int expectedCars = 5;

            // Act 
            var cars = this.carsManager.Cars;

            // Arrange
            Assert.AreEqual(expectedCars, cars.Count);
        }

        [TestMethod]
        public void CheckNumberOfAvailableCarsTest()
        {
            // Arrange
            // If the file is new and app was not used, expected available cars is 5 (all of them).
            const int expectedCars = 5;

            // Act 
            var cars = this.carsManager.Cars;

            // Arrange
            Assert.AreEqual(expectedCars, cars.Count);
        }

        #endregion

        [TestMethod]
        public void CheckNumberOfAllOwnCarsMockTest()
        {
            // Arrange
            var mockCarService = new Mock<ICarService>();
            mockCarService.Setup(x => x.GetCars(false)).Returns(this.stubbedCars);
            int expected = this.stubbedCars.Count;

            var testee = new CarsManager(mockCarService.Object);

            // Act
            int actual = testee.Cars.Count;

            // Assert 
            Assert.AreEqual(expected, actual);

        }
    }
}
