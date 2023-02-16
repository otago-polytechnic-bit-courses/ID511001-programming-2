# 04: Debugging

Debugging is the process of identifying and resolving errors (also called bugs) in your code. When you write code, it is not uncommon to make mistakes, such as syntax errors, logical errors, or runtime errors. Debugging is the process of finding and fixing these errors so that your code runs correctly.

There are several techniques and tools that can be used for debugging code, including:

* Using the **Visual Studio Debugger**: **Visual Studio** provides a built-in debugger that allows you to step through your code line by line, set breakpoints, view the values of variables, and more.
* Using the **Console**: You can use the `Console` class to print out the values of variables and other information to the console while your program is running. This can help you to understand what your code is doing and to identify errors.
* Using the **Immediate Window**: The **Immediate Window** allows you to execute code and check the values of variables while your program is in break mode.
* Using the **Watch Window**: The **Watch Window** allows you to see the value of a variable or an expression while your program is running.
* Using the **Call Stack Window**: The **Call Stack Window** allows you to see the sequence of method calls that led to the current point in the execution of your program.
* Using the **Output Window**: The **Output Window** allows you to see the debug messages that you write to the console.

When you find an error in your code, you can use these tools and techniques to understand what is causing the error, and to fix it. Once you have fixed the error, you can then test your code again to make sure that it works correctly.

Debugging is an important part of the development process and it can save a lot of time and effort by identifying and resolving errors early on.

# 04: Unit Testing

Unit testing is the process of testing individual units of code, such as methods or classes, in isolation from the rest of the program. The goal of unit testing is to ensure that each unit of code behaves correctly and that it meets the requirements specified for it. Unit tests are usually automated, which means that they can be run automatically and repeatedly without human intervention.

Unit tests are typically written using a unit testing framework, such as **MSTest**, **xUnit**, or **NUnit**, which provides a set of tools and libraries for creating, running, and managing unit tests. The tests are usually written using a test-driven development (TDD) approach, where the tests are written before the actual implementation of the code.

Here's an example of a simple unit test using **MSTest**:

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void AddShouldReturnCorrectSum()
        {
            Calc calculator = new Calc();
            double firstNum = 2.0;
            double secondNum = 3.0;
            double expected = 5.0;
            double actual = calculator.Add(firstNum, secondNum);
            Assert.AreEqual(expected, actual);
        }
    }
}
```

In this example, the test class `CalcTests` has one test method `AddShouldReturnCorrectSum()`. This method uses the `Assert.AreEqual()` method to check that the result of the `Add()` method of the `Calculator` class is equal to the expected value. The test method is decorated with the `[TestMethod]` attribute, which tells the unit testing framework that this method is a test.

When the test is run, the unit testing framework will execute the `AddShouldReturnCorrectSum()` method and check the assertion. If the assertion passes, the test is considered to have passed. If the assertion fails, the test is considered to have failed and the framework will provide a detailed error message.

Unit testing is an important practice in software development, as it helps to ensure that the code is working correctly, it helps to detect and fix bugs early, and it allows for more confident and safe changes and refactoring of the code. It also helps to increase the quality and maintainability of the code.

Let us look at how to create a test class. Open the `Calculator` project in **Visual Studio**. It can be found in the `04-calculator-example` directory. Right-click on `Solution 'Calculator'` in the **Solution Explorer**. Click on **Add** then **New Project...**. You will be presented with a **Add a new project** window. Choose the **MSTest Test Project** template, and name it `CalculatorTests`. Once you have created the project, you will see the following:

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
```

Rename the `UnitTest1.cs` file to `CalcTests.cs` and add the code from the `CalcTests` example above. **Note:** Do not remove any `using` directives. You will need to add a project reference to `CalculatorTests`. Without this, you will not be able to access the `Calc` class. To do this, right-click on `CalculatorTests`. Click on **Add** then **Project Reference...**. You will be presented with a **Reference Manager** window. Check `Calculator`. Add the following `using` directive - `using Calculator;` below `using Microsoft.VisualStudio.TestTools.UnitTesting;`. Now you should have access to the `Calc` class. To run `CalculatorTests`, press the <kbd>ctrl</kbd> + <kbd>r</kbd> + <kbd>t</kbd>.

# Formative Assessment

Before you start, create a new branch called **04-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Create a unit test for four of the six programs in **02-formative-assessment**. Ensure that you cover all fields and methods concerned.

# Research Assessment

## Task 1:

The following activity involves debugging a program called `Debugging`.

```cs
using System;

namespace Debugging
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = 5
            Console.WriteLine("The value of x is: " + x);

            int x = 5;
            int y = 10;

            if (x < y)
            {
                Console.WriteLine("x is greater than y");
            }
            else
            {
                Console.WriteLine("y is greater than x");
            }
        }

        static void SomeMethod()
        {
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine(i);
                i--;
            }
        }
    }
}
```

Identify one syntax error and two logical errors in the code above. Also, explain how to fix these errors.

## Task 2:

Explain the following exceptions:

1. `ArgumentNullException`
2. `IndexOutOfRangeException`
3. `NullReferenceException`
4. `FileNotFoundException`
5. `IOException`
6. `DivideByZeroException`

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.