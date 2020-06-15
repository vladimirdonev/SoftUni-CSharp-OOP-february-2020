using Logger.Core;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int appenderscount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppendersFactory factory = new AppendersFactory();
            
            for (int i = 0; i < appenderscount; i++)
            {
                var cmdargs = Console.ReadLine().Split(" ").ToArray();
                if(cmdargs.Length == 2)
                {
                    try
                    {
                        var appendertype = cmdargs[0];
                        var layouttype = cmdargs[1];
                        var level = "INFO";
                        IAppender appender = factory.ProduceAppender(appendertype, layouttype, level);
                        appenders.Add(appender)
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    
                }
                else if(cmdargs.Length == 3)
                {
                    try
                    {
                        var appendertype = cmdargs[0];
                        var layouttype = cmdargs[1];
                        var reportlevel = cmdargs[2];
                        IAppender appender = factory.ProduceAppender(appendertype, layouttype, reportlevel);
                        appenders.Add(appender);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    
                }
            }
            ILogger logger = new Logger.Models.Logger(appenders);
            Engine engine = new Engine(logger);
            engine.Run();
        }
    }
}
