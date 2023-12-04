using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplar
{
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    throw new Exception("Balance cannot be negative");
                _balance = value;
            }
        }
    }
}
