# 01: GitHub and C#

## GitHub

In this course, we are going to use **GitHub** and **GitHub Classroom** to manage our development. Begin by clicking the following:

[https://classroom.github.com/a/Xg7esDmf](https://classroom.github.com/a/Xg7esDmf)

## Development Workflow

By default, **GitHub Classroom** creates an empty repository. Firstly, you must create a **README** and `.gitignore` file. **GitHub** provides an option for creating new files once the repository is created.

## Create a README

Click on the **Add file** button, then the **Create new file** button. Name your file `README.md` (Markdown), then click on the **Commit new file** button. You should see a new file in your formative assessments repository called `README.md` and the `main` branch.

## Create a .gitignore File

Like before, click on the **Add file** button and then the **Create new file** button. Name your file `.gitignore`. A `.gitignore` template dropdown will appear on the right-hand side of the screen. Select the **Visual Studio** `.gitignore` template. Click on the **Commit new file** button. You should see a new file in your formative assessments repository called `.gitignore`.

**Resources:**

- <https://git-scm.com/docs/gitignore>
- <https://github.com/github/gitignore>

## Clone a Repository

Open up **Git Bash** or whatever alternative you see fit on your computer. Clone your formative assessments repository to a location on your computer using the command: `git clone <repository URL>`.

**Resource:**

- <https://git-scm.com/docs/git-clone>

## C#

**C#** is a programming language developed by **Microsoft** for building web applications, mobile applications, desktop applications and games. It is a modern, **object-oriented** language designed to be easy to use and similar in syntax to other popular programming languages such as **C++** and **Java**. **C#** is commonly used to build applications on the **Microsoft .NET Framework**, and developers can also use it to build cross-platform applications using frameworks like **Xamarin** and **.NET**.

## Main Method

The **Main** method is the entry point for all **C#** programs. It is the first method that is called when a program is executed. The **Main** method is declared with the `static` keyword, which means that it can be called without creating an instance of the class that contains it. It also has a return type of `void`, which means that it does not return a value. The **Main** method is typically declared in a **class** called `Program` and is usually the only method in that **class**. For example:

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Code to be executed
        Console.WriteLine("Hello, World!");
    }
}
```

You can also use **top-level statements** (available in C# 9.0 and later) to simplify your code. This allows you to write code directly without having to create a **class** structure. For example:

```cs
using System;

// Top-level statements - no Main method or Program class needed
Console.WriteLine("Hello, World!");
```

**Note:** In this course, it is recommended that you use the traditional **Main** method approach for better understanding of C# structure.

**Resources:**

- Main method - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/>
- Top-level statements - <https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements>

## Variables

A **variable** is a named storage location that holds a value of a specific data type. **Variables** are used to store values that can change during the execution of a program. A **variable** is declared by specifying the data type and the **variable** name. For example:

```cs
int x;
string name;
bool isTrue;
```

In the above example, `x` is a **variable** of type `int`, `name` is a **variable** of type `string`, and `isTrue` is a **variable** of type `bool`. Once a **variable** is declared, you can assign a value using the assignment operator (`=`). For example:

```cs
x = 5;
name = "John Doe";
isTrue = true;
```

You can also declare and assign a value to a **variable** in a single statement:

```cs
int x = 5;
string name = "John Doe";
bool isTrue = true;
```

It is also possible to use the `var` keyword to declare a **variable**. The compiler will infer the type based on the value assigned to it:

```cs
var x = 5;        // Inferred as int
var name = "John Doe";  // Inferred as string
var isTrue = true;      // Inferred as bool
```

Note that **variables** declared with the `var` keyword must be initialized at the time of declaration, and the type cannot be changed once inferred.

If you want to declare a variable whose value cannot be changed once it has been assigned, you can use the `const` keyword to declare a **constant**:

```cs
const int MaxValue = 100;
const string CompanyName = "Acme Corp";
const bool IsDebugMode = true;

