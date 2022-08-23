using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class PartTimeEmployee: AllEmployees
    {
        private double hourlyRate;

        public PartTimeEmployee(string firstName, string lastName, string email, double hourlyRate)
            : base(firstName, lastName, email)
        {
            this.hourlyRate = hourlyRate;
        }

        public double CalculateBonus()
        {
            return 0;
        }
    }
}
