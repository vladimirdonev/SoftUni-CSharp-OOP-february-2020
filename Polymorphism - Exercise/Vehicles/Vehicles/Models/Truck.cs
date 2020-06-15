using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double Fuel_Consumption_Increment = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption,double tankcapacity) 
            : base(fuelQuantity, fuelConsumption,tankcapacity)
        {
        }

        public override double FuelConsumption 
        { get => base.FuelConsumption;
            protected set
            {
                base.FuelConsumption = value + Fuel_Consumption_Increment;
            }
        }

        public override void Refuel(double fuel)
        {
            if(fuel > TankCapacity)
            {
                base.Refuel(fuel);
            }
            fuel *= 0.95;
            base.Refuel(fuel);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
