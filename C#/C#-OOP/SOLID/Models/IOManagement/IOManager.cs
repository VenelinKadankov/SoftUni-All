using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
            : this()
        {
            this.fileName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndPathExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory(); // статичен клас в С#, с метода вземаме текущата директория


            return currentDir;
        }
    }
}
