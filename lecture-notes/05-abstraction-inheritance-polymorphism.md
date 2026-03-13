# Week 05 — Abstraction, Inheritance & Polymorphism

## Navigation

| | Link |
|---|---|
| ← Previous | [Week 04 — Classes, Objects & Encapsulation](./lecture-notes/04-classes-objects-encapsulation.md) |
| → Next | [Week 06 — Interfaces & Enumerations](./lecture-notes/06-composition-interfaces-enumerations.md) |

---

## 1. Abstraction

**Abstraction** means modelling a concept at a high level without exposing its internal workings. You focus on *what* something does, not *how* it does it.

A familiar real-world example: you can drive a car using the steering wheel, pedals, and gear shift without knowing anything about the engine, brakes, or transmission. The internal details are **abstracted away**.

In C#, abstraction is achieved through `abstract` classes and interfaces (see Section 3.3).

---

## 2. Inheritance

**Inheritance** lets a new class (the **derived** or **child** class) acquire the fields, properties, and methods of an existing class (the **base** or **parent** class). The derived class can also add new members or override inherited ones.

```cs
public class Animal
{
    protected string name;  // protected — accessible in this class and all derived classes
    protected int    age;

    public Animal(string name, int age)
    {
        this.name = name;
        this.age  = age;
    }

    // virtual — derived classes may override these methods with their own implementation
    public virtual string Eat()  => "The animal is eating";
    public virtual string Sleep() => "The animal is sleeping";

    public virtual string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}
```

Deriving a `Dog` class from `Animal`:

```cs
public class Dog : Animal  // Dog inherits from Animal
{
    private string colour;

    // : base(name, age) calls the Animal constructor to initialise inherited fields
    public Dog(string name, int age, string colour) : base(name, age)
    {
        this.colour = colour;
    }

    // override — replaces the base class's Eat() with a Dog-specific version
    public override string Eat() => "The dog is eating dog food";

    // New method specific to Dog — Animal does not have this
    public string Bark() => "Woof woof!";

    public override string Name { get => name; set => name = value; }
    public string Colour { get => colour; set => colour = value; }
}
```

Using both classes:

```cs
public Form1()
{
    InitializeComponent();

    Animal animal = new Animal("Bob", 10);
    MessageBox.Show(animal.Name);   // "Bob"

    Dog dog = new Dog("Fido", 5, "Brown");
    MessageBox.Show(dog.Colour);    // "Brown"
    MessageBox.Show(dog.Eat());     // "The dog is eating dog food"
    MessageBox.Show(dog.Sleep());   // "The animal is sleeping" (inherited, not overridden)
}
```

| Key terms | |
|---|---|
| Base class | The parent class whose members are inherited |
| Derived class | The child class that inherits from the base class |
| `protected` | Accessible within the class and any derived classes — not accessible from outside |
| `virtual` | Marks a method or property as overridable in derived classes |
| `override` | Replaces a `virtual` method in a derived class with a new implementation |
| `: base(...)` | Calls the base class constructor from within the derived class constructor |

---

## 3. Polymorphism

**Polymorphism** allows a single method or property to behave differently depending on context. There are two types:

| Type | Also called | How it works |
|---|---|---|
| Compile-time | Static / overloading | Same method name, different parameter signatures |
| Run-time | Dynamic / overriding | Derived class provides a different implementation of a `virtual` method |

---

### 3.1 Compile-Time Polymorphism — Method Overloading

Multiple methods share the same name but have different parameter signatures. The compiler chooses the correct version at compile time:

```cs
public class Calculator
{
    // Two Add() methods — same name, different parameter types
    public int    Add(int    x, int    y) => x + y;
    public double Add(double x, double y) => x + y;
}
```

```cs
Calculator calc = new Calculator();
MessageBox.Show(calc.Add(5, 5).ToString());     // 10   — calls int version
MessageBox.Show(calc.Add(5.5, 5.0).ToString()); // 10.5 — calls double version
```

---

### 3.2 Run-Time Polymorphism — `virtual` and `override`

A base class declares a method as `virtual` (providing a default implementation). Derived classes can `override` it with their own version. If a derived class does not override, it inherits the default:

```cs
public class Shape
{
    public virtual string Draw() => "Drawing a shape";
}

public class Rectangle : Shape
{
    public override string Draw() => "Drawing a rectangle";  // replaces default
}

public class Circle : Shape
{
    // Draw() is not overridden — Circle inherits Shape's default implementation
}
```

```cs
Shape     shape     = new Shape();
Rectangle rectangle = new Rectangle();
Circle    circle    = new Circle();

MessageBox.Show(shape.Draw());     // "Drawing a shape"
MessageBox.Show(rectangle.Draw()); // "Drawing a rectangle"
MessageBox.Show(circle.Draw());    // "Drawing a shape" (inherited default)
```

