# 01: Development Workflow and C#

# Development Workflow

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

## Create a Local Branch

`cd` into your formative assessments repository and create a branch using the command `git branch <name of the branch>`. Checkout from the `main` branch to the new branch using the command `git checkout <name of the branch>`. Alternatively, you can create and checkout a branch using the command `git checkout -b <name of the branch>`.

For each formative assessment, create a new branch, i.e., branch name `01-formative-assessment`. When you create a new branch, make sure you are creating it from the branch you last worked on.

**Resources:**
- <https://git-scm.com/docs/git-branch>
- <https://git-scm.com/docs/git-checkout>

## Push Local Branch to Remote Repository

Push your local branch, i.e., `01-formative-assessment`, to your remote repository using the command `git push -u origin <name of branch>`. You will continue working on your formative assessment code until you are ready to submit it.

## Create a Pull Request

Once you have completed a formative assessment, create a pull request. Go to your formative assessments repository on GitHub. Click on the **Pull requests** tab, then click on the **New pull request** button. You will see two dropdowns (base and compare). Click the compare dropdown, select the formative assessments branch you want to compare with the `main` branch, and then click the **Create pull request** button.

On the right side of the screen, you will see **Reviewers**. Click on the **Reviewers** section. Add **grayson-orr** as reviewers, then click the **Create pull request** button.

**Grayson** will receive an email. **Grayson** will review your formative assessment code, and you will receive feedback. You may be asked to reflect on your feedback and fix your formative assessment code. You will receive an email when your formative assessment code has been reviewed or approved.

# C#

## What is C#?

**C#** is a programming language developed by **Microsoft** for building web, mobile applications, desktop applications and games. It is a modern, **object-oriented** language designed to be easy to use and similar in syntax to other popular programming languages such as **C++** and **Java**. **C#** is commonly used to build applications on the **Microsoft .NET Framework**, but developers can also use it to build cross-platform applications using frameworks like **Xamarin** and **.NET Core**.

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

## If-Else Statements

An **if-else** statement is a **control flow statement** that allows the program to make decisions based on a specific condition. The basic syntax of an **if-else** statement is:

```cs
if (condition)
{
    // code to be executed if the condition is true
}
else
{
    // code to be executed if the condition is false
}
```

The condition is a **boolean expression** evaluated as either `true` or `false`. The code inside the first curly braces (`{ }`) is executed if the condition is `true`. If the condition is `false`, the code inside the second set of curly braces is executed.

For example, the following code checks if `x` is greater than `y`. If so, it prints "x is greater than y" to the console. If not, it prints "x is less than or equal to y" to the console.

```cs
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
        // code to be executed if expression equals value1
        break;
    case value2:
        // code to be executed if expression equals value2
        break;
    ...
    default:
        // code to be executed if expression does not match any of the values
        break;
}
```

The expression is evaluated and its value is compared to the values specified in each case. If a match is found, the code block associated with that case is executed. It is important to include a `break` statement at the end of each case block to exit the `switch` statement after the code block has been executed.

For example, the following code uses a `switch` statement to check the value of `x` and prints a message to the console based on its value:

```cs
switch (x)
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
switch (day)
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
    // code to be executed
}
```

For example, the following code uses a `for` loop to print the numbers 0 to 9 to the console:

```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

- `while` loops: These loops are used to execute a block of code while a certain condition is true. The basic syntax of a `while` loop is:

```cs
while (condition)
{
    // code to be executed
}
```

For example, the following code uses a `while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}
```

- `do-while` loops: These loops are similar to while loops, but the code inside the loop is guaranteed to be executed at least once. The basic syntax of a `do-while` loop is:

```cs
do
{
    // code to be executed
} while (condition);
```

For example, the following code uses a `do-while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 10);
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
int[] numbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
foreach (int i in numbers)
{
    Console.WriteLine(i);
}
```

## Methods

In **C#**, a **method** is a block of code that performs a specific task and can be called (invoked) by name. Methods are used to encapsulate and organise code and can accept parameters and return a value. There are several types of **methods** in **C#**, including:

- Instance **methods**: These **methods** are associated with an instance of a **class** and can access the instance's data.

```cs
public class MyClass {
    public int myValue = 0;

    public void IncreaseValue(int amount) {
        myValue += amount;
    }
}

