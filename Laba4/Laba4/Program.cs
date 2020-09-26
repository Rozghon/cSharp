using System;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Size of massive: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] massive = new int[n];

            for(int i = 0; i < massive.Length; i++)
            {
                Console.WriteLine("Element " + i + ": ");
                n = Convert.ToInt32(Console.ReadLine());
                massive[i] = n;
            }

            Console.WriteLine("Input index of your element: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Previous element: " + massive[n - 1]);
            Console.WriteLine("Your element: " + massive[n]);
            Console.WriteLine("Next element: " + massive[n + 1]);
        }
    }
}
