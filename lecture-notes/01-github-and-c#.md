# 01: GitHub and C#

## GitHub

In this course, we are going to use **GitHub** and **GitHub Classroom** to manage our development. Begin by clicking the following:

https://classroom.github.com/a/9Cn3pu5-

You will use this repository for your **formative assessments** only.

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

## Full Resource

You can find the full resource on **GitHub** - <https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/main-s1-24/resources/github-classroom-setup.md>. It also includes information on **Git Integration in Visual Studio**.

## C#

**C#** is a programming language developed by **Microsoft** for building web, mobile applications, desktop applications and games. It is a modern, **object-oriented** language designed to be easy to use and similar in syntax to other popular programming languages such as **C++** and **Java**. **C#** is commonly used to build applications on the **Microsoft .NET Framework**, but developers can also use it to build cross-platform applications using frameworks like **Xamarin** and **.NET Core**.

## Main Method

The **Main** method is the entry point for all **C#** programs. It is the first method that is called when a program is executed. The **Main** method is declared with the `static` keyword, which means that it can be called without creating an instance of the class that contains it. It also has a return type of `void`, which means that it does not return a value. The **Main** method is typically declared in a **class** called `Program` and is usually the only method in that **class**. For example:

```cs
// Using directives

class Program
{
    static void Main(string[] args)
    {
        // Code to be executed
    }
}
```

You can also use **top-level statements** to declare the **Main** method. This allows you to write code directly in the **Main** method without having to create a **class**. For example:

```cs
// Using directives

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

**Note:** In this course, it is recommended that you use the **Main** method approach.

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

In the above example, `x` is a **variable** of type `int`, `name` is a **variable** of type `string`, and `isTrue` is a **variable** of type `bool`. Once a **variable** is declared, you can assign a value using the assignment operator, i.e., `=`. For example:

```cs
x = 5;
name = "John Doe";
isTrue = true;
```

You can also declare and assign a value to a **variable** in a single statement like this:

```cs
int x = 5;
string name = "John Doe";
bool isTrue = true;
```

It is also possible to use the `var` keyword to declare a **variable**. The compiler will then infer the type based on the value assigned to it.

```cs
var x = 5;
var name = "John Doe";
var isTrue = true;
```

Note that **variables** declared with the `var` keyword can only be initialised at the time of declaration. It cannot be reassigned with a different type.

What happens if you want to declare a variable whose value cannot be changed once it has been assigned? You can use the `const` keyword to declare a **constant**. For example:

```cs
const int x = 5;
const string name = "John Doe";
const bool isTrue = true;

x = 10; // This will cause an error
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

The condition is a **boolean expression** evaluated as either `true` or `false`. The code inside the first curly braces (`{ }`) is executed if the condition is `true`. If the condition is `false`, the code inside the second set of curly braces is executed.

For example, the following code checks if `x` is greater than `y`. If so, it prints "x is greater than y" to the console. If not, it prints "x is less than or equal to y" to the console.

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

You can also chain multiple conditions using `else if` like the following example:

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

You can chain as many else if you need.

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
    ... // As many cases as you need
    default:
        // Code to be executed if expression does not match any of the values
        break;
}
```

The expression is evaluated and its value is compared to the values specified in each case. If a match is found, the code block associated with that case is executed. It is important to include a `break` statement at the end of each case block to exit the `switch` statement after the code block has been executed.

For example, the following code uses a `switch` statement to check the value of `x` and prints a message to the console based on its value:

```cs
int x = 1;

switch (x) // Switch on an integer
{
    case 1:
        Console.WriteLine("x is 1");
        break;
    case 2:
        Console.WriteLine("x is 2");
        break;
    default:
        Console.WriteLine("x is not 1 or 2");
        break;
}
```

The `default` case is optional and will be executed if the value of the expression does not match any of the values specified in the case statements. You can also use the `switch` statement with `string`, like the following example:

```cs
string day = "Monday";

