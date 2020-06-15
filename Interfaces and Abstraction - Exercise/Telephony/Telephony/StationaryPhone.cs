using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : Icallable
    {
        public string Colling(string number)
        {
            if(!number.All(ch => char.IsDigit(ch)))
            {
                return "Invalid number!";
            }
            string Dialing = $"Dialing... {number}";
            return Dialing;
        }
    }
}
