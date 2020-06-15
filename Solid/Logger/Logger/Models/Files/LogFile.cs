using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Files
{
    public class LogFile : IFile
    {
        private IOManager iOManager;

        public LogFile(string folderName, string fileName)
        {
            iOManager = new IOManager(folderName, fileName);
            this.iOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => iOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout,IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;

            Level level = error.Level;

            string message = error.Message;

            string formatedmessage = string.Format(format, dateTime.ToString("M/dd/yyy H:mm:ss tt", CultureInfo.InvariantCulture),
                message, level.ToString());
            return formatedmessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);
            long size = text.Where(ch => char.IsLetter(ch)).Sum(ch => ch);
            return size;
        }
    }
}
