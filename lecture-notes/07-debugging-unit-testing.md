# Week 07 — Debugging & Unit Testing

## Navigation

|            | Link                                    |
| ---------- | --------------------------------------- |
| ← Previous | [Week 06 — Interfaces, Composition & Enumerations](lecture-notes/06-interfaces-composition-enumerations.md) |
| → Next     | [Week 08 — Code Smells & Refactoring](lecture-notes/08-code-smells-refactoring.md)                                |

---

## 1. Debugging

**Debugging** is the process of finding and fixing errors (bugs) in your code. Bugs fall into three categories:

| Type          | When it occurs                             | Example                                    |
| ------------- | ------------------------------------------ | ------------------------------------------ |
| Syntax error  | At compile time — code won't build         | Missing `;`, misspelled keyword            |
| Runtime error | While the program is running               | Dividing by zero, `NullReferenceException` |
| Logic error   | Program runs but produces the wrong result | Using `+` instead of `*` in a calculation  |

Syntax errors are caught by the compiler before the program runs. Runtime and logic errors require the debugger.

---

### 1.1 The Visual Studio Debugger

Visual Studio includes a built-in debugger that lets you pause execution, inspect variable values, and step through code line by line.

| Tool                    | Keyboard shortcut | What it does                                          |
| ----------------------- | ----------------- | ----------------------------------------------------- |
| Start debugging         | `F5`              | Runs the program with the debugger attached           |
| Start without debugging | `Ctrl + F5`       | Runs the program normally (no debugger)               |
| Toggle breakpoint       | `F9`              | Adds or removes a breakpoint on the current line      |
| Step over               | `F10`             | Executes the current line and moves to the next       |
| Step into               | `F11`             | Steps inside a method call to debug it line by line   |
| Step out                | `Shift + F11`     | Finishes the current method and returns to the caller |
| Stop debugging          | `Shift + F5`      | Stops the running program                             |

---

### 1.2 Breakpoints

A **breakpoint** is a marker on a line of code that tells the debugger to pause execution when it reaches that line. Once paused, you can inspect variables and evaluate expressions.

To add a breakpoint, click in the grey margin to the left of a line number, or press `F9` with the cursor on that line. A red circle appears to indicate the breakpoint.

```cs
public int Divide(int a, int b)
{
    int result = a / b;   // set a breakpoint here to inspect a, b, and result
    return result;
}
```

When execution pauses at a breakpoint you can:

- Hover over a variable to see its current value
- Use the **Locals** window (**Debug > Windows > Locals**) to see all local variables
- Use the **Watch** window (**Debug > Windows > Watch**) to monitor specific expressions
- Use the **Immediate** window (**Debug > Windows > Immediate**) to evaluate expressions on the fly

---

### 1.3 Common Exceptions

| Exception                  | Common cause                                                                  |
| -------------------------- | ----------------------------------------------------------------------------- |
| `NullReferenceException`   | Calling a method or accessing a property on a `null` object                   |
| `IndexOutOfRangeException` | Accessing an array index that does not exist                                  |
| `FormatException`          | Parsing a string that is not in the expected format (e.g. `int.Parse("abc")`) |
| `DivideByZeroException`    | Dividing an integer by zero                                                   |
| `FileNotFoundException`    | Attempting to open a file that does not exist                                 |
| `StackOverflowException`   | Infinite recursion — a method calls itself without a base case                |

When an unhandled exception occurs, Visual Studio highlights the line and shows the exception type and message. Read the message carefully — it almost always tells you what went wrong and where.

---

### 1.4 Defensive Coding

Good debugging starts with writing code that anticipates problems before they occur.

```cs
// Bad — throws NullReferenceException if name is null
public string Greet(string name)
{
    return "Hello, " + name.ToUpper();
}

// Good — guard against null before use
public string Greet(string name)
{
    if (name == null)
        throw new ArgumentNullException(nameof(name), "Name cannot be null");
    return "Hello, " + name.ToUpper();
}
```

Use `nameof(parameter)` to refer to a parameter name as a string — it is refactor-safe and avoids typos.

| Key terms               |                                                                                 |
| ----------------------- | ------------------------------------------------------------------------------- |
| Bug                     | An error in code that causes incorrect or unexpected behaviour                  |
| Breakpoint              | A marker that pauses execution so you can inspect the program's state           |
| Step over (`F10`)       | Execute the current line and advance — does not enter called methods            |
| Step into (`F11`)       | Enter a called method and debug it line by line                                 |
| Locals window           | Shows all local variables and their values at the current breakpoint            |
| Watch window            | Monitors specific expressions or variables throughout a debugging session       |
| `ArgumentNullException` | Exception thrown when a required argument is `null`                             |
| `nameof`                | Returns the name of a variable, method, or property as a string — refactor-safe |

