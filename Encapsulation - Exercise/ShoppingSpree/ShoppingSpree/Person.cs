using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;
        public Person(string name,decimal money)
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Money 
        {
            get {return this.money; }
            private set
            {
                if(value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }
            } 
        }
        public void AddProduct(Product product)
        {
            bag.Add(product);

            this.Money -= product.Cost;
        }
        public bool Haveproduct(Person person)
        {
            if(person.bag.Count > 0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.name} - {string.Join(", ", bag)}");
            return sb.ToString().TrimEnd();
        }
    }
}
