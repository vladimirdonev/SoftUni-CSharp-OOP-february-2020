using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
		private string name;

		private int age;
		
		private string group;

		private int food;
		public Rebel(string name,int age,string group)
		{
			this.Name = name;
			this.Age = age;
			this.Group = group;
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
		public string Group
		{
			get { return group; }
			set { group = value; }
		}

		public int Food 
		{
			get { return this.food; }
			set { this.food = value; } 
		}

		public void BuyFood()
		{
			this.Food += 5;
		}
	}
}
