using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public Calc() { }
        
        public double Start()
        {
            Console.WriteLine("Enter the first number:");
            double firstNum = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double secondNum = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the operator (+, -, *, /):");
            string op = Console.ReadLine();

            double result = 0;

            switch (op)
            {
                case "+":
                    result = Add(firstNum, secondNum);
                    break;
                case "-":
                    result = Subtract(firstNum, secondNum);
                    break;
                case "*":
                    result = Multiply(firstNum, secondNum);
                    break;
                case "/":
                    result = Divide(firstNum, secondNum);
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }

            return result;
        }

        public double Add(double firstNum, double secondNum) => firstNum + secondNum;

        public double Subtract(double firstNum, double secondNum) => firstNum - secondNum;

        public double Multiply(double firstNum, double secondNum) => firstNum * secondNum;

        public double Divide(double firstNum, double secondNum)
        {
            if (secondNum == 0) return 0;
            else return firstNum / secondNum;
        }
    }
}
