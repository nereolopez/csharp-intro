﻿using CarRentalAgency.Model;
using CarRentalAgency.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency.Logic
{
    // Interface implemented on Part III
    public class CarsManager : ICarsManager
    {
        // Commented on Part II
        // CarService carService;

        // Commented out on PART III
        // Added on Part II
        //CarFileService carService;

        // Added on Part III
        ICarService carService;

        public List<Car> Cars => this.carService.GetCars();
        public List<Car> AvailableCars => this.Cars.Where(car => car.IsAvailable).ToList();

        // Constructor Replaced on Part III
        //public CarsManager()
        //{
        //    // Commented Out in Part II
        //    // this.carService = new CarService();

        //    // Added on Part II
        //    this.carService = new CarFileService();
        //}

        // Constructor Introduced in Part III
        public CarsManager(ICarService carService)
        {
            this.carService = carService;
        }

        public void ShowCars()
        {
            this.DisplayCarsOnScreen(this.Cars);
        }

        public void ShowAvailableCars()
        {
            this.DisplayCarsOnScreen(this.AvailableCars);
        }

        public void AddCar()
        {
            Console.WriteLine("This option is not yet available");
        }

        public void BlockCar(string carId)
        {
            this.carService.BlockCar(carId);
        }

        public void RemoveCar()
        {
            Console.WriteLine("This option is not yet available");
        }

        private void DisplayCarsOnScreen(List<Car> cars)
        {
            Console.Clear();
            Console.WriteLine("These are the cars we own:");

            int counter = 0;
            foreach (var car in cars)
            {
                counter++;
                string isAvailable = car.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine("{0}. {1} {2} {3}. {4}", counter, car.Maker, car.Model, car.EnergyType, isAvailable);
            }
        }
    }
}
