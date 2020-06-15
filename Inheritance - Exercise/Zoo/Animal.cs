using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        private string name { get; set; }
        public Animal(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
