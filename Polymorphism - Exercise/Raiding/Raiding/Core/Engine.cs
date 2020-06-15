using Raiding.Factory;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine
    {
        private ICollection<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            HeroFactory factory = new HeroFactory();
            BaseHero hero = null;
            int count = 0;
            while (count < n)
            {
                var heroname = Console.ReadLine();
                var herotype = Console.ReadLine();
                    try
                    {
                        hero = factory.CreateHero(heroname,herotype);
                        heroes.Add(hero);
                        count++;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                    
                
            }
            int bosshealth = int.Parse(Console.ReadLine());
            int totalpower = 0;
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
                totalpower += item.Power;
            }
            if(totalpower >= bosshealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