// MaxValue = 200; // This will cause a compiler error
```

## If-Else Statements

An **if-else** statement is a **control flow statement** that allows the program to make decisions based on a specific condition. The basic syntax of an **if-else** statement is:

```cs
if (condition)
{
    // Code to be executed if the condition is true
}
else
{
    // Code to be executed if the condition is false
}
```

The condition is a **boolean expression** that evaluates to either `true` or `false`. If the condition is `true`, the code inside the first set of curly braces is executed. If the condition is `false`, the code inside the `else` block is executed.

For example, the following code checks if `x` is greater than `y`:

```cs
int x = 5;
int y = 10;

if (x > y)
{
    Console.WriteLine("x is greater than y");
}
else
{
    Console.WriteLine("x is less than or equal to y");
}
```

You can also chain multiple conditions using `else if`:

```cs
int x = 5;
int y = 10;

if (x > y)
{
    Console.WriteLine("x is greater than y");
}
else if (x == y)
{
    Console.WriteLine("x is equal to y");
}
else
{
    Console.WriteLine("x is less than y");
}
```

You can chain as many `else if` statements as needed.

## Switch Statement

A `switch` statement is a **control flow statement** that allows a program to select one of many code blocks to be executed based on the value of a given expression. The basic syntax of a `switch` statement is:

```cs
switch (expression)
{
    case value1:
        // Code to be executed if expression equals value1
        break;
    case value2:
        // Code to be executed if expression equals value2
        break;
    default:
        // Code to be executed if expression doesn't match any case
        break;
}
```

The expression is evaluated and its value is compared to the values specified in each case. If a match is found, the code block associated with that case is executed. It is important to include a `break` statement at the end of each case block to exit the `switch` statement.

Here's an example using an integer:

```cs
int dayOfWeek = 3;

switch (dayOfWeek)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        Console.WriteLine("Invalid day");
        break;
}
```

You can also use the `switch` statement with strings:

```cs
string day = "Monday";

switch (day)
{
    case "Monday":
        Console.WriteLine("Start of the work week");
        break;
    case "Friday":
        Console.WriteLine("TGIF!");
        break;
    default:
        Console.WriteLine("Regular day");
        break;
}
```

The `default` case is optional and will be executed if the value of the expression doesn't match any of the specified cases.

## Loops

There are several types of loops in **C#**:

### For Loops

`for` loops are used to execute a block of code a specified number of times. The basic syntax is:

```cs
for (initialization; condition; increment)
{
    // Code to be executed
}
```

Example - print numbers 0 to 9:

```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i); // 0, 1, 2, ..., 9
}
```

**Note:** You can omit the curly braces if the loop body contains only one statement.

You can also decrement or use different increment values:

```cs
// Decrement
for (int i = 10; i > 0; i--)
{
    Console.WriteLine(i); // 10, 9, 8, ..., 1
}

// Increment by 2
for (int i = 0; i < 10; i += 2)
{
    Console.WriteLine(i); // 0, 2, 4, 6, 8
}
```

You can use the `break` keyword to exit a loop early:

```cs
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break; // Exit the loop when i equals 5
    }
    Console.WriteLine(i); // Prints 0, 1, 2, 3, 4
}
```

### Foreach Loops

`foreach` loops are used to iterate over collections such as arrays or lists:

```cs
foreach (datatype variable in collection)
{
    // Code to be executed
}
```

Example:

```cs
int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

### While Loops

`while` loops execute a block of code while a condition is true:

```cs
while (condition)
{
    // Code to be executed
}
```

Example:

```cs
int i = 0;
while (i < 10)
{
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
    i++;
}
```

### Do-While Loops

`do-while` loops are similar to while loops, but the code is guaranteed to execute at least once:

```cs
do
{
    // Code to be executed
} while (condition);
```

Example:

```cs
int i = 0;
do
{
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
    i++;
} while (i < 10);
```

## Methods

In **C#**, a **method** is a block of code that performs a specific task and can be called by name. Methods are used to encapsulate and organize code, and can accept parameters and return values. There are several types of **methods** in **C#**:

### Instance Methods

These **methods** are associated with an instance of a **class** and can access the instance's data:

```cs
public class Calculator
{
    private int value = 0;

    public void Add(int amount)
    {
        value += amount;
    }

    public int GetValue()
    {
        return value;
    }
}

// Usage:
Calculator calc = new Calculator();
calc.Add(5);
Console.WriteLine(calc.GetValue()); // Output: 5
```

### Static Methods

These **methods** are associated with a **class** rather than an instance and can only access static data:

```cs
public class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

// Usage:
int result = MathHelper.Add(2, 3);
Console.WriteLine(result); // Output: 5
```

### Constructors

These special **methods** are used to create and initialize instances of a **class**:

```cs
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// Usage:
Person person = new Person("John", 25);
Console.WriteLine($"{person.Name} is {person.Age} years old");
```

### Expression-Bodied Methods

For methods with single expressions, you can use the expression-bodied syntax:

```cs
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public bool IsEven(int number) => number % 2 == 0;
}
```

**Resources:**

- Methods - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods>
- Constructors - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors>
- Extension methods - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods>
- Expression-bodied members - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members>

## Type Conversion and Casting

Type conversion is the process of converting a value from one data type to another. There are several types of conversions in **C#**:

### Implicit Conversion

This occurs automatically when converting from a smaller data type to a larger one without risk of data loss:

```cs
int x = 5;
double y = x; // Implicit conversion from int to double
Console.WriteLine(y); // Output: 5.0
```

### Explicit Casting

This requires explicit specification and may result in data loss:

```cs
double x = 5.7;
int y = (int)x; // Explicit cast from double to int
Console.WriteLine(y); // Output: 5 (decimal part is lost)
```

### Parse and Convert Methods

For converting strings to other types:

```cs
string numberText = "123";
int number = int.Parse(numberText);
// or
int number2 = Convert.ToInt32(numberText);
```

### TryParse Methods

Safer conversion that doesn't throw exceptions:

```cs
string input = "abc";
if (int.TryParse(input, out int result))
{
    Console.WriteLine($"Converted: {result}");
}
else
{
    Console.WriteLine("Conversion failed");
}
```

## Error Handling

Error handling involves anticipating and managing errors that may occur during program execution. This is typically achieved through **try-catch** blocks and **exception** objects.

### Basic Try-Catch

```cs
try
{
    // Code that may throw an exception
    int result = int.Parse("abc");
}
catch (FormatException ex)
{
    // Handle specific exception type
    Console.WriteLine($"Invalid format: {ex.Message}");
}
catch (Exception ex)
{
    // Handle any other exception
    Console.WriteLine($"An error occurred: {ex.Message}");
}
```

### Try-Catch-Finally

The `finally` block executes regardless of whether an exception occurs:

```cs
try
{
    // Risky code
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Cannot divide by zero");
}
finally
{
    // This code always runs
    Console.WriteLine("Cleanup operations");
}
```

### Using Statement

The `using` statement ensures proper disposal of resources:

```cs
string fileName = "example.txt";

using (var reader = new StreamReader(fileName))
{
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
} // StreamReader is automatically disposed here
```

## File Processing

File processing involves reading from or writing to files using classes in the `System.IO` namespace.

### Reading Files

Using the `File` class for simple operations:

```cs
using System;
using System.IO;

// Read entire file at once
string fileName = "example.txt";
if (File.Exists(fileName))
{
    string content = File.ReadAllText(fileName);
    Console.WriteLine(content);
}
else
{
    Console.WriteLine("File not found");
}
```

Using `StreamReader` for line-by-line reading:

```cs
string fileName = "example.txt";

try
{
    using (StreamReader reader = new StreamReader(fileName))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found");
}
```

### Writing Files

Using the `File` class:

```cs
string fileName = "output.txt";
string content = "Hello, World!";
File.WriteAllText(fileName, content);
```

Using `StreamWriter`:

