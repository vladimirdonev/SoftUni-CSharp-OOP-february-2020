using System;
using System.Collections.Generic;
using WildFarm.Factory;
using WildFarm.Models;

namespace WildFarm.Engine
{
    public class Build
    {
        private Dictionary<Animal, Food> Zoo;
        public Build()
        {
            Zoo = new Dictionary<Animal, Food>();
        }
            
        public void run()
        {
            int count = 0;
            string command = null;
            Animal animal = null;
            while (command != "End")
            {
                command = Console.ReadLine();
                if(command == "End")
                {
                    break;
                }
                string[] cmdargs = command.Split(" ");
                AnimalFactory animalFactory = new AnimalFactory();
                FoodFactory foodFactory = new FoodFactory();
                Food food = null;
                if(count % 2 == 0)
                {
                    string animaltype = cmdargs[0];
                    if (animaltype == "Hen" || animaltype == "Owl")
                    {
                        animal = ProduceBirds(cmdargs, animalFactory, animaltype);
                    }
                    else if(animaltype == "Mouse" || animaltype == "Dog")
                    {
                        animal = ProduceMammal(cmdargs, animalFactory, animaltype);
                    }
                    else if(animaltype == "Cat" || animaltype == "Tiger")
                    {
                        animal = ProduceFeline(cmdargs, animalFactory, animaltype);
                    }
                    
                }
                else
                {
                    string foodtype = cmdargs[0];
                    int Quantity = int.Parse(cmdargs[1]);
                    food = foodFactory.ProduceFood(foodtype, Quantity);
                    Zoo.Add(animal, food);
                    animal = null;
                }
                count++;
            }
            foreach (var item in Zoo)
            {
                try
                {
                    Console.WriteLine(item.Key.AnimalSound());
                    item.Key.Feed(item.Value);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var item in Zoo)
            {
                Console.WriteLine(item.Key.ToString());
            }
        }

        private static Animal ProduceFeline(string[] cmdargs, AnimalFactory animalFactory, string animaltype)
        {
            Animal animal;
            string name = cmdargs[1];
            double weight = double.Parse(cmdargs[2]);
            string livingregion = cmdargs[3];
            string breed = cmdargs[4];
            animal = animalFactory.ProduceFeline(animaltype, name, weight, livingregion, breed);
            return animal;
        }

        private static Animal ProduceMammal(string[] cmdargs, AnimalFactory animalFactory, string animaltype)
        {
            Animal animal;
            string name = cmdargs[1];
            double weight = double.Parse(cmdargs[2]);
            string livingregion = cmdargs[3];
            animal = animalFactory.ProduceMammal(animaltype, name, weight, livingregion);
            return animal;
        }

        private static Animal ProduceBirds(string[] cmdargs, AnimalFactory animalFactory, string animaltype)
        {
            Animal animal;
            string name = cmdargs[1];
            double weight = double.Parse(cmdargs[2]);
            double wingsize = double.Parse(cmdargs[3]);
            animal = animalFactory.ProduceBirds(animaltype, name, weight, wingsize);
            return animal;
        }
    }
}