switch (day) // Switch on a string
{
    case "Monday":
        Console.WriteLine("Today is Monday");
        break;
    case "Tuesday":
        Console.WriteLine("Today is Tuesday");
        break;
    default:
        Console.WriteLine("Today is not Monday nor Tuesday");
        break;
}
```

## Loops

There are several types of loops in **C#**, including:

- `for` loops: These loops are used to execute a block of code a specified number of times. The basic syntax of a `for` loop is:

```cs
for (initialisation; condition; increment)
{
    // Code to be executed
}
```

For example, the following code uses a `for` loop to print the numbers 0 to 9 to the console:

```cs
for (int i = 0; i < 10; i++) // Initialise i to 0, check if i is less than 10, increment i by 1
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
```

**Note:** You can omit the curly braces if the loop body contains only one statement.

You can also decrement the value of the loop variable, like the following example:

```cs
for (int i = 10; i > 0; i--) // Initialise i to 10, check if i is greater than 0, decrement i by 1
{
    Console.WriteLine(i); // Prints 10, 9, 8, ..., 1
}
```

How about incrementing by 2? You can do that too:

```cs
for (int i = 0; i < 10; i += 2) // Initialise i to 0, check if i is less than 10, increment i by 2
{
    Console.WriteLine(i); // Prints 0, 2, 4, ..., 8
}
```

What happens if you want to `break` out of a loop? You can use the `break` keyword to exit the loop. For example:

```cs
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break; // Exit the loop when i is equal to 5
    }
    Console.WriteLine(i); // Prints 0, 1, 2, 3, 4
}
```

`foreach` loops: These loops are used to iterate over the items in a collection, such as an array or list. The basic syntax of a `foreach` loop is:

```cs
foreach (var item in collection)
{
    // code to be executed
}
```

For example, the following code uses a foreach loop to print the items of an array to the console:

```cs
int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
foreach (int i in numbers)
{
    Console.WriteLine(i);
}
```

- `while` loops: These loops are used to execute a block of code while a certain condition is true. The basic syntax of a `while` loop is:

```cs
while (condition)
{
    // Code to be executed
}
```

For example, the following code uses a `while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;

while (i < 10)
{
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
    i++;
}
```

- `do-while` loops: These loops are similar to while loops, but the code inside the loop is guaranteed to be executed at least once. The basic syntax of a `do-while` loop is:

```cs
do
{
    // Code to be executed
} while (condition);
```

For example, the following code uses a `do-while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;

do
{
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
    i++;
} while (i < 10);
```

`foreach` loops: These loops are used to iterate over the items in a collection, such as an array or list. The basic syntax of a `foreach` loop is:

```cs
// Note: item is a variable that represents an item in the collection. It can be named anything you want
foreach (var item in collection)
{
    // Code to be executed
}
```

For example, the following code uses a foreach loop to print the items of an array to the console:

```cs
int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

foreach (int i in numbers)
{
    Console.WriteLine(i); // Prints 0, 1, 2, ..., 9
}
```

## Methods

In **C#**, a **method** is a block of code that performs a specific task and can be called (invoked) by name. Methods are used to encapsulate and organise code and can accept parameters and return a value. There are several types of **methods** in **C#**, including:

- Instance **methods**: These **methods** are associated with an instance of a **class** and can access the instance's data.

```cs
public class MyClass 
{
    public int myValue = 0;

    public void IncreaseValue(int amount) 
    { // This is the method signature - name and parameter(s)
        myValue += amount; // or myValue = myValue + amount;
    }
}

// Usage:
MyClass myObj = new MyClass();
myObj.IncreaseValue(5);
Console.WriteLine(myObj.myValue); // 5
```

- Static **methods**: These **methods** are associated with a **class** and do not have access to an instance's data. They can only access static data.

```cs
public class MyClass 
{
    public static int Add(int a, int b) 
    { 
        return a + b;
    }
}

// Usage:
int result = MyClass.Add(2, 3);
Console.WriteLine(result); // 5
```

- Constructors: These **methods** are used to create and initialise an instance of a **class**.

```cs
public class MyClass 
{
    public int myValue;

    public MyClass(int value) 
    {
        myValue = value;
    }
}

