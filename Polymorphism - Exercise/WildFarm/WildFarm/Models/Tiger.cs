using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.CustumExeptions;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double WeightGain = 1;
        public Tiger(string name, double weight,string livingregion, string breed) 
            : base(name, weight,livingregion, breed)
        {
            
        }

        public override string AnimalSound()
        {
            return "ROAR!!!";
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
