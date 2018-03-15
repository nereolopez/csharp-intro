using CarRentalAgency.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRentalAgency.Services
{
    // Interface implementation added on Part III
    class CustomerFileService : ICustomerService
    {
        private const string filePath = @"c:\test\customers.txt";

        List<Customer> customers;

        public CustomerFileService()
        {
            this.customers = new List<Customer>();
            InitializeFile();
        }

        public List<Customer> GetCustomers(bool refresh = false)
        {
            if (this.customers.Count == 0 || refresh)
            {
                var customersFromFile = File.ReadAllLines(filePath);

                this.customers.Clear();
                foreach (var customerLine in customersFromFile)
                {
                    var customer = customerLine.Trim(' ').Split(';');

                    this.customers.Add(
                        new Customer(customer[0],
                                     customer[1],
                                     Convert.ToDateTime(customer[2]),
                                     customer[3],
                                     customer[4])
                    );
                }
            }

            return this.customers;
        }

        private static void InitializeFile()
        {
            if (File.Exists(filePath) == false)
            {
                var sampleData = new string[]{
                    "Bob; Robson; 28/5/1980; 436475J;a31e3e8a-7cda-42a2-953f-ddee039074b3",
                    "Amanda; Walls; 8/2/1983; 387498R;4c9a81a1-b1f8-46b2-b83f-8d37d3f14e04",
                    "Rick; Anderson; 16/12/1977; 356672D;8c6ff341-192a-4c67-9039-2668e5dbda41",
                    "Catherine; Bell; 9/1/1966; 326243Y;f2afc57c-3480-42bf-b6c9-eec6d9733266",
            };

                File.WriteAllLines(filePath, sampleData);
            }
        }
    }
}
