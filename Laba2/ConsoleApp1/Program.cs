using System;
using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double nn, nk, S = 1;

            nn = Convert.ToDouble(Console.ReadLine());
            nk = Convert.ToDouble(Console.ReadLine());

            for (int i = Convert.ToInt32(nn); i <= Convert.ToInt32(nk); i++)
            {
                S *= (Math.Pow(i, 2) - (Math.Pow(-1, (Math.Pow(i, 2) + 1) * i))) / (Math.Pow(i, 2) + 2);
            }

            Console.WriteLine(S);
        }
}