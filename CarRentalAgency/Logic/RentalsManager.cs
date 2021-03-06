﻿using CarRentalAgency.Model;
using CarRentalAgency.Services;
using System;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    // Interface implemented on Part III
    public class RentalsManager : IRentalsManager
    {
        // Commented out on Part III
        // CustomersManager customersManager;
        // CarsManager carsManager;

        // Added on Part III
        IRentalService rentalService;
        ICarsManager carsManager;
        ICustomersManager customersManager;

        // Added in Part II
        public List<Rental> Rentals => this.rentalService.GetRentals();
        public List<Rental> ActiveRentals => this.rentalService.GetActiveRentals();

        // RentalFileService rentalService; // Commented out on Part III

        // Commented out on Part II
        // List<Rental> rentals;

        // Constructor replaced on Part III
        //public RentalsManager(CustomersManager customersManager, CarsManager carsManager) {
        //    this.customersManager = customersManager;
        //    this.carsManager = carsManager;

        //    // Commented out on Part II
        //    // this.rentals = new List<Rental>();

        //    // Added in Part II
        //    this.rentalService = new RentalFileService();
        //}

        // Added on Part III
        public RentalsManager(ICustomersManager customersManager, ICarsManager carsManager, IRentalService rentalService)
        {
            this.customersManager = customersManager;
            this.carsManager = carsManager;
            this.rentalService = rentalService;
        }

        public void AddRental()
        {
            Console.Clear();
            Console.WriteLine("Please enter the information for the rental.");

            var customer = this.SelectCustomer();
            var car = this.SelectCar();
            var startDate = this.SelectDate("Select the start date for the rental");
            var endDate = this.SelectDate("Select the start date for the rental");
            var cardNumber = this.AskForCreditCardNumber();

            var rental = new Rental(car, customer.Id, startDate, endDate, cardNumber);

            // Commented out on Part II
            // this.rentals.Add(rental);

            // Added on Part II
            this.rentalService.AddRental(rental);

            this.carsManager.BlockCar(car.Id);

            this.ShowAddedRentalInformation(rental, customer, car);
        }

        public void CloseRental()
        {
            Rental rentalToClose = null;
            int selectedRentalIndex;
            bool validOption = false;

            while (validOption == false)
            {
                this.ShowActiveRentals();
                Console.WriteLine("Select the rental to close");

                try
                {
                    selectedRentalIndex = Convert.ToInt32(Console.ReadLine());
                    selectedRentalIndex--;
                    if (selectedRentalIndex < this.ActiveRentals.Count)
                    {
                        rentalToClose = this.ActiveRentals[selectedRentalIndex];
                        validOption = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please select a valid option (from 1 to {0}", this.ActiveRentals.Count);
                }
            }

            Console.WriteLine("Does the returned car have any damage? (y/n)");
            bool carIsDamaged = Console.ReadLine().ToUpper() == "Y";

            this.CloseRental(rentalToClose, carIsDamaged);
        }

        /// <summary>
        /// Closes, Persists and returns the closed Rental
        /// </summary>
        /// <param name="rental"></param>
        /// <returns></returns>
        public Rental CloseRental(Rental rental, bool carIsDamaged)
        {
            // ToDo implement based on the tests

            return rental;
        }

        private void ShowAddedRentalInformation(Rental rental, Customer customer, Car car)
        {
            Console.Clear();
            Console.WriteLine("The rental has been registered correctly. Here is the rental information:");
            Console.WriteLine("Customer: {0}", customer.FullName);
            Console.WriteLine("Start date: {0}", rental.StartDate);
            Console.WriteLine("End date: {0}", rental.EndDate);
            Console.WriteLine("Car: {0} {1} {2}", car.Maker, car.Model, car.EnergyType);
            Console.WriteLine("Expected Fee: {0}", rental.Fee);
            Console.WriteLine("Deposit: {0}", rental.DepositFee);
        }

        private Customer SelectCustomer()
        {
            Customer selectedCustomer = null;
            int selectedCustomerIndex;
            bool validOption = false;

            while (validOption == false)
            {
                var customers = this.customersManager.Customers;
                this.customersManager.ShowCustomers();
                Console.WriteLine("Select the customer for the rental");

                try
                {
                    selectedCustomerIndex = Convert.ToInt32(Console.ReadLine());
                    selectedCustomerIndex--;
                    if (selectedCustomerIndex < customers.Count)
                    {
                        selectedCustomer = customers[selectedCustomerIndex];
                        validOption = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please select a valid option (from 1 to {0}", customers.Count);
                }
            }

            return selectedCustomer;
        }

        private Car SelectCar()
        {
            Car selectedCar = null;
            int selectedCarIndex;
            bool validOption = false;

            while (validOption == false)
            {
                var availableCars = this.carsManager.AvailableCars;
                this.carsManager.ShowAvailableCars();
                Console.WriteLine("Select the car for the rental");

                try
                {
                    selectedCarIndex = Convert.ToInt32(Console.ReadLine());
                    selectedCarIndex--;
                    if (selectedCarIndex < availableCars.Count)
                    {
                        selectedCar = availableCars[selectedCarIndex];
                        validOption = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please select a valid option (from 1 to {0}", availableCars.Count);
                }
            }

            return selectedCar;
        }

        private DateTime SelectDate(string message)
        {
            string selectedDate = string.Empty;
            bool validInput = false;

            Console.WriteLine(message);

            while (validInput == false)
            {
                try
                {
                    selectedDate = Console.ReadLine();
                    Convert.ToDateTime(selectedDate);
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid date");
                }
            }

            return Convert.ToDateTime(selectedDate);
        }

        private int AskForCreditCardNumber()
        {
            int creditCardNumber = 0;
            bool validInput = false;
            Console.WriteLine("Please enter the customer's credit card number");

            while (validInput == false)
            {
                try
                {
                    creditCardNumber = Convert.ToInt32(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid credit card number (only digits)");
                }
            }

            return creditCardNumber;
        }

        private void ShowActiveRentals()
        {
            Console.Clear();
            Console.WriteLine("These are the current active rentals");
            int index = 0;
            foreach (var rental in this.ActiveRentals)
            {
                index++;
                // Ideally, we would get the customer name based on the ID and the Car Maker and Brand.
                Console.WriteLine("{0}. {1} - {2}", index, rental.CustomerId, rental.CarId);
            }
        }
    }
}
