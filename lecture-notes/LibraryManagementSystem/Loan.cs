using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Loan
    {
        private DateTime loanDate;
        private DateTime returnDate;

        public Loan(DateTime loanDate, DateTime returnDate)
        {
            this.loanDate = loanDate;
            this.returnDate = returnDate;
        }

        public int GetLoanDuration() => (ReturnDate - LoanDate).Days;

        public DateTime LoanDate { get => loanDate; set => loanDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
    }
}
