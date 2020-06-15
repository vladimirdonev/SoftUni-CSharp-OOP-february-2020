using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var citizens = new List<Citizen>();
            var rebels = new List<Rebel>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                if(input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebels.Add(rebel);
                }
                else
                {
                    var Citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    citizens.Add(Citizen);
                }
            }
            string name = Console.ReadLine();
            var Totalfood = new HashSet<IBuyer>();
            while(name != "End")
            {
                if(name == "End")
                {
                    break;
                }
                var citizen = citizens.FirstOrDefault(x => x.Name == name);
                var rebel = rebels.FirstOrDefault(x => x.Name == name);
                if (citizen != null)
                {
                    citizen.BuyFood();
                    Totalfood.Add(citizen);
                }
                else if(rebel != null)
                {
                    rebel.BuyFood();
                    Totalfood.Add(rebel);
                }
                name = Console.ReadLine();
            }
            int food = 0;
            foreach (var item in Totalfood)
            {
                food += item.Food;
            }
            Console.WriteLine(food);
        }
    }
}
