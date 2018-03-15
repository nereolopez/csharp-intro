using CarRentalAgency.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency.Services
{
    // Interface implementation added on Part III
    public class CarService : ICarService
    {
        List<Car> cars;

        public CarService()
        {
            this.cars = new List<Car>();
            this.CreateHardcodedCars();
        }

        public List<Car> GetCars(bool refresh = false)
        {
            return this.cars;
        }

        public Car GetCar(string carId)
        {
            return this.cars.FirstOrDefault(car => car.Id == carId);
        }

        public void BlockCar(string carId)
        {
            var index = this.cars.FindIndex(car => car.Id == carId);
            this.cars[index].Block();
        }

        private void CreateHardcodedCars()
        {
            this.cars.Add(new Car("Seat", "Ibiza", EnergyType.Gas, 0, 50, 300, 0.006m, 200));
            this.cars.Add(new Car("VW", "Golf", EnergyType.Electric, 0, 70, 300, 0.006m, 250));
            this.cars.Add(new Car("Peugeot", "3008", EnergyType.Diesel, 0, 90, 300, 0.006m, 300));
            this.cars.Add(new Car("Audi", "A4", EnergyType.Diesel, 0, 120, 300, 0.006m, 400));
            this.cars.Add(new Car("Mercedes", "GLE Coupe", EnergyType.Hybrid, 0, 160, 300, 0.006m, 600));
        }
    }
}
