using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Linq;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private IError error;
        private ErrorFactory Factory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            Factory = new ErrorFactory();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();
                if(input[0] == "END")
                {
                    break;
                }

                string level = input[0];
                string time = input[1];
                string message = input[2];
                try
                {
                    error = Factory.ProduceError(time, message, level);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
            Console.WriteLine(this.logger);
        }
    }
}
