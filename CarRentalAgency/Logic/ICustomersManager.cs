using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    public interface ICustomersManager
    {
        List<Customer> Customers { get; }

        void ShowCustomers();
        void AddCustomer();
    }
}
