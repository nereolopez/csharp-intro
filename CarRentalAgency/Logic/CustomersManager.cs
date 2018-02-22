using CarRentalAgency.Model;
using CarRentalAgency.Services;
using System;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    class CustomersManager
    {
        CustomerService customerService;

        public List<Customer> Customers => this.customerService.GetCustomers();

        public CustomersManager()
        {
            this.customerService = new CustomerService();
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
