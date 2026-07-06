# Module 03: Classes, Objects and Encapsulation

## Navigation

|              | Link                                                                        |
| ------------ | --------------------------------------------------------------------------- |
| ← ← Previous | [Module 02: Collections and LINQ](./02-collections-and-linq.md)             |
| → Next       | [Module 04: Windows Forms Applications](./04-windows-forms-applications.md) |

---

_(This week uses the same recurring labels explained in Week 01: why it matters, design first, quick check, and task.)_

Everything so far has been about manipulating data C# already knows about: numbers, strings, lists of them. This week you start defining your **own** types. This is where "programming" starts to feel like modelling the real world in code, which is really what most of this course is about from here on.

---

## 1. Struct: a quick recap

You may have used a `struct` in Programming 1: a small bundle of related fields and methods.

```cs
public struct Dog
{
    public string name;
    public int age;
    public string Bark() => "Woof woof!";
}
```

## 2. Classes

A **class** looks almost identical, but it's a different kind of thing under the hood, and that difference matters more than the syntax suggests.

```cs
public class Dog
{
    public string name;
    public int age;
    public string Bark() => "Woof woof!";
}
```

|                | Struct                              | Class                                          |
| -------------- | ----------------------------------- | ---------------------------------------------- |
| Type           | Value type                          | Reference type                                 |
| Stored         | Stack / inline                      | Heap                                           |
| Copying        | Copies the whole value              | Copies a reference to the same object          |
| Inheritance    | Not supported                       | Supported (Week 06)                            |
| Can be `null`? | No (unless nullable)                | Yes                                            |
| Best for       | Small, immutable, single-value data | Larger objects with behaviour and shared state |

**Why this matters.** If you copy a `struct` into a new variable and change the copy, the original is untouched, because each variable has its own data. Copy a class reference and change it through the new variable, and you'll see the change through the _original_ variable too, because both point at the same object. This trips people up constantly, so keep it in mind whenever something behaves unexpectedly after an assignment.

Reference: [Choosing between class and struct](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct)

| Key terms      |                                                                |
| -------------- | -------------------------------------------------------------- |
| Value type     | Copied by value, so each variable owns its own data            |
| Reference type | Copied by reference, so variables can point at the same object |

---

## 3. Understanding `null`

That "Can be `null`?" row above deserves more than one line, because it's the source of the single most common runtime error you'll hit from here on: `NullReferenceException`.

A reference type variable doesn't have to point at an object at all. It can point at nothing, which C# represents with the value `null`.

```cs
Dog myDog = null;   // myDog exists, but doesn't refer to any Dog object yet

MessageBox.Show(myDog.Bark());   // throws NullReferenceException: there's no object to call Bark() on
```

This happens constantly in perfectly ordinary code: a method that's supposed to find something returns nothing because there was no match, a field is declared but never assigned before it's used, or an object is only created later in some code paths but not others. The fix isn't to avoid `null`, since it's a normal and useful value. The fix is to check for it before you use the object.

```cs
if (myDog != null)
    MessageBox.Show(myDog.Bark());
else
    MessageBox.Show("No dog to bark!");
```

Two operators make this shorter to write. The **null-conditional operator** `?.` calls a member only if the object isn't `null`, and evaluates to `null` itself if it is, instead of throwing:

```cs
string result = myDog?.Bark();   // "Woof woof!" if myDog exists, otherwise null, no exception either way
```

The **null-coalescing operator** `??` supplies a fallback value when the left-hand side is `null`:

```cs
string result = myDog?.Bark() ?? "No dog to bark!";   // falls back if myDog is null, or if Bark() itself returned null
```

**Design first.** Any time a method returns an object that might not exist (a search that might not find a match, a lookup that might come up empty), decide up front what the caller should do about that. Deciding "return `null` and let the caller check" versus "throw an exception" versus "return a default object instead" is a real design choice, not an afterthought, and it's much easier to make before you've written the method than after something crashes because of it.

### 3.1 A modern feature worth recognising: nullable reference types

New .NET projects generate with **nullable reference types** switched on by default (you may have noticed `<Nullable>enable</Nullable>` in your `.csproj` file). With this turned on, the compiler treats every reference type as _not allowed_ to be `null` unless you explicitly say otherwise with a `?`:

```cs
string name = "Aroha";     // the compiler expects this to never be null
string? nickname = null;   // the ? says "this one is allowed to be null"
```

With this feature enabled, assigning `null` to a plain `string` shows a compiler warning (not an error) as an early hint that you might be about to cause a `NullReferenceException`. It doesn't stop bugs on its own, but it does make the compiler actively point at places where a `null` might sneak through, rather than staying silent until it crashes at runtime. You don't need to switch this on for this course's tasks, but it's worth recognising the `?` syntax when you see it in other projects, since it's now the modern default.

