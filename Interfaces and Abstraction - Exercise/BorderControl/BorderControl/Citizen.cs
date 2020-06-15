using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICitizen,Ibirthable,IBuyer
    {
        private string name;

        private int age;
        
        private string id;
        
        private string birthday;
        
        private int food;

        public Citizen(string name,int age,string id,string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Id 
        { 
            get { return this.id; }
            set { this.id = value; } 
        }

        public string Birthday 
        { 
            get { return this.birthday; }
            set { this.birthday = value; } 
        }

        public int Food 
        {
            get { return this.food; }
            set { this.food = value; } 
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
