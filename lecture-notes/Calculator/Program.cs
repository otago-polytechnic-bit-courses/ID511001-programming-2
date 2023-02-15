using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            double result = calculator.Start();
            Console.WriteLine("Result: " + result);
        }
    }
}
