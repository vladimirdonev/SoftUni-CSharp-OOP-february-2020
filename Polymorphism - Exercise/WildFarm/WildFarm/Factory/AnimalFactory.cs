using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Factory
{
    public class AnimalFactory
    {
        public Animal ProduceFeline(string type, string name, double weight,string livingregion,string breed)
        {
            Animal animal = null;
            if(type == "Cat")
            {
                animal = new Cat(name, weight, livingregion, breed);
                return animal;
            }
            else if(type == "Tiger")
            {
                animal = new Tiger(name, weight, livingregion, breed);
            }
            if (animal == null)
            {
                throw new Exception();
            }
            return animal;
        }
        public Animal ProduceBirds(string type, string name, double weight,double wingsize)
        {
            Animal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, wingsize);
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, wingsize);
            }
            if(animal == null)
            {
                throw new Exception();
            }
            return animal;

        }
        public Animal ProduceMammal(string type, string name,double weight,string livingregion)
        {
            Animal animal = null;
            if(type == "Dog")
            {
                animal = new Dog(name, weight, livingregion);
            }
            else if(type == "Mouse")
            {
                animal = new Mouse(name, weight, livingregion);
            }
            return animal;
        }
    }
}
