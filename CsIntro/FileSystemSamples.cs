using System;
using System.IO;

namespace CsIntro
{
    class FileSystemSamples
    {
        string workingPath = @"C:\test";
        string fileName = "MyFile.txt";

        public void CreateDirectory()
        {
            string directory = "MyDir";
            string directoryPath = Path.Combine(workingPath, directory);

            Console.WriteLine("Creating directory (if not exists) in {0}", directoryPath);
            Directory.CreateDirectory(directoryPath);
        }

        public void CreateFile()
        {
            string filePath = Path.Combine(workingPath, fileName);
            if (File.Exists(filePath) == false)
            {
                // We first check if it Exists because the Create metehod
                // overwrites the existing one if any!
                File.Create(filePath);
                Console.WriteLine("{0} was created", fileName);
            }
            else
            {
                Console.WriteLine("{0} already exists", fileName);
            }
        }

        public void WriteIntoFile()
        {
            string[] lines = new string[]
            {
                "This is the first line",
                "This is the second line",
                "This is the third line",
            };

            // As we don't want to override the file in this sample
            // we'll Append instead of Writing
            string filePath = Path.Combine(workingPath, fileName);
            if (File.Exists(filePath) == false)
            {
                this.CreateFile();
            }

            File.AppendAllLines(filePath, lines);
            Console.WriteLine("Contend added to {0}", filePath);
        }

        public void ReadLinesFromFile()
        {
            string filePath = Path.Combine(workingPath, fileName);
            var readLines = File.ReadAllLines(filePath);

            Console.WriteLine("This is the content of the file:");
            foreach (var line in readLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
