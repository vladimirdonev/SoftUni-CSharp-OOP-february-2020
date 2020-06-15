using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeCalories = 1000;
        private const double grams = 250;
        private const decimal CakePrice = 5m;
        public Cake(string name) 
            : base(name, CakePrice, grams,CakeCalories)
        {
            

        }
        
    }
}
