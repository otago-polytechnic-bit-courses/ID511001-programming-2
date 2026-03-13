# Week 08 — Code Smells & Refactoring

## Navigation

|            | Link                                                                             |
| ---------- | -------------------------------------------------------------------------------- |
| ← Previous | [Week 07 — Debugging & Unit Testing](./lecture-notes/07-debugging-unit-testing.md) |
| → Next     | [Week 09 — Serialisation](./lecture-notes/09-serialisation.md)                     |

---

## 1. What is Refactoring?

**Refactoring** is the process of restructuring existing code without changing its external behaviour. The goal is to make code easier to read, maintain, and extend — not to add new features or fix bugs.

> "Any fool can write code that a computer can understand. Good programmers write code that humans can understand." — Martin Fowler

A good habit is to write unit tests _before_ refactoring (see Week 07). If your tests still pass after the refactor, you have not accidentally broken anything.

---

## 2. Code Smells

A **code smell** is a surface-level symptom in code that suggests a deeper problem with the design. Smells do not always mean the code is broken — they are signals that refactoring may be needed.

The smells below are organised by the OOP concept they most commonly violate.

---

## 3. Smells Related to Classes and Encapsulation

---

### 3.1 Large Class (God Object)

A class that does too much — it has too many fields, methods, and responsibilities. This violates the **Single Responsibility Principle (SRP)**: a class should have only one reason to change.

**Smell:**

```cs
// OrderManager does everything — pricing, validation, email, and reporting
public class OrderManager
{
    public void PlaceOrder(Order order) { ... }
    public double CalculateDiscount(Order order) { ... }
    public bool ValidateOrder(Order order) { ... }
    public void SendConfirmationEmail(Order order) { ... }
    public void GenerateInvoice(Order order) { ... }
    public void LogOrder(Order order) { ... }
    public List<Order> GetOrderHistory(int customerId) { ... }
}
```

**Refactored** — split responsibilities into focused classes:

```cs
public class OrderService        { public void PlaceOrder(Order order) { ... } }
public class DiscountCalculator  { public double Calculate(Order order) { ... } }
public class OrderValidator      { public bool Validate(Order order) { ... } }
public class EmailService        { public void SendConfirmation(Order order) { ... } }
public class InvoiceGenerator    { public void Generate(Order order) { ... } }
public class OrderRepository     { public List<Order> GetHistory(int id) { ... } }
```

Each class now has a single, clear responsibility and a single reason to change.

---

### 3.2 Data Class

A class that contains only fields and properties with no meaningful behaviour. Data classes often indicate that behaviour that belongs to the class has been placed elsewhere.

**Smell:**

```cs
public class Rectangle
{
    public double Width  { get; set; }
    public double Height { get; set; }
}

// Behaviour that belongs to Rectangle is sitting in a utility class instead
public static class GeometryUtils
{
    public static double Area(Rectangle r)      => r.Width * r.Height;
    public static double Perimeter(Rectangle r) => 2 * (r.Width + r.Height);
}
```

**Refactored** — move behaviour into the class that owns the data:

```cs
public class Rectangle
{
    public double Width  { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width  = width;
        Height = height;
    }

    public double Area()      => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}
```

---

### 3.3 Public Fields

Exposing fields directly as `public` bypasses encapsulation — any code can change the value without validation or notification.

**Smell:**

```cs
public class BankAccount
{
    public decimal Balance;   // anyone can set this to any value, including negative
}
```

**Refactored** — replace public fields with properties that can enforce rules:

```cs
public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get => balance;
        private set   // only this class can change the balance directly
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative");
            balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit must be positive");
        Balance += amount;
    }
}
```

| Key terms                             |                                                                                  |
| ------------------------------------- | -------------------------------------------------------------------------------- |
| Single Responsibility Principle (SRP) | A class should have only one reason to change                                    |
| God Object                            | A class that knows too much or does too much — a Large Class taken to an extreme |
| Data class                            | A class with only fields and properties and no meaningful behaviour              |
| Encapsulation                         | Hiding internal state behind a controlled public interface (see Week 04)         |

---

## 4. Smells Related to Inheritance

---

### 4.1 Refused Bequest

