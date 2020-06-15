using MilitaryElite.Contracts;
using MilitaryElite.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstname, string lastname, decimal salary, string corps) 
            : base(id, firstname, lastname, salary)
        {
            this.Corps = this.TryParce(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParce(string corps)
        {
            Corps corps1;
            bool parced = Enum.TryParse<Corps>(corps, out corps1);
            if (!parced)
            {
                throw new Exception("Invalid corps");
            }
            return corps1;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary}{Environment.NewLine}"
                + $"Corps: {this.Corps}";
        }
    }
}
