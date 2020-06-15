using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight,string LivingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = LivingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, ";
        }
    }
}
