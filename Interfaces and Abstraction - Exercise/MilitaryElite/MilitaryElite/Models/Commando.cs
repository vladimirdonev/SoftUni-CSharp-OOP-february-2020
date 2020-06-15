using MilitaryElite.Contracts;
using MilitaryElite.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(int id, string firstname, string lastname, decimal salary, string corps) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public void CompleteMission()
        {
            foreach (var mission in this.missions)
            {
                if(mission.State == State.Finished)
                {
                    throw new Exception("Mission already completed!");
                }
                mission.State = State.Finished;
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Mission:");
            foreach (var item in this.missions)
            {
                builder.AppendLine(item.ToString());
            }
            builder.ToString().TrimEnd();
            return base.ToString() + builder;
        }
    }
}
