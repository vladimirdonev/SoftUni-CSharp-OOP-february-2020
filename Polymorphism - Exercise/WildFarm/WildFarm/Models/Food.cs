using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Food
    {
        public Food(int Quantity)
        {
            this.Quantity = Quantity;
        }

        public int Quantity { get; set; }
    }
}