---

## 2. Unit Testing

A **unit test** is an automated test that verifies a small, isolated piece of code — typically a single method — behaves as expected. Unit tests catch regressions early, document intended behaviour, and make refactoring safer.

---

### 2.1 MSTest in Visual Studio

Visual Studio includes **MSTest**, a built-in unit testing framework. To add a test project:

**Step 1** — In **Solution Explorer**, right-click the solution and select **Add > New Project**.

**Step 2** — Select **MSTest Test Project** and give it a name that matches your main project with a `.Tests` suffix (e.g. `MyApp.Tests`).

**Step 3** — In the test project, right-click **Dependencies** and select **Add Project Reference**. Check the box for your main project so the tests can access its classes.

---

### 2.2 Anatomy of a Test

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoPositiveIntegers_ReturnsCorrectSum()
    {
        // Arrange — set up the objects and inputs needed for the test
        Calculator calc = new Calculator();

        // Act — call the method being tested
        int result = calc.Add(3, 5);

        // Assert — verify the result is what we expect
        Assert.AreEqual(8, result);
    }
}
```

The **Arrange / Act / Assert** (AAA) pattern keeps tests readable and consistent:

| Phase   | Purpose                                      |
| ------- | -------------------------------------------- |
| Arrange | Create objects, set up input data            |
| Act     | Call the method under test                   |
| Assert  | Verify the result matches the expected value |

Test method names follow the convention `MethodName_Scenario_ExpectedResult` — this makes failing tests self-documenting.

---

### 2.3 Common Assert Methods

| Method                                 | Passes when                                |
| -------------------------------------- | ------------------------------------------ |
| `Assert.AreEqual(expected, actual)`    | `expected` and `actual` are equal          |
| `Assert.AreNotEqual(expected, actual)` | `expected` and `actual` are not equal      |
| `Assert.IsTrue(condition)`             | `condition` is `true`                      |
| `Assert.IsFalse(condition)`            | `condition` is `false`                     |
| `Assert.IsNull(value)`                 | `value` is `null`                          |
| `Assert.IsNotNull(value)`              | `value` is not `null`                      |
| `Assert.ThrowsException<T>(action)`    | The action throws an exception of type `T` |

---

### 2.4 Testing a Class — Full Example

Given the following class in your main project:

```cs
public class BankAccount
{
    private decimal balance;

    public decimal Balance { get => balance; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative");
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");
        if (amount > balance)
            throw new InvalidOperationException("Insufficient funds");
        balance -= amount;
    }
}
```

A corresponding test class in `MyApp.Tests`:

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BankAccountTests
{
    // --- Constructor ---

    [TestMethod]
    public void Constructor_PositiveInitialBalance_SetsBalance()
    {
        BankAccount account = new BankAccount(100m);
        Assert.AreEqual(100m, account.Balance);
    }

    [TestMethod]
    public void Constructor_NegativeInitialBalance_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new BankAccount(-1m));
    }

    // --- Deposit ---

    [TestMethod]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        BankAccount account = new BankAccount(100m);
        account.Deposit(50m);
        Assert.AreEqual(150m, account.Balance);
    }

    [TestMethod]
    public void Deposit_ZeroAmount_ThrowsArgumentException()
    {
        BankAccount account = new BankAccount(100m);
        Assert.ThrowsException<ArgumentException>(() => account.Deposit(0m));
    }

    // --- Withdraw ---

    [TestMethod]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        BankAccount account = new BankAccount(100m);
        account.Withdraw(40m);
        Assert.AreEqual(60m, account.Balance);
    }

    [TestMethod]
    public void Withdraw_AmountExceedsBalance_ThrowsInvalidOperationException()
    {
        BankAccount account = new BankAccount(100m);
        Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(200m));
    }
}
```

---

### 2.5 Running Tests

Open the **Test Explorer** panel (**Test > Test Explorer**). Click **Run All** (or press `Ctrl + R, A`) to run every test in the solution.

| Icon              | Meaning                                                  |
| ----------------- | -------------------------------------------------------- |
| ✅ Green tick     | Test passed                                              |
| ❌ Red cross      | Test failed — click to see the expected vs actual values |
| ⚠️ Yellow warning | Test was skipped or inconclusive                         |

