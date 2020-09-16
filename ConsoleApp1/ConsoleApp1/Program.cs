using System;
using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int S = 0; int a, b;

            for (int i = 0; i < 3; i++)
            {
                b = i + 1;
                Console.WriteLine("Введiть опiр " + b + "-го елемента:");
                a = Convert.ToInt32(Console.ReadLine());
                S += a;
            }

            Console.WriteLine("Опiр: " + S);
        }
    }
}