A derived class inherits methods from its parent but does not use them — or worse, overrides them to do nothing or throw an exception. This usually means inheritance is being used when it should not be.

**Smell:**

```cs
public class Bird
{
    public virtual void Fly() => Console.WriteLine("Flying");
    public virtual void Sing() => Console.WriteLine("Singing");
}

public class Penguin : Bird
{
    // Penguins cannot fly — this override does nothing, which is misleading
    public override void Fly() => throw new NotSupportedException("Penguins cannot fly");
}
```

**Refactored** — use an interface to represent only the capabilities a class actually has:

```cs
public interface IFlyable { void Fly(); }
public interface ISingable { void Sing(); }

public class Sparrow : IFlyable, ISingable
{
    public void Fly()  => Console.WriteLine("Flying");
    public void Sing() => Console.WriteLine("Singing");
}

public class Penguin : ISingable
{
    // Penguin implements only what it can actually do — no misleading Fly() method
    public void Sing() => Console.WriteLine("Honking");
}
```

---

### 4.2 Inappropriate Intimacy Through Inheritance

A derived class reaches into the protected internals of its base class directly rather than using the public interface. This creates tight coupling — changing the base class risks breaking the derived class.

**Smell:**

```cs
public class Animal
{
    protected string name;   // derived classes access this field directly
    protected int    age;
}

public class Dog : Animal
{
    public string GetInfo() => $"{name} is {age} years old";   // direct field access
}
```

**Refactored** — expose data through properties and access them via the public interface:

```cs
public class Animal
{
    public string Name { get; protected set; }
    public int    Age  { get; protected set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age  = age;
    }
}

public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) { }

    // Uses the public interface — not tightly coupled to field names or storage
    public string GetInfo() => $"{Name} is {Age} years old";
}
```

---

### 4.3 Deep Inheritance Hierarchy

Inheritance chains longer than two or three levels become hard to follow and fragile — a change anywhere in the chain can have unexpected effects throughout.

**Smell:**

```cs
// Six levels deep — hard to reason about what Vehicle actually does
class Vehicle { }
class MotorVehicle   : Vehicle { }
class Car            : MotorVehicle { }
class Sedan          : Car { }
class LuxurySedan    : Sedan { }
class ElectricLuxury : LuxurySedan { }
```

**Refactored** — flatten the hierarchy and use composition for variable behaviour:

```cs
public interface IDriveable   { void Drive(); }
public interface IElectric    { int BatteryLevel { get; } }

public class Car : IDriveable
{
    public string Make  { get; }
    public string Model { get; }
    public bool   IsLuxury { get; }

    public Car(string make, string model, bool isLuxury = false)
    {
        Make     = make;
        Model    = model;
        IsLuxury = isLuxury;
    }

    public void Drive() => Console.WriteLine($"Driving {Make} {Model}");
}

public class ElectricCar : Car, IElectric
{
    public int BatteryLevel { get; private set; }

    public ElectricCar(string make, string model, int batteryLevel)
        : base(make, model)
    {
        BatteryLevel = batteryLevel;
    }
}
```

| Key terms                           |                                                                                                    |
| ----------------------------------- | -------------------------------------------------------------------------------------------------- |
| Refused Bequest                     | A derived class that ignores or invalidates inherited behaviour from its parent                    |
| Inappropriate Intimacy              | A class that directly accesses the internal details of another class                               |
| Deep hierarchy                      | An inheritance chain so long that it becomes difficult to reason about or maintain                 |
| Liskov Substitution Principle (LSP) | A derived class should be usable wherever its base class is expected, without surprising behaviour |

---

## 5. Smells Related to Methods

---

### 5.1 Long Method

A method that is too long to read in one screen. Long methods usually contain multiple distinct concerns that should be separate methods.

**Smell:**

