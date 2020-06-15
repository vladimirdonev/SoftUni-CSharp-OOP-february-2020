using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
		private int stats;
		private string name;
		private int endurance;
		private int sprint;
		private int dribble;
		private int passing;
		private int shooting;

		public Player(string name, int endurance, int shooting, int sprint, int dribble, int passing)
		{
			Name = name;
			Endurance = endurance;
			Shooting = shooting;
			Sprint = sprint;
			Dribble = dribble;
			Passing = passing;
		}

		public string Name
		{
			get { return name; }
			set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("A name should not be empty.");
				}
				name = value; 
			}
		}


		public double Stats => averagestat();

		private int Endurance
		{
			get { return endurance; }
			set 
			{ 
				if(Checkvalue(value) == false)
				{
					throw new Exception("Endurance should be between 0 and 100.");
				}
				endurance = value; 
			}
		}

		private int Shooting
		{
			get { return shooting; }
			set 
			{ 
				if(Checkvalue(value) == false)
				{
					throw new Exception("Shooting should be between 0 and 100.");
				}
				shooting = value; 
			}
		}

		private int Sprint
		{
			get { return sprint; }
			set 
			{
				if (Checkvalue(value) == false)
				{
					throw new Exception("Sprint should be between 0 and 100.");
				}
				sprint = value; 
			}
		}
		
		private int Dribble
		{
			get { return dribble; }
			set 
			{
				if (Checkvalue(value) == false)
				{
					throw new Exception("Dribble should be between 0 and 100.");
				}
				dribble = value; 
			}
		}

		private int Passing
		{
			get { return passing; }
			set 
			{
				if (Checkvalue(value) == false)
				{
					throw new Exception("Passing should be between 0 and 100.");
				}
				passing = value; 
			}
		}

		private bool Checkvalue(int value)
		{
			if (value >= 0 && value < 100)
			{
				return true;
			}
			return false;
		}

		private double averagestat()
		{
			double totalstat = ((double)this.Sprint + (double)this.Dribble + (double)this.Endurance + (double)this.Passing + (double)this.Shooting) / 5;
			double rounded = Math.Round(totalstat);
			return rounded;
		}


	}
}
