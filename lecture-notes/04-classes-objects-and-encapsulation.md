# Week 04 — Classes, Objects & Encapsulation

## Navigation

|            | Link                                                                                                              |
| ---------- | ----------------------------------------------------------------------------------------------------------------- |
| ← Previous | [Week 03 — Windows Forms Application](lecture-notes/03-windows-forms-application.md)                              |
| → Next     | [Week 05 — Abstraction, Inheritance & Polymorphism](lecture-notes/05-abstraction-inheritance-and-polymorphism.md) |

---

## 1. Struct (Recap)

A **struct** is a data structure that groups related fields and methods together. You may have encountered structs in Programming 1. Here is a simple example:

```cs
public struct Dog
{
    public string name;
    public int    age;

    public string Bark() => "Woof woof!";
}
```

---

## 2. Class

A **class** is a blueprint for creating **objects**. It defines the initial state (fields) and behaviour (methods) that every object created from it will have. The syntax looks almost identical to a struct:

```cs
public class Dog
{
    // Fields — store the object's state
    public string name;
    public int    age;

    // Method — defines behaviour
    public string Bark() => "Woof woof!";
}
```

📖 Reference: [Choosing between class and struct](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct)

---

## 3. Struct vs Class

| Feature                   | Struct                                | Class                                     |
| ------------------------- | ------------------------------------- | ----------------------------------------- |
| Type                      | Value type                            | Reference type                            |
| Memory                    | Stack or inline                       | Heap                                      |
| Parameterless constructor | Not allowed                           | Allowed                                   |
| Inheritance               | Cannot inherit                        | Supports inheritance                      |
| Nullability               | Cannot be `null` (unless nullable)    | Can be `null`                             |
| Performance               | Efficient for small, immutable types  | More flexible, slight overhead            |
| Best for                  | Small, lightweight, single-value data | Larger, complex objects with shared state |
| Copying                   | Copies entire value                   | Copies reference only                     |

| Key terms      |                                                                                   |
| -------------- | --------------------------------------------------------------------------------- |
| Value type     | Copied when assigned — each variable holds its own data (e.g. `int`, `struct`)    |
| Reference type | Copied by reference — variables point to the same object in memory (e.g. `class`) |
| Stack          | Memory region used for local variables and parameters                             |
| Heap           | Memory region used for objects                                                    |
| Immutable      | An object whose state cannot be changed after creation                            |
| Nullable       | A type that can be assigned `null`                                                |

---

## 4. Objects

To create an **object** from a class, use the `new` keyword:

```cs
public Form1()
{
    InitializeComponent();

    Dog myDog = new Dog();   // create a new Dog object
    myDog.name = "Max";      // set the name field
    myDog.age  = 3;          // set the age field

    MessageBox.Show(myDog.Bark()); // "Woof woof!"
}
```

| Key terms |                                                                        |
| --------- | ---------------------------------------------------------------------- |
| Object    | A specific instance of a class — created with the `new` keyword        |
| Field     | A variable declared inside a class that stores the object's state      |
| Method    | A function declared inside a class that defines the object's behaviour |

---

## 5. Constructors

A **constructor** is a special method called automatically when an object is created. It is used to set the object's initial state. A constructor has the same name as the class and no return type:

```cs
public class Dog
{
    public string name;
    public int    age;

    // Constructor — called when Dog object is created with new Dog(...)
    public Dog(string name, int age)
    {
        this.name = name;  // 'this' refers to the current object (see Section 6)
        this.age  = age;
    }

    public string Bark() => "Woof woof!";
}
```

Creating an object with the constructor:

```cs
Dog myDog = new Dog("Max", 3);   // name and age set via constructor
MessageBox.Show(myDog.Bark());   // "Woof woof!"
```

> **Note:** If you see a syntax error on `new Dog("Max", 3)`, you may be using an older version of C# that requires a slightly different constructor syntax. Check with your lecturer.

---

## 6. The `this` Keyword

`this` refers to the **current object** inside a class. It is most commonly used in constructors to distinguish between a parameter and a field that share the same name:

```cs
public class Dog
{
    public string name;
    public int    age;

    public Dog(string name, int age)
    {
        this.name = name;  // this.name = the field; name = the parameter
        this.age  = age;
    }

    public string Bark()        => "Woof woof!";
    public string DisplayInfo() => $"Name: {name}, Age: {age}";

    // ToString() is called automatically when the object is converted to a string
    public override string ToString() => $"Name: {name}, Age: {age}";
}
```

---

## 7. `ToString()`

`ToString()` is a built-in method inherited by every class. Overriding it lets you control the string representation of your object:

```cs
Dog myDog = new Dog("Max", 3);
MessageBox.Show(myDog.ToString()); // "Name: Max, Age: 3"
```

---

## 8. Static Classes

