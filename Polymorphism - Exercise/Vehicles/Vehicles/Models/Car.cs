using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double Airconditionconsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption,double tankcapacity) 
            : base(fuelQuantity, fuelConsumption,tankcapacity)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption;
            protected set
            {
                base.FuelConsumption = value + Airconditionconsumption;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
