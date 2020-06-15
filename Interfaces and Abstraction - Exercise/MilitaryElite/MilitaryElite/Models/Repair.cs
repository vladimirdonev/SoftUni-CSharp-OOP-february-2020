using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Repair : Irepair
    {

        public Repair(string partname, int hours)
        {
            this.Partname = partname;
            this.Hours = hours;
        }
        public string Partname { get; private set; }

        public int Hours { get; private set; }
        public override string ToString()
        {
            return $"Part Name: {this.Partname} Hours Worked: {this.Hours}";
        }
    }
}
