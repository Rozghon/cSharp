using System.Collections.Generic;
using System;

namespace Laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collector = new List<string>();
            bool isNewElement = true;

            while (isNewElement)
            {
                Console.WriteLine("Do you want to enter a new item? Y N");
                string inputString = Console.ReadLine();
                if (inputString == "Y" || inputString == "y")
                {
                    Console.WriteLine("Enter a new item: ");
                    collector.Add(Console.ReadLine());
                }
                else
                {
                    isNewElement = false;
                }
            }

            int[] massive = new int[collector.Count];
            for(int i = 0; i < collector.Count; i++)
            {
                massive[i] = collector[i].Length;
            }
            massiveElementCounter(massive);
        }

        static public void massiveElementCounter(int[] Array)
        {
            int Count = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length; j++)
                {
                    if (Array[i] == Array[j])
                        Count++;
                }
                Console.WriteLine("Element {0} occurs in the array {1} time", Array[i], Count);
                Count = 0;
            }
        }
    }
}