using CarRentalAgency.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarRentalAgency.Services
{
    // Class added on Part II of the series
    public class CarFileService
    {
        private const string filePath = @"c:\test\cars.txt";

        List<Car> cars;

        public CarFileService()
        {
            this.cars = new List<Car>();
            InitializeFile();
        }

        public List<Car> GetCars(bool refresh = false)
        {
            if (this.cars.Count == 0 || refresh)
            {
                var carsFromFile = File.ReadAllLines(filePath);

                this.cars.Clear();
                foreach (var carLine in carsFromFile)
                {
                    var car = carLine.Trim(' ').Split(';');

                    this.cars.Add(
                        new Car(car[0],
                                car[1],
                                (EnergyType)Enum.Parse(typeof(EnergyType), car[2]),
                                Convert.ToInt32(car[3]),
                                Convert.ToDecimal(car[4]),
                                Convert.ToInt32(car[5]),
                                Convert.ToDecimal(car[6]),
                                Convert.ToDecimal(car[7]),
                                Convert.ToBoolean(car[8]),
                                car[9])
                    );
                }
            }

            return this.cars;
        }

        public Car GetCar(string carId)
        {
            return this.cars.FirstOrDefault(car => car.Id == carId);
        }

        public void BlockCar(string carId)
        {
            var index = this.cars.FindIndex(car => car.Id == carId);
            this.cars[index].Block();

            this.WriteCarsToFile();
        }

        private static void InitializeFile()
        {
            if (File.Exists(filePath) == false)
            {
                var sampleData = new string[]{
                    "Seat; Ibiza; Gas; 0; 50; 300; 0.006; 200; true; da17af5b-9336-4622-bd13-dadfbafb0ed6",
                    "VW; Golf; Electric; 1500; 70; 300; 0.006; 250; true; 687749ef-afe0-4ae1-a60c-ec0070c3c725",
                    "Peugeot; 3008; Diesel; 2345; 90; 300; 0.006; 300; true; c8df3069-6dd8-4562-938f-3c1f26da19a6",
                    "Audi; A4; Diesel; 173; 120; 300; 0.006; 400; true; afcb4fa4-0da2-41e1-a5df-4b749f4b5bc8",
                    "Mercedes; GLE Coupe; Hybrid; 3656; 160; 300; 0.006; 600; true; 5a808461-30b4-4d1a-b720-0be8f620c8b5"
                };

                File.WriteAllLines(filePath, sampleData);
            }
        }

        private void WriteCarsToFile()
        {
            var data = new string[this.cars.Count];
            for (int i = 0; i < this.cars.Count; i++)
            {
                data[i] = this.cars[i].ToString();
            }
            File.WriteAllLines(filePath, data);
        }
    }
}