A **static class** cannot be instantiated — you never call `new` on it. All its members must also be `static`. Static classes are useful for grouping utility methods and constants.

```cs
public static class Utils
{
    public static void BubbleSort(int[] arr)
    {
        int  n = arr.Length;
        bool isSwapped;

        for (int i = 0; i < n - 1; i++)
        {
            isSwapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap adjacent elements
                    int temp  = arr[j];
                    arr[j]    = arr[j + 1];
                    arr[j + 1] = temp;
                    isSwapped = true;
                }
            }

            // If no swaps occurred on this pass, the array is already sorted
            if (!isSwapped) break;
        }
    }
}
```

Calling a static method — no object required:

```cs
int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
MessageBox.Show($"Original: {string.Join(", ", arr)}");
Utils.BubbleSort(arr);
MessageBox.Show($"Sorted:   {string.Join(", ", arr)}");
```

| Key terms     |                                                                          |
| ------------- | ------------------------------------------------------------------------ |
| Static class  | A class that cannot be instantiated — called directly via the class name |
| Static member | A field or method that belongs to the class itself, not to any instance  |

---

## 9. Scoping (Access Modifiers)

Access modifiers control the visibility of fields, methods, and other class members.

| Modifier             | Accessible from                                       |
| -------------------- | ----------------------------------------------------- |
| `public`             | Anywhere — inside and outside the class               |
| `private`            | Only within the class where it is defined             |
| `protected`          | Within the class and any derived (child) classes      |
| `internal`           | Within the same assembly (`.exe` or `.dll`)           |
| `protected internal` | Same assembly, or derived classes in other assemblies |
| `static`             | Belongs to the class, not to a specific instance      |

> Other keywords — `abstract`, `sealed`, `override`, `virtual` — relate to inheritance and polymorphism, which are covered in Week 05.

Choosing the right access modifier is important for controlling visibility, enforcing good design, and preventing unintended access to internal implementation details.

---

## 10. Encapsulation

**Encapsulation** means hiding the internal implementation of a class and exposing only what is necessary through a public interface. It promotes abstraction, modularity, and data integrity — one of the core principles of object-oriented programming.

A common real-world analogy is a bank account: the balance is hidden from the public, but the bank exposes controlled operations (deposit, withdraw, view balance) through a safe interface.

---

### 10.1 Properties

In C#, encapsulation is typically achieved by making fields `private` and exposing them through `public` **properties**:

```cs
public class BankAccount
{
    private decimal balance;   // private — cannot be accessed directly from outside

    // Property — the public interface for reading and writing the balance
    public decimal Balance
    {
        get => balance;
        set => balance = value;
    }
}
```

---

### 10.2 Property Validation

Properties can include validation logic in the `set` accessor to ensure data is always in a valid state:

```cs
public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get => balance;
        set
        {
            if (value < 0)
                throw new Exception("Balance cannot be negative");
            balance = value;
        }
    }
}
```

Using the validated property:

```cs
public Form1()
{
    InitializeComponent();

    BankAccount accountOne = new BankAccount();
    accountOne.Balance = 1000;
    MessageBox.Show($"Balance: {accountOne.Balance}"); // "Balance: 1000"

    BankAccount accountTwo = new BankAccount();
    try
    {
        accountTwo.Balance = -1000;                     // throws exception
        MessageBox.Show($"Balance: {accountTwo.Balance}"); // never reached
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message); // "Balance cannot be negative"
    }
}
```

| Key terms      |                                                                                              |
| -------------- | -------------------------------------------------------------------------------------------- |
| Encapsulation  | Hiding implementation details and exposing only a controlled public interface                |
| Property       | A class member with `get` and/or `set` accessors — the standard way to expose private fields |
| `get` accessor | Reads and returns the field value                                                            |
| `set` accessor | Assigns a new value to the field — can include validation logic                              |
| `private`      | Restricts access to within the class — prevents direct external modification                 |

---

## 11. Class Diagram

A **class diagram** is a UML (Unified Modeling Language) diagram that shows the structure of a class and its relationships with other classes. It is used to plan and communicate software design.

---

### 11.1 Installing Class Designer in Visual Studio

> Lab computers have Class Designer pre-installed. For your personal machine, follow these steps.

**Step 1** — Click **Tools > Get Tools and Features...**

**Step 2** — Switch to the **Individual components** tab.

**Step 3** — Search for **Class Designer**, check the box, then click **Modify**. Installation takes a few minutes.

---

### 11.2 Creating a Class Diagram

**Step 1** — In **Solution Explorer**, right-click the project name and select **Add > New Item**.

**Step 2** — Select **Class Diagram**, give it a name, and click **Add**.

**Step 3** — Drag classes from **Solution Explorer** onto the designer canvas. There may be a brief delay before they appear.

