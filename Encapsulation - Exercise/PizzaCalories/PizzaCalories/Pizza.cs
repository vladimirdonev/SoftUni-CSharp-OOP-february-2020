using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
	public class Pizza
	{
		private Dough dough;
		private List<Topping> toppings;
		private string name;
		private const int mintoppings = 1;
		public Pizza(string name)
		{
			this.Name = name;
			this.toppings = new List<Topping>();
		}

		public string Name
		{
			get { return name; }
			private set
			{
				if (value.Length < 1 || value.Length > 15)
				{
					throw new Exception("Pizza name should be between 1 and 15 symbols.");
				}
				name = value;
			}
		}

		public Dough Dough
		{
			get { return dough; }
			set { dough = value; }
		}
		public int Numberoftoppings => this.toppings.Count;

		public double TotalCalories => Totalcalories();

		public void AddToppings(Topping topping)
		{ 
			if(this.Numberoftoppings == 10)
			{
				throw new Exception("Number of toppings should be in range [0..10].");
			}
			this.toppings.Add(topping);
		}

		private double Totalcalories() 
		{
			double total = Dough.TotalCalories;
			for (int i = 0; i < toppings.Count; i++)
			{
				total += toppings[i].TotalCalories;
			}
			return total;
		}
		public override string ToString()
		{
			return $"{this.Name} - {this.TotalCalories:f2} Calories.";
		}
	}
}
