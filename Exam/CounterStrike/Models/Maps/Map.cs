using System;
using System.Collections.Generic;

using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var Terrorist = new List<IPlayer>();
            var CounterTerrorist = new List<IPlayer>();
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    Terrorist.Add(player);
                }
                else if(player.GetType().Name == "CounterTerrorist")
                {
                    CounterTerrorist.Add(player);
                }
            }
            var win = string.Empty;
            while (true)
            {
                var terroristalive = 0;
                var counterterroristalive = 0;
                for (int i = 0; i < CounterTerrorist.Count; i++)
                {
                    if(Terrorist[i].IsAlive == true)
                    {
                        if(CounterTerrorist[i].IsAlive == true)
                        {
                            CounterTerrorist[i].TakeDamage(Terrorist[i].Gun.Fire());
                        }
                    }
                }
                for (int i = 0; i < Terrorist.Count; i++)
                {
                    if (CounterTerrorist[i].IsAlive == true)
                    {
                        if(Terrorist[i].IsAlive == true)
                        {
                            Terrorist[i].TakeDamage(CounterTerrorist[i].Gun.Fire());
                        }
                    }
                }
                for (int i = 0; i < Terrorist.Count; i++)
                {
                    if(Terrorist[i].IsAlive == true)
                    {
                        terroristalive++;
                    }
                }
                for (int i = 0; i < CounterTerrorist.Count; i++)
                {
                    if(CounterTerrorist[i].IsAlive == true)
                    {
                        counterterroristalive++;
                    }
                }
                if(terroristalive == 0)
                {
                    win = "Counter Terrorist wins!";
                    break;
                }
                else if(counterterroristalive == 0)
                {
                    win = "Terrorist wins!";
                    break;
                }
            }
            return win;
        }
    }
}
