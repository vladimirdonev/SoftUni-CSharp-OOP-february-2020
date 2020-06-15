using Logger.Files;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppendersFactory
    {
        private LayoutFactory LayoutFactory;
        public AppendersFactory()
        {
            this.LayoutFactory = new LayoutFactory();
        }
        public IAppender ProduceAppender(string appendertype,string layoutstr,string levelstr)
        {
            Level level;
            bool hasparced = Enum.TryParse<Level>(levelstr,true, out level);
            if (!hasparced)
            {
                throw new Exception("Invalid level type!");
            }

            ILayout layout = this.LayoutFactory.ProduceLayout(layoutstr);

            IAppender appender;
            if(appendertype == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if(appendertype == "FileAppender")
            {
                IFile file = new LogFile("\\data\\", "logs.txt");
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");
            }
            return appender;
        }
    }
}
