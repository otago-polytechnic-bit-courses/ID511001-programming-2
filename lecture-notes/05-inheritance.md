# 05: Inheritance

Lecture video can be found here - https://bit.ly/3mVhEZS

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
    public int Colour { get => colour; set => colour = value; }
}
```

In this example, the `Animal` class is the base class. It has two fields, `name` and `age`, two properties, `Name` and `Age` and two virtual methods `Eat()` and `Sleep()`. 

The `Dog` class is the derived class. It inherits the base class's fields and methods and has a new method, `Bark()`. A derived class can also override the base class's methods and properties
 using the `override` keyword.

Inheritance is a powerful concept that allows you to reuse existing code and to model relationships between classes and objects naturally and intuitively. It also enables you to create a hierarchical structure of classes that allows you to define common behaviour and characteristics in a base class and then extend or specialize that behaviour in derived classes.

# Formative Assessment

Before you start, create a new branch called **05-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Create a base class called `Vehicle` with the `private` fields - `brand`, `model`, and `year`. Create a constructor method that accepts all fields. Create a `virtual` method called `PrintDetails` which prints the `Vehicle`'s `brand`, `model`, and `year` using `Console.WriteLine`. 

Create a class called `Car` which derives from `Vehicle` with the private field - `numOfDoors`. Create a constructor that accepts all base class's fields, i.e., `brand`, `model`, and `year` and its own, i.e., `numOfDoors`. Create an `override` method for `PrintDetails` which prints the `Car`s `numOfDoors` using `Console.WriteLine`. 

In the `main` method, create two `Car` objects and call the `PrintDetails` method for each.

## Task 2:

Extend the `Animal` and `Dog` example to include a derived class called `Cat`. 

In the `main` method, create a `Dog` and `Cat` object and call the `Eat` and `Sleep` methods.

## Task 3:

Create a base class called `Person` with the `private` fields - `name` and `age`. Create a constructor method that accepts all fields. Create a `virtual` method called `PrintDetails` which prints the `Person`'s `name` and `age` using `Console.WriteLine`. 

Create a class called `Student` which derives from `Person` with the private field - `grade`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `grade`. Create an `override` method for `PrintDetails` which prints the `Student`'s `name`, `age` and `grade` using `Console.WriteLine`. 

Create a class called `Lecturer` which derives from `Person` with the private field - `subject`. Create a constructor that accepts all base class's fields, i.e., `name` and `age` and its own, i.e., `subject`. Create an `override` method for `PrintDetails` which prints the `Lecturer`'s `name`, `age` and `subject` using `Console.WriteLine`. 

In the `main` method, create a `Person`, `Student` and `Lecturer` object and call the `PrintDetails` method for each.

## Task 4:

Create a unit test for each task above. Ensure that you cover all fields and methods concerned.
