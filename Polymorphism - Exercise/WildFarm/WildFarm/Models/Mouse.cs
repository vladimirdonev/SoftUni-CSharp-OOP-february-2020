using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustumExeptions;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double Weight_Gain = 0.1;
        public Mouse(string name, double weight, string LivingRegion) 
            : base(name, weight, LivingRegion)
        {
        }

        public override string AnimalSound()
        {
            return "Squeak";
        }

        public override void Feed(Food food)
        {
            if(food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                double totalweightgain = Weight_Gain * (double)food.Quantity;
                this.Weight += totalweightgain;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                string msg = string.Format($"{WrongFoodExeption.Exp_Msg}", GetType().Name, food.GetType().Name);
                throw new Exception(msg);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.FoodEaten}]";
        }
    }
}
