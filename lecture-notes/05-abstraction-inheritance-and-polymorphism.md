# 05: Abstraction, Inheritance and Polymorphism

## Abstraction

Abstraction allows you to create a class that represents a concept or an entity in the real world, without exposing the internal workings of the class. It helps you to focus on the high-level functionality of the class, rather than the low-level details.

Here is a real-world example of abstraction:

Imagine you have a car. You can drive the car without knowing how the engine works, how the brakes work, or how the transmission works. You just need to know how to use the steering wheel, the pedals, and the gear shift. The car's internal workings are abstracted away from you.

## Inheritance

Inheritance allows a new class to inherit the properties and methods of an existing class, called the base class or the parent class. The new class, called the derived class or the child class, can inherit all or some of the base class members and can also add new members or override existing members.

Here's an example of inheritance:

```cs
public class Animal
{
    protected string name;
    protected int age;

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Virtual - derived classes can override the base class implementation
    public virtual string Eat() => "The animal is eating";
    public virtual string Sleep() => "The animal is sleeping";

    public virtual string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; } 
}
```

```cs
public class Dog : Animal
{
    // Adding a new field
    private string colour;

    public Dog(string name, int age, string colour) : base(name, age) // The base class's constructor
    {
        this.colour = colour;
    }

    // Overriding the base class's implementation
    public override string Eat() => "The dog is eating dog food";

    // Its own class method
    public string Bark() => "Woof woof!";

    public override string Name { get => name; set => name = value; }
    public string Colour { get => colour; set => colour = value; }
}
```

In this example, the `Animal` class is the base class. It has two fields, `name` and `age`, two properties, `Name` and `Age` and two virtual methods `Eat()` and `Sleep()`.

The `Dog` class is the derived class. It inherits the base class's fields and methods and has a new method, `Bark()`. A derived class can also override the base class's methods and properties using the `override` keyword.

Let us look at how to use a base and derived class in C#:

```cs
public Form1() 
{
    InitializeComponent();

    Animal animal = new Animal("Bob", 10); // Base class
    MessageBox.Show(animal.Name); // Base class's property

    Dog dog = new Dog("Fido", 5, "Brown"); // Derived class
    MessageBox.Show(dog.Colour); // Derived class's property
}
```

## Polymorphism

Polymorphism allows a single method or property to have multiple forms or behaviours. It is one of the fundamental principles of object-oriented programming, along with encapsulation and inheritance.

There are two types of polymorphism:

1. **Compile-time polymorphism**: also known as static polymorphism or overloading. It allows different methods to have the same name but different signatures (number, type, or order of parameters). It is achieved by **method overloading**, **operator overloading**, and **constructor overloading**.
2. **Run-time polymorphism**: also known as dynamic polymorphism or overriding. It allows a derived class to provide a different implementation of a method already defined in its base class. It is achieved by method overriding, requiring the `virtual` and `override` keywords.

Here is an example of **polymorphism** using **method overloading**:

```cs
public class Calculator
{
    public int Add(int x, int y) => x + y;
    public double Add(double x, double y) => x + y;
}
```

Usage in `Form1.cs`:

```cs
public Form1()
{
    InitializeComponent();

    Calculator calc = new Calculator();
    MessageBox.Show(calc.Add(5, 5).ToString()); // 10
    MessageBox.Show(calc.Add(5.5, 5.0).ToString()); // 10.5
}
```

In this example, the `Calculator` class has two methods called `Add()` that have the same name but different signatures. The first one takes two integers as arguments and returns their sum, and the second takes two doubles as arguments and returns their sum.

Here is an example of **polymorphism** using **virtual** method and **method overriding**:

```cs
public class Shape
{
    public virtual string Draw() => "Drawing a shape";
}
```

```cs
public class Rectangle : Shape
{
    public override string Draw() => "Drawing a rectangle";
}
```

```cs
public class Circle : Shape
{
    // Notice that the Draw() method is not overridden in the Circle class
}
```

Usage in `Form1.cs`:

```cs
public Form1()
{
    InitializeComponent();

    Shape shape = new Shape();
    Rectangle rectangle = new Rectangle();
    Circle circle = new Circle();
    
    MessageBox.Show(shape.Draw()); // Drawing a shape
    MessageBox.Show(rectangle.Draw()); // Drawing a rectangle
    MessageBox.Show(circle.Draw()); // Drawing a shape (inherited from base class)
}
```

In this example, the `Shape` class is the base class, and it has a `virtual` method `Draw()`, that returns "Drawing a shape". The `Rectangle` class and `Circle` class are derived classes. The `Rectangle` class overrides the `Draw()` method to provide its own implementation, while the `Circle` class inherits the base class's implementation.

Here is an example of **polymorphism** using **abstract** classes and **method overriding**:

```cs
public abstract class Shape
{
    public abstract string Draw();
}
```

