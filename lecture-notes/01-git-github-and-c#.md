# Module 01: Getting Set Up with Git, GitHub and C#

## Navigation

|                   | Link                                                            |
| ----------------- | --------------------------------------------------------------- |
| GitHub Repository | [ID511001-S2-26](https://classroom.github.com/a/Ury_53GW)       |
| → Next            | [Module 02: Collections and LINQ](./02-collections-and-linq.md) |

---

## How these notes work

You'll see the same handful of markers all the way through the course, every week, so you always know what kind of thing you're looking at:

| Marker                | What it means                                                             |
| --------------------- | ------------------------------------------------------------------------- |
| **Why this matters.** | The reason the thing exists, before you see the syntax                    |
| **Design first.**     | A short planning step to do _before_ you open the code editor             |
| **Quick check.**      | A tiny, ungraded self-test. If you can't answer it, re-read the bit above |
| **Task**              | A graded exercise, placed right after the content it needs                |
| Key terms             | A glossary table at the end of each section                               |

Tasks sit right after the section that teaches them, not bundled at the end. Do them as you go. It's much easier to fix a misunderstanding on the spot than to discover it three sections later.

---

## 1. Git & GitHub

This course uses **Git** for version control and **GitHub** to hand out and collect your repositories. If you haven't used Git before: think of it as a save system for your code that also lets you look back at every previous save.

Click the GitHub Repository link above, accept the assignment, and you'll get your own empty repository.

### 1.1 Your first two files

An empty repository is a blank page, so the first thing to do is give it a `README.md` and a `.gitignore` before you write a single line of C#.

**README.md**: in your repository, click **Add file, then Create new file**, name it `README.md`, and commit it. This is the file GitHub shows on your repository's homepage. It's also where you'll log your AI tool usage each week (see the note at the start of every task list).

**.gitignore**: same process, but name it `.gitignore`. A template dropdown appears on the right of the editor, so pick **Visual Studio**. This stops build files, temporary files, and other clutter your IDE generates from ever being committed.

### 1.2 Cloning your repository

Open a terminal (Git Bash, or whatever you're comfortable with) and pull your repository down to your machine:

```bash
git clone <repository URL>
```

| Key terms    |                                                                   |
| ------------ | ----------------------------------------------------------------- |
| Repository   | A project folder tracked by Git, with a full history of changes   |
| `.gitignore` | Tells Git which files and folders to leave out of version control |
| `README.md`  | The file GitHub renders on your repository's homepage             |
| `git clone`  | Downloads a copy of a remote repository to your machine           |

References: [gitignore docs](https://git-scm.com/docs/gitignore) · [GitHub gitignore templates](https://github.com/github/gitignore) · [git-clone](https://git-scm.com/docs/git-clone)

---

## 2. The house style: naming and comments

Before any code, it's worth knowing the conventions you'll be expected to follow. It's much easier to write things correctly the first time than to rename everything later.

| Identifier type          | Convention              | Example                        |
| ------------------------ | ----------------------- | ------------------------------ |
| Classes and methods      | PascalCase              | `MyClass`, `CalculateTotal`    |
| Variables and parameters | camelCase               | `userName`, `totalAmount`      |
| Constants                | PascalCase              | `MaxRetries`, `DefaultTimeout` |
| Private fields           | `_` prefix + camelCase  | `_userName`, `_isInitialized`  |
| Interfaces               | `I` prefix + PascalCase | `IRepository`, `ICalculator`   |

Pick names that describe _what the thing is for_, not what type it is. Use `age`, not `intAge`.

```cs
// Single-line comment

/*
   Multi-line comment,
   spans several lines
*/

/// <summary>
/// Calculates the area of a rectangle.
/// </summary>
/// <param name="width">The width of the rectangle</param>
/// <param name="height">The height of the rectangle</param>
public double CalculateRectangleArea(double width, double height) => width * height;
```

A comment should explain **why**, not **what**. If your variable and method names are good, the _what_ should already be obvious just from reading the code.

---

## 3. Design first: thinking before typing

This is the first of many "design first" moments you'll see this course. The habit is simple: **before you write any code, write down, in plain English or a quick sketch, what the code needs to do, step by step.** This is sometimes called pseudocode.

Take FizzBuzz, a classic small problem you'll meet later this week:

> For each number, if it divides evenly by both 3 and 5, say "FizzBuzz". If it divides by 3 only, say "Fizz". If it divides by 5 only, say "Buzz". Otherwise, say the number.

Notice that sentence contains no C# at all: no `if`, no `%`, no braces. That's deliberate. Once the _logic_ is settled, the code almost writes itself:

```
IF number divides by 3 AND by 5 → "FizzBuzz"
ELSE IF number divides by 3     → "Fizz"
ELSE IF number divides by 5     → "Buzz"
ELSE                            → the number itself
```

Programmers who skip this step usually end up debugging their _logic_ and their _syntax_ at the same time, which is a lot harder than debugging one at a time. You'll be asked to jot down a short plan like this before several tasks in this course. It doesn't need to be formal, just enough that another person could follow your thinking.

---

## 4. C# program structure

Every C# console program needs a starting point: the `Main` method. It's the first thing that runs.

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

> Newer versions of C# allow **top-level statements**, which skip the class and `Main` declaration entirely. This course sticks with the explicit `Main` method so the structure of a program stays visible. You'll need to recognise it in every project from here on.

| Key terms |                                                                    |
| --------- | ------------------------------------------------------------------ |
| `Main`    | The entry point, where execution starts                            |
| `static`  | Belongs to the class itself, callable without creating an instance |
| `void`    | The method returns nothing                                         |

---

## 5. Variables and types

A variable is a named box that holds a value of a particular type.

```cs
// Declare, then assign
int x;
x = 5;

// Declare and assign together
int score = 100;
string greeting = "Hello";
bool isTrue = true;
```

`var` asks the compiler to work out the type for you, from whatever you assign:

```cs
var x = 5;             // int
var name = "John Doe"; // string
```

`const` locks a value in permanently. Try to reassign it and the compiler stops you:

```cs
const int MaxValue = 100;

// The next line won't compile: const values can never be reassigned
// MaxValue = 200;
```

**Quick check.** What type does the compiler infer for `var total = 19.99;`? _(It's `double`.)_

### 5.1 How do you actually decide which type to use?

This is the question people get stuck on far more than the syntax itself. Rather than memorising a list, ask yourself what the value actually represents, then work outward from that.

1. **Is it text, even a single letter or a whole sentence?** Use `string`. A single character on its own can use `char`, but this is rare in practice; a `string` of length one works fine too.
2. **Is it a yes/no or true/false state?** Use `bool`.
3. **Is it a whole number, with no fractional part, like a count or an age?** Use `int`. If it genuinely needs to be bigger than about two billion, which is rare for a course project, use `long`.
4. **Does it involve money, or anything where rounding errors would actually matter, like prices, totals, or invoices?** Use `decimal`. It's built for exact base-10 arithmetic, which is exactly what money needs.
5. **Is it any other kind of measurement with a fractional part, like a temperature, a distance, or a percentage?** Use `double`. It's the general-purpose choice for real-world numbers that aren't money.

```cs
string name = "Aroha";          // text
bool isEnrolled = true;         // yes/no
int numberOfStudents = 24;      // a count, whole number
decimal price = 19.99m;         // money, needs the m suffix
double temperature = 21.5;      // a measurement, fractional
char grade = 'A';               // a single character
```

Notice the `m` suffix on the `decimal` literal. Without it, C# assumes a number with a decimal point is a `double`, and won't let you assign it to a `decimal` variable without an explicit cast. This one detail causes the most common type-related error in this course, so it's worth remembering now.

| Type      | Use it for                                         | Example       |
| --------- | -------------------------------------------------- | ------------- |
| `string`  | Text, of any length                                | `"Aroha"`     |
| `char`    | A single character                                 | `'A'`         |
| `bool`    | A yes/no or true/false state                       | `true`        |
| `int`     | Whole numbers, everyday range                      | `24`          |
| `long`    | Whole numbers too large for `int`                  | `9000000000L` |
| `decimal` | Money, or anything needing exact decimal precision | `19.99m`      |
| `double`  | Other real-world numbers with a fractional part    | `21.5`        |

If you're genuinely unsure, `var` will tell you what the compiler decided, which is a quick way to check your own instincts while you're still building a feel for this. Hover over a `var` variable in Visual Studio and it shows you the inferred type directly in the tooltip.

| Key terms |                                                            |
| --------- | ---------------------------------------------------------- |
| Variable  | A named location holding a value that can change           |
| `var`     | Compiler infers the type from the assigned value           |
| `const`   | A value fixed at compile time, and can never be reassigned |

### 5.2 A note on strings: they don't change in place

This one catches almost everybody at least once, so it's worth flagging early: a `string` in C# is **immutable**, meaning once it's created, it can never be changed. Every method that looks like it's "changing" a string is actually building a brand new one and handing it back to you.

```cs
string name = "john";
name.ToUpper();           // does nothing useful: the result is thrown away
Console.WriteLine(name);  // still "john"

name = name.ToUpper();    // this is the fix: capture the new string it returns
Console.WriteLine(name);  // "JOHN"
```

The same applies to `Trim()`, `Replace()`, `Substring()`, and every other string method you'll use this course. None of them modify the original. They all return a new string, and if you don't assign that return value to something, it's simply lost.

```cs
string sentence = "  Hello, World!  ";
sentence.Trim();                     // the trimmed version is discarded
Console.WriteLine($"[{sentence}]");  // "[  Hello, World!  ]", unchanged

sentence = sentence.Trim();          // now it sticks
Console.WriteLine($"[{sentence}]");  // "[Hello, World!]"
```

If a task's expected output doesn't match what you're seeing, and you're working with strings, this is one of the first things worth checking: did you actually keep the result of the method call, or did you call it and throw the answer away?

| Key terms |                                                                                  |
| --------- | -------------------------------------------------------------------------------- |
| Immutable | Cannot be changed after creation; any "modification" returns a new value instead |

---

## 6. Making decisions

**if / else** runs one branch or another depending on a condition:

```cs
int x = 5, y = 10;

if (x > y)
    Console.WriteLine("x is greater than y");
else if (x == y)
    Console.WriteLine("x is equal to y");
else
    Console.WriteLine("x is less than y");
```

**switch** picks a branch based on a single value. It's handy once you have more than two or three options:

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

`break` is required at the end of each `case`, or the compiler will complain. `default` is your fallback for anything that doesn't match.

| Key terms         |                                            |
| ----------------- | ------------------------------------------ |
| `switch` / `case` | Chooses a branch based on matching a value |
| `break`           | Exits the current `switch` (or loop)       |
| `default`         | Runs when nothing else matches             |

### 6.1 A newer shorthand: switch expressions

The `switch` statement above works, but it's a lot of words (`case`, `break`, repeated `Console.WriteLine`) for what's really just "pick one value based on another." A **switch expression** does exactly that, and nothing else: it produces a single value, rather than running a block of statements.

```cs
string day = "Monday";

string message = day switch
{
    "Monday" => "Start of the work week",
    "Friday" => "TGIF!",
    _ => "Regular day"
};

Console.WriteLine(message);
```

A few differences worth noticing: the value being checked comes _before_ the `switch` keyword, each arm uses `=>` instead of `:` and `break`, and `_` replaces `default` as the catch-all. There's no falling through between cases either, so you don't need `break` at all.

Use whichever form reads more clearly for what you're doing. If you're producing one value to use immediately (like a label's text, or a category name), the expression form is usually shorter and harder to get wrong. If each branch needs to do several different things, like calling more than one method, the original `switch` statement is still the right tool.

| Key terms         |                                                                               |
| ----------------- | ----------------------------------------------------------------------------- |
| Switch expression | A `switch` that produces a single value, using `=>` instead of `case`/`break` |
| `_`               | The catch-all pattern in a switch expression, equivalent to `default`         |

---

## 7. Loops

Four flavours, each suited to a different situation.

**for** — use it when you know how many times you want to repeat:

```cs
for (int i = 0; i < 10; i++)
    Console.WriteLine(i); // 0..9
```

**foreach**: use it when you want every item in a collection and don't care about the index:

```cs
int[] numbers = { 0, 1, 2, 3, 4 };
foreach (int number in numbers)
    Console.WriteLine(number);
```

**while**: use it when you don't know in advance how many iterations you need. The condition is checked _before_ each pass:

```cs
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}
```

**do-while**: the same as `while`, but the body always runs at least once, because the condition is checked _after_:

```cs
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 10);
```

`break` exits a loop early, the same way it exits a `switch`.

| Key terms  |                                                                 |
| ---------- | --------------------------------------------------------------- |
| `for`      | Fixed number of iterations                                      |
| `foreach`  | One pass per element in a collection                            |
| `while`    | Condition checked before each pass                              |
| `do-while` | Condition checked after each pass, so the body always runs once |

**Design first.** For both tasks below, write your plan in plain English first, something like "loop through the array, add each value to a running total, then divide by the count," before you touch the keyboard.

### Task 1: Array Average

Create a `double` array named `nums` with the values `45.3, 67.5, -45.6, 20.34, -33.0, 45.6`. Loop over the array, sum the values, then divide by the array's length to get the average. Display the result with string interpolation.

### Task 2: Array Operations

Create an `int` array called `nums` with the values `21, 19, 68, 55, 42, 12`.

1. Loop over the array and display only the odd numbers
2. Sort the array from lowest to highest (`Array.Sort(nums)` sorts in place)
3. Display the sorted array

---

## 8. Converting between types

**Implicit conversion** happens automatically when there's no risk of losing data:

```cs
int x = 5;
double y = x; // widened automatically → 5.0
```

**Explicit casting** is manual, and can lose data:

```cs
double x = 5.7;
int y = (int)x; // truncated → 5
```

**Parsing strings** turns text into a number:

```cs
string numberText = "123";
int number = int.Parse(numberText);       // throws if the text isn't a valid number
```

**TryParse** is the safer version. It never throws; it just tells you whether it worked:

```cs
if (int.TryParse("abc", out int result))
    Console.WriteLine($"Converted: {result}");
else
    Console.WriteLine("Conversion failed"); // this branch runs because "abc" isn't a number
```

Prefer `TryParse` any time the input is coming from a user. You never want your program to crash just because someone fat-fingered a text box.

| Key terms           |                                                    |
| ------------------- | -------------------------------------------------- |
| Implicit conversion | Automatic, safe widening (e.g. `int` → `double`)   |
| Explicit cast       | Manual narrowing with `(type)`, may lose data      |
| `Parse`             | String → type, throws on invalid input             |
| `TryParse`          | String → type, returns `false` instead of throwing |

---

## 9. Methods

A method is a named, reusable block of code. This is where the `this` keyword and constructors first show up. Pay attention here, because you'll use this pattern in almost every class you write from now on.

**Instance methods** operate on a specific object:

```cs
public class Calculator
{
    private int _value;   // private field, only this class can touch it directly

    public void Add(int amount)
    {
        _value += amount;
    }

    public int GetValue() => _value;
}

Calculator calc = new Calculator();
calc.Add(5);
Console.WriteLine(calc.GetValue()); // 5
```

**Static methods** belong to the class itself, so no object is required:

```cs
public class MathHelper
{
    public static int Add(int a, int b) => a + b;
}

int result = MathHelper.Add(2, 3); // 5
```

**Constructors and `this`**: a constructor runs automatically when you create an object with `new`. When a constructor's parameter has the same name as a field, `this` is how you tell them apart. `this.name` means "the field that belongs to this object", while plain `name` means "the parameter that was just passed in".

```cs
public class Person
{
    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        this._name = name;   // this._name = the field, name = the parameter
        this._age = age;
    }

    public string Name { get => _name; set => _name = value; }
    public int Age { get => _age; set => _age = value; }
}

Person person = new Person("John", 25);
Console.WriteLine($"{person.Name} is {person.Age} years old");
```

You'll notice `Name` and `Age` above are **properties**, not plain fields. A private field does the actual storing, and a public property controls how the outside world reads and writes it. This pattern (a private field, plus `this` in the constructor, plus a property with `get`/`set`) is the standard shape you'll use for almost every class in this course, so it's worth getting comfortable with it now. We'll dig into _why_ it's built this way in Week 03.

**Expression-bodied methods** are a shorthand for a method that's just one expression:

```cs
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public bool IsEven(int number) => number % 2 == 0;
}
```

| Key terms                |                                                                                     |
| ------------------------ | ----------------------------------------------------------------------------------- |
| Instance method          | Tied to a specific object, can access that object's data                            |
| Static method            | Tied to the class itself, no object needed                                          |
| Constructor              | Runs automatically when an object is created with `new`                             |
| `this`                   | Refers to the current object, and disambiguates a field from a same-named parameter |
| Expression-bodied member | `=> expression` shorthand for a single-statement method                             |

**Design first.** For each task below, write down the method's **name**, its **inputs**, and its **output** before you write the body. If you can't describe those three things in one line, you're not ready to code it yet.

### Task 3: FizzBuzz

Write a static method `FizzBuzz(int num)` that returns a `string`:

| Condition            | Return value           |
| -------------------- | ---------------------- |
| Divisible by 3 and 5 | `"FizzBuzz"`           |
| Divisible by 3 only  | `"Fizz"`               |
| Divisible by 5 only  | `"Buzz"`               |
| Neither              | The number as a string |

Call it for every odd number from 1 to 15 and print each result.

### Task 4: Convert to Seconds

Write a static method `ConvertToSeconds(int hours, int minutes)` that returns the total seconds.

| Test                      | Expected |
| ------------------------- | -------- |
| `ConvertToSeconds(2, 30)` | `9000`   |
| `ConvertToSeconds(1, 15)` | `4500`   |

### Task 5: Word Count

Given `string sentence = "The anemone, the wild violet, the hepatica, and the funny little curled-up ferns.";`, split it into words with `String.Split()`, then count how many times `"the"` appears, case-insensitive.

> **Hint:** lower-case each word before comparing.

### Task 6: Is Prime

Write a static method `IsPrime(int num)` that returns `bool`. Numbers less than 2 are never prime; otherwise check divisibility from 2 up to `Math.Sqrt(num)`.

| Test          | Expected |
| ------------- | -------- |
| `IsPrime(7)`  | `True`   |
| `IsPrime(10)` | `False`  |
| `IsPrime(2)`  | `True`   |
| `IsPrime(1)`  | `False`  |

### Task 7: Remove Vowels

Write a static method `RemoveVowels(string word)` that strips out `a, e, i, o, u` (both cases) and returns the result.

| Test                          | Expected     |
| ----------------------------- | ------------ |
| `RemoveVowels("AEIOU")`       | `""`         |
| `RemoveVowels("bcd fgh")`     | `"bcd fgh"`  |
| `RemoveVowels("C@#omput!er")` | `"C@#mpt!r"` |
| `RemoveVowels("")`            | `""`         |

### Task 8: Is Palindrome

Write a static method `IsPalindrome(string word)` that returns `true` if the string reads the same forwards and backwards.

| Test                                    | Expected |
| --------------------------------------- | -------- |
| `IsPalindrome("rAceCaR".ToLower())`     | `True`   |
| `IsPalindrome("")`                      | `True`   |
| `IsPalindrome("12321")`                 | `True`   |
| `IsPalindrome("amanaplanacanalpanama")` | `True`   |

### Task 9: Is Anagram

Write a static method `IsAnagram(string firstString, string secondString)` that returns `true` if both strings contain exactly the same letters, in any order.

| Test                            | Expected |
| ------------------------------- | -------- |
| `IsAnagram("listen", "silent")` | `True`   |
| `IsAnagram("abc", "abcd")`      | `False`  |
| `IsAnagram("a!b@c", "c@b!a")`   | `True`   |

> **Hint:** convert both strings to `char[]`, sort them, and compare with LINQ's `SequenceEqual`. You'll meet LINQ properly next week, but this is a nice early taste of it.

---

## 10. Handling errors

Things go wrong at runtime: a file's missing, or a user types letters into a number field. **Exceptions** are how C# represents that.

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
    // Catch-all, always goes last
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    Console.WriteLine("This always runs"); // cleanup, regardless of outcome
}
```

`using` guarantees a resource (like a file) gets closed even if something throws while it's open. Modern C# offers two forms: the original block form, and a shorter **using declaration** that disposes the resource automatically at the end of its containing scope, without needing an extra set of braces.

```cs
// Block form: the resource is disposed exactly when this block ends
using (var reader = new StreamReader("example.txt"))
{
    string content = reader.ReadToEnd();
    Console.WriteLine(content);
} // reader.Dispose() happens automatically here

// Using declaration: shorter, and disposes at the end of the enclosing method or block instead
using var reader = new StreamReader("example.txt");
string content = reader.ReadToEnd();
Console.WriteLine(content);
// reader.Dispose() happens automatically here, at the end of the enclosing scope
```

Both are correct. This course generally prefers the using declaration, since it reads more like ordinary code, but the block form is still useful whenever you specifically want a resource closed partway through a method, before other code below it runs.

| Key terms       |                                                                  |
| --------------- | ---------------------------------------------------------------- |
| Exception       | An object representing a runtime error                           |
| `try` / `catch` | Wraps risky code and handles specific failure types              |
| `finally`       | Always runs, used for cleanup                                    |
| `using`         | Disposes a resource automatically when the block (or scope) ends |

---

## 11. Reading and writing files

File operations live in `System.IO`.

```cs
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

Line by line, with proper error handling:

```cs
try
{
    using StreamReader reader = new StreamReader("example.txt");
    string line;
    while ((line = reader.ReadLine()) != null) // null means end of file
        Console.WriteLine(line);
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found");
}
```

Writing:

```cs
File.WriteAllText("output.txt", "Hello, World!"); // overwrite or create

using StreamWriter writer = new StreamWriter("output.txt");
writer.WriteLine("Line 1");
writer.WriteLine("Line 2");
```

> Use `Path.Combine()` to build file paths. It picks the right separator for whatever OS you're on.

| Key terms                       |                                                          |
| ------------------------------- | -------------------------------------------------------- |
| `File`                          | Static helper class for simple one-shot reads and writes |
| `StreamReader` / `StreamWriter` | Read/write a stream, efficient for larger files          |
| `Path.Combine()`                | Builds a cross-platform file path                        |

**Design first.** Before either task, write down what should happen in the _unhappy path_, where the file doesn't exist. Deciding that up front, rather than discovering it when your program crashes, is the whole point of defensive coding.

### Task 10: Filter Countries from File

Create a `countries.txt` with one country name per line. Read it and display only the countries starting with `'B'` or `'b'`. Handle a missing file gracefully, and don't let the program crash.

### Task 11: Random Joke from File

Create a `computer-jokes.txt` with one joke per line. Read them into an array, then use `new Random().Next(0, jokes.Length)` to display one at random each run. Handle a missing file gracefully.

---

## Before you submit

- [ ] Every task above is complete and tested
- [ ] Code follows the naming conventions from Section 2
- [ ] `README.md` records any AI tool prompts you used and how you used the response (refining a prompt and then checking the output counts; pasting an answer in unread doesn't)
- [ ] Pushed to your GitHub repository

**A note on AI tools:** using them well is a skill in itself. That means refining your prompt until it gives you something useful, and actually reading and testing what comes back rather than trusting it blindly. Log what you asked and how you used it in your `README.md`. This is expected every week from here on, so it won't be repeated in every file, but it always applies.
