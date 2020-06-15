using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name,decimal price)
        {
            this.Name = name;
            this.Cost = price;
        }
        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public decimal Cost 
        {
            get { return this.cost; }
            private set 
            {
                if(value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.cost = value; 
            }
        }
        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}
