using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var log in Appenders)
            {
                if (log.Level <= error.Level)
                {
                    log.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Logger info");
            foreach (var log in appenders)
            {
                builder.AppendLine(log.ToString());
            }
           return builder.ToString().TrimEnd();
        }
    }
}
