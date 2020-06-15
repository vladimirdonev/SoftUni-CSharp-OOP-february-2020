using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string name,string type)
        {
            BaseHero hero = null;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
            }
            if(hero == null)
            {
                throw new Exception("Invalid hero!");
            }
            return hero;
        }
    }
}