// Usage:
MyClass myObj = new MyClass();
myObj.IncreaseValue(5);
Console.WriteLine(myObj.myValue); 
```

**Ask ChatGPT 🤖** - What are other **methods** in **C#**?:

- Static **methods**: These **methods** are associated with a **class** and do not have access to an instance's data. They can only access static data.

```cs
public class MyClass {
    public static int Add(int a, int b) {
        return a + b;
    }
}

// Usage:
int result = MyClass.Add(2, 3);
Console.WriteLine(result); 
```

- Constructors: These **methods** are used to create and initialise an instance of a **class**.

```cs
public class MyClass {
    public int myValue;

    public MyClass(int value) {
        myValue = value;
    }
}

// Usage:
MyClass myObj = new MyClass(5);
Console.WriteLine(myObj.myValue); 
```

- Destructors: These **methods** are used to clean up resources when an instance of a **class** is no longer needed. It is not recommended in **C#**. 

```cs
public class MyClass {
    ~MyClass() {
        // Clean up resources
    }
}
```

- Extension methods: These **methods** are used to add functionality to existing **classes** without modifying the source code. Also, they require the `this` keyword on the first parameter, which defines the type of object the **method** will be an extension of.

```cs
public static class MyClass {
    public static int Multiply(this int num, int factor) {
        return num * factor;
    }
}