| Key terms                           |                                                                                                    |
| ----------------------------------- | -------------------------------------------------------------------------------------------------- |
| `null`                              | A reference that points at no object                                                               |
| `NullReferenceException`            | Thrown when you try to use a member on something that's `null`                                     |
| `?.`                                | Null-conditional operator: calls a member only if the object isn't `null`                          |
| `??`                                | Null-coalescing operator: supplies a fallback value when the left-hand side is `null`              |
| Nullable reference type (`string?`) | Marks a reference type as allowed to be `null`; without the `?`, the compiler warns if it might be |

---

## 4. Design first: think in responsibilities, not code

Before you write a class, answer two questions on paper:

1. **What does this thing need to know?** → becomes your fields
2. **What does this thing need to do?** → becomes your methods

For a `Dog`, that might look like:

> Knows: name, age. Does: bark.

This is a tiny version of a technique called **CRC cards** (Class, Responsibility, Collaborator). Professional teams do this on whiteboards before writing a line of code, because it's much cheaper to redesign a sentence than to redesign a class hierarchy. You'll be asked to write this kind of one-line responsibility summary before several tasks this week, and it's genuinely worth doing even when it feels obvious. The times it _isn't_ obvious are exactly when this step saves you.

Once you've settled the responsibilities, sketching a quick **class diagram**, just a box with three sections (name, fields, methods), makes the plan visible before you type anything:

```
┌─────────────────┐
│       Dog        │
├─────────────────┤
│ - name: string   │
│ - age: int       │
├─────────────────┤
│ + Bark(): string │
└─────────────────┘
```

`-` means private, `+` means public. You'll see why that matters in Section 7.

---

## 5. Objects

A class is a blueprint; an **object** is a specific thing built from that blueprint, created with `new`.

```cs
Dog myDog = new Dog();
myDog.name = "Max";
myDog.age = 3;
MessageBox.Show(myDog.Bark()); // "Woof woof!"
```

| Key terms |                                                                     |
| --------- | ------------------------------------------------------------------- |
| Object    | A specific instance of a class, created with `new`                  |
| Field     | A variable declared inside a class, storing the object's state      |
| Method    | A function declared inside a class, defining the object's behaviour |

### 5.1 A modern shorthand: target-typed `new`

Modern C# lets you drop the type name after `new` when it's already obvious from the variable's declared type, since repeating `Dog` twice on the same line adds nothing the compiler doesn't already know:

```cs
Dog myDog = new Dog();   // the type you'll usually see written out, especially while you're learning
Dog myDog = new();       // target-typed new: identical result, less repetition
```

Both lines do exactly the same thing. This course writes out the full form in its own examples, since seeing the type twice makes it easier to keep track of what you're creating while these ideas are still new. Once you're comfortable, feel free to use the shorter form yourself; you'll see it often in other people's code.

---

## 6. Constructors and `this`

Setting every field manually after `new`, like above, is error-prone, since nothing stops you forgetting one. A **constructor** runs automatically at creation time and forces the caller to supply the values that matter.

```cs
public class Dog
{
    private string name;
    private int age;

    public Dog(string name, int age)
    {
        this.name = name;  // this.name = the field, name = the parameter
        this.age = age;
    }

    public string Bark() => "Woof woof!";
}

Dog myDog = new Dog("Max", 3);
```

`this` refers to the current object. You'll use it constantly to disambiguate a field from a parameter that shares its name. This is the standard, idiomatic way to write a constructor in C#, and it's the pattern you should default to for the rest of the course.

**`ToString()`** is a method every class inherits automatically. Override it to control how your object looks when converted to text:

```cs
public class Dog
{
    private string name;
    private int age;

    public Dog(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString() => $"Name: {name}, Age: {age}";
}

Dog myDog = new Dog("Max", 3);
MessageBox.Show(myDog.ToString()); // "Name: Max, Age: 3"
```

### Task 1: Custom Class

Pick an object from your everyday environment. Write its one-line responsibility summary first (_knows / does_), then create a class for it with at least three fields. Methods are optional but encouraged.

---

## 7. Access modifiers

Not everything inside a class should be touchable from outside it. Access modifiers control that.

| Modifier    | Accessible from                                          |
| ----------- | -------------------------------------------------------- |
| `public`    | Anywhere                                                 |
| `private`   | Only inside the class it's declared in                   |
| `protected` | The class, and any class that inherits from it (Week 06) |
| `internal`  | Anywhere in the same project                             |

> `abstract`, `sealed`, `override`, and `virtual` relate to inheritance. You'll meet those in Week 06.

---

## 8. Encapsulation

