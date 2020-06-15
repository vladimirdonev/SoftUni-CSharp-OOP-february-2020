using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Command_PostFix = "Command";

        public CommandInterpreter()
        {

        }

        public string Read(string args)
        {
            string[] input = args.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandname = input[0] + Command_PostFix;

            string[] cmdargs = input.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type CommandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandname.ToLower());

            if(CommandType == null)
            {
                throw new ArgumentException("Ivalid command type!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(CommandType);

            string result = command.Execute(cmdargs);

            return result;
        }
    }
}
