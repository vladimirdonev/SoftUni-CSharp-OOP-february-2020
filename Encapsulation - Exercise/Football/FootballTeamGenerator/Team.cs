using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
		private string name;
		private List<Player> numberofplayers;
		private double rating;
		public Team(string name)
		{
			this.Name = name;
			this.numberofplayers = new List<Player>();
		}

		public string Name
		{
			get { return name; }
			set 
			{
				name = value; 
			}
		}

		public double Rating => totalaverage();
		

		private double totalaverage()
		{
			double sum = 0;
			if(this.numberofplayers.Count == 0)
			{
				return 0;
			}
			for (int i = 0; i < numberofplayers.Count; i++)
			{
				sum += numberofplayers[i].Stats;
			}
			sum /= numberofplayers.Count;
			double roundedsum = Math.Round(sum);
			return roundedsum;
		}

		public void Addplayer(Player player)
		{
			this.numberofplayers.Add(player);
		}
		public void Removeplayer(string playername)
		{
			var player = numberofplayers.FirstOrDefault(x => x.Name == playername);
			if(player != null)
			{
				numberofplayers.Remove(player);
			}
			else
			{
				throw new Exception($"Player {playername} is not in {this.Name} team.");
			}
		}

	}
}
