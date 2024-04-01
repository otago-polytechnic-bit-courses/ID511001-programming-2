namespace Exemplar
{
    public partial class Form1 : Form
    {
        enum EDays { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

        public Form1()
        {
            InitializeComponent();

            Circle circle = new Circle(5.0);
            MessageBox.Show(circle.Area().ToString());

            Enum.TryParse("Monday", out EDays today);

            if (today == EDays.Friday)
            {
                MessageBox.Show("It is Friday!");
            }
            else
            {
                MessageBox.Show("It is not Friday!");
            }
        }
    }
}