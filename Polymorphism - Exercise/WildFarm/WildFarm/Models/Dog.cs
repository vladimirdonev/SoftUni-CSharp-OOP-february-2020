using System;
using WildFarm.CustumExeptions;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double WeightGain = 0.4;
        public Dog(string name, double weight, string LivingRegion) 
            : base(name, weight, LivingRegion)
        {
        }

        public override string AnimalSound()
        {
            return "Woof!";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                double totalweightgain = (double)food.Quantity * WeightGain;
                this.Weight += totalweightgain;
                this.FoodEaten += food.Quantity;
            }
            else throw new Exception(string.Format(WrongFoodExeption.Exp_Msg, GetType().Name, food.GetType().Name));
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.FoodEaten}]";
        }
    }
}
