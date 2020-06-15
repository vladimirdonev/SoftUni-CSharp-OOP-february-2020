using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class Smartphone : Icallable
    {
        public string Colling(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                return "Invalid number!";
            }
            string calling = $"Calling... {number}";
            return calling;
        }
        public string Browsing(string site)
        {
            if(site.Any(ch => char.IsDigit(ch)))
            {
                return "Invalid URL!";
            }
            string browsing = $"Browsing: {site}!";
            return browsing;
        }
    }
}
