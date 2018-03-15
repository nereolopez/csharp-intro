using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Services
{
    // Added on Part III
    public interface ICarService
    {
        List<Car> GetCars(bool refresh = false);

        Car GetCar(string carId);

        void BlockCar(string carId);
    }
}
