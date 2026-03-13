# Week 06 — Composition, Interfaces & Enumerations

## Navigation

|            | Link                                                                                                          |
| ---------- | ------------------------------------------------------------------------------------------------------------- |
| ← Previous | [Week 05 — Abstraction, Inheritance & Polymorphism](lecture-notes/05-abstraction-inheritance-polymorphism.md) |
| → Next     | [Week 07 — Debugging & Unit Testing](lecture-notes/07-debugging-unit-testing.md)                              |

---

## 1. Interfaces

An **interface** is a reference type that defines a **contract** — a set of members that any implementing class must provide. An interface contains only abstract members (no implementation). This separates _what_ a class must do from _how_ it does it.

Interfaces are defined with the `interface` keyword. By convention, interface names are prefixed with `I`:

```cs
public interface IShape
{
    double Area();
    double Perimeter();
}
```

Any class that implements `IShape` must provide its own implementation of both `Area()` and `Perimeter()`.

---

### 1.1 Implementing an Interface

A class implements an interface using the `:` operator — the same syntax as inheritance:

```cs
public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width  = width;   // 'this.' required — parameter names match field names
        this.height = height;
    }

    // Both interface members must be implemented
    public double Area()      => width * height;
    public double Perimeter() => 2 * (width + height);
}
```

```cs
public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area()      => Math.PI * Math.Pow(radius, 2);
    public double Perimeter() => 2 * Math.PI * radius;
}
```

Both `Rectangle` and `Circle` satisfy the `IShape` contract — they can now be used interchangeably wherever an `IShape` is expected.

| Key terms            |                                                                                            |
| -------------------- | ------------------------------------------------------------------------------------------ |
| Interface            | A reference type that defines a contract — a list of members a class must implement        |
| Contract             | The guarantee that any class implementing the interface will provide the specified members |
| `I` prefix           | Naming convention for interfaces (e.g. `IShape`, `IInventoryItem`)                         |
| Implementing a class | A class that uses `:` to satisfy an interface contract and provides all required members   |

---

## 2. Composition

**Composition** is a design technique where a class is built from one or more other objects rather than inheriting from them. Instead of saying a class _is a_ something (inheritance), composition says a class _has a_ something.

A common guideline in object-oriented design is to **favour composition over inheritance** — it tends to produce more flexible, loosely coupled code that is easier to change.

---

### 2.1 Composition vs Inheritance

|              | Inheritance                                                   | Composition                                                            |
| ------------ | ------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Relationship | "is a" (a `Dog` is an `Animal`)                               | "has a" (a `Car` has an `Engine`)                                      |
| Coupling     | Tight — child is bound to parent's structure                  | Loose — components can be swapped independently                        |
| Reuse        | Reuses code through the class hierarchy                       | Reuses code by delegating to contained objects                         |
| Flexibility  | Harder to change base class without affecting derived classes | Components can be changed or replaced without touching the owner class |

---

### 2.2 Example

Rather than inheriting from an `Engine` class, a `Car` _contains_ one:

```cs
public class Engine
{
    public int Horsepower { get; private set; }

    public Engine(int horsepower)
    {
        Horsepower = horsepower;
    }

    public string Start() => "Engine started";
    public string Stop()  => "Engine stopped";
}

public class Car
{
    private Engine engine;   // Car HAS AN Engine — composition

    public string Make  { get; private set; }
    public string Model { get; private set; }

    public Car(string make, string model, int horsepower)
    {
        Make   = make;
        Model  = model;
        engine = new Engine(horsepower);   // Engine created and owned by Car
    }

    // Car delegates engine behaviour to the Engine object
    public string Start() => engine.Start();
    public string Stop()  => engine.Stop();

    public override string ToString() =>
        $"{Make} {Model} — {engine.Horsepower} hp";
}
```

Usage in `Form1.cs`:

```cs
Car car = new Car("Toyota", "Corolla", 140);
MessageBox.Show(car.ToString()); // "Toyota Corolla — 140 hp"
MessageBox.Show(car.Start());    // "Engine started"
MessageBox.Show(car.Stop());     // "Engine stopped"
```

The `Car` class exposes `Start()` and `Stop()` without the caller needing to know that an `Engine` exists inside. If the engine implementation ever changes, only the `Engine` class needs to be updated — `Car` and any code that uses `Car` remain untouched.

---

### 2.3 Combining Interfaces and Composition

Interfaces and composition work well together. An interface defines the contract; composition provides the implementation by delegating to specialised objects:

```cs
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[LOG] {message}");
}

public class OrderProcessor
{
    private ILogger logger;   // depends on the ILogger interface, not a concrete class

    public OrderProcessor(ILogger logger)
    {
        this.logger = logger;
    }

    public void ProcessOrder(string orderId)
    {
        // Delegate logging to whatever ILogger was injected
        logger.Log($"Processing order {orderId}");
    }
}
```

Because `OrderProcessor` depends on the `ILogger` **interface** rather than a specific class, you can swap in a different logger (file logger, database logger, etc.) without changing `OrderProcessor` at all.

