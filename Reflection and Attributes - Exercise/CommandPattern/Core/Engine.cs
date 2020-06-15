﻿using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                try
                {
                    string result = this.commandInterpreter.Read(command);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

        }
    }
}
