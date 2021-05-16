using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.IO;

namespace Laba18_1_4
{
    class Program
    {
        private static string path = @"G:\test";

        static void Main(string[] args)
        {
            if (Directory.Exists(path))
            {
                deleteDirectories(path);
            }

            DirectoryInfo directory = new DirectoryInfo(path);
            for (int i = 0; i < 100; i++)
            {
                directory.CreateSubdirectory($"Folder_{i}");
            }
            Console.WriteLine("Done");
            foreach (DirectoryInfo i in directory.GetDirectories())
            {
                i.Delete();
            }
            Console.WriteLine("Delete");

            int maximum = Int32.MaxValue;
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    directory.CreateSubdirectory($"Folder_{i}");
                    directory = new DirectoryInfo(directory.FullName + $"\\Folder_{i}");
                }
                catch (PathTooLongException)
                {
                    maximum = i + 1;
                    break;
                }
            }
            Console.WriteLine($"Maximum: {maximum}");
            deleteDirectories(path);
            Console.WriteLine("Deleted");
            maximum = 0;
            directory = new DirectoryInfo("G:\\");
            string stringName = "";
            while (true)
            {
                stringName += 1;
                try
                {
                    directory.CreateSubdirectory(stringName);
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine($"Maximum length: {maximum}");
                    break;
                }
                maximum++;
                Directory.Delete("G:\\" + stringName);
            }

            Console.ReadLine();
        }

        private static void deleteDirectories(string path)
        {
            if (Directory.GetDirectories(path).Length > 0)
            {
                foreach (string i in Directory.GetDirectories(path))
                {
                    deleteDirectories(i);
                }
            }
            Directory.Delete(path);
        }
    }
}
