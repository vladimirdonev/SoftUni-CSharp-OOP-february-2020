using System;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var phonenumbers = Console.ReadLine().Split(" ");
            var smartphone = new Smartphone();
            var stationaryphone = new StationaryPhone();
            for (int i = 0; i < phonenumbers.Length; i++)
            {
                var phonenumber = phonenumbers[i];
                if(phonenumber.Length == 7)
                {
                    Console.WriteLine(stationaryphone.Colling(phonenumber));
                }
                else if(phonenumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Colling(phonenumber));
                }
            }
            var sitestobrowse = Console.ReadLine().Split(" ");
            for (int i = 0; i < sitestobrowse.Length; i++)
            {
                var site = sitestobrowse[i].ToString();
                Console.WriteLine(smartphone.Browsing(site));
            }
        }
    }
}
