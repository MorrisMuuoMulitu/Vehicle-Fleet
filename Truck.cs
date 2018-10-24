using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleet
{
    class Truck : Vehicle
    {
        private double CarryingCapacity;
        public static double Multipier;

        public Truck(string id, string registrationNumber, int manufacturingYear, double fuelConsumption, double carryingCapacity) :
        base(id, registrationNumber, manufacturingYear, fuelConsumption)
        {
            this.CarryingCapacity = carryingCapacity;
        }
        public override int RentFee()
        {
            return (int)(CarryingCapacity * Multipier);
        }
        public override string ToString()
        {
            return base.ToString() + "\ncarrying capacity" + CarryingCapacity;
        }
    }
}