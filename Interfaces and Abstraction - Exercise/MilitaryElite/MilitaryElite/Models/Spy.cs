using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstname, string lastname,int codenumber) 
            : base(id, firstname, lastname)
        {
            this.CodeNumer = codenumber;
        }

        public int CodeNumer { get; private set; }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Code Number: {this.CodeNumer}";
        }
    }
}
