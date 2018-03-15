using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Services
{
    // Added on Part III
    public interface IRentalService
    {
        List<Rental> GetRentals(bool refresh = false);
        List<Rental> GetActiveRentals(bool refresh = false);

        void AddRental(Rental rental);
    }
}
