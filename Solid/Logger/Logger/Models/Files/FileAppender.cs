using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Files
{
    public class FileAppender : IAppender
    {

        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string Formatedmessage = File.Write(Layout, error);
            System.IO.File.WriteAllText(this.File.Path, Formatedmessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}, File size: {this.File.Size}";
        }
    }
}
