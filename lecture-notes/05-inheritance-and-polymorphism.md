# 05: Inheritance and Polymorphism

## Inheritance

Inheritance is a mechanism that allows a new class to inherit the properties and methods of an existing class, called the base class or the parent class. The new class, called the derived class or the child class, can inherit all or some of the base class members and can also add new members or override existing members.

Inheritance is one of the fundamental principles of object-oriented programming, along with encapsulation and polymorphism. It allows you to create a hierarchy of classes, where a derived class inherits the properties and methods of its base class and can add new properties and methods or override existing ones.

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

    // virtual - derived classes can override the base class implementation
    public virtual void Eat() { /*...*/ }
    public virtual void Sleep() { /*...*/ }

    public virtual string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}

public class Dog : Animal
{
    // Adding a new field
    private string colour;

    public Dog(string name, int age, string colour) : base(name, age) // The base class's constructor
    {
        this.colour = colour;
    }

    // Overriding the base class's implementation
    public override void Eat() { /*...*/ }

    // Its own class method
    public void Bark() { /*...*/ }

    public override string Name { get => name; set => name = value; }
    public string Colour { get => colour; set => colour = value; }
}
```

In this example, the `Animal` class is the base class. It has two fields, `name` and `age`, two properties, `Name` and `Age` and two virtual methods `Eat()` and `Sleep()`. 

The `Dog` class is the derived class. It inherits the base class's fields and methods and has a new method, `Bark()`. A derived class can also override the base class's methods and properties
 using the `override` keyword.

Inheritance is a powerful concept that allows you to reuse existing code and to model relationships between classes and objects naturally and intuitively. It also enables you to create a hierarchical structure of classes that allows you to define common behaviour and characteristics in a base class and then extend or specialize that behaviour in derived classes.

## Polymorphism

Polymorphism is a mechanism that allows a single method or property to have multiple forms or behaviours. It is one of the fundamental principles of object-oriented programming, encapsulation, and inheritance.

There are two types of polymorphism:

1. Compile-time polymorphism: also known as static polymorphism or overloading. It allows different methods to have the same name but different signatures (number, type, or order of parameters). It is achieved by **method overloading**, **operator overloading**, and **constructor overloading**.
2. Run-time polymorphism: also known as dynamic polymorphism or overriding. It allows a derived class to provide a different implementation of a method already defined in its base class. It is achieved by method overriding, requiring the `virtual` and `override` keywords.

Here is an example of **polymorphism** using **method overloading**:

```cs
public class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public double Add(double x, double y)
    {
        return x + y;
    }
}
```

In this example, the `Calculator` class has two methods called `Add()` that have the same name but different signatures. The first one takes two integers as arguments and returns their sum, and the second takes two doubles as arguments and returns their sum.

Here is an example of **polymorphism** using **virtual** method and **method overriding**:

```cs
public class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}
```

In this example, the `Shape` class is the base class, and it has a virtual method `Draw()`, that prints "Drawing a shape" to the console. The `Rectangle` class and `Circle` class are derived classes. They both inherit the `Draw()` method from the base class and then override it to provide their implementation. The `Rectangle` class will print "Drawing a rectangle".

Here is an example of **polymorphism** using **abstract** classes and **method overriding**:

```cs
public abstract class Shape
{
    public abstract void Draw();
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}
```

**What is the difference?**

The `virtual` method in the original code provides a default implementation for the `Draw()` method in the `Shape` class, which can be overridden in any derived classes if necessary. The `abstract` method, i.e., `Draw()` method, does not provide any default implementation in the `Shape` class. Instead, it requires any derived classes to implement the `Draw()` method, making it mandatory for them to provide their own implementation.

# Formative Assessment

Before you start, create a new **C# Console** application called **05-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Create a base class called `Vehicle` with the `protected` fields - `brand`, `model`, and `year`. Create a constructor method that accepts all fields. Create a `virtual` method called `PrintDetails` which prints the `Vehicle`'s `brand`, `model`, and `year` using `Console.WriteLine`. 

Create a class called `Car` which derives from `Vehicle` with the private field - `numOfDoors`. Create a constructor that accepts all base class's fields, i.e., `brand`, `model`, and `year` and its own, i.e., `numOfDoors`. Create an `override` method for `PrintDetails` which prints the `Car`s `numOfDoors` using `Console.WriteLine`. 

In the `main` method, create two `Car` objects and call the `PrintDetails` method for each.

## Task 2:

Extend the `Animal` and `Dog` example to include a derived class called `Cat`. 

In the `main` method, create a `Dog` and `Cat` object and call the `Eat` and `Sleep` methods.

## Task 3:

Create a base class called `Person` with the `protected` fields - `name` and `age`. Create a constructor method that accepts all fields. Create a `virtual` method called `PrintDetails` which prints the `Person`'s `name` and `age` using `Console.WriteLine`. 

Create a class called `Student` which derives from `Person` with the private field - `grade`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `grade`. Create an `override` method for `PrintDetails` which prints the `Student`'s `name`, `age` and `grade` using `Console.WriteLine`. 

Create a class called `Lecturer` which derives from `Person` with the private field - `subject`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `subject`. Create an `override` method for `PrintDetails` which prints the `Lecturer`'s `name`, `age` and `subject` using `Console.WriteLine`. 

In the `main` method, create a `Person`, `Student` and `Lecturer` object and call the `PrintDetails` method for each.

## Task 4:

In this task, you will create a console program that prompts the user to enter a shape and return the area of that shape.

Here are steps you should consider:

1. Declare a base class called Shape that contains a `virtual` method called `CalculateArea()` that returns a `double`.
2. Declare two derived classes called `Rectangle` and `Circle` that inherit from the `Shape` base class.
3. Implement the `CalculateArea()` method in the `Rectangle` and `Circle` classes to calculate the area of a rectangle and a circle respectively.
4. Prompt the user to select a shape from the list of shapes.
5. Parse the user's input and create an instance of the selected shape.
6. Prompt the user to enter the required dimensions of the selected shape. For example, if the user selects a rectangle, the program should prompt the user to enter the length and width of the rectangle.
7. Calculate the area of the selected shape using polymorphism by calling the `CalculateArea()` method on the shape object created in step 5.
8. Output the area of the selected shape to the console.
9. Add error handling to the program to handle invalid input. If the user enters invalid input, the program should output "Invalid input. Please try again." and prompt the user to enter valid input.

```cs
// Expected output:

Please select a shape:
1. Rectangle
2. Circle

Enter your choice: 1
You selected Rectangle. Please enter the length: 5
Please enter the width: 3
The area of the rectangle is 15.

Please select a shape:
1. Rectangle
2. Circle

Enter your choice: 2
You selected Circle. Please enter the radius: 4
The area of the circle is 50.27.

Please select a shape:
1. Rectangle
2. Circle

Enter your choice: 3
Invalid input. Please try again.

Please select a shape:
1. Rectangle
2. Circle

Enter your choice: Circle
Invalid input. Please try again.
```

# Formative Assessment Submission

Push your code to your **GitHub** repository.
