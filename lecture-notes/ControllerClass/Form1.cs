using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerClass
{
    public partial class Form1 : Form
    {
        private const int TOTAL = 50;
        private const int RED_POSITION = 180;
        private const int BLUE_POSITION = 280;
        private const int PURPLE_POSITION = 380;

        private Graphics graphics;
        private Random random;
        private List<Molecule> molecules;

        public Form1()
        {
            InitializeComponent();

            graphics = CreateGraphics();
            random = new Random();

            molecules = new List<Molecule>();

            for (int i = 0; i < TOTAL; i++)
            {
                molecules.Add(new Molecule(new Point(RED_POSITION, RED_POSITION), Color.Red, graphics, random));
                molecules.Add(new Molecule(new Point(BLUE_POSITION, BLUE_POSITION), Color.Blue, graphics, random));
                molecules.Add(new Molecule(new Point(PURPLE_POSITION, PURPLE_POSITION), Color.Purple, graphics, random));
            }

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            foreach (Molecule molecule in molecules)
            {
                molecule.Draw();
            }
        }
    }
}
