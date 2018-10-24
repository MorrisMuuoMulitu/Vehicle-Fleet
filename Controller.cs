using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VehicleFleet
{
    class Controller
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private string BUS = "bus";
        private string TRUCK = "truck";
        public void Start()
        {
            StaticValues();
            ReadData();
            Output("\n The registered vehicles");
            //Travelling();
            Output("\n Afer travelling");
            AverageAge();
            MaxTravelled();
            Sorting();

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("The Registration number" + vehicle.RegistrationNumber + "the current cost" +
                vehicle.CurrentCost + "the fee" + vehicle.RentFee());
            }

        }

        private void StaticValues()
        {
            Vehicle.CurrentYear = 2017;
            Vehicle.BaseFee = 1000;
            Vehicle.ProfitMargin = 10;

            Bus.Multipier = 15;
            Truck.Multipier = 10;
        }

        private void ReadData()
        {
            StreamReader streamReader = new StreamReader("Vehicle.txt");
            string type, registrationNr, id;
            int seats, manufacturingYr;
            double carryingCapacity, consumption;
            string dataLine;
            string[] data;
            int idNr = 1;

            while (!streamReader.EndOfStream)
            {
                dataLine = streamReader.ReadLine();
                data = dataLine.Split(';');
                type = data[0];
                registrationNr = data[1];
                manufacturingYr = int.Parse(data[2]);
                consumption = double.Parse(data[3]);
                id = type.Substring(0, 1).ToUpper() + idNr;

                if (type == BUS)
                {
                    seats = int.Parse(data[4]);
                    vehicles.Add(new Bus(id, registrationNr, manufacturingYr, consumption, seats));
                }
                else if (type == TRUCK)
                {
                    carryingCapacity = double.Parse(data[4]);
                    vehicles.Add(new Truck(id, registrationNr, manufacturingYr,
                    consumption, carryingCapacity));
                }
                idNr++;
            }
            streamReader.Close();
        }

        private void Output(string cim)
        {
            Console.WriteLine(cim);
            foreach (Vehicle jarmu in vehicles)
            {
                Console.WriteLine(jarmu);
            }
        }
        /*
        private void Travelling()
        {
            int costSum = 0, feeSum = 0;
            Random rand = new Random();
            int lowerLimitOfFuelPrice = 400, upperLimitOfFluelPrice = 420;
            double maxDistance = 300;
            int operationLimit = 200;
            int vehicleIndex;
            Vehicle vehicle;
            int numberOfTransports = 0;
            Console.WriteLine("\nSimulation of travelling\n");
            for (int i = 0; i < (int)rand.Next(operationLimit); i++)
            {
                vehicleIndex = rand.Next(vehicles.Count);
                vehicle = vehicles[vehicleIndex];
                if (vehicle.Transports(rand.NextDouble() * maxDistance,
                rand.Next(lowerLimitOfFuelPrice, upperLimitOfFluelPrice)))
                {
                    numberOfTransports++;
                    Console.WriteLine("\nThe registration number of travelling vehicle: " +
                    vehicle.RegistrationNumber +
                    "\nCurrent cost: " + vehicle.CurrentCost + " Ft." +
                    "\nCurrent fee: " + vehicle.RentFee() + " Ft.");
                    feeSum += vehicle.RentFee();
                    costSum += vehicle.CurrentCost;
                }
                vehicleIndex = rand.Next(vehicles.Count);
                vehicles[vehicleIndex].TransportEnd();
            }
            Console.WriteLine("\n\nTotal cost: " + costSum + " Ft." +
            "\n\nTotal fee: " + feeSum + " Ft." +
            "\n\nProfit: " + (feeSum - costSum) + "Ft." +
            "\n\nNumber of transports: " + numberOfTransports);
        }*/

        private void AverageAge()
        {
            double ageSum = 0;
            int itemNr = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                ageSum += vehicle.age();
                itemNr++;
            }
            if (itemNr > 0)
            {
                Console.WriteLine("\nThe average of vehicles' age: " + ageSum / itemNr + " year.");
            }
            else
                Console.WriteLine("there are no vehicles");
        }

        private void MaxTravelled()
        {
            double max = vehicles[0].TravelledKm;
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicles[0].TravelledKm > max)
                {
                    max = vehicles[0].TravelledKm;
                }
            }
            Console.WriteLine("\nThe highed travellers are with {0: 000.00} km:\n", max);
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicles[0].TravelledKm == max)
                {
                    Console.WriteLine(vehicle.RegistrationNumber);
                }
            }
        }

        private void Sorting()
        {
            Vehicle temp;
            for (int i = 0; (i < vehicles.Count - 1); i++)
            {
                for (int j = i + 1; (j < vehicles.Count); j++)
                {
                    if (vehicles[i].FuelConsumption > vehicles[j].FuelConsumption)
                    {
                        temp = vehicles[i];
                        vehicles[i] = vehicles[j];
                        vehicles[j] = temp;
                    }
                }
            }
            Console.WriteLine("\nOrdering by consumption: ");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("{0,-10} {1:00.0} liter / 100 km.",
                vehicle.RegistrationNumber, vehicle.FuelConsumption);
            }
        }
    }
}