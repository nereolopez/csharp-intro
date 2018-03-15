using CarRentalAgency.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRentalAgency.Services
{
    // Implementing interface on Part III
    // Added in Part II
    class RentalFileService : IRentalService
    {
        private const string filePath = @"c:\test\rentals.txt";
        private CarFileService carService;

        List<Rental> rentals;
        List<Rental> activeRentals;

        public RentalFileService()
        {
            this.rentals = new List<Rental>();
            this.activeRentals = new List<Rental>();
            this.carService = new CarFileService();
            InitializeFile();
        }

        public List<Rental> GetRentals(bool refresh = false)
        {
            if (this.rentals.Count == 0 || refresh)
            {
                var rentalsFromFile = File.ReadAllLines(filePath);

                this.rentals.Clear();
                foreach (var rentalLine in rentalsFromFile)
                {
                    var rental = rentalLine.Trim(' ').Split(';');
                    this.rentals.Add(Rental.Parse(rental));
                }
            }


            return this.rentals;
        }

        public List<Rental> GetActiveRentals(bool refresh = false)
        {
            if (this.activeRentals.Count == 0 || refresh)
            {
                var rentalsFromFile = File.ReadAllLines(filePath);
                this.activeRentals.Clear();
                foreach (var rentalLine in rentalsFromFile)
                {
                    var rental = rentalLine.Trim(' ').Split(';');
                    RentalStatus status = (RentalStatus)Enum.Parse(typeof(RentalStatus), rental[9]);

                    if (status == RentalStatus.Ongoing)
                    {
                        this.activeRentals.Add(Rental.Parse(rental));
                    }
                }
            }

            return this.activeRentals;
        }

        public void AddRental(Rental rental)
        {
            this.rentals.Add(rental);
            this.WriteRentalsToFile();
        }

        private static void InitializeFile()
        {
            if (File.Exists(filePath) == false)
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        private void WriteRentalsToFile()
        {
            var data = new string[this.rentals.Count];
            for (int i = 0; i < this.rentals.Count; i++)
            {
                data[i] = this.rentals[i].ToString();
            }
            File.WriteAllLines(filePath, data);
        }
    }
}
