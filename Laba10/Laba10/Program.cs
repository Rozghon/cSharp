using System;

namespace Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 123.123d;
            int[] array = { 1, 3, 4, 5, 8 };
            string inp;

            inp = Console.ReadLine();

            Console.WriteLine(number.Reverse());

            Console.WriteLine(inp.Reverse());

            array.ReverseArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();
            array.MinMaxReverse();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }

    public static class StringExtension
    {
        public static string Reverse(this string originalString)
        {
            char[] reversedCharArray = new char[originalString.Length];
            int i = 0;
            int j = originalString.Length - 1;
            while (i <= j)
            {
                reversedCharArray[i] = originalString[j];
                reversedCharArray[j] = originalString[i];
                i++; j--;
            }
            return new string(reversedCharArray);
        }
    }

    public static class IntExtension
    {
        public static int[] ReverseArray(this int[] arr)
        {
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
            return arr;
        }

        public static int[] MinMaxReverse(this int[] arr)
        {
            int min = arr[0];
            int max = arr[0];

            int minId = 0;
            int maxId = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == min)
                {
                    minId = i;
                }
                if (arr[i] == max)
                {
                    maxId = i;
                }
            }

            arr[minId] = max;
            arr[maxId] = min;

            return arr;
        }
    }

    public static class DoubleExtension
    {
        public static double Reverse(this double source)
        {
            double distance = 0;
            int decPoint = 0;

            while (source - (long)source > 0)
            {
                source = source * 10;
                decPoint++;
            }

            int totalDigits = 0;

            while (source > 0)
            {
                int d = (int)source % 10;
                distance = distance * 10 + d;
                source = (long)(source / 10);
                totalDigits++;
            }

            if (decPoint > 0)
            {
                int reversedDecPoint = totalDigits - decPoint;
                for (int i = 0; i < reversedDecPoint; i++) distance = distance / 10;
            }

            return distance;
        }
    }
}