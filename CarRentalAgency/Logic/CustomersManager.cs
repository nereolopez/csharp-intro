using CarRentalAgency.Model;
using CarRentalAgency.Services;
using System;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    // Interface implemented on Part III
    public class CustomersManager : ICustomersManager
    {
        // Commented Out in Part II
        // CustomerService customerService;

        // Commented out on Part III
        // Added on Part II
        //CustomerFileService customerService;

        // Added on Part III
        ICustomerService customerService;

        public List<Customer> Customers => this.customerService.GetCustomers();

        // Constructor replaced on Part III
        //public CustomersManager()
        //{
        //    this.customerService = new CustomerFileService();
        //}

        // Added on Part III
        public CustomersManager(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public void ShowCustomers()
        {
            DisplayCustomersOnScren(this.Customers);
        }

        public void AddCustomer()
        {
            Console.WriteLine("This option is not yet available");
        }

        private void DisplayCustomersOnScren(List<Customer> customers)
        {
            Console.Clear();
            Console.WriteLine("These are our customers so far:");

            int counter = 0;
            foreach (var customer in customers)
            {
                counter++;
                Console.WriteLine("{0}. {1}", counter, customer.FullName);
            }
        }
    }
}
