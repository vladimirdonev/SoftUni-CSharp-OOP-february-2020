using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public LieutenantGeneral(int id, string firstname, string lastname, decimal salary) 
            : base(id, firstname, lastname, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)this.privates;
        

        public void AddPrivates(ISoldier @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Privates:");
            foreach (var item in privates)
            {
                builder.AppendLine(item.ToString());
            }
            builder.ToString().TrimEnd();
            return $"{base.ToString() + Environment.NewLine}" +
                builder;
        }
    }
}
