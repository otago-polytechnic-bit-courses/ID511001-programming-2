# 06 A: Polymorphism

Polymorphism is a mechanism that allows a single method or property to have multiple forms or behaviours. It is one of the fundamental principles of object-oriented programming, encapsulation, and inheritance.

There are two types of polymorphism:

1. Compile-time polymorphism: also known as static polymorphism or overloading. It allows different methods to have the same name but different signatures (number, type, or order of parameters). It is achieved by method overloading, operator overloading, and constructor overloading.
2. Run-time polymorphism: also known as dynamic polymorphism or overriding. It allows a derived class to provide a different implementation of a method already defined in its base class. It is achieved by method overriding, requiring the `virtual` and `override` keywords.

Here is an example of polymorphism using method overloading:

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

Here is an example of polymorphism using method overriding:

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

In this example, the `Shape` class is the base class, and it has a virtual method `Draw()`, that prints "Drawing a shape" to the console. The `Rectangle` class and `Circle` class are derived classes. They both inherit the Draw() method from the base class and then override it to provide their implementation. The `Rectangle` class will print "Drawing a rectangle".

# 06 B: Enumerations

An enumeration (or enum for short) is a value type that is used to define a set of named constants. Enumerations are useful when you have a fixed set of values that a variable can take on, such as the days of the week or the suits in a deck of cards.

An enumeration is defined using the `enum` keyword, followed by the name of the enumeration, and a list of enumerators, which are the named constants. Each enumerator is separated by a comma, and each enumerator is assigned an integer value starting from 0 by default. Here is an example:

```cs
enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

The enumerators in the example above are Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday and their respective values will be 0, 1, 2, 3, 4, 5, 6.

You can also give explicit values to the enumerators, for example:`

```cs
enum Days { Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
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

Before you start, create a new branch called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

In this task, you will create a console program that prompts the user to enter their favourite day of the week.

Here are steps you should consider:

1. Declare an `enum` called `Days` with the following days: `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, and `Sunday`. 
2. Parse the user's input and convert it into a `Day` enum value. 
3. Use a `switch` statement to output a message to the console based on the user's input. For example, if the user enters "Friday", the program should output "You like Fridays!". 
4. Add error handling to handle an invalid input. If the user enters an invalid day, the program should output "Invalid input. Please try again." and prompt the user to enter a valid day of the week.

```cs
// Expected output:

Enter your favorite day of the week: Tuesday
You like Tuesdays!

Enter your favorite day of the week: Monday
You like Mondays!

Enter your favorite day of the week: Blah
Invalid input. Please try again.

Enter your favorite day of the week: Wednesday
You like Wednesdays!
```

## Task 1 (Advanced Task):

Modify the program to allow the user to enter multiple days of the week separated by commas. The program should output a message for each day of the week entered by the user.

## Task 2:

In this task, you will create a console program that prompts the user to select a colour and display some text in that selected colour.

Here are steps you should consider:

1. Declare an `enum` called `Colour` with the following values: `Red`, `Green`, `Blue`, and `Yellow`.
2. Declare an `enum` called `ColourHexCode` with the following hex codes for each color: Red - "#FF0000", Green - "#00FF00", Blue - "#0000FF", and Yellow - "#FFFF00".
3. Display all the available colours to the user before prompting them to select a colour.
4. Prompts the user to select a colour from the list of colors.
5. Parse the user's input and convert it into a `Colour` enum value.
6. Use a `switch` statement to set the text colour based on the user's input, and output a message to the console based on the user's input. For example, if the user selects Red, the program should set the console text colour to red and output "You selected Red with hex code #FF0000!".
7. Add error handling to the program to handle invalid input. If the user enters an invalid colour, the program should output "Invalid input. Please try again." and prompt the user to select a valid colour. 

```cs
// Expected output:

Please select a color:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: 2
You selected Green with hex code #00FF00!

Please select a color:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: Purple
Invalid input. Please try again.

Please select a color:
1. Red
2. Green
3. Blue
4. Yellow

Enter your choice: 5
Invalid input. Please try again.
```