---

### 3.3 Run-Time Polymorphism — `abstract` Classes

An `abstract` class cannot be instantiated directly. It can declare `abstract` methods — methods with no implementation — that every derived class **must** override:

```cs
public abstract class Shape
{
    // abstract — no implementation here; derived classes must provide one
    public abstract string Draw();
}

public class Rectangle : Shape
{
    public override string Draw() => "Drawing a rectangle";
}

public class Circle : Shape
{
    public override string Draw() => "Drawing a circle";
}
```

```cs
Rectangle rectangle = new Rectangle();
Circle    circle    = new Circle();

MessageBox.Show(rectangle.Draw()); // "Drawing a rectangle"
MessageBox.Show(circle.Draw());    // "Drawing a circle"

// Shape shape = new Shape(); // compile error — cannot instantiate an abstract class
```

---

### 3.4 `virtual` vs `abstract`

| | `virtual` | `abstract` |
|---|---|---|
| Provides a default implementation | ✓ Yes | ✗ No |
| Derived class must override | ✗ Optional | ✓ Mandatory |
| Class must be declared `abstract` | ✗ No | ✓ Yes |
| Can be instantiated directly | ✓ Yes | ✗ No |

> A method cannot be declared as both `virtual` and `abstract` — this is invalid syntax and will not compile.

| Key terms | |
|---|---|
| Polymorphism | The ability of a method or property to behave differently depending on context |
| Method overloading | Multiple methods with the same name but different parameter signatures |
| `abstract` class | A class that cannot be instantiated and may contain abstract methods |
| `abstract` method | A method with no implementation — derived classes must override it |
| Compile-time polymorphism | Method selected by the compiler based on parameter types (overloading) |
| Run-time polymorphism | Method selected at runtime based on the actual object type (overriding) |

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Vehicle and Car

Create a base class `Vehicle` with the following structure:

| Member | Detail |
|---|---|
| Fields | `protected` `brand`, `model` (`string`), `year` (`int`) |
| Constructor | Accepts `brand`, `model`, `year` |
| `DisplayDetails()` | `virtual` — returns a string showing brand, model, and year |

Create a derived class `Car` that inherits from `Vehicle`:

| Member | Detail |
|---|---|
| Field | `private int numOfDoors` |
| Constructor | Accepts `brand`, `model`, `year`, `numOfDoors` — calls `base(...)` |
| `DisplayDetails()` | `override` — returns the base class info plus the number of doors |

In `Form1()`, create two `Car` objects and display each one's `DisplayDetails()` via `MessageBox.Show`.

---

### Task 2 — Extend Animal with Cat

Extend the `Animal` and `Dog` example from the notes by adding a derived class `Cat`:

| Member | Detail |
|---|---|
| Field | At least one own field (e.g. `breed`) |
| Constructor | Accepts base class fields plus its own |
| `Eat()` | `override` — returns a cat-specific message |

In `Form1()`, create one `Dog` and one `Cat`. Use `MessageBox.Show` to call `Eat()` and `Sleep()` on each.

> **Hint:** `Sleep()` is defined in `Animal` and is not overridden — both `Dog` and `Cat` will inherit it.

---

### Task 3 — Person, Student, Lecturer

Create a base class `Person` and two derived classes:

**`Person`** — `protected` fields `name` (`string`) and `age` (`int`); constructor; `virtual DisplayDetails()` returning name and age.

**`Student`** — inherits `Person`; adds `private string grade`; `override DisplayDetails()` includes grade.

**`Lecturer`** — inherits `Person`; adds `private string subject`; `override DisplayDetails()` includes subject.

In `Form1()`, create one object of each type and display each one's `DisplayDetails()` via `MessageBox.Show`.

---

### Task 4 — Shape Area Calculator

Build a Windows Forms application that calculates the area of a shape selected by the user.

1. Declare an abstract base class `Shape` with a `virtual` method `CalculateArea()` that returns a `double`
2. Derive `Rectangle` and `Circle` from `Shape` — override `CalculateArea()` in each:
   - Rectangle: `length × width`
   - Circle: `π × radius²`
3. Use `RadioButton` controls or a `ComboBox` to let the user select a shape
4. Show the appropriate `TextBox` controls for the required dimensions (e.g. length and width for Rectangle, radius for Circle)
5. When the user confirms, create an instance of the selected shape and call `CalculateArea()` on it
6. Display the result in a `Label`
7. Add error handling — if the user enters invalid input, display `"Invalid input. Please try again."` and let them retry

> **Hint:** use `double.TryParse` to safely convert `TextBox` input. Wrap the shape selection and calculation in a `try-catch` block. Use `Math.PI` for the circle area formula.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.