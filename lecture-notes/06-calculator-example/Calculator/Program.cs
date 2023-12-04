using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int sum = 0;

            for (int i = 1; i <= n; i++)
                sum += i;

            while (n > 0)
            {
                Console.WriteLine(n);
                n--;
            }
        }
    }
}
