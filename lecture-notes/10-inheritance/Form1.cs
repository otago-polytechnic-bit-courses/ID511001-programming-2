using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public partial class Form1 : Form
    {
        private FullTimeEmployee mabel;
        private FullTimeEmployee henry;
        private PartTimeEmployee roger;
        public Form1()
        {
            InitializeComponent();

            mabel = new FullTimeEmployee("Mabel", "Jones", "mabel.jones@gmail.com", 50000);
            henry = new FullTimeEmployee("Henry", "Smith", "henry.smith@gmail.com", 65000);
            roger = new PartTimeEmployee("Roger", "Brown", "roger.brown@gmail.com", 21.50);
        }
    }
}
