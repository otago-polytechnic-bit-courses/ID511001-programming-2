# Week 01 — GitHub & C# Fundamentals   

## Navigation

|                  | Link                                                                                         |
| ---------------- | -------------------------------------------------------------------------------------------- |
| GitHub Classroom | [ID511001-S1-26](https://classroom.github.com/a/Ury_53GW)                                    |
| → Next           | [Week 02 - Arrays, Lists, Dictionaries & LINQ](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/s1-26/lecture-notes/02-arrays-lists-dictionaries-and-linq.md) |

---

## 1. GitHub

In this course we use **GitHub** and **GitHub Classroom** to manage development. Click the GitHub Classroom link above to accept the assignment and create your repository.

---

### 1.1 Development Workflow

By default, GitHub Classroom creates an empty repository. Your first task is to add a `README.md` and a `.gitignore` file before writing any code.

---

### 1.2 Create a README

Click **Add file > Create new file**. Name the file `README.md`, then click **Commit new file**. You should see `README.md` appear in the `main` branch of your repository.

---

### 1.3 Create a .gitignore File

Click **Add file > Create new file** again. Name the file `.gitignore`. A template dropdown will appear on the right — select the **Visual Studio** template. Click **Commit new file**.

| Key terms    |                                                                                                 |
| ------------ | ----------------------------------------------------------------------------------------------- |
| `.gitignore` | A file that tells Git which files and folders to exclude from version control                   |
| `README.md`  | A Markdown file that describes the project — rendered automatically on the repository home page |

📖 References: [gitignore docs](https://git-scm.com/docs/gitignore) · [GitHub gitignore templates](https://github.com/github/gitignore)

---

### 1.4 Clone a Repository

Open **Git Bash** (or your preferred terminal). Clone your repository to your computer:

```bash
git clone <repository URL>
```

📖 Reference: [git-clone](https://git-scm.com/docs/git-clone)

---

## 2. C#

**C#** is a modern, object-oriented programming language developed by Microsoft. It is used to build web applications, desktop applications, mobile apps, and games. C# runs on the **.NET Framework** and supports cross-platform development through frameworks like **Xamarin** and **.NET**.

---

### 2.1 Main Method

The `Main` method is the **entry point** of every C# program — it is the first method called when the program runs.

```cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

C# 9.0 introduced **top-level statements**, which remove the need for an explicit `Main` method:

```cs
using System;

// Top-level statements — no class or Main method needed
Console.WriteLine("Hello, World!");
```

> **Note:** This course uses the traditional `Main` method approach for a clearer understanding of C# program structure.

| Key terms            |                                                                      |
| -------------------- | -------------------------------------------------------------------- |
| `Main`               | The entry point method — C# starts execution here                    |
| `static`             | The method can be called without creating an instance of its class   |
| `void`               | The method does not return a value                                   |
| Top-level statements | C# 9.0+ shorthand — omits the `Program` class and `Main` declaration |

📖 References: [Main method](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/) · [Top-level statements](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements)

---

### 2.2 Variables

A **variable** is a named storage location that holds a value of a specific type. Variables are declared by specifying a type and a name, then assigned a value with `=`.

```cs
// Declaration
int x;
string name;
bool isTrue;

// Assignment
x = 5;
name = "John Doe";
isTrue = true;

// Declaration and assignment in one line
int score = 100;
string greeting = "Hello";
```

The `var` keyword lets the compiler **infer** the type from the assigned value:

```cs
var x = 5;            // inferred as int
var name = "John Doe"; // inferred as string
var isTrue = true;     // inferred as bool
```

Use `const` to declare a value that must not change after assignment:

```cs
const int MAX_VALUE = 100;
const string COMPANY_NAME = "Acme Corp";

// MAX_VALUE = 200; // compiler error — constants cannot be reassigned
```

| Key terms |                                                                                              |
| --------- | -------------------------------------------------------------------------------------------- |
| Variable  | A named memory location holding a value that can change at runtime                           |
| `var`     | Keyword that triggers type inference — the compiler deduces the type from the assigned value |
| `const`   | Keyword that declares a compile-time constant — value cannot be changed after assignment     |

---

### 2.3 If-Else Statements

An **if-else** statement executes different code blocks depending on whether a condition is `true` or `false`.

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

Chain as many `else if` blocks as needed between the opening `if` and the final `else`.

---

### 2.4 Switch Statement

A `switch` statement selects a code block to execute based on the value of an expression.

```cs
int dayOfWeek = 3;

switch (dayOfWeek)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 3:
        Console.WriteLine("Wednesday");
        break;
    default:
        // Executes if no case matches
        Console.WriteLine("Invalid day");
        break;
}
```

`switch` also works with strings:

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

| Key terms |                                                                       |
| --------- | --------------------------------------------------------------------- |
| `switch`  | Selects one of many code blocks based on an expression's value        |
| `case`    | A labelled branch that executes when the expression matches its value |
| `break`   | Exits the `switch` — required at the end of each `case` block         |
| `default` | Optional fallback branch that runs when no `case` matches             |

---

### 2.5 Loops

C# provides four loop types for different scenarios.

**For loop** — use when you know the number of iterations in advance:

```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i); // 0, 1, 2, ..., 9
}

