# 06: Enumerations, Debugging and Unit Testing

## Enumerations

An enumeration (or enum for short) is a value type that is used to define a set of named constants. Enumerations are useful when you have a fixed set of values that a variable can take on, such as the days of the week or the suits in a deck of cards.

An enumeration is defined using the `enum` keyword, followed by the name of the enumeration, and a list of enumerators, which are the named constants. Each enumerator is separated by a comma, and each enumerator is assigned an integer value starting from 0 by default. Here is an example:

```cs
enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

The enumerators in the example above are Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday and their respective values will be 0, 1, 2, 3, 4, 5, 6.

You can also give explicit values to the enumerators, for example:`

```cs
enum Days { Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

In this example, Monday is assigned the value 1, and the rest of the enumerators are assigned the value of the previous enumerator plus one.

You can use an enumeration like any other variable. You can assign a value or compare it to other enumeration values. For example:

```cs
Days today = Days.Monday;
if (today == Days.Friday)
{
    Console.WriteLine("It's Friday!");
}
else
{
    Console.WriteLine("It's not Friday.");
}
```

## Debugging

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

## Unit Testing 

You can find today's coding example - **06-calculator-example.zip** in the **lecture-notes** directory.

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

Before you start, create a new branch called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

In this task, you will create a console program that prompts the user to enter their favourite day of the week.

Here are steps you should consider:

1. Declare an `enum` called `Days` with the following days: `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, and `Sunday`.
2. Parse the user's input and convert it into a `Day` enum value.
3. Use a `switch` statement to output a message to the console based on the user's input. For example, if the user enters "Friday", the program should output "You like Fridays!".
4. Add error handling to handle an invalid input. If the user enters an invalid day, the program should output "Invalid input. Please try again." and prompt the user to enter a valid day of the week.

```cs
// Expected output:

Enter your favourite day of the week: Tuesday
You like Tuesdays!

Enter your favourite day of the week: Monday
You like Mondays!

Enter your favourite day of the week: Blah
Invalid input. Please try again.

Enter your favourite day of the week: Wednesday
You like Wednesdays!
```

## Task 2:

Modify the program to allow the user to enter multiple days of the week separated by commas. The program should output a message for each day of the week entered by the user.

## Task 3:

In this task, you will create a console program that prompts the user to select a colour and output some text in that selected colour.

Here are steps you should consider:

1. Declare an `enum` called `Colour` with the following values: `Red`, `Green`, `Blue`, and `Yellow`.
2. Declare an `enum` called `ColourHexCode` with the following hex codes for each color: Red - "0xFF0000", Green - "0x00FF00", Blue - "0x0000FF", and Yellow - "0xFFFF00".
3. Display all the available colours to the user before prompting them to select a colour.
4. Prompts the user to select a colour from the list of colors.
5. Parse the user's input and convert it into a `Colour` enum value.
6. Use a `switch` statement to set the text colour based on the user's input, and output a message to the console based on the user's input. For example, if the user selects Red, the program should set the console text colour to red and output "You selected Red with hex code #FF0000!".
7. Add error handling to the program to handle invalid input. If the user enters an invalid colour, the program should output "Invalid input. Please try again." and prompt the user to select a valid colour.

```cs
// Expected output:

Please select a colour:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: 2
You selected Green with hex code #00FF00!

Please select a colour:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: Purple
Invalid input. Please try again.

Please select a colour:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: 5
Invalid input. Please try again.
```

## Task 4:

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

## Task 5:

Create a unit test for two tasks in **03-formative-assessment**. Ensure that you cover all fields and methods concerned.

# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please do not your own pull request.