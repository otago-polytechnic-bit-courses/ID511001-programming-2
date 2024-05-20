namespace Exemplar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Space key pressed!");
            }

            //if (e.KeyCode == Keys.Space && e.Control)
            //{
            //    MessageBox.Show("Ctrl + Space key pressed!");
            //}

            //switch (e.KeyCode)
            //{
            //    case Keys.A:
            //        MessageBox.Show("A key pressed!");
            //        break;
            //    case Keys.B:
            //        MessageBox.Show("B key pressed!");
            //        break;
            //    case Keys.Right:
            //        pictureBox1.Left += 10;
            //        break;
            //    case Keys.Left:
            //        pictureBox1.Left -= 10;
            //        break;
            //    default:
            //        MessageBox.Show("Other key pressed!");
            //        break;
            //}
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Enter key released!");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
                MessageBox.Show("The 'a' key was pressed!");
            }
        }
    }
}