// Decrement
for (int i = 10; i > 0; i--)
{
    Console.WriteLine(i); // 10, 9, 8, ..., 1
}
```

Use `break` to exit a loop early:

```cs
for (int i = 0; i < 10; i++)
{
    if (i == 5) break;     // stop when i reaches 5
    Console.WriteLine(i);  // prints 0, 1, 2, 3, 4
}
```

**Foreach loop** — use when iterating over a collection:

```cs
int[] numbers = { 0, 1, 2, 3, 4 };

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

**While loop** — use when you do not know the number of iterations in advance:

```cs
int i = 0;
while (i < 10)
{
    Console.WriteLine(i); // 0, 1, 2, ..., 9
    i++;
}
```

**Do-while loop** — like `while`, but the body is guaranteed to execute at least once:

```cs
int i = 0;
do
{
    Console.WriteLine(i); // 0, 1, 2, ..., 9
    i++;
} while (i < 10);
```

| Key terms  |                                                                                        |
| ---------- | -------------------------------------------------------------------------------------- |
| `for`      | Loop that runs for a set number of iterations                                          |
| `foreach`  | Loop that iterates over every element in a collection                                  |
| `while`    | Loop that runs while a condition is `true` — condition checked before each iteration   |
| `do-while` | Like `while`, but the body runs at least once — condition checked after each iteration |
| `break`    | Immediately exits the enclosing loop                                                   |

---

### 2.6 Methods

A **method** is a named block of code that performs a specific task and can be called by name. Methods can accept parameters and return values.

**Instance methods** — operate on an instance of a class:

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

Calculator calc = new Calculator();
calc.Add(5);
Console.WriteLine(calc.GetValue()); // 5
```

**Static methods** — belong to the class itself, not an instance:

```cs
public class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

int result = MathHelper.Add(2, 3); // 5
```

**Constructors** — special methods that initialise a new instance:

```cs
public class Person
{
    public string Name { get; set; }
    public int Age  { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age  = age;
    }
}

Person person = new Person("John", 25);
Console.WriteLine($"{person.Name} is {person.Age} years old");
```

**Expression-bodied methods** — concise single-expression syntax:

```cs
public class Calculator
{
    public int  Add(int a, int b)    => a + b;
    public bool IsEven(int number)   => number % 2 == 0;
}
```

| Key terms                |                                                                                 |
| ------------------------ | ------------------------------------------------------------------------------- |
| Instance method          | A method tied to an object instance — can access instance data                  |
| Static method            | A method tied to the class itself — called without creating an instance         |
| Constructor              | A special method that runs when an object is created, used to set initial state |
| Expression-bodied member | Shorthand `=> expression` syntax for single-expression methods                  |

📖 References: [Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods) · [Constructors](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors) · [Expression-bodied members](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)

---

### 2.7 Type Conversion and Casting

**Implicit conversion** — automatic, no data loss (smaller → larger type):

```cs
int x = 5;
double y = x; // int is automatically widened to double
Console.WriteLine(y); // 5.0
```

**Explicit casting** — manual, may lose data (larger → smaller type):

```cs
double x = 5.7;
int y = (int)x; // decimal part is truncated
Console.WriteLine(y); // 5
```

**Parse / Convert** — convert strings to other types:

```cs
string numberText = "123";
int number  = int.Parse(numberText);
int number2 = Convert.ToInt32(numberText);
```

**TryParse** — safer conversion that does not throw on failure:

```cs
string input = "abc";
if (int.TryParse(input, out int result))
{
    Console.WriteLine($"Converted: {result}");
}
else
{
    Console.WriteLine("Conversion failed"); // reached here because "abc" is not a number
}
```

| Key terms           |                                                                                 |
| ------------------- | ------------------------------------------------------------------------------- |
| Implicit conversion | Automatic widening conversion — no data loss, no syntax required                |
| Explicit cast       | Manual narrowing conversion using `(type)` — may truncate data                  |
| `Parse`             | Converts a string to a target type — throws if the string is invalid            |
| `TryParse`          | Like `Parse` but returns `false` instead of throwing — preferred for user input |

---

### 2.8 Error Handling

**Error handling** anticipates and manages exceptions that may occur during execution.

**Basic try-catch:**

```cs
try
{
    int result = int.Parse("abc"); // throws FormatException
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid format: {ex.Message}");
}
catch (Exception ex)
{
    // Catch-all — place after specific catches
    Console.WriteLine($"An error occurred: {ex.Message}");
}
```

**try-catch-finally** — the `finally` block runs regardless of whether an exception occurred:

```cs
try
{
    int result = 10 / 0; // throws DivideByZeroException
}
catch (DivideByZeroException)
{
    Console.WriteLine("Cannot divide by zero");
}
finally
{
    Console.WriteLine("This always runs"); // cleanup code goes here
}
```

**`using` statement** — guarantees that a resource is disposed even if an exception is thrown:

```cs
string fileName = "example.txt";

