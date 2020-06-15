using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {

        protected Feline(string name, double weight, string LivingRegion,string breed) 
            : base(name, weight,LivingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, ";
        }
    }
}
