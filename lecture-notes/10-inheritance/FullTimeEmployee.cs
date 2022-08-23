using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class FullTimeEmployee: AllEmployees
    {
        private double salary;

        public FullTimeEmployee(string firstName, string lastName, string email, double salary)
            : base(firstName, lastName, email)
        {
            this.salary = salary;
        }

        public void CalculateRedundancy()
        {
        }
    }
}