**Encapsulation** means hiding a class's internal state and exposing only a controlled, public way to interact with it. It's one of the core ideas behind object-oriented programming, and it's the direct outcome of the "knows / does" thinking from Section 4. The fields are what it _knows_, kept private, while the public members are the safe, deliberate way anything else is allowed to interact with that knowledge.

The classic analogy is a bank account: your balance isn't a public number anyone can edit. The bank exposes controlled operations (deposit, withdraw, check balance) instead.

### 8.1 The full pattern: private field + property

```cs
public class BankAccount
{
    private decimal balance;   // private, so nothing outside this class can touch it directly

    public decimal Balance
    {
        get => balance;
        set => balance = value;
    }
}
```

This is the standard shape for encapsulated data in C#: a **private field** doing the actual storing, and a **public property** controlling access to it. Notice this is exactly the pattern you've already been using since Week 01: a private field, a constructor with `this`, and a property with `get`/`set`. Now you know _why_ it's built that way.

### 8.2 Why bother with a property instead of just a public field?

Because a property can enforce rules. A public field can't stop anyone setting it to nonsense:

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
                throw new ArgumentException("Balance cannot be negative");
            balance = value;
        }
    }
}
```

```cs
BankAccount accountOne = new BankAccount();
accountOne.Balance = 1000;
MessageBox.Show($"Balance: {accountOne.Balance}"); // "Balance: 1000"

try
{
    BankAccount accountTwo = new BankAccount();
    accountTwo.Balance = -1000; // throws
}
catch (ArgumentException ex)
{
    MessageBox.Show(ex.Message); // "Balance cannot be negative"
}
```

### 8.3 The shorthand: auto-implemented properties

If a property has no validation logic, and it's just a straightforward pass-through, writing out the private field is unnecessary ceremony. C# lets you skip it with an **auto-implemented property**, which quietly creates the backing field for you:

```cs
public class Dog
{
    public string Name { get; set; }   // no explicit private field, the compiler makes one
    public int Age { get; set; }

    public Dog(string name, int age)
    {
        Name = name;   // no 'this.' needed here, since there's no local field to clash with
        Age = age;
    }
}
```

**Rule of thumb for this course:** if a property needs validation (like `Balance` above), write it out fully with a private field. If it's a simple pass-through with nothing to enforce, the auto-property shorthand is perfectly acceptable, and it's often what you'll see in professional codebases. Either way, keep fields `private` and interact with them through properties. A `public` field with no `get`/`set` at all is a code smell you'll formally learn about in Week 10.

You can also restrict a property to be read-only from outside the class, by making the setter `private`:

```cs
public string Name { get; private set; }  // readable anywhere, settable only inside this class
```

### 8.4 `readonly`: locking a field after construction

You met `const` back in Week 01, for values fixed at compile time. `readonly` is the equivalent for a field whose value isn't known until an object is actually created, but that should never change after that. It's set once, in the constructor, and never again:

```cs
public class Employee
{
    private readonly string employeeId;   // fixed once the object is built, no matter what happens later
    private string name;

    public Employee(string employeeId, string name)
    {
        this.employeeId = employeeId;   // allowed: this is the constructor
        this.name = name;
    }

    public void UpdateName(string newName)
    {
        name = newName;   // fine: name isn't readonly

        // The next line won't compile: readonly fields can't be reassigned after construction
        // employeeId = "new-id";
    }
}
```

Use `readonly` for anything that identifies or defines an object and genuinely shouldn't drift over its lifetime, like an ID, a creation date, or a fixed reference to another object it was built with. It's the same instinct as `private set`, just enforced one level earlier, directly on the field rather than through a property.

| Key terms                 |                                                                            |
| ------------------------- | -------------------------------------------------------------------------- |
| Encapsulation             | Hiding internal state, exposing a controlled public interface              |
| Property                  | A member with `get`/`set`, the standard way to expose a private field      |
| Auto-implemented property | Shorthand `{ get; set; }`, where the compiler generates the backing field  |
| `private set`             | A property readable from anywhere, but only settable inside its own class  |
| `readonly`                | A field that can only be assigned inside the constructor, then never again |

**Quick check.** Would you use a full private-field property, or an auto-property, for a `Person`'s `Email` if you needed to guarantee it always contains an `@`? _(The full version, since you need somewhere to put the validation.)_

### Task 2: Car Class

| Member                  | Type           | Access              |
| ----------------------- | -------------- | ------------------- |
| `make`                  | `string`       | `private` field     |
| `model`                 | `string`       | `private` field     |
| `year`                  | `int`          | `private` field     |
| `Make`, `Model`, `Year` | matching types | `public` properties |

Constructor accepts `make`, `model`, `year` and uses `this` to assign them. Create three `Car` objects and display each one's details via `MessageBox.Show`.

### Task 3: Employee Class

Same pattern: private fields `name` (`string`), `age` (`int`), `salary` (`decimal`), each with a public property, and a constructor taking all three. Create three `Employee` objects and display their details.

---

## 9. Static classes and members

A **static** member belongs to the class itself, not to any individual object. You never call `new` on a static class, and every member inside it must also be `static`. They're useful for grouping utility logic that doesn't need any object state.

```cs
public static class Utils
{
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool isSwapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // swap
                    isSwapped = true;
                }
            }
            if (!isSwapped) break; // already sorted, so stop early
        }
    }
}