// Usage:
MyClass myObj = new MyClass(5);
Console.WriteLine(myObj.myValue); // 5
```

- Finalisers/Destructors: These **methods** are used to clean up resources when an instance of a **class** is no longer needed. It is not recommended in **C#**.

```cs
public class MyClass {
    ~MyClass() // Note: The use of the tilde (~) character. This indicates that this 
               // is a finaliser/destructor. You may see this in other programming languages, for example, C++
    { 

        // Clean up resources
    }
}
```

- Extension methods: These **methods** are used to add functionality to existing **classes** without modifying the source code. Also, they require the `this` keyword on the first parameter, which defines the type of object the **method** will be an extension of.

```cs
public static class MyClass {
    public static int Multiply(this int num, int factor) 
    {
        return num * factor;
    }
}

// Usage:
int result = 5.Multiply(3);
Console.WriteLine(result); // 15
```

**Note:** If a method's block has one statement, you can use the **expression-bodied** syntax. For example:

```cs
public class MyClass 
{
    public int myValue = 0;

    public void IncreaseValue(int amount) => myValue += amount;
}
```

**Resources:**
- Methods - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods>
- Constructors - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors>
- Finalisers/Destructors - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/destructors>
- Extension methods - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods>
- Expression-bodied members - <https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members>

## Casting

Casting is the process of converting a value of one data type to another data type. There are two types of casting in **C#**:

- Implicit casting: This is when a value of one data type is converted to another data type without the need for an explicit cast. This can be done when you are converting from a smaller data type to a larger data type. For example: 

```cs
int x = 5;
double y = x; // Implicit cast from int to double
// Output: 5
```

The compiler handles this automatically without the need for an explicit cast.

- Explicit casting: This is when a value of one data type is converted to another data type using an explicit cast. The programmer must explicitly specify the type of conversion. **Note:** There is a risk of data loss when using explicit casting. For example:

```cs
double x = 5.5;
int y = (int)x; // Explicit cast from double to int
// Output: 5
```

You lost the decimal part of the number when you casted from `double` to `int`.

## Error Handling

Error handling is anticipating and managing errors that may occur during the execution of a program. It is typically achieved through the use of **try-catch** blocks and **exception** objects. The `try` block contains code that may generate an **exception**, and the `catch` block contains code that will be executed if an **exception** is thrown. The **exception** object contains information about the error that occurred, such as the type of error and a description of the error. The `using` statement can also be used to ensure that resources are properly disposed of even in the event of an **exception**.

Here is an example of a basic **try-catch** block:

```cs
try
{
    // Code that may throw an exception
    int x = int.Parse("abc"); // Is "abc" a valid integer?
}
catch (FormatException ex)
{
    // Code that will be executed if an exception is thrown
    Console.WriteLine($"Error: {ex.Message}");
}
```

In this example, the code in the `try` block attempts to parse a string to an integer, but the string `abc` is not a valid integer, so a `FormatException` is thrown. The `catch` block catches this exception and prints an error message to the console.

Another example using the `using` statement:

```cs
string fileName = "example.txt";

using (FileStream stream = new FileStream(fileName, FileMode.Open))
{
    // Code that uses the stream
}
```

In this example, the `using` statement ensures that the `FileStream` object is properly disposed of, even if an exception is thrown while the stream is in use.

You can also have multiple `catch` blocks to handle different exception types, like this:

```cs
try
{
    // Code that may throw an exception
    int x = int.Parse("abc"); 
    int y = int.Parse("456");
}
catch (FormatException ex)
{
    // Code that will be executed if a FormatException is thrown
    Console.WriteLine($"Error: {ex.Message}");
}
catch (OverflowException ex)
{
    // Code that will be executed if a OverflowException is thrown
    Console.WriteLine($"Error: {ex.Message}");
}
```

In this example, if the code in the `try` block throws a `FormatException`, the first `catch` block will be executed, if it throws a `OverflowException`, the second `catch` block will be executed.

**Note:** There is a third type of block called `finally` that can be used to execute code after the `try` and `catch` blocks have been executed, regardless of whether an exception was thrown or not. 

## File Processing

File processing is the process of reading from or writing to files on a computer's file system. It can be done using the **classes** and **methods** in the System.IO namespace, which provides various **classes** for working with files, directories and other types of I/O (input/output) operations.

For example, the `File` **class** provides **methods** for creating, copying, moving, and deleting files. In contrast, the `StreamReader` and `StreamWriter` **classes** provide **methods** for reading from and writing to text files, respectively.

Here is an example of how to use the `File` **class** to read the contents of a text file:

```cs
string fileName = "example.txt";
string text = File.ReadAllText(fileName);
Console.WriteLine(text);
```

**Question:** Where do you stored `example.txt`?

This code uses the `ReadAllText()` **method** of the `File` **class** to read the contents of the file `example.txt` and assigns the result to `text`.

Here is another example of how to use the `StreamReader` **class** to read the contents of a text file:

```cs
string fileName = "example.txt";