```cs
public class Rectangle : Shape
{
    public override string Draw() => "Drawing a rectangle";
}
```

```cs
public class Circle : Shape
{
    public override string Draw() => "Drawing a circle";
}
```

Usage in `Form1.cs`:

```cs
public Form1()
{
    InitializeComponent();

    Rectangle rectangle = new Rectangle();
    Circle circle = new Circle();
    
    MessageBox.Show(rectangle.Draw()); // Drawing a rectangle
    MessageBox.Show(circle.Draw()); // Drawing a circle
    
    // Note: You cannot create an instance of an abstract class
    // Shape shape = new Shape(); // This would cause a compile error
}
```

You can declare `virtual` and `abstract` methods in the same class. However, you cannot declare a method as both `virtual` and `abstract`. The following code will not compile:

```cs
public abstract class Shape
{
    public virtual abstract string Draw(); // This is invalid syntax
}
```

**What is the difference?**

The `virtual` method in the original code provides a default implementation for the `Draw()` method in the `Shape` class, which can be overridden in any derived classes if necessary. The `abstract` method, i.e., `Draw()` method, does not provide any default implementation in the `Shape` class. Instead, it requires any derived classes to implement the `Draw()` method, making it mandatory for them to provide their own implementation.

# Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name.

**Important Note About AI Tools:**

Learning to use AI tools is valuable, but you **must** be aware of the following:

- Refine your prompts to get useful responses
- Don't trust AI responses blindly - verify and test the code
- Acknowledge AI tool usage in your assessment's repository **README.md** file, including what prompts you used and how you applied the responses

## Task 1:

Create a base class called `Vehicle` with the `protected` fields - `brand`, `model`, and `year`. Create a constructor method that accepts all fields. Create a `virtual` method called `DisplayDetails` that returns a `string` which displays the `Vehicle`'s `brand`, `model`, and `year`.

Create a class called `Car` which derives from `Vehicle` with the private field - `numOfDoors`. Create a constructor that accepts all base class's fields, i.e., `brand`, `model`, and `year` and its own, i.e., `numOfDoors`. Create an `override` method for `DisplayDetails` which displays the `Car`'s `numOfDoors` as well as the base class information.

In the `Form1()` constructor, create two `Car` objects. Using the `MessageBox.Show()` method, call the `DisplayDetails` method for each `Car`.

## Task 2:

Extend the `Animal` and `Dog` example to include a derived class called `Cat`. The `Cat` class should have its own field (e.g., `breed`) and should override the `Eat` method to provide a cat-specific implementation.

In the `Form1()` constructor, create a `Dog` and `Cat` object. Using the `MessageBox.Show()` method, call the `Eat` and `Sleep` methods for each `Dog` and `Cat`.

## Task 3:

Create a base class called `Person` with the `protected` fields - `name` and `age`. Create a constructor method that accepts all fields. Create a `virtual` method that returns a `string` called `DisplayDetails` which outputs the `Person`'s `name` and `age`.

Create a class called `Student` which derives from `Person` with the private field - `grade`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `grade`. Create an `override` method for `DisplayDetails` which outputs the `Student`'s `name`, `age` and `grade`.

Create a class called `Lecturer` which derives from `Person` with the private field - `subject`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `subject`. Create an `override` method for `DisplayDetails` which outputs the `Lecturer`'s `name`, `age` and `subject`.

In the `Form1()` constructor, create a `Person`, `Student` and `Lecturer` object. Using the `MessageBox.Show()` method, call the `DisplayDetails` method for each `Person`, `Student` and `Lecturer`.

## Task 4:

In this task, you will create an application that prompts the user to select a shape and returns the area of that shape.

Here are steps you should consider:

1. Declare a base class called `Shape` that contains a `virtual` method called `CalculateArea()` that returns a `double`.
2. Declare two derived classes called `Rectangle` and `Circle` that inherit from the `Shape` base class.
3. Implement the `CalculateArea()` method in the `Rectangle` and `Circle` classes to calculate the area of a rectangle and a circle respectively.
4. Use `RadioButton` controls or a `ComboBox` to allow the user to select a shape from the list of shapes.
5. Parse the user's input and create an instance of the selected shape.
6. Use `TextBox` controls to prompt the user to enter the required dimensions of the selected shape. For example, if the user selects a rectangle, the application should prompt the user to enter the length and width of the rectangle.
7. Calculate the area of the selected shape using polymorphism by calling the `CalculateArea()` method on the shape object created in step 5.
8. Output the area of the selected shape in a `Label`.
9. Add error handling to the application to handle invalid input. If the user enters invalid input, the application should output "Invalid input. Please try again." and prompt the user to enter valid input.

## Submission

Push your completed code to your **GitHub** repository. Ensure your code is well-commented and follows proper naming conventions.
