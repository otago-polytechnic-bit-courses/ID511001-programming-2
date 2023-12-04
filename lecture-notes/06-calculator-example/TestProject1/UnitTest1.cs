using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calc calculator = new Calc();
            double firstNum = 0;
            double secondNum = 10;
            double expectedSum = 12.0;

            double actualSum = calculator.Divide(firstNum, secondNum);
            Assert.AreEqual("Cannot divide by zero", actualSum);

        }
    }
}