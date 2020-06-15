using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DefoultPower = 80;

        public Druid(string name) 
            : base(name)
        {
            this.Power = DefoultPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
