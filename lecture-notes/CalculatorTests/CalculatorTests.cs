using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddShouldReturnCorrectSum()
        {
            Calc calculator = new Calc();
            int x = 2;
            int y = 3;
            int expected = 5;

            int actual = calculator.Add(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}