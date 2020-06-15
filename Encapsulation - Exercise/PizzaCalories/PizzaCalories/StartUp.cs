using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var CreatePizza = Console.ReadLine().Split(" ");
                var Pizza = new Pizza(CreatePizza[1]);
                var CreateDough = Console.ReadLine().Split(" ");
                var flour = CreateDough[1];
                var baking = CreateDough[2];
                var weight = double.Parse(CreateDough[3]);
                var Dough = new Dough(flour, baking, weight);
                Pizza.Dough = Dough;
                var command = string.Empty;
                while (command != "END")
                {
                    command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }
                    var splitedinput = command.Split(" ");
                    var topping = splitedinput[1].ToString();
                    var firstletter = topping[0].ToString();
                    var uppercase = firstletter.ToUpper();
                    topping = topping.Replace(firstletter, uppercase);
                    weight = double.Parse(splitedinput[2]);
                    var topping1 = new Topping(topping, weight);
                    Pizza.AddToppings(topping1);
                }
                Console.WriteLine(Pizza.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
