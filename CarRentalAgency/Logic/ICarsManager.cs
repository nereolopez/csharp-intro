using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    public interface ICarsManager
    {
        List<Car> Cars { get; }
        List<Car> AvailableCars { get; }

        void ShowCars();
        void ShowAvailableCars();
        void AddCar();
        void BlockCar(string carId);
        void RemoveCar();
    }
}
