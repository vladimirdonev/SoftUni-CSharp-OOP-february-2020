using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Factory
{
    public class FoodFactory
    {
        public Food ProduceFood(string foodtype,int Quantity)
        {
            Food food = null;
            switch (foodtype)
            {
                case "Vegetable":
                    food = new Vegetable(Quantity);
                    break;
                case "Fruit":
                    food = new Fruit(Quantity);
                    break;
                case "Meat":
                    food = new Meat(Quantity);
                    break;
                case "Seeds":
                    food = new Seeds(Quantity);
                    break;

            }
            return food;
        }
    }
}