using (var reader = new StreamReader(fileName))
{
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
} // StreamReader.Dispose() is called automatically here
```

| Key terms |                                                                                   |
| --------- | --------------------------------------------------------------------------------- |
| Exception | An object that represents an error condition at runtime                           |
| `try`     | Wraps code that might throw an exception                                          |
| `catch`   | Handles a specific type of exception — multiple `catch` blocks can be chained     |
| `finally` | Block that always executes, used for cleanup (closing files, releasing resources) |
| `using`   | Ensures a resource implementing `IDisposable` is disposed when the block exits    |

---

### 2.9 File Processing

File operations use classes from the `System.IO` namespace.

**Reading a file all at once:**

```cs
using System;
using System.IO;

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

**Reading line by line with `StreamReader`:**

```cs
try
{
    using (StreamReader reader = new StreamReader("example.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) != null) // null signals end of file
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

**Writing a file:**

```cs
// Overwrite (or create) in one call
File.WriteAllText("output.txt", "Hello, World!");

// Write multiple lines with StreamWriter
using (StreamWriter writer = new StreamWriter("output.txt"))
{
    writer.WriteLine("Line 1");
    writer.WriteLine("Line 2");
}
```

> **Note:** Use `Path.Combine()` to build file paths — it handles directory separators correctly across operating systems. Always handle `FileNotFoundException` and `UnauthorizedAccessException`.

| Key terms        |                                                                                    |
| ---------------- | ---------------------------------------------------------------------------------- |
| `System.IO`      | Namespace containing file and stream classes                                       |
| `File`           | Static class with helper methods for simple one-shot file reads and writes         |
| `StreamReader`   | Reads characters from a stream — efficient for large files or line-by-line reading |
| `StreamWriter`   | Writes characters to a stream                                                      |
| `Path.Combine()` | Builds a file path from parts using the correct separator for the current OS       |

---

### 2.10 Naming Conventions

| Identifier type          | Convention              | Example                        |
| ------------------------ | ----------------------- | ------------------------------ |
| Classes and methods      | PascalCase              | `MyClass`, `CalculateTotal`    |
| Variables and parameters | camelCase               | `userName`, `totalAmount`      |
| Constants                | PascalCase              | `MaxRetries`, `DefaultTimeout` |
| Private fields           | `_` prefix + camelCase  | `_userName`, `_isInitialized`  |
| Static fields            | PascalCase              | `DefaultValue`                 |
| Interfaces               | `I` prefix + PascalCase | `IRepository`, `ICalculator`   |

Use meaningful names that clearly describe the purpose of the variable, method, or class.

---

### 2.11 Comments and Documentation

```cs
// Single-line comment

/*
   Multi-line comment
   spans multiple lines
*/

