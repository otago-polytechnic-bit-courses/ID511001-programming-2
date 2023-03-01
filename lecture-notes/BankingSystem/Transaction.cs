using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Transaction
    {
        private double amount;
        private string type;

        public Transaction(double amount, string type)
        {
            this.amount = amount;
            this.type = type; // This can either be a withdraw or deposit
        }

        public override string ToString() => $"{type}: {amount}";
    }
}
