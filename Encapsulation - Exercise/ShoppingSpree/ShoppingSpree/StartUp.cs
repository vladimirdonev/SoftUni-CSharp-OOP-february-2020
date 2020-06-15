using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = null;
            int count = 0;
            var persons = new List<Person>();
            var products = new List<Product>();
            try
            {


                while (count <= 1)
                {

                    command = Console.ReadLine();
                    string[] splitedinput = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < splitedinput.Length; i++)
                    {
                        var tokens = splitedinput[i].Split("=");
                        var name = tokens[0];
                        var money = decimal.Parse(tokens[1]);
                        if (count == 0)
                        {
                            var person = new Person(name, money);
                            persons.Add(person);
                        }
                        else
                        {
                            var product = new Product(name, money);
                            products.Add(product);
                        }

                    }
                    count++;

                }


                while (command != "END")
                {
                    command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }
                    var splitedinput = command.Split(" ");
                    var personname = splitedinput[0];
                    var productname = splitedinput[1];
                    var person = persons.FirstOrDefault(x => x.Name == personname);
                    var product = products.FirstOrDefault(x => x.Name == productname);
                    if (person.Money < product.Cost)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        for (int i = 0; i < persons.Count; i++)
                        {
                            if (persons[i].Name == person.Name)
                            {
                                persons[i].AddProduct(product);
                                Console.WriteLine($"{person.Name} bought {product.Name}");
                            }
                        }
                    }
                }
                foreach (var person in persons)
                {
                    if (person.Haveproduct(person) == false)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine(person.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
