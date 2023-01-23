# 06 A: Polymorphism

Polymorphism is a mechanism that allows a single method or property to have multiple forms or behaviours. It is one of the fundamental principles of object-oriented programming, encapsulation, and inheritance.

There are two types of polymorphism:

1. Compile-time polymorphism: also known as static polymorphism or overloading. It allows different methods to have the same name but different signatures (number, type, or order of parameters). It is achieved by method overloading, operator overloading, and constructor overloading.
2. Run-time polymorphism: also known as dynamic polymorphism or overriding. It allows a derived class to provide a different implementation of a method already defined in its base class. It is achieved by method overriding, requiring the `virtual` and `override` keywords.

Here is an example of polymorphism using method overloading:

```cs
class Calculator
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

Here is an example of polymorphism using method overriding:

```cs
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}
```

In this example, the `Shape` class is the base class, and it has a virtual method `Draw()`, that prints "Drawing a shape" to the console. The `Rectangle` class and `Circle` class are derived classes. They both inherit the Draw() method from the base class and then override it to provide their implementation. The `Rectangle` class will print "Drawing a rectangle".

# 06 B: Enumerations

An enumeration (or enum for short) is a value type that is used to define a set of named constants. Enumerations are useful when you have a fixed set of values that a variable can take on, such as the days of the week or the suits in a deck of cards.

An enumeration is defined using the `enum` keyword, followed by the name of the enumeration, and a list of enumerators, which are the named constants. Each enumerator is separated by a comma, and each enumerator is assigned an integer value starting from 0 by default. Here is an example:

```cs
enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
```

The enumerators in the example above are Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday and their respective values will be 0, 1, 2, 3, 4, 5, 6.

You can also give explicit values to the enumerators, for example:`

```cs
enum Days { Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
```

In this example, Monday is assigned the value 1, and the rest of the enumerators are assigned the value of the previous enumerator plus one.

You can use an enumeration like any other variable. You can assign a value or compare it to other enumeration values. For example:

```cs
Days today = Days.Monday;
if (today == Days.Friday)
{
    Console.WriteLine("It's Friday!");
}
else
{
    Console.WriteLine("It's not Friday.");
}
```

# Formative Assessment
