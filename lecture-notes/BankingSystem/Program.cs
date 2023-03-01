using System;
using System.Collections.Generic;

namespace BankingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Customer customer = new Customer("Grayson Orr", "123 Hyde Street", "+64 271234567");
            customer.OpenAccount();
            customer.Deposit(1000);
            customer.Withdraw(500);
            customer.CheckBalance();
            customer.PrintTransactions();
        }
    }
}