```cs
private void button1_Click(object sender, EventArgs e)
{
    // Validate input
    if (string.IsNullOrWhiteSpace(textBoxName.Text))
    {
        MessageBox.Show("Name is required");
        return;
    }
    if (!int.TryParse(textBoxAge.Text, out int age) || age < 0 || age > 150)
    {
        MessageBox.Show("Enter a valid age between 0 and 150");
        return;
    }

    // Build the employee object
    Employee employee = new Employee(textBoxName.Text, age);

    // Save to list and update display
    employees.Add(employee);
    listBox1.Items.Clear();
    foreach (Employee emp in employees)
        listBox1.Items.Add(emp.ToString());

    // Clear the form
    textBoxName.Text = "";
    textBoxAge.Text  = "";
}
```

**Refactored** — extract each concern into its own private method:

```cs
private void button1_Click(object sender, EventArgs e)
{
    if (!ValidateInput(out int age)) return;

    Employee employee = CreateEmployee(age);
    AddEmployee(employee);
    ClearForm();
}

private bool ValidateInput(out int age)
{
    age = 0;
    if (string.IsNullOrWhiteSpace(textBoxName.Text))
    {
        MessageBox.Show("Name is required");
        return false;
    }
    if (!int.TryParse(textBoxAge.Text, out age) || age < 0 || age > 150)
    {
        MessageBox.Show("Enter a valid age between 0 and 150");
        return false;
    }
    return true;
}

private Employee CreateEmployee(int age) =>
    new Employee(textBoxName.Text, age);

private void AddEmployee(Employee employee)
{
    employees.Add(employee);
    listBox1.Items.Clear();
    foreach (Employee emp in employees)
        listBox1.Items.Add(emp.ToString());
}

private void ClearForm()
{
    textBoxName.Text = "";
    textBoxAge.Text  = "";
}
```

The `button1_Click` handler now reads like a summary — you can understand the flow at a glance without reading every detail.

---

### 5.2 Duplicate Code

The same (or very similar) logic appears in more than one place. If it needs to change, every copy must be found and updated — easy to miss one.

**Smell:**

```cs
private void buttonCelsius_Click(object sender, EventArgs e)
{
    if (!double.TryParse(textBoxTemp.Text, out double temp))
    {
        MessageBox.Show("Invalid temperature");
        return;
    }
    double result = (temp - 32) * 5 / 9;
    labelResult.Text = $"{result:F2} °C";
}

private void buttonFahrenheit_Click(object sender, EventArgs e)
{
    if (!double.TryParse(textBoxTemp.Text, out double temp))
    {
        MessageBox.Show("Invalid temperature");  // duplicated
        return;
    }
    double result = (temp * 9 / 5) + 32;
    labelResult.Text = $"{result:F2} °F";
}
```

**Refactored** — extract the shared parsing logic:

```cs
private bool TryGetTemperature(out double temp)
{
    if (!double.TryParse(textBoxTemp.Text, out temp))
    {
        MessageBox.Show("Invalid temperature");
        return false;
    }
    return true;
}

private void buttonCelsius_Click(object sender, EventArgs e)
{
    if (!TryGetTemperature(out double temp)) return;
    labelResult.Text = $"{(temp - 32) * 5 / 9:F2} °C";
}

private void buttonFahrenheit_Click(object sender, EventArgs e)
{
    if (!TryGetTemperature(out double temp)) return;
    labelResult.Text = $"{(temp * 9 / 5) + 32:F2} °F";
}
```

---

### 5.3 Magic Numbers and Strings

Unnamed literal values scattered through code. When the value needs to change, it must be hunted down in every place it appears — and the original intent of the value is unclear.

**Smell:**

```cs
public double CalculatePay(double hoursWorked)
{
    if (hoursWorked > 40)
        return (40 * 18.50) + ((hoursWorked - 40) * 18.50 * 1.5);
    return hoursWorked * 18.50;
}
```

**Refactored** — replace literals with named constants:

```cs
private const double HourlyRate       = 18.50;
private const double StandardHours    = 40.0;
private const double OvertimeMultiplier = 1.5;

public double CalculatePay(double hoursWorked)
{
    if (hoursWorked > StandardHours)
    {
        double overtimeHours = hoursWorked - StandardHours;
        return (StandardHours * HourlyRate) + (overtimeHours * HourlyRate * OvertimeMultiplier);
    }
    return hoursWorked * HourlyRate;
}
```

