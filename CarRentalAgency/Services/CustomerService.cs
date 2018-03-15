using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Services
{
    // Interface implementation added on Part III
    class CustomerService : ICustomerService
    {
        List<Customer> customers;

        public CustomerService()
        {
            this.customers = new List<Customer>();
            this.CreateHardcodedCustomers();
        }

        public List<Customer> GetCustomers(bool refresh = false)
        {
            return this.customers;
        }

        private void CreateHardcodedCustomers()
        {
            this.customers.Add(new Customer("Bob", "Robson", new System.DateTime(1980, 5, 28), "436475J"));
            this.customers.Add(new Customer("Amanda", "Walls", new System.DateTime(1983, 2, 8), "387498R"));
            this.customers.Add(new Customer("Rick", "Anderson", new System.DateTime(1977, 12, 16), "356672D"));
            this.customers.Add(new Customer("Catherine", "Bell", new System.DateTime(1966, 9, 1), "326243Y"));
        }
    }
}
