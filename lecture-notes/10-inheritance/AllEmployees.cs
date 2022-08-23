using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class AllEmployees
    {
        protected string firstName;
        protected string lastName;
        protected string email;

        public AllEmployees(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public void PrintFullName()
        {
        }
    }
}