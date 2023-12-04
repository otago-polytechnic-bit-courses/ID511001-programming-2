namespace Exemplar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Animal animal = new("Bob", 10); // Base class
            MessageBox.Show(animal.Name); // Base class's property

            Dog dog = new("Fido", 5, "Brown"); // Derived class
            MessageBox.Show(dog.Colour); // Base class's property
        }
    }
}