using (StreamReader reader = new StreamReader(fileName))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
```

In this example, the `StreamReader` **class** is used to read the contents of the file `example.txt` line by line, and each line is printed to the console.

Similarly, the `File` **class** has **methods** to write to a file, as well as `StreamWriter` **class**.

```cs
string fileName = "example.txt";
File.WriteAllText(fileName, "Hello, World!");
```

This code uses the `WriteAllText()` **method** of the `File` **class** to write the string "Hello, World!" to the file `example.txt`.

```cs
string fileName = "example.txt";

using (StreamWriter writer = new StreamWriter(fileName))
{
    writer.WriteLine("Hello,");
    writer.WriteLine("World!");
}
```

This example uses the `StreamWriter` **class** to write the strings "Hello," and "World!" to the file "example.txt", each on a new line.

These are just a few examples of how to perform file processing. Still, the `System.IO` namespace provides many other **classes** and **methods** for working with files and directories, such as the `Directory` **class** for working with directories, the `FileInfo` and `DirectoryInfo` **classes** for working with file and directory metadata, and the `FileSystemWatcher` **class** for monitoring changes to the file system.

## Naming Conventions

Try and follow the naming conventions below when naming your **classes**, **methods**, **variables**, etc.:

- Use meaningful names that describe what the **class**, **method**, **variable**, etc. does
- Use **PascalCase** for **classes** and **methods**.
- Use **camelCase** for **variables** and **parameters**.
- Use **ALL_CAPS** for **constants**.
- Private fields should be prefixed with an underscore (`_`). For example, `private string _someVariableName;`
- Static fields should be prefixed with a lowercase `s` (`s_`). For example, `static string s_someVariableName;`

**Note:** You will learn about the private and static keywords in `04-classes-objects-and-encapsulation.md`.

## Commenting

Comments are used to explain the code and make it easier to understand. They are ignored by the compiler and do not affect the execution of the program. There are two types of comments in **C#**:

- Single-line comments: These comments start with `//` and continue until the end of the line.

```cs
// This is a single-line comment
```

- Multi-line comments: These comments start with `/*` and end with `*/`. They can span multiple lines.

```cs
/*
This is a multi-line comment
*/
```

There are also **XML** documentation comments, which are used to document code and can be used by tools like **Visual Studio** to provide **IntelliSense**. They start with `///` and continue until the end of the line.

```cs
/// <summary>
/// This is an XML comment
/// </summary>
```

**Note:** In the assessments, you will use **XML** documentation comments to document your code. You can comment out code that you wish to refer to at a later date. Otherwise, these should be removed before submitting your work.

# Formative Assessment

Before you start, create a new **C# Console** application called **01-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Create a **double array** named `nums` with the values 45.3, 67.5, -45.6, 20.34, -33.0, 45.6. Iterate over the **array** using a loop and calculate the sum of all items. Divide that sum by the total number of items in the **array** to find the average. Use **string interpolation** to display the average in the desired format.

## Task 2:

Create a **static method** called `fizzBuzz` that takes in an integer `num`. Inside the **static method**, check if `num` is a multiple of 3 and if so, return "Fizz". Check if `num` is a multiple of 5 and if so, return "Buzz". If `num` is a multiple of both 3 and 5, return "FizzBuzz". Create a for loop that starts at 1, ends at 15 and increments by 2 each time. Inside the for loop, call the `fizzBuzz` **static method** with the current iteration **variable** `i` and print the result.

