using MilitaryElite.Contracts;
using MilitaryElite.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Missions : IMission
    {
        public Missions(string missionname, string state)
        {
            this.CodeName = missionname;
            this.State = TryParce(state);
        }
        public string CodeName { get; private set; }

        public State State { get;  set; }
        private State TryParce(string state)
        {
            State state1;
            bool parced = Enum.TryParse<State>(state, out state1);
            if (!parced)
            {
                throw new Exception("Invaid mission state");
            }
            return state1;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
