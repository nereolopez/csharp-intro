using CarRentalAgency.Model;
using System.Collections.Generic;

namespace CarRentalAgency.Logic
{
    interface IRentalsManager
    {
        List<Rental> Rentals { get; }

        void AddRental();
        // Added on Part IV
        void CloseRental();
    }
}
