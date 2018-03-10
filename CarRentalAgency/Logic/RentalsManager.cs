using CarRentalAgency.Model;
using CarRentalAgency.Services;
using System;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    class RentalsManager
    {
        CustomersManager customersManager;
        CarsManager carsManager;

        // Commented out in Part II
        // List<Rental> rentals;

        // Added in Part II
        private RentalFileService rentalService;
        public List<Rental> Rentals => this.rentalService.GetRentals();
        public List<Rental> ActiveRentals => this.rentalService.GetActiveRentals();

        public RentalsManager(CustomersManager customersManager, CarsManager carsManager)
        {
            this.customersManager = customersManager;
            this.carsManager = carsManager;

            // Commented out on Part II
            // this.rentals = new List<Rental>();

            // Added in Part II
            this.rentalService = new RentalFileService();
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

        public void ShowAddedRentalInformation(Rental rental, Customer customer, Car car)
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
                var cars = this.carsManager.Cars;
                this.carsManager.ShowAvailableCars();
                Console.WriteLine("Select the car for the rental");

                try
                {
                    selectedCarIndex = Convert.ToInt32(Console.ReadLine());
                    selectedCarIndex--;
                    if (selectedCarIndex < cars.Count)
                    {
                        selectedCar = cars[selectedCarIndex];
                        validOption = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please select a valid option (from 1 to {0}", cars.Count);
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
    }
}
