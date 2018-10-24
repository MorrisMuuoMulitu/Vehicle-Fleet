using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleet
{
    class Vehicle
    {
        //properties
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public int ManufacturingYear { get; set; }
        public double FuelConsumption { get; set; }
        public static int CurrentYear { get; set; }
        public bool IsFree { get; set; }
        public static int BaseFee { get; set; }
        public static int ProfitMargin { get; set; }
        //public static int CurrentCost { get; private set; }
        public int TravelledKm { get; private set; }
        //public static double CurrentFuelPrice { get; private set; }
        public double CurrentCost { get; set; }

        //constructor
        public Vehicle(string id, string registrationNumber, int manufacturingYear, double fuelConsumption)
        {
            this.Id = id;
            this.RegistrationNumber = registrationNumber;
            this.ManufacturingYear = manufacturingYear;
            this.FuelConsumption = fuelConsumption;
            IsFree = true;
        }
        //method
        public int age()
        {
            return CurrentYear - ManufacturingYear;
        }
        public bool DistanceTravelled(int currentDistance, int fuelPrice)
        {
            if (IsFree)
            {
                TravelledKm += currentDistance;
                CurrentCost = fuelPrice * currentDistance * FuelConsumption / 100;
                IsFree = false;
                return true;

            }
            return false;
        }
        public virtual int RentFee()
        {
            return (int)(BaseFee + CurrentCost * ProfitMargin / 100);
        }
        public void TransportEnd()
        {
            IsFree = true;
        }
        public override string ToString()
        {
            return "\nThe id of " + this.GetType().Name.ToLower() + ": " + Id +
            "\n\tregistration number: " + RegistrationNumber +
            "\n\tage: " + age() + " year" +
            "\n\tfuel-consumption: " + FuelConsumption + " liter/100 km" +
            "\n\tsodometer: " + TravelledKm + " km";
        }

    }
}