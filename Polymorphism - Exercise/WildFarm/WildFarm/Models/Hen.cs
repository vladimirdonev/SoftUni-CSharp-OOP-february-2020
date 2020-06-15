using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double WeightGain = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AnimalSound()
        {
            return "Cluck";
        }

        public override void Feed(Food food)
        {
            double totalweightgain = (double)food.Quantity * WeightGain;
            this.Weight += totalweightgain;
            this.FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.FoodEaten}]";
        }
    }
}
