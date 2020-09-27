using System;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, raz, curRaz;
            bool isChange = false;

            Console.WriteLine("Rows: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Columns: ");
            m = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //1
            for(int i = 0; i < n; i++)
            {
                isChange = false;
                curRaz = matrix[i, 1] - matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    raz = matrix[i, j] - matrix[i, j - 1];
                    if( raz != curRaz)
                    {
                        j = m;
                        isChange = false;
                    }
                    else
                    {
                        isChange = true;
                    }
                }
                if(isChange)
                {
                    Console.WriteLine("Row " + i + "is grow or fall;");
                }
            }

            //2
            for (int i = 0; i < n; i++)
            {
                isChange = false;
                curRaz = matrix[1, i] - matrix[0, i];
                for (int j = 1; j < m; j++)
                {
                    raz = matrix[j, i] - matrix[j - 1, i];
                    if (raz != curRaz)
                    {
                        j = m;
                        isChange = false;
                    }
                    else
                    {
                        isChange = true;
                    }
                }
                if (isChange)
                {
                    Console.WriteLine("Column " + i + "is grow or fall;");
                }
            }
        }
    }
}
