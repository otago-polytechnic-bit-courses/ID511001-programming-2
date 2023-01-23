# 04 A: Debugging

Debugging is the process of identifying and resolving errors (also called bugs) in your code. When you write code, it is not uncommon to make mistakes, such as syntax errors, logical errors, or runtime errors. Debugging is the process of finding and fixing these errors so that your code runs correctly.

There are several techniques and tools that can be used for debugging code, including:

* Using the **Visual Studio Debugge**r: **Visual Studio** provides a built-in debugger that allows you to step through your code line by line, set breakpoints, view the values of variables, and more.
* Using the **Console**: You can use the `Console` class to print out the values of variables and other information to the console while your program is running. This can help you to understand what your code is doing and to identify errors.
* Using the **Immediate Window**: The **Immediate Window** allows you to execute code and check the values of variables while your program is in break mode.
* Using the **Watch Window**: The **Watch Window** allows you to see the value of a variable or an expression while your program is running.
* Using the **Call Stack Window**: The **Call Stack Window** allows you to see the sequence of method calls that led to the current point in the execution of your program.
* Using the **Output Window**: The **Output Window** allows you to see the debug messages that you write to the console.

When you find an error in your code, you can use these tools and techniques to understand what is causing the error, and to fix it. Once you have fixed the error, you can then test your code again to make sure that it works correctly.

Debugging is an important part of the development process and it can save a lot of time and effort by identifying and resolving errors early on.

# 04 B: Unit Testing

Unit testing is the process of testing individual units of code, such as methods or classes, in isolation from the rest of the program. The goal of unit testing is to ensure that each unit of code behaves correctly and that it meets the requirements specified for it. Unit tests are usually automated, which means that they can be run automatically and repeatedly without human intervention.

Unit tests are typically written using a unit testing framework, such as **MSTest**, **xUnit**, or **NUnit**, which provides a set of tools and libraries for creating, running, and managing unit tests. The tests are usually written using a test-driven development (TDD) approach, where the tests are written before the actual implementation of the code.

Here's an example of a simple unit test using **MSTest**:

```cs
[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void AddShouldReturnSum()
    {
        // Arrange
        Calculator calculator = new Calculator();
        int x = 2;
        int y = 3;
        int expected = 5;

        // Act
        int actual = calculator.Add(x, y);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
```

In this example, the test class `CalculatorTests` has one test method `AddShouldReturnSum()`. This method uses the `Assert.AreEqual()` method to check that the result of the `Add()` method of the `Calculator` class is equal to the expected value. The test method is decorated with the `[TestMethod]` attribute, which tells the unit testing framework that this method is a test.

When the test is run, the unit testing framework will execute the `AddShouldReturnSum()` method and check the assertion. If the assertion passes, the test is considered to have passed. If the assertion fails, the test is considered to have failed and the framework will provide a detailed error message.

Unit testing is an important practice in software development, as it helps to ensure that the code is working correctly, it helps to detect and fix bugs early, and it allows for more confident and safe changes and refactoring of the code. It also helps to increase the quality and maintainability of the code.

# Formative Assessment
