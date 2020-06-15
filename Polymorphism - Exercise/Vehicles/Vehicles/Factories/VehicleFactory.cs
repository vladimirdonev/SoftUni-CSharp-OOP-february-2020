using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type,double fuelquantity,double fuelconsumption,double tankcapacity)
        {
            Vehicle vehicle = null;
            if(type == "Car")
            {
                vehicle = new Car(fuelquantity, fuelconsumption,tankcapacity);
                return vehicle;
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(fuelquantity, fuelconsumption,tankcapacity);
                return vehicle;
            }
            else if(type == "Bus")
            {
                vehicle = new Bus(fuelquantity, fuelconsumption, tankcapacity);
            }
            if(vehicle == null)
            {
                throw new Exception();
            }
            return vehicle;
        }
    }
}