| Key terms             |                                                                                 |
| --------------------- | ------------------------------------------------------------------------------- |
| Long method           | A method that is too long — contains multiple concerns that should be extracted |
| Extract method        | The refactoring technique of moving a block of code into its own named method   |
| Duplicate code        | The same logic appearing in more than one place — a maintenance liability       |
| Magic number / string | An unnamed literal value in code whose meaning is not immediately clear         |
| `const`               | A compile-time constant — the correct place to store named literal values       |

---

## 6. Smells Related to Coupling

---

### 6.1 Feature Envy

A method in one class that is more interested in the data of another class than its own — it calls many methods or accesses many properties of a different class.

**Smell:**

```cs
public class OrderPrinter
{
    public string PrintSummary(Order order)
    {
        // This method is entirely about Order's data — it belongs in Order, not here
        string customerName = order.Customer.Name;
        string address      = order.Customer.Address;
        decimal total       = order.Items.Sum(i => i.Price * i.Quantity);
        return $"Order for {customerName} at {address}. Total: {total:C}";
    }
}
```

**Refactored** — move the method to the class whose data it uses:

```cs
public class Order
{
    public Customer        Customer { get; }
    public List<OrderItem> Items    { get; }

    // Behaviour belongs here — Order knows its own data best
    public string PrintSummary()
    {
        decimal total = Items.Sum(i => i.Price * i.Quantity);
        return $"Order for {Customer.Name} at {Customer.Address}. Total: {total:C}";
    }
}
```

---

### 6.2 Primitive Obsession

Using primitive types (`string`, `int`, `double`) to represent concepts that warrant their own class. This scatters related validation and behaviour across the codebase.

**Smell:**

```cs
public class Employee
{
    public string Name;
    public string Email;      // any string — no validation
    public string PhoneNumber; // any string — no format enforced
}
```

**Refactored** — introduce small value classes:

```cs
public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!value.Contains("@"))
            throw new ArgumentException("Invalid email address");
        Value = value;
    }

    public override string ToString() => Value;
}

public class Employee
{
    public string Name  { get; }
    public Email  Email { get; }   // validation now lives in Email, not scattered

    public Employee(string name, Email email)
    {
        Name  = name;
        Email = email;
    }
}
```

| Key terms           |                                                                                       |
| ------------------- | ------------------------------------------------------------------------------------- |
| Feature Envy        | A method that accesses the data of another class more than its own                    |
| Primitive Obsession | Overusing primitive types for concepts that deserve their own class                   |
| Coupling            | The degree to which two classes depend on each other — lower is better                |
| Value object        | A small class representing a concept (e.g. `Email`, `Money`) with built-in validation |

---

## 7. Refactoring Safely

Refactoring without a safety net risks introducing new bugs. Follow this process:

1. **Write tests first** — ensure the current behaviour is covered by unit tests (Week 07) before making any changes
2. **Make one change at a time** — rename, extract, or move one thing, then run the tests
3. **Keep changes small** — a refactoring commit should contain only restructuring, not new features or bug fixes
4. **Use IDE tooling** — Visual Studio's built-in refactoring shortcuts reduce the chance of manual errors

| Shortcut      | Action                                                        |
| ------------- | ------------------------------------------------------------- |
| `F2`          | Rename a symbol everywhere it is used                         |
| `Ctrl + R, M` | Extract the selected code into a new method                   |
| `Ctrl + R, E` | Encapsulate a field (wraps it in a property automatically)    |
| `Ctrl + .`    | Show quick fix / refactoring suggestions for the current line |

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name. For each task, write at least two unit tests (using the MSTest project from Week 07) that confirm the behaviour is unchanged after your refactor.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Identify the Smells

Read the following class and list every code smell you can identify. For each smell, name it, explain why it is a problem, and state which refactoring technique you would apply.

