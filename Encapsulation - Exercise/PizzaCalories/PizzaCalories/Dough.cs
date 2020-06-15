using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
		private string flour;
		private string bakingtechnique;
		private double weight;
		private const double MinWeight = 1;
		private const double MaxWeight = 200;
		private const double caloriespergram = 2;
		public Dough(string flour, string bakingTechnique, double weight)
		{
			Flour = flour;
			BakingTechnique = bakingTechnique;
			Weight = weight;
		}

		public string Flour
		{
			get { return flour; }
			private set 
			{
				if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
				{
					this.flour = value;
				}
				else
				{
					throw new Exception("Invalid type of dough.");
				}
			}
		}

		public string BakingTechnique
		{
			get { return bakingtechnique; }
			private set 
			{ 
				if(value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
				{
					this.bakingtechnique = value;
				}
				else
				{
					throw new Exception("Invalid baking technique");
				}
			}
		}

		public double Weight
		{
			get { return weight; }
			private set 
			{ 
				if(value < MinWeight || value > MaxWeight)
				{
					throw new Exception("Dough weight should be in the range [1..200].");
				}
				this.weight = value;
			}
		}

		public double TotalCalories => Totalcalories();
		
		private double Totalcalories()
		{
			var flourcalories = 0.0;
			var bakingtechniquecalories = 0.0;
			switch (this.Flour.ToLower())
			{
				case "white":
					flourcalories = 1.5;
					break;
				case "wholegrain":
					flourcalories = 1;
					break;
			}
			switch (this.BakingTechnique.ToLower())
			{
				case "crispy":
					bakingtechniquecalories = 0.9;
					break;
				case "chewy":
					bakingtechniquecalories = 1.1;
					break;
				case "homemade":
					bakingtechniquecalories = 1;
					break;

			}
			double Totalcalories = (caloriespergram * Weight) * flourcalories * bakingtechniquecalories;
			return Totalcalories;
		}
	}
}
