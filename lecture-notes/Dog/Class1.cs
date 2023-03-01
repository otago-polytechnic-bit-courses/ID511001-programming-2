using System;
using System.Collections.Generic;

class BankAccount
{
    private double balance;
    private List<Transaction> transactions;

    public BankAccount()
    {
        balance = 0.0;
        transactions = new List<Transaction>();
    }

    public double GetBalance()
    {
        return balance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
        transactions.Add(new Transaction(amount, "Deposit"));
    }

    public void Withdraw(double amount)
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient funds!");
            return;
        }

        balance -= amount;
        transactions.Add(new Transaction(amount, "Withdrawal"));
    }

    public void PrintTransactions()
    {
        Console.WriteLine("\nTransaction History:\n");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine(transaction.ToString());
        }
    }
}

class Customer
{
    private string name;
    private string address;
    private string mobileNumber;
    private BankAccount account;

    public Customer(string name, string address, string mobileNumber)
    {
        this.name = name;
        this.address = address;
        this.mobileNumber = mobileNumber;
        account = new BankAccount();
    }

    public void OpenAccount()
    {
        Console.WriteLine("Account opened successfully!");
    }

    public void Deposit(double amount)
    {
        account.Deposit(amount);
    }

    public void Withdraw(double amount)
    {
        account.Withdraw(amount);
    }

    public void GetBalance()
    {
        Console.WriteLine($"Your current balance is: {account.GetBalance()}");
    }

    public void PrintTransactions()
    {
        account.PrintTransactions();
    }
}

class Transaction
{
    private double amount;
    private string type;

    public Transaction(double amount, string type)
    {
        this.amount = amount;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{type}: {amount}";
    }
}

class Program
{
    static void Main()
    {
        Customer customer = new Customer("John Doe", "123 Main St", "555-555-5555");
        customer.OpenAccount();
        customer.Deposit(1000.0);
        customer.Withdraw(500.0);
        customer.Deposit(2000.0);
        customer.GetBalance();
        customer.PrintTransactions();
    }
}
