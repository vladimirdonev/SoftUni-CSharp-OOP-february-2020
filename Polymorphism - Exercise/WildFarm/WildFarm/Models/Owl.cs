using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustumExeptions;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AnimalSound()
        {
            return "Hoot Hoot";
        }

        public override void Feed(Food food)
        {
            if(food.GetType().Name == "Meat")
            {
                double totalgain = (double)food.Quantity * WeightGain;
                this.Weight += totalgain;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception(string.Format(WrongFoodExeption.Exp_Msg, GetType().Name, food.GetType().Name));
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.FoodEaten}]";
        }
    }
}
