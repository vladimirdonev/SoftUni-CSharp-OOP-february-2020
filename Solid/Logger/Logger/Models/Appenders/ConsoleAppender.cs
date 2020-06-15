using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout,Level level)
        {
            this.Layout = layout;
            this.Level = Level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;

            Level level = error.Level;

            string message = error.Message;

            string formatedmessage = string.Format(format, dateTime.ToString("M/dd/yyy H:mm:ss tt",CultureInfo.InvariantCulture),
                message, level.ToString());
            Console.WriteLine(formatedmessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";
        }
    }
}
