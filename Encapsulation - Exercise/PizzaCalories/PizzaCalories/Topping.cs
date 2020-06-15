using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
		private double weight;
		private string toppingtype;
		private const double Minweight = 1;
		private const double Maxweight = 50;
		private const double caloriespergram = 2;

		public Topping(string toppingType, double weight)
		{
			ToppingType = toppingType;
			Weight = weight;
		}

		public string ToppingType
		{
			get { return toppingtype; }
			private set 
			{ 
				if(CheckToppingType(value) == false)
				{
					throw new Exception($"Cannot place {value} on top of your pizza.");
				}
				toppingtype = value; 
			}
		}

		public double Weight
		{
			get { return weight; }
			private set 
			{ 
				if(value < Minweight || value > Maxweight)
				{
					throw new Exception($"{this.ToppingType} weight should be in the range [1..50].");
				}
				weight = value; 
			}
		}

		private bool CheckToppingType(string value)
		{
			bool validtopping = false;
			switch (value.ToLower())
			{
				case "meat":
					validtopping = true;
					break;
				case "veggies":
					validtopping = true;
					break;
				case "cheese":
					validtopping = true;
					break;
				case "sauce":
					validtopping = true;
					break;
			}
			return validtopping;
		}

		public double TotalCalories => Totalcalories();
		private double Totalcalories()
		{
			double toppingcalories = 0;
			switch (this.ToppingType.ToLower())
			{
				case "meat":
					toppingcalories = 1.2;
					break;
				case "veggies":
					toppingcalories = 0.8;
					break;
				case "cheese":
					toppingcalories = 1.1;
					break;
				case "sauce":
					toppingcalories = 0.9;
					break;
			}
			double totalcalories = (caloriespergram * this.Weight) * toppingcalories;
			return totalcalories;
		}
	}
}
