using System;
using WildFarm.CustumExeptions;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.3;

        public Cat(string name, double weight, string LivingRegion,string breed) 
            : base(name, weight, LivingRegion,breed)
        {
            
        }

        public override string AnimalSound()
        {
            return "Meow";
        }

        public override void Feed(Food food)
        {
            if(food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
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