| Key terms                           |                                                                                            |
| ----------------------------------- | ------------------------------------------------------------------------------------------ |
| Composition                         | Building a class by containing instances of other classes rather than inheriting from them |
| "has a" relationship                | The defining characteristic of composition — one class owns or uses another                |
| Delegation                          | Forwarding a method call from the owner class to a contained object                        |
| Favour composition over inheritance | A design guideline — prefer "has a" over "is a" for more flexible, loosely coupled code    |

---

## 3. Enumerations

An **enumeration** (`enum`) is a value type that defines a set of named constants. Enums are useful when a variable can only take one of a fixed set of values — days of the week, card suits, order statuses, and so on.

```cs
enum EDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

By default, enumerators are assigned integer values starting from 0. In the example above: `Monday = 0`, `Tuesday = 1`, …, `Sunday = 6`.

You can assign explicit values — subsequent enumerators continue incrementing from the last explicit value:

```cs
enum EDays { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
// Monday = 1, Tuesday = 2, ... Sunday = 7
```

---

### 3.1 Using an Enum

```cs
EDays today = EDays.Monday;

if (today == EDays.Friday)
    MessageBox.Show("It is Friday!");
else
    MessageBox.Show("It is not Friday!");
```

---

### 3.2 Parsing a String to an Enum

**`Enum.Parse`** — converts a string to an enum value, throws an exception if the string is invalid:

```cs
EDays today = (EDays)Enum.Parse(typeof(EDays), "Monday");
```

**`Enum.TryParse`** — safer approach, returns `false` instead of throwing:

```cs
if (Enum.TryParse("Monday", out EDays today))
{
    if (today == EDays.Friday)
        MessageBox.Show("It is Friday!");
    else
        MessageBox.Show("It is not Friday!");
}
else
{
    MessageBox.Show("Invalid day entered.");
}
```

The `out` keyword passes the parameter by reference so the method can write a value back to the caller. Unlike `ref`, the variable does not need to be initialised before being passed — the method is responsible for setting it.

| Feature        | `Enum.Parse`                          | `Enum.TryParse`                 |
| -------------- | ------------------------------------- | ------------------------------- |
| Invalid string | Throws `ArgumentException`            | Returns `false`                 |
| Return type    | The parsed enum value (cast required) | `bool`                          |
| Best for       | Trusted input                         | User input or untrusted sources |

| Key terms       |                                                                                  |
| --------------- | -------------------------------------------------------------------------------- |
| `enum`          | A value type that defines a set of named integer constants                       |
| Enumerator      | A named constant within an enum (e.g. `EDays.Monday`)                            |
| `Enum.Parse`    | Converts a string to an enum value — throws on invalid input                     |
| `Enum.TryParse` | Converts a string to an enum value — returns `false` on invalid input            |
| `out`           | Passes a parameter by reference so a method can write a value back to the caller |

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Inventory System

Build an application that simulates a simple inventory system.

**Step 1** — Create an interface called `IInventoryItem`:

| Member                | Signature             |
| --------------------- | --------------------- |
| Display item name     | `string Display()`    |
| Calculate total value | `double TotalPrice()` |

**Step 2** — Create a class `Product` that implements `IInventoryItem`:

| Member         | Detail                                                    |
| -------------- | --------------------------------------------------------- |
| `name`         | `private string`                                          |
| `price`        | `private double`                                          |
| `quantity`     | `private int`                                             |
| Constructor    | `public Product(string name, double price, int quantity)` |
| `Display()`    | Returns the product's `name`                              |
| `TotalPrice()` | Returns `price × quantity`                                |

**Step 3** — In `Form1`, create a `List<IInventoryItem>` called `inventory` and add the following products:

| Name   | Price | Quantity |
| ------ | ----- | -------- |
| Apple  | 0.99  | 10       |
| Orange | 1.99  | 5        |
| Banana | 2.99  | 2        |

**Step 4** — Create a `private void DisplayInventory()` method that iterates over `inventory` and displays each item's name and total price in a `MessageBox.Show`. Expected output:

```
Apple: 9.9
Orange: 9.95
Banana: 5.98
```

> **Hint:** use `$"{item.Display()}: {item.TotalPrice()}"` inside a loop to build the display string. Concatenate each line with `\n` for a multi-line message box.

---

### Task 2 — Favourite Day

Build an application that asks the user to enter their favourite day of the week.

**Step 1** — Declare an `enum` called `EDays` with the values: `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, `Sunday`.

**Step 2** — Read the user's input from a `TextBox` and parse it to an `EDays` value using `Enum.TryParse`.

**Step 3** — Use a `switch` statement to display a message in a `Label` based on the parsed value. For example: `"You like Fridays!"`.

**Step 4** — If `TryParse` returns `false` (invalid input), display `"Invalid input. Please try again."` and allow the user to try again.

> **Hint:** `Enum.TryParse` is case-sensitive by default — consider calling `.Trim()` on the input and capitalising the first letter (or using `ignoreCase: true` in the overload) to handle entries like `"friday"` or `" Friday "`.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