int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
Utils.BubbleSort(arr); // no object needed, called on the class itself
```

| Key terms     |                                                                   |
| ------------- | ----------------------------------------------------------------- |
| Static class  | Cannot be instantiated, and is called directly via the class name |
| Static member | Belongs to the class itself, not to any instance                  |

---

## 10. Composing objects from other objects

Classes can contain other classes as fields. This is how you model real relationships, like a course belonging to a department, belonging to an institution.

**Design first.** Before Task 4, draw three boxes for `Institution`, `Department`, and `Course`, and connect them with arrows showing which one _contains_ which. This is the same class-diagram thinking from Section 4, just applied to more than one class at once.

```cs
public class Institution
{
    private string name, region, country;

    public Institution(string name, string region, string country)
    {
        this.name = name;
        this.region = region;
        this.country = country;
    }

    public string Name { get => name; set => name = value; }
    public string Region { get => region; set => region = value; }
    public string Country { get => country; set => country = value; }
}

public class Department
{
    private Institution institution;   // Department HAS AN Institution
    private string name;

    public Department(Institution institution, string name)
    {
        this.institution = institution;
        this.name = name;
    }

    public Institution Institution { get => institution; set => institution = value; }
    public string Name { get => name; set => name = value; }
}
```

### Task 4: Institution, Department, Course and Seeder

Create four classes in separate `.cs` files, each with a constructor using `this`, and public properties for every private field.

**`Institution`**: `name`, `region`, `country` (all `string`).

**`Department`**: `institution` (`Institution`), `name` (`string`).

**`Course`**: `department` (`Department`), `code`, `name`, `description` (`string`), `credits`, `fees` (`int`).

**`Seeder`**: a `static` class with three static `List` fields and three seed methods:

```cs
public static class Seeder
{
    private static List<Institution> institutions = new List<Institution>();
    private static List<Department> departments = new List<Department>();
    private static List<Course> courses = new List<Course>();

    public static List<Institution> SeedInstitutions()
    {
        institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
        // TODO: add two more
        return institutions;
    }

    public static List<Department> SeedDepartments()
    {
        departments.Add(new Department(institutions[0], "Information Technology"));
        // TODO: add two more
        return departments;
    }

    public static List<Course> SeedCourses()
    {
        courses.Add(new Course(departments[0], "ID511001", "Programming 2", "Advanced programming concepts", 15, 3500));
        // TODO: add two more
        return courses;
    }
}
```

In `Form1()`, call the three seed methods, then display each course's details, including its department and institution, in a `Label`.

---

## 11. Bringing LINQ back in

Now that you're building lists of your own objects, everything you learned about LINQ last week applies directly to them.

### Task 5: Product Average Price

```cs
// Product.cs
public class Product
{
    private string name;
    private double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public string Name { get => name; set => name = value; }
    public double Price { get => price; set => price = value; }
}
```

```cs
// Form1.cs
private List<Product> products;

public Form1()
{
    InitializeComponent();
    products = new List<Product>
    {
        new Product("Apple", 1.99),
        new Product("Banana", 2.99),
        new Product("Orange", 3.99)
    };
}
```

Write a LINQ query that calculates the average price of all products and displays it in a `Label`.

> **Hint:** `products.Average(p => p.Price)`.

---

## 12. Class diagrams in Visual Studio

You've been sketching class diagrams by hand this week. Visual Studio can also generate and edit them for you, which is worth knowing for bigger projects.

**Installing (if it's not already on your machine):** **Tools → Get Tools and Features → Individual components** tab → search **Class Designer** → check the box → **Modify**.

**Creating one:** right-click your project in **Solution Explorer → Add → New Item → Class Diagram**, name it, and drag classes from Solution Explorer onto the canvas.

### Task 6: Class Diagrams

Create a class diagram for **two** of the classes (or class groups) you built this week. Export or screenshot them and include them in your repository.

---

## Before you submit

- [ ] All 6 tasks complete and tested
- [ ] Every class uses private fields, a constructor with `this`, and properties (full or auto), with no bare public fields
- [ ] `README.md` updated with any AI prompts used
- [ ] Pushed to your GitHub repository
