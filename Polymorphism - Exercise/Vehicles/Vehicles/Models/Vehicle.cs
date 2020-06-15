using System;
using Vehicles.Models.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private double fuelquantity;
        public Vehicle(double fuelQuantity,double fuelConsumption,double tankcapacity)
        {
            this.TankCapacity = tankcapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        {
            get
            {
                return this.fuelquantity;
            }
            protected set
            {
                this.fuelquantity = value;
            } 
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            double fuelneeded = distance * FuelConsumption;
            if(fuelneeded > this.FuelQuantity)
            {
                string ex = string.Format(Exeptionmsg.EXP_MSG, this.GetType().Name);
                throw new Exception(ex);
            }
            this.FuelQuantity -= fuelneeded;
            return string.Format($"{this.GetType().Name} travelled {distance} km");
        }


        public virtual void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (fuel > TankCapacity)
                {
                    throw new Exception($"Cannot fit {fuel} fuel in the tank");
                }
                this.FuelQuantity += fuel;
            }
            else
            {
                throw new Exception("Fuel must be a positive number");
            }
        }
    }
}
