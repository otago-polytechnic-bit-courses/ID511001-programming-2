using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exceptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string message = "Do you want to exit the application?";
            //string caption = "My Application”";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, caption, buttons);
            //if (result == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}


            int number1 = 10;
               
            try
            {
                int number2 = Convert.ToInt16(textBox1.Text); 
                int number3 = number1 / number2;
            }
            catch (FormatException f)
            {
                MessageBox.Show("An error has occurred: " + f.Message);
            }
            catch (DivideByZeroException d)
            {
                MessageBox.Show("An error has occurred: " + d.Message);
            }
            finally
            {
                MessageBox.Show("Put clean up code here");
            }

            MessageBox.Show("And now continuing with the program...");

        }
    }
}