// Usage:
int result = 5.Multiply(3);
Console.WriteLine(result); 
```

## Error Handling

Error handling is anticipating and managing errors that may occur during the execution of a program. It is typically achieved through the use of **try-catch** blocks and **exception** objects. The `try` block contains code that may generate an **exception**, and the `catch` block contains code that will be executed if an **exception** is thrown. The **exception** object contains information about the error that occurred, such as the type of error and a description of the error. The `using` statement can also be used to ensure that resources are properly disposed of even in the event of an **exception**.

Here is an example of a basic **try-catch** block:

```cs
try
{
    // code that may throw an exception
    int x = int.Parse("abc");
}
catch (FormatException ex)
{
    // code that will be executed if an exception is thrown
    Console.WriteLine("Error: " + ex.Message);
}
```

**Ask ChatGPT 🤖** - How do you convert `Console.WriteLine("Error: " + ex.Message);` to use **string interpolation** in **C#**?:

In this example, the code in the `try` block attempts to parse a string to an integer, but the string `abc` is not a valid integer, so a `FormatException` is thrown. The `catch` block catches this exception and prints an error message to the console.

Another example using the `using` statement:

```cs
using (FileStream stream = new FileStream("file.txt", FileMode.Open))
{
    // code that uses the stream
    // ...
}
```

In this example, the `using` statement ensures that the `FileStream` object is properly disposed of, even if an exception is thrown while the stream is in use.

You can also have multiple `catch` blocks to handle different exception types, like this:

```cs
try
{
    // code that may throw an exception
    int x = int.Parse("abc");
    int y = int.Parse("456");
}
catch (FormatException ex)
{
    // code that will be executed if a FormatException is thrown
    Console.WriteLine("Error: " + ex.Message);
}
catch (OverflowException ex)
{
    // code that will be executed if a OverflowException is thrown
    Console.WriteLine("Error: " + ex.Message);
}
```

In this example, if the code in the try block throws a `FormatException`, the first catch block will be executed, if it throws a `OverflowException`, the second catch block will be executed.

## File Processing

File processing is the process of reading from or writing to files on a computer's file system. It can be done using the **classes** and **methods** in the System.IO namespace, which provides various **classes** for working with files, directories and other types of I/O (input/output) operations.

For example, the `File` **class** provides **methods** for creating, copying, moving, and deleting files. In contrast, the `StreamReader` and `StreamWriter` **classes** provide **methods** for reading from and writing to text files, respectively.

Here is an example of how to use the `File` **class** to read the contents of a text file:

```cs
string text = File.ReadAllText("example.txt");
Console.WriteLine(text);
```

**Question:** Where do you stored `example.txt`?

This code uses the `ReadAllText()` **method** of the `File` **class** to read the contents of the file `example.txt` and assigns the result to `text`.

Here is another example of how to use the `StreamReader` **class** to read the contents of a text file:

```cs
using (StreamReader reader = new StreamReader("example.txt"))
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
File.WriteAllText("example.txt", "Hello, World!");
```
This code uses the `WriteAllText()` **method** of the `File` **class** to write the string "Hello, World!" to the file `example.txt`.

```cs
using (StreamWriter writer = new StreamWriter("example.txt"))
{
    writer.WriteLine("Hello,");
    writer.WriteLine("World!");
}
```

This example uses the `StreamWriter` **class** to write the strings "Hello," and "World!" to the file "example.txt", each on a new line.

These are just a few examples of how to perform file processing. Still, the System.IO namespace provides many other **classes** and **methods** for working with files and directories, such as the `Directory` **class** for working with directories, the `FileInfo` and `DirectoryInfo` **classes** for working with file and directory metadata, and the `FileSystemWatcher` **class** for monitoring changes to the file system.

# Formative Assessment

Before you start, create a new branch called **01-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Create a **double array** named `nums` with the values 45.3, 67.5, -45.6, 20.34, -33.0, 45.6. Iterate over the **array** using a loop and calculate the sum of all items. Divide that sum by the total number of items in the **array** to find the average. Use **string interpolation** to display the average in the desired format.

## Task 2:

Create a **method** called `fizzBuzz` that takes in an integer `num`. Inside the **method**, check if `num` is a multiple of 3 and if so, return "Fizz". Check if `num` is a multiple of 5 and if so, return "Buzz". If `num` is a multiple of both 3 and 5, return "FizzBuzz". Create a for loop that starts at 1, ends at 15 and increments by 2 each time. Inside the for loop, call the `fizzBuzz` **method** with the current iteration **variable** `i` and print the result.

## Task 3:

Create an **array** of **integers** called `nums` with the values 21, 19, 68, 55, 42, 12. Iterate over the **array** and check if each number is odd. If it is, display it. Finally, sort the **array** from lowest to highest, then display again.

## Task 4:

Create a **method** called `isAnagram` that takes in two parameters, `someStrOne` and `someStrTwo` which are both strings. Inside the **method**, write code to check if `someStrOne` and `someStrTwo` are an anagram of each other. An anagram is a word or phrase made by rearranging the letters of another word or phrase. Compare the characters of both strings after sorting them. Return `true` if they match and `false` otherwise.

In my solution, I converted the two **strings** to **char** arrays and sorted them using the `Array.Sort` **method**. Then I compared the sorted char arrays using the `SequenceEqual` **method** and returned `true` if they match, otherwise `false`.

## Task 5:

Create a **method** called `convert` that takes in two parameters, `hours` and `minutes` which are both integers. Inside the **method**, write code to convert both `hours` and `minutes` to seconds. Multiply the number of hours by 3600 (the number of seconds in an hour) and the number of minutes by 60 (the number of seconds in a minute). Add these values together and return the total number of seconds.

## Task 6:

Create a **string variable** called `sentence` and assign the value "The anemone, the wild violet, the hepatica, and the funny little curled-up." to it. Convert the string into an array. Use a loop to count the number of occurrences of the word "the" in the array.

In my solution, I used the `String.Split` **method** to split the sentence into words by the space character.

## Task 7:

Create a **method** called `removeVowels` that takes in a parameter `word` which is a string. Inside the **method**, write code to remove all vowels from `word`. Use a regular expression or a loop to check each character of the word and remove the vowels.

To handle the edge case where the word does not contain vowels, you can check if `word` is equal to the result after removing vowels. If it is the same, you can return a message indicating that the word does not contain vowels, otherwise, return `word` without vowels.

## Task 8:

Create a **method** called `isPalindrome` that takes in a parameter `word` which is a string. Inside the **method**, write code to check if `word` is a palindrome. A palindrome is a word, phrase, or sequence that reads the same backward as forward. Compare the characters of `word` from the beginning and end of the string. If they match, continue checking until you reach the middle of the string. If all characters match, return `true`, otherwise, return `false`.

## Task 9:

Create a **method** called `isPrime` that takes in a parameter `num` which is an integer. Inside the **method**, write code to check if `num` is a prime number. A prime number is a number that is only divisible by 1 and itself. Use a loop to check if `num` is divisible by any number other than 1 and itself. If it is, return `false`, otherwise, return `true`.

## Task 10:


# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please do not your own pull request.