When a test fails, Test Explorer shows the expected value, the actual value, and the line that threw the assertion. Fix the code (or the test, if it was written incorrectly) and run again.

---

### 2.6 What Makes a Good Unit Test

- **Fast** — tests should run in milliseconds; avoid file I/O, databases, or network calls
- **Isolated** — each test should set up its own state and not depend on another test
- **Repeatable** — the same test run on the same code should always produce the same result
- **Self-documenting** — the test name should describe exactly what is being verified
- **One assertion per test** — testing one thing at a time makes failures easier to diagnose

| Key terms              |                                                                                     |
| ---------------------- | ----------------------------------------------------------------------------------- |
| Unit test              | An automated test that verifies a single, isolated piece of behaviour               |
| MSTest                 | Microsoft's built-in unit testing framework for Visual Studio                       |
| `[TestClass]`          | Attribute that marks a class as containing test methods                             |
| `[TestMethod]`         | Attribute that marks a method as an individual test                                 |
| Arrange / Act / Assert | The standard three-phase pattern for structuring a unit test                        |
| Test Explorer          | The Visual Studio panel used to run and view unit test results                      |
| Regression             | A bug introduced when changing existing code — unit tests catch these automatically |

---

## Exercises

Before you start, add a new **MSTest Test Project** to your existing solution and add a reference to your main project.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Debug a Broken Method

The following method contains at least two bugs. Create a Windows Forms application, paste the method in, and use the Visual Studio debugger (breakpoints, Step Over, Locals window) to identify and fix both bugs. Document what each bug was and how you found it in a comment block above the method.

```cs
public static double CalculateAverage(int[] numbers)
{
    int sum = 0;
    for (int i = 0; i <= numbers.Length; i++)
    {
        sum += numbers[i];
    }
    return sum / numbers.Length;
}
```

> **Hint:** set a breakpoint on the loop line and use Step Over (`F10`) to watch `i` and `sum` change each iteration. Pay attention to what happens when `i` equals `numbers.Length`.

---

### Task 2 — Unit Test a Calculator

Create a `Calculator` class in your main project with the following static methods:

| Method                       | Behaviour                                                    |
| ---------------------------- | ------------------------------------------------------------ |
| `Add(int a, int b)`          | Returns `a + b`                                              |
| `Subtract(int a, int b)`     | Returns `a - b`                                              |
| `Multiply(int a, int b)`     | Returns `a * b`                                              |
| `Divide(double a, double b)` | Returns `a / b` — throws `DivideByZeroException` if `b == 0` |

In your test project, write at least **two tests per method** following the AAA pattern and the `MethodName_Scenario_ExpectedResult` naming convention. Include at least one test for the `DivideByZeroException` case.

> **Hint:** use `Assert.ThrowsException<DivideByZeroException>(() => Calculator.Divide(10, 0))` to test that the exception is thrown.

---

### Task 3 — Unit Test a String Utility

Create a static class `StringUtils` in your main project with the following methods (you may recognise these from Week 01):

| Method                          | Behaviour                                                          |
| ------------------------------- | ------------------------------------------------------------------ |
| `RemoveVowels(string word)`     | Returns the string with all vowels removed                         |
| `IsPalindrome(string word)`     | Returns `true` if the string reads the same forwards and backwards |
| `IsAnagram(string a, string b)` | Returns `true` if `a` and `b` contain the same letters             |

In your test project, write tests that cover normal cases, edge cases (empty string, single character, mixed case), and any cases where you expect `false` or an empty result. Use the test cases from Week 01 as your starting point.

> **Hint:** write one `[TestMethod]` per scenario rather than combining multiple assertions in one test — this way a failing test tells you exactly which case broke.

---

### Task 4 — Unit Test the BankAccount Class

Using the `BankAccount` class from Section 2.4, add the following additional tests to `BankAccountTests`:

1. `Deposit_MultipleDeposits_BalanceIsCorrect` — deposit twice and verify the final balance
2. `Withdraw_ExactBalance_BalanceIsZero` — withdraw the full balance and verify it reaches zero
3. `Withdraw_NegativeAmount_ThrowsArgumentException` — verify a negative withdrawal throws `ArgumentException`
4. `Constructor_ZeroInitialBalance_BalanceIsZero` — verify a zero opening balance is valid and sets balance to zero

> **Hint:** for test 2, create an account with a known balance, withdraw exactly that amount, and assert `Balance == 0m`.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
