using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        private VehicleFactory vehicleFactory;
        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = Producevehicle();
            Vehicle truck = Producevehicle();
            Vehicle bus = Producevehicle();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] cmdargs = Console.ReadLine().Split(" ");
                    var command = cmdargs[0];
                    var vehicletype = cmdargs[1];
                    var distance = double.Parse(cmdargs[2]);

                    if (command == "Drive")
                    {
                        if (vehicletype == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicletype == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if(vehicletype == "Bus")
                        {
                            Bus bus1 = (Bus)bus;
                            Console.WriteLine(bus1.DrivePeople(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicletype == "Car")
                        {
                            car.Refuel(distance);
                        }
                        else if (vehicletype == "Truck")
                        {
                            truck.Refuel(distance);
                        }
                        else if(vehicletype == "Bus")
                        {
                            bus.Refuel(distance);
                        }
                    }
                    else if(command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }


        private Vehicle Producevehicle()
        {
            string[] vehicleargs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string type = vehicleargs[0];
            double fuelquantity = double.Parse(vehicleargs[1]);
            double fuelconsumption = double.Parse(vehicleargs[2]);
            double tankcapacity = double.Parse(vehicleargs[3]);
            Vehicle vehicle = vehicleFactory.ProduceVehicle(type, fuelquantity, fuelconsumption,tankcapacity);
            return vehicle;
        }
    }
}
