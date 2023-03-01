using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Customer
    {
        private const string NO_BANK_ACCOUNT = "You do not have a bank account. Please open a bank account";

        private string name;
        private string address;
        private string mobileNumber;
        private BankAccount? bankAccount;

        public Customer(string name, string address, string mobileNumber)
        {
            this.name = name;
            this.address = address;
            this.mobileNumber = mobileNumber;
            bankAccount = null; // Bank account is not created
        }

        public void OpenAccount()
        {
            // If the bank account is not created
            if (bankAccount == null)
            {
                bankAccount = new BankAccount(); // Create the bank account
                Console.WriteLine("Bank account successfully opened");
            }
            else Console.WriteLine("Bank account already opened");
        }

        public void Deposit(double amount)
        {
            // If the bank account is created
            if (bankAccount != null) bankAccount.Deposit(amount);
            else Console.WriteLine(NO_BANK_ACCOUNT);
        }

        public void Withdraw(double amount)
        {
            // If the bank account is created
            if (bankAccount != null) bankAccount.Withdraw(amount);
            else Console.WriteLine(NO_BANK_ACCOUNT);
        }

        public void CheckBalance()
        {
            // If the bank account is created
            if (bankAccount != null) bankAccount.CheckBalance();
            else Console.WriteLine(NO_BANK_ACCOUNT);
        }

        public void PrintTransactions()
        {
            // If the bank account is created
            if (bankAccount != null) bankAccount.PrintTransactions();
            else Console.WriteLine(NO_BANK_ACCOUNT);
        }
    }
}
