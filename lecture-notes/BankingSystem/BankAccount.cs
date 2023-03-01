using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class BankAccount
    {
        private double balance;
        private List<Transaction> transactions;

        public BankAccount()
        {
            balance = 0;
            transactions = new List<Transaction>();
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                transactions.Add(new Transaction(amount, "Deposit"));
                Console.WriteLine($"Deposit successful. New balance is {balance}");
            }
            else Console.WriteLine("Invalid amount. Please try again");
        }

        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    transactions.Add(new Transaction(amount, "Withdrawal"));
                    Console.WriteLine($"Withdrawal successful. New balance is {balance}");
                }
                else Console.WriteLine("Insufficient balance");
            }
            else Console.WriteLine("Invalid amount. Please try again");
        }

        public void CheckBalance() => Console.WriteLine($"Current balance is {balance}");
    
        public void PrintTransactions()
        {
            Console.WriteLine("Transaction log:");
            foreach (Transaction t in transactions)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