**Step 4** — Save and close the designer when done. Reopen at any time by double-clicking the diagram file in Solution Explorer.

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Custom Class

Choose an object from your classroom or everyday environment. Create a class for it with at least **three fields**. Methods are optional but encouraged.

> **Hint:** think about what data describes the object (its fields) and what actions it can perform (its methods).

---

### Task 2 — Car Class

Create a `Car` class with the following structure, then use it in your Form:

| Member  | Type     | Access            |
| ------- | -------- | ----------------- |
| `make`  | `string` | `private` field   |
| `model` | `string` | `private` field   |
| `year`  | `int`    | `private` field   |
| `Make`  | `string` | `public` property |
| `Model` | `string` | `public` property |
| `Year`  | `int`    | `public` property |

Include a constructor that accepts `make`, `model`, and `year`. Create three `Car` objects and display their `Make`, `Model`, and `Year` in a `Label`.

---

### Task 3 — Employee Class

Create an `Employee` class with the following structure, then use it in your Form:

| Member   | Type      | Access            |
| -------- | --------- | ----------------- |
| `name`   | `string`  | `private` field   |
| `age`    | `int`     | `private` field   |
| `salary` | `decimal` | `private` field   |
| `Name`   | `string`  | `public` property |
| `Age`    | `int`     | `public` property |
| `Salary` | `decimal` | `public` property |

Include a constructor that accepts all three values. Create three `Employee` objects and display their details in a `Label`.

---

### Task 4 — Institution, Department, Course & Seeder

Create four classes in separate `.cs` files. Each class should have a constructor and public properties for all private fields.

**`Institution`** — private fields: `name` (`string`), `region` (`string`), `country` (`string`).

**`Department`** — private fields: `institution` (`Institution`), `name` (`string`).

**`Course`** — private fields: `department` (`Department`), `code` (`string`), `name` (`string`), `description` (`string`), `credits` (`int`), `fees` (`int`).

**`Seeder`** — a `static` class with three static `List` fields (`institutions`, `departments`, `courses`) and three static seed methods. Use the starter code below:

```cs
using System.Collections.Generic;

public static class Seeder
{
    private static List<Institution> institutions = new List<Institution>();
    private static List<Department>  departments  = new List<Department>();
    private static List<Course>      courses      = new List<Course>();

    public static List<Institution> SeedInstitutions()
    {
        institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
        // TODO: add two more institutions
        return institutions;
    }

    public static List<Department> SeedDepartments()
    {
        departments.Add(new Department(institutions[0], "Information Technology"));
        // TODO: add two more departments
        return departments;
    }

    public static List<Course> SeedCourses()
    {
        courses.Add(new Course(departments[0], "ID511001", "Programming 2", "Advanced programming concepts", 15, 3500));
        // TODO: add two more courses
        return courses;
    }
}
```

In `Form1.cs`, call the seed methods in the constructor, then display each course's details (including its department and institution) in a `Label`.

```cs
public partial class Form1 : Form
{
    private List<Institution> institutions;
    private List<Department>  departments;
    private List<Course>      courses;

    public Form1()
    {
        InitializeComponent();

        institutions = Seeder.SeedInstitutions();
        departments  = Seeder.SeedDepartments();
        courses      = Seeder.SeedCourses();
    }
}
```

---

### Task 5 — Product Average Price

You have been given the following `Product` class and list. Create a `Product.cs` file with the class, then add the list to `Form1.cs`:

```cs
// Product.cs
public class Product
{
    private string name;
    private double price;

    public Product(string name, double price)
    {
        this.name  = name;
        this.price = price;
    }

    public string Name  { get => name;  set => name  = value; }
    public double Price { get => price; set => price = value; }
}

// Form1.cs
private List<Product> products;

public Form1()
{
    InitializeComponent();

    products = new List<Product>
    {
        new Product("Apple",  1.99),
        new Product("Banana", 2.99),
        new Product("Orange", 3.99)
    };
}
```

Write a LINQ query that calculates and displays the **average price** of all products in a `Label`.

> **Hint:** use `products.Average(p => p.Price)`.

---

### Task 6 — Dogs from File

Create a text file called `dogs.txt` with the following content (one dog per line, fields separated by a comma):

```
Scooby-Doo,2
Astro,5
Bolt,10
Augie,6
Dixie,9
```

Read the file using `StreamReader` or `File.ReadAllLines`. For each line, split on `','`, create a `Dog` object, and add it to a list. Display the `name` and `age` of every dog in a `DataGridView`. Include error handling for missing files and invalid data.

> **Hint:** use `line.Split(',')` to separate each line into parts. Wrap the file-reading code in a `try-catch` block to handle `FileNotFoundException` and `FormatException`.

---

### Task 7 — Class Diagrams

Create a class diagram for **two** of the applications you have built in this course. Export or screenshot the diagrams and include them in your repository.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