```cs
public class StudentManager
{
    public string name;
    public int age;
    public double grade;
    public string email;

    public void ProcessStudent()
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Name required");
            return;
        }
        if (age < 0 || age > 120)
        {
            MessageBox.Show("Invalid age");
            return;
        }
        if (!email.Contains("@"))
        {
            MessageBox.Show("Invalid email");
            return;
        }

        double gpa = grade / 100.0 * 4.0;
        string letter;
        if (gpa >= 3.7)       letter = "A";
        else if (gpa >= 3.3)  letter = "A-";
        else if (gpa >= 3.0)  letter = "B+";
        else if (gpa >= 2.7)  letter = "B";
        else                  letter = "C";

        string report = $"Student: {name}\nAge: {age}\nEmail: {email}\nGPA: {gpa:F2}\nGrade: {letter}";
        MessageBox.Show(report);

        string log = $"[{DateTime.Now}] Processed {name}";
        File.AppendAllText("log.txt", log + Environment.NewLine);
    }
}
```

> **Hint:** look for violations of SRP, public fields, long method, magic numbers, and feature envy.

---

### Task 2 — Refactor a Large Class

The `ShoppingCart` class below has too many responsibilities. Refactor it by splitting it into at least three focused classes. Write unit tests before refactoring to confirm the behaviour, then run them again after to confirm nothing broke.

```cs
public class ShoppingCart
{
    private List<(string Name, double Price, int Quantity)> items = new();

    public void AddItem(string name, double price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (price < 0)    throw new ArgumentException("Price cannot be negative");
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive");
        items.Add((name, price, quantity));
    }

    public double CalculateSubtotal() =>
        items.Sum(i => i.Price * i.Quantity);

    public double CalculateDiscount()
    {
        double subtotal = CalculateSubtotal();
        if (subtotal > 200) return subtotal * 0.10;
        if (subtotal > 100) return subtotal * 0.05;
        return 0;
    }

    public double CalculateTotal() =>
        CalculateSubtotal() - CalculateDiscount();

    public string GenerateReceipt()
    {
        string lines = string.Join("\n", items.Select(i =>
            $"{i.Name} x{i.Quantity} @ {i.Price:C} = {i.Price * i.Quantity:C}"));
        return $"{lines}\n\nSubtotal: {CalculateSubtotal():C}\nDiscount: {CalculateDiscount():C}\nTotal: {CalculateTotal():C}";
    }
}
```

> **Hint:** consider a `CartValidator`, a `PricingCalculator`, and a `ReceiptGenerator` as your three classes.

---

### Task 3 — Replace Magic Numbers

The method below contains several magic numbers and a long conditional chain. Refactor it to use named constants and extract the grade-lookup logic into its own method.

```cs
public string GetLetterGrade(double score)
{
    if (score >= 90) return "A";
    if (score >= 80) return "B";
    if (score >= 70) return "C";
    if (score >= 60) return "D";
    return "F";
}

public double CalculateBonus(double salary, int yearsOfService)
{
    if (yearsOfService >= 10) return salary * 0.15;
    if (yearsOfService >= 5)  return salary * 0.10;
    return salary * 0.05;
}
```

> **Hint:** use `private const double` for the thresholds and multipliers. Consider a dictionary for the grade boundaries.

---

### Task 4 — Fix Refused Bequest

The class below contains a Refused Bequest. Refactor it using interfaces so that each class only exposes the capabilities it actually supports. Write unit tests that verify each class's behaviour before and after the refactor.

```cs
public class Shape
{
    public virtual double Area()      => 0;
    public virtual double Perimeter() => 0;
    public virtual void   Rotate(double degrees) => throw new NotSupportedException();
    public virtual void   Scale(double factor)   => throw new NotSupportedException();
}

public class Circle : Shape
{
    private double radius;
    public Circle(double radius) { this.radius = radius; }
    public override double Area()      => Math.PI * radius * radius;
    public override double Perimeter() => 2 * Math.PI * radius;
    public override void   Scale(double factor) { radius *= factor; }
    // Rotate is not overridden — circles look the same when rotated
}

public class Rectangle : Shape
{
    private double width, height, rotationDegrees;
    public Rectangle(double w, double h) { width = w; height = h; }
    public override double Area()      => width * height;
    public override double Perimeter() => 2 * (width + height);
    public override void   Rotate(double degrees) { rotationDegrees += degrees; }
    public override void   Scale(double factor) { width *= factor; height *= factor; }
}
```

> **Hint:** introduce `IScalable` and `IRotatable` interfaces. `Circle` implements `IScalable` but not `IRotatable`. `Rectangle` implements both.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