/// <summary>
/// Calculates the area of a rectangle.
/// </summary>
/// <param name="width">The width of the rectangle</param>
/// <param name="height">The height of the rectangle</param>
/// <returns>The area of the rectangle</returns>
public double CalculateRectangleArea(double width, double height)
{
    return width * height;
}
```

> **Note:** Use comments to explain _why_ — not _what_ — the code does. Well-named variables and methods should make the _what_ self-evident.

---

## Exercises

Before you start, create a new **C# Console** application with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Array Average

Create a `double` array named `nums` with the values `45.3, 67.5, -45.6, 20.34, -33.0, 45.6`. Iterate over the array, sum all values, then divide by the array length to find the average. Display the result using string interpolation.

---

### Task 2 — FizzBuzz

Create a static method called `FizzBuzz` that takes an `int num` parameter and returns a `string`:

| Condition                 | Return value           |
| ------------------------- | ---------------------- |
| Divisible by both 3 and 5 | `"FizzBuzz"`           |
| Divisible by 3 only       | `"Fizz"`               |
| Divisible by 5 only       | `"Buzz"`               |
| None of the above         | The number as a string |

Call `FizzBuzz` for every odd number from 1 to 15 (loop increments by 2) and print each result.

---

### Task 3 — Array Operations

Create an `int` array called `nums` with the values `21, 19, 68, 55, 42, 12`. Then:

1. Iterate over the array and display only the odd numbers
2. Sort the array from lowest to highest
3. Display the sorted array

> **Hint:** `Array.Sort(nums)` sorts in place.

---

### Task 4 — Convert to Seconds

Create a static method called `ConvertToSeconds` that takes `int hours` and `int minutes` and returns the total number of seconds.

| Test case                 | Expected output |
| ------------------------- | --------------- |
| `ConvertToSeconds(2, 30)` | `9000`          |
| `ConvertToSeconds(1, 15)` | `4500`          |

---

### Task 5 — Word Count

Create a `string` variable called `sentence` and assign it `"The anemone, the wild violet, the hepatica, and the funny little curled-up ferns."`. Split the string into a word array using `String.Split()`, then count how many times the word `"the"` appears (case-insensitive).

> **Hint:** convert each word to lower case before comparing with `"the"`.

---

### Task 6 — Is Prime

Create a static method called `IsPrime` that takes an `int num` parameter and returns a `bool`. The method should return `false` for numbers less than 2, then check divisibility from 2 up to `√num`.

| Test case     | Expected output |
| ------------- | --------------- |
| `IsPrime(7)`  | `True`          |
| `IsPrime(10)` | `False`         |
| `IsPrime(2)`  | `True`          |
| `IsPrime(1)`  | `False`         |

> **Hint:** use `Math.Sqrt(num)` for the upper bound of the divisibility check.

---

### Task 7 — Remove Vowels

Create a static method called `RemoveVowels` that takes a `string word` parameter, removes all vowels (a, e, i, o, u — upper and lower case), and returns the result. Handle empty strings and strings with no vowels.

| Test case                     | Expected output |
| ----------------------------- | --------------- |
| `RemoveVowels("AEIOU")`       | `""`            |
| `RemoveVowels("bcd fgh")`     | `"bcd fgh"`     |
| `RemoveVowels("C@#omput!er")` | `"C@#mpt!r"`    |
| `RemoveVowels("")`            | `""`            |
| `RemoveVowels("aaaaa")`       | `""`            |

---

### Task 8 — Is Palindrome

Create a static method called `IsPalindrome` that takes a `string word` parameter and returns `true` if it reads the same forwards and backwards, `false` otherwise.

| Test case                               | Expected output |
| --------------------------------------- | --------------- |
| `IsPalindrome("Racecar")`               | `False`         |
| `IsPalindrome("rAceCaR".ToLower())`     | `True`          |
| `IsPalindrome("")`                      | `True`          |
| `IsPalindrome(" ")`                     | `True`          |
| `IsPalindrome("a")`                     | `True`          |
| `IsPalindrome("12321")`                 | `True`          |
| `IsPalindrome("amanaplanacanalpanama")` | `True`          |

---

### Task 9 — Is Anagram

Create a static method called `IsAnagram` that takes two `string` parameters — `firstString` and `secondString` — and returns `true` if they are anagrams of each other (same letters, different order).

| Test case                       | Expected output |
| ------------------------------- | --------------- |
| `IsAnagram("Listen", "Silent")` | `False`         |
| `IsAnagram("listen", "silent")` | `True`          |
| `IsAnagram("abc", "abcd")`      | `False`         |
| `IsAnagram("", "")`             | `True`          |
| `IsAnagram("a!b@c", "c@b!a")`   | `True`          |

> **Hint:** convert both strings to `char[]`, sort them, and compare with `SequenceEqual` from LINQ.

---

### Task 10 — Filter Countries from File

Write code that reads a file called `countries.txt` containing country names (one per line). Display only the countries that start with `'B'` or `'b'`. Handle the case where the file does not exist using proper exception handling. Do not modify `countries.txt`.

> **Hint:** create a `countries.txt` file in your project directory and populate it with country names for testing.

---

### Task 11 — Random Joke from File

Write code that reads a file called `computer-jokes.txt` containing jokes (one per line). Store the jokes in an array and use the `Random` class to select and display one joke at random each time the program runs. Handle the case where the file does not exist. Do not modify `computer-jokes.txt`.

> **Hint:** `new Random().Next(0, jokes.Length)` returns a random index within the array bounds.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions outlined in Section 2.10.
