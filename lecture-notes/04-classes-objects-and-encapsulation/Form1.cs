namespace Exemplar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Dog myDog = new("Max", 3);
            MessageBox.Show(myDog.Bark()); // Output: "Woof woof!"

            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            MessageBox.Show($"Original array: {string.Join(", ", arr)}");
            Utils.BubbleSort(arr);
            MessageBox.Show($"Sorted array: {string.Join(", ", arr)}");

            BankAccount accountOne = new BankAccount();
            accountOne.Balance = 1000;
            MessageBox.Show($"Balance: {accountOne.Balance}");

            BankAccount accountTwo = new BankAccount();
            try
            {
                accountTwo.Balance = -1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}