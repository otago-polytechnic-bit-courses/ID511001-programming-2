using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calc calculator = new Calc();
            double result = calculator.Start();
            Console.WriteLine("Result: " + result);
        }
    }
}
