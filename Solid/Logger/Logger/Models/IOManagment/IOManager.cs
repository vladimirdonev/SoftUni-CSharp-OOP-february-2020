using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.IOManagment
{
    public class IOManager : IIOManager
    {
        private string currentpath { get; set; }

        private string foldername { get; set; }

        private string filename { get; set; }

        private IOManager()
        {
            this.currentpath = this.GetCurrentDirectory();
        }

        public IOManager(string foldername,string filename)
            :this()
        {
            this.foldername = foldername;
            this.filename = filename;
        }

        public string CurrentDirectoryPath => this.currentpath + this.foldername;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.filename;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath,string.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentdir = Directory.GetCurrentDirectory();

            return currentdir;
        }
    }
}
