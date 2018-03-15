using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Services
{
    // Added on Part III
    public interface ICustomerService
    {
        List<Customer> GetCustomers(bool refresh = false);
    }
}