## Task 3:

Create an **array** of **integers** called `nums` with the values 21, 19, 68, 55, 42, 12. Iterate over the **array** and check if each number is odd. If it is, display it. Finally, sort the **array** from lowest to highest, then display again.

## Task 4:

Create a **static method** called `isAnagram` that takes in two parameters, `someStrOne` and `someStrTwo` which are both strings. Inside the **static method**, write code to check if `someStrOne` and `someStrTwo` are an anagram of each other. An anagram is a word or phrase made by rearranging the letters of another word or phrase. Compare the characters of both strings after sorting them. Return `true` if they match and `false` otherwise.

In my solution, I converted the two **strings** to **char** arrays and sorted them using the `Array.Sort` **static method**. Then I compared the sorted char arrays using the `SequenceEqual` **static method** and returned `true` if they match, otherwise `false`.

Declare the following test cases in the `Main()` method:

``cs
Console.WriteLine(isAnagram("listen", "silent")); // Expected output: true
Console.WriteLine(isAnagram("hello", "world")); // Expected output: false
``

## Task 5:

Create a **static method** called `convert` that takes in two parameters, `hours` and `minutes` which are both integers. Inside the **static method**, write code to convert both `hours` and `minutes` to seconds. Multiply the number of hours by 3600 (the number of seconds in an hour) and the number of minutes by 60 (the number of seconds in a minute). Add these values together and return the total number of seconds.

Declare the following test cases in the `Main()` method:

``cs
Console.WriteLine(convert(2, 30)); // Expected output: 9000
Console.WriteLine(convert(1, 15)); // Expected output: 4500
``

## Task 6:

Create a **string variable** called `sentence` and assign the value "The anemone, the wild violet, the hepatica, and the funny little curled-up." to it. Convert the string into an array. Use a loop to count the number of occurrences of the word "the" in the array.

In my solution, I used the `String.Split` **static method** to split the sentence into words by the space character.

## Task 7:

Create a **static method** called `removeVowels` that takes in a parameter `word` which is a string. Inside the **static method**, write code to remove all vowels from `word`. Use a regular expression or a loop to check each character of the word and remove the vowels.

To handle the edge case where the word does not contain vowels, you can check if `word` is equal to the result after removing vowels. If it is the same, you can return a message indicating that the word does not contain vowels, otherwise, return `word` without vowels.

Declare the following test cases in the `Main()` method:

``cs
Console.WriteLine(removeVowels("C#")); // Expected output: C#
Console.WriteLine(removeVowels("programming")); // Expected output: prgrmmng
``

## Task 8:

Create a **static method** called `isPalindrome` that takes in a parameter `word` which is a string. Inside the **static method**, write code to check if `word` is a palindrome. A palindrome is a word, phrase, or sequence that reads the same backward as forward. Compare the characters of `word` from the beginning and end of the string. If they match, continue checking until you reach the middle of the string. If all characters match, return `true`, otherwise, return `false`.

Declare the following test cases in the `Main()` method:

``cs
Console.WriteLine(isPalindrome("level")); // Expected output: true
Console.WriteLine(isPalindrome("hello")); // Expected output: false
``

## Task 9:

Create a **static method** called `isPrime` that takes in a parameter `num` which is an integer. Inside the **static method**, write code to check if `num` is a prime number. A prime number is a number that is only divisible by 1 and itself. Use a loop to check if `num` is divisible by any number other than 1 and itself. If it is, return `false`, otherwise, return `true`.

Declare the following test cases in the `Main()` method:

``cs
Console.WriteLine(isPrime(7)); // Expected output: true
Console.WriteLine(isPrime(10)); // Expected output: false
``

## Task 10:

Write some code that reads in a file called `computer-jokes.txt` containing a list of computer jokes. The program should store the jokes in an array and randomly select and display a joke each time it is run.

## Task 11:

Write some code that reads in a file called `countries.txt` containing a list of country names. The program should display only the names of the countries that start with the letter **'B'**.

## Submission

Push your code to your **GitHub** repository.
