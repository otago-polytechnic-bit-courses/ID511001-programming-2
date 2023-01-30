# 02 A: Classes & Objects

A class is a blueprint for creating objects (a particular data structure), providing initial values for state (member variables or fields), and implementations of behaviour (member functions or methods). A class can be defined using the `class` keyword, followed by the class name.

Here is an example of a simple class:

```cs
class Dog
{
    // fields
    public string name;
    public int age;

    // methods
    public void Bark()
    {
        Console.WriteLine("Woof woof!");
    }
}
```

In this example, the class `Dog` has two fields, `name` and `age`, which represent the name and age of a dog, respectively. The class also has one method, `Bark()`, which causes the dog to bark by printing "Woof woof!" to the console.

To create an object from this class, you can use the `new` keyword and the class constructor like this:

```cs
Dog myDog = new Dog();
myDog.name = "Max";
myDog.age = 3;
myDog.Bark(); 
```

This code creates a new object of type `Dog` named "myDog", assigns values to its name and age fields, and then calls the `Bark()` method on the object, which causes it to bark.

Classes can also have constructors, which are special methods that are called when an object is created and can be used to initialize the object's state. For example:

```cs
class Dog
{
    // fields
    public string name;
    public int age;

    // constructor
    public Dog(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // methods
    public void Bark()
    {
        Console.WriteLine("Woof woof!");
    }
}
```

In this example, the class `Dog` has a constructor that takes two parameters, `name` and `age`, and assigns them to the corresponding fields. To create an object from this class, you can use the constructor and pass in the required parameters like this:

```cs
Dog myDog = new Dog("Max", 3);
myDog.Bark(); // Output: "Woof woof!"
```

This code creates a new object of type `Dog` named "myDog" and assigns values to its name and age fields via the constructor. Then it calls the Bark() method on the object, which causes it to bark.

# 02 B: Scoping

There are several keywords that can be used to define the scope of variables, methods, and other elements of a class or struct. The most commonly used scope keywords are:

- `public`: Elements defined as public can be accessed from anywhere within the program, both inside and outside the class or struct in which they are defined.

- `private`: Elements defined as private can only be accessed within the class or struct in which they are defined.

- `protected`: Elements defined as protected can be accessed within the class or struct in which they are defined and any derived classes.

- `internal`: Elements defined as internal can be accessed within the same assembly (a single deployment unit such as a .dll or .exe file) in which they are defined, but not from other assemblies.

- `protected internal`: Elements defined as protected internal can be accessed within the same assembly in which they are defined and from derived classes in other assemblies.

- `static`: Elements defined as static are associated with the class or struct rather than with a specific instance of the class or struct. They can be accessed without creating an instance of the class or struct.

It is also worth noting that there are other keywords, such as `abstract`, `sealed`, `override` and `virtual`, are used in the context of inheritance and polymorphism to define the behaviour of the classes and methods.

It is important to choose the right scope keyword depending on the intended use of the element in question, as it can affect the visibility, accessibility and overall design of the program.

# Formative Assessment
