using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Common;

namespace Vehicles
{
    class Bus : Vehicle
    {
        private const double Fuel_Icrement = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankcapacity) 
            : base(fuelQuantity, fuelConsumption, tankcapacity)
        {
        }

        public string DrivePeople(double distance)
        {
            double fuelneeded = distance * (FuelConsumption + Fuel_Icrement);
            if (fuelneeded > this.FuelQuantity)
            {
                string ex = string.Format(Exeptionmsg.EXP_MSG, this.GetType().Name);
                throw new Exception(ex);
            }
            this.FuelQuantity -= fuelneeded;
            return string.Format($"{this.GetType().Name} travelled {distance} km");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
