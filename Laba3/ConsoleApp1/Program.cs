using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] area = new int[8, 8];
            int[] currentPosition = new int[2];
            int[] nextPosition = new int[2];

            bool isCanMove = false;

            Console.WriteLine("Input current position X: ");
            currentPosition[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input current position Y: ");
            currentPosition[1] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input next position X: ");
            nextPosition[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input next position Y: ");
            nextPosition[1] = Convert.ToInt32(Console.ReadLine());

            if(nextPosition[0] == currentPosition[0] - 1 &&
                nextPosition[1] == currentPosition[1] + 2)
            {
                isCanMove = true;
            }
            else if(nextPosition[0] == currentPosition[0] + 1 &&
                nextPosition[1] == currentPosition[1] + 2)
            {
                isCanMove = true;
            }
            else if(nextPosition[0] == currentPosition[0] + 2 &&
                nextPosition[1] == currentPosition[1] + 1)
            {
                isCanMove = true;
            }
            else if (nextPosition[0] == currentPosition[0] + 2 &&
                nextPosition[1] == currentPosition[1] - 1)
            {
                isCanMove = true;
            }
            else if (nextPosition[0] == currentPosition[0] - 1 &&
                nextPosition[1] == currentPosition[1] - 2)
            {
                isCanMove = true;
            }
            else if (nextPosition[0] == currentPosition[0] + 1 &&
                nextPosition[1] == currentPosition[1] - 2)
            {
                isCanMove = true;
            }
            else if (nextPosition[0] == currentPosition[0] - 2 &&
                nextPosition[1] == currentPosition[1] + 1)
            {
                isCanMove = true;
            }
            else if (nextPosition[0] == currentPosition[0] - 2 &&
                nextPosition[1] == currentPosition[1] - 1)
            {
                isCanMove = true;
            }
            else
            {
                isCanMove = false;
            }

            Console.WriteLine(isCanMove);
        }
    }
}