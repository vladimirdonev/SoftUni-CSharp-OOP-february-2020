using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<Irepair> repairs;

        public Engineer(int id, string firstname, string lastname, decimal salary, string corps) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.repairs = new List<Irepair>();
        }

        public IReadOnlyCollection<Irepair> Repairs => (IReadOnlyCollection<Irepair>)this.repairs;

        public void AddRepair(Irepair repair)
        {
            this.repairs.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Repairs:");
            foreach (var item in repairs)
            {
                builder.AppendLine(item.ToString());
            }
            builder.ToString().TrimEnd();
            return base.ToString() + builder;
        }
    }
}