```cs
string fileName = "output.txt";

using (StreamWriter writer = new StreamWriter(fileName))
{
    writer.WriteLine("Line 1");
    writer.WriteLine("Line 2");
}
```

**Note:** When working with file paths, consider using `Path.Combine()` for cross-platform compatibility, and always handle potential exceptions like `FileNotFoundException` or `UnauthorizedAccessException`.

## Naming Conventions

Follow these naming conventions when writing C# code:

- **Classes and Methods**: Use **PascalCase** (e.g., `MyClass`, `CalculateTotal`)
- **Variables and Parameters**: Use **camelCase** (e.g., `userName`, `totalAmount`)
- **Constants**: Use **PascalCase** (e.g., `MaxRetries`, `DefaultTimeout`)
- **Private Fields**: Prefix with underscore and use camelCase (e.g., `_userName`, `_isInitialized`)
- **Static Fields**: Use **PascalCase** (e.g., `DefaultValue`)
- **Interfaces**: Prefix with 'I' and use PascalCase (e.g., `IRepository`, `ICalculator`)

Use meaningful names that clearly describe the purpose of the variable, method, or class.

## Comments and Documentation

### Single-Line Comments

```cs
// This is a single-line comment
int x = 5; // Comment at end of line
```

### Multi-Line Comments

```cs
/*
This is a multi-line comment
that spans multiple lines
*/
```

### XML Documentation Comments

Used for generating documentation and providing IntelliSense:

```cs
/// <summary>
/// Calculates the area of a rectangle
/// </summary>
/// <param name="width">The width of the rectangle</param>
/// <param name="height">The height of the rectangle</param>
/// <returns>The area of the rectangle</returns>
public double CalculateRectangleArea(double width, double height)
{
    return width * height;
}
```

**Note:** Use comments to explain complex logic, not obvious code. Write self-documenting code with meaningful names when possible.

# Exercises

Before you start, create a new **C# Console** application with a descriptive name.

**Important Note About AI Tools:**

Learning to use AI tools is valuable, but you **must** be aware of the following:

- Refine your prompts to get useful responses
- Don't trust AI responses blindly - verify and test the code
- Acknowledge AI tool usage in your assessment's repository **README.md** file, including what prompts you used and how you applied the responses

## Task 1:

Create a **double array** named `nums` with the values 45.3, 67.5, -45.6, 20.34, -33.0, 45.6. Iterate over the **array** using a loop and calculate the sum of all items. Divide that sum by the total number of items in the **array** to find the average. Use **string interpolation** to display the average with appropriate formatting.

## Task 2:

Create a **static method** called `FizzBuzz` that takes an integer `num` as a parameter. Inside the method:

- If `num` is divisible by both 3 and 5, return "FizzBuzz"
- If `num` is divisible by 3, return "Fizz"
- If `num` is divisible by 5, return "Buzz"
- Otherwise, return the number as a string

Create a for loop that starts at 1, ends at 15, and increments by 2 each iteration. Call the `FizzBuzz` method with each value and print the result.

## Task 3:

Create an **integer array** called `nums` with the values 21, 19, 68, 55, 42, 12.

1. Iterate over the array and display only the odd numbers
2. Sort the array from lowest to highest
3. Display the sorted array

## Task 4:

Create a **static method** called `ConvertToSeconds` that takes two parameters: `hours` and `minutes` (both integers). The method should:

- Convert hours to seconds (multiply by 3600)
- Convert minutes to seconds (multiply by 60)
- Return the total seconds

Test your method with these cases in `Main()`:

```cs
Console.WriteLine(ConvertToSeconds(2, 30)); // Expected output: 9000
Console.WriteLine(ConvertToSeconds(1, 15)); // Expected output: 4500
```

## Task 5:

Create a **string variable** called `sentence` and assign it the value "The anemone, the wild violet, the hepatica, and the funny little curled-up ferns."

Convert the string into a word array using `String.Split()` method, then use a loop to count how many times the word "the" appears (case-insensitive).

## Task 6:

