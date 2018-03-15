using CarRentalAgency.Logic;
using CarRentalAgency.Services;
using System;

namespace CarRentalAgency
{
    class Program
    {
        // Commented out on Part III
        //static CarsManager carsManager;
        // static CustomersManager customersManager;
        // static RentalsManager rentalsManager;

        // Added on Part III
        static ICarsManager carsManager;
        static ICustomersManager customersManager;
        static IRentalsManager rentalsManager;

        static void Main(string[] args)
        {
            // Commented out on Part III
            // carsManager = new CarsManager();
            // customersManager = new CustomersManager();
            // rentalsManager = new RentalsManager(customersManager, carsManager);

            // Added on Part III (yes, the best would be not to instantiate the types below here but in a container instead, which we are not using so far...)
            carsManager = new CarsManager(new CarFileService());
            customersManager = new CustomersManager(new CustomerFileService());
            rentalsManager = new RentalsManager(customersManager, carsManager, new RentalFileService());

            MainMenu();
        }

        static void MainMenu()
        {
            int option = 0;

            while (option != 4)
            {
                Console.Clear();
                Console.WriteLine("RENTAL PROGRAM MAIN MENU");
                Console.WriteLine("1. Manage Cars");
                Console.WriteLine("2. Manage Customer");
                Console.WriteLine("3. Manage Rentals");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Write the number of the actinon you want to take:");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            CarsMenu();
                            WaitForUserInput();
                            break;
                        case 2:
                            CustomersMenu();
                            WaitForUserInput();
                            break;
                        case 3:
                            RentalsMenu();
                            WaitForUserInput();
                            break;
                        case 4:

                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid option (a number from 1 to 4.");
                    option = 0;
                }
            }
        }

        static void CarsMenu()
        {
            int option = 0;

            while (option != 4)
            {
                Console.Clear();
                Console.WriteLine("CARS MENU");
                Console.WriteLine("1. List All Cars");
                Console.WriteLine("2. Add a Car");
                Console.WriteLine("3. Remove a Car");
                Console.WriteLine("4. Back to main menu");
                Console.WriteLine("Write the number of the actinon you want to take:");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            carsManager.ShowCars();
                            WaitForUserInput();
                            break;
                        case 2:
                            carsManager.AddCar();
                            WaitForUserInput();
                            break;
                        case 3:
                            carsManager.RemoveCar();
                            WaitForUserInput();
                            break;
                        case 4:
                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid option (a number from 1 to 4.");
                    option = 0;
                }
            }
        }

        static void CustomersMenu()
        {
            int option = 0;

            while (option != 3)
            {
                Console.Clear();
                Console.WriteLine("CUSTOMERS MENU");
                Console.WriteLine("1. List All Customers");
                Console.WriteLine("2. Add a Customer");
                Console.WriteLine("3. Back to main menu");
                Console.WriteLine("Write the number of the actinon you want to take:");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            customersManager.ShowCustomers();
                            WaitForUserInput();
                            break;
                        case 2:
                            customersManager.AddCustomer();
                            WaitForUserInput();
                            break;
                        case 3:
                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid option (a number from 1 to 3.");
                    option = 0;
                }
            }
        }

        static void RentalsMenu()
        {
            int option = 0;

            while (option != 3)
            {
                Console.Clear();
                Console.WriteLine("CUSTOMERS MENU");
                Console.WriteLine("1. New Rental");
                Console.WriteLine("2. Close Rental");
                Console.WriteLine("3. Back to main menu");
                Console.WriteLine("Write the number of the actinon you want to take:");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            rentalsManager.AddRental();
                            WaitForUserInput();
                            break;
                        case 2:
                            // Added in Part IV
                            rentalsManager.CloseRental();
                            WaitForUserInput();
                            break;
                        case 3:
                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid option (a number from 1 to 3.");
                    option = 0;
                }
            }
        }

        static void WaitForUserInput()
        {
            Console.WriteLine("Please, press any key to continue...");
            Console.ReadKey();
        }
    }
}
