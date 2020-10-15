using System;

namespace Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 3, 4, 5, 8 }; 
            string inp;
            
            inp = Console.ReadLine();
            Console.WriteLine(Reverse(inp));
            Console.WriteLine(ReverseRecursion(inp));
            Console.WriteLine(ReverseArray(ref array));
        }

        static string Reverse(string originalString)
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

        static string ReverseRecursion(string s)
        {
            if (s.Length == 1)
                return s;

            return ReverseRecursion(s.Substring(1)) + s[0];
        }

        static int[] ReverseArray(ref int[] arr)
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
    }
}