Create a **static method** called `IsPrime` that takes an integer `num` as a parameter. The method should:

- Return `false` for numbers less than 2
- Check if the number is divisible by any number from 2 to the square root of `num`
- Return `true` if no divisors are found, `false` otherwise

Test your method with these cases in `Main()`:

```cs
Console.WriteLine(IsPrime(7));  // Expected output: True
Console.WriteLine(IsPrime(10)); // Expected output: False
Console.WriteLine(IsPrime(2));  // Expected output: True
Console.WriteLine(IsPrime(1));  // Expected output: False
```

# Summative Assessment

The following tasks are part of the **Classroom Tasks** assessment worth 10%. This section is worth 2%. **Note:** Partial marks **will not** be given for incomplete functionality.

## Task 1:

Create a **static method** called `RemoveVowels` that takes a string `word` as a parameter. Remove all vowels (a, e, i, o, u - both uppercase and lowercase) from the string and return the result.

Handle the edge case where the input string is empty or contains no vowels.

Test cases:

```cs
Console.WriteLine(RemoveVowels("AEIOU"));        // Expected: ""
Console.WriteLine(RemoveVowels("bcd fgh"));      // Expected: "bcd fgh"
Console.WriteLine(RemoveVowels("C@#omput!er"));  // Expected: "C@#mpt!r"
Console.WriteLine(RemoveVowels(""));             // Expected: ""
Console.WriteLine(RemoveVowels("aaaaa"));        // Expected: ""
```

## Task 2:

Create a **static method** called `IsPalindrome` that takes a string `word` as a parameter and returns `true` if it's a palindrome (reads the same forwards and backwards), `false` otherwise.

Test cases:

```cs
Console.WriteLine(IsPalindrome("Racecar"));                                              // Expected: False
Console.WriteLine(IsPalindrome("rAceCaR".ToLower()));                                   // Expected: True
Console.WriteLine(IsPalindrome(""));                                                    // Expected: True
Console.WriteLine(IsPalindrome(" "));                                                   // Expected: True
Console.WriteLine(IsPalindrome("a"));                                                   // Expected: True
Console.WriteLine(IsPalindrome("12321"));                                               // Expected: True
Console.WriteLine(IsPalindrome("A man a plan a canal Panama".Replace(" ", "").ToLower())); // Expected: True
```

## Task 3:

Create a **static method** called `IsAnagram` that takes two string parameters `firstString` and `secondString`. Return `true` if they are anagrams of each other (contain the same letters in different order), `false` otherwise.

**Hint:** Convert both strings to character arrays, sort them, and compare using `SequenceEqual` from LINQ.

Test cases:

```cs
Console.WriteLine(IsAnagram("Listen", "Silent"));                    // Expected: False
Console.WriteLine(IsAnagram("Listen".ToLower(), "Silent".ToLower())); // Expected: True
Console.WriteLine(IsAnagram("abc", "abcd"));                         // Expected: False
Console.WriteLine(IsAnagram("", ""));                                // Expected: True
Console.WriteLine(IsAnagram("a!b@c", "c@b!a"));                      // Expected: True
```

## Task 4:

Write code that reads a file called `countries.txt` containing a list of country names (one per line). Display only the countries that start with the letter 'B' or 'b'.

**Requirements:**

- Handle the case where the file doesn't exist
- Use proper exception handling
- You cannot modify the `countries.txt` file

**Note:** You'll need to create a `countries.txt` file in your project directory with a list of countries for testing.

## Task 5:

Write code that reads a file called `computer-jokes.txt` containing computer jokes (one per line). Store the jokes in an array and randomly select one to display each time the program runs.

**Requirements:**

- Handle the case where the file doesn't exist
- Use proper exception handling
- Use `Random` class for selection
- You cannot modify the `computer-jokes.txt` file

**Note:** You'll need to create a `computer-jokes.txt` file with jokes for testing.

## Submission

Push your completed code to your **GitHub** repository. Ensure your code is well-commented and follows the naming conventions outlined in this document.
