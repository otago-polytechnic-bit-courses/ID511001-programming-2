# 05: Interfaces, Enumerations and Functional Programming

## Interfaces

An interface is a reference type that contains only abstract members. It defines a contract that a class must implement. An interface can contain properties and methods. An interface does not provide any implementation of the members it defines—it merely specifies the members that must be supplied by classes that implement the interface.

An interface is defined using the `interface` keyword, followed by the name of the interface, and a list of members. Here is an example:

```cs
interface IShape
{
    double Area();
    double Perimeter();
}
```

The `IShape` interface defines two methods: `Area` and `Perimeter`. Any class that implements the `IShape` interface must implement these two methods.

To implement an interface, a class must use the `:` operator, followed by the name of the interface. Here is an example:

```cs
public class Rectangle : IShape
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        this._width = width;
        this._height = height;
    }

    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}

public class Circle : IShape
{
    private double _radius;

    public Circle(double radius)
    {
        this._radius = radius;
    }

    public double Area() => Math.PI * Math.Pow(Radius, 2);
    public double Perimeter() => 2 * Math.PI * Radius;
}
```

**Note:** In terms of naming conventions, interfaces should be prefixed with the letter `I`.

## Composition vs. Inheritance

You will hear about two different ways of reusing code: composition and inheritance. As you know, inheritance is when a class inherits from another class. Composition is when a class contains an instance of another class. Inheritance is an "is-a" relationship, while composition is a "has-a" relationship.

## Enumerations

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
    Console.WriteLine("It's not Friday!");
}
```

What about parsing a string to an enumeration value? You can use the `Enum.Parse` method to parse a string to an enumeration value. For example:

```cs
Days today = (Days)Enum.Parse(typeof(Days), "Monday");

// or

Days today;

Enum.TryParse("Monday", out today);

if (today == Days.Friday)
{
    Console.WriteLine("It's Friday!");
}
else
{
    Console.WriteLine("It's not Friday!");
}
```

What is the difference between `Enum.Parse` and `Enum.TryParse`? `Enum.Parse` will throw an exception if the string cannot be parsed to an enumeration value. `Enum.TryParse` will return a boolean value indicating whether the string can be parsed to an enumeration value. If it can be parsed, the out parameter will contain the parsed value. If it cannot be parsed, the out parameter will contain the default value of the enumeration.

What is the `out` keyword? The `out` keyword is used to pass a parameter by reference. It is similar to the `ref` keyword, except that the parameter does not have to be initialised before it is passed to the method. The method is responsible for initialising the parameter before it returns.

##

# Functional Programming

# Formative Assessment

Before you start, create a new **C# Console** application called **04-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

You have been given two **sets** containing some numbers.

```cs
Set mySet = new Set();
mySet.Add(1);
mySet.Add(3);
mySet.Add(2);

Set myOtherSet = new Set();
myOtherSet.Add(4);
myOtherSet.Add(3);
```

Implement the following:

1. In the `Set` class, create a `Print` method that uses a loop to display each item in the `items` collection.
2. Use the `Contains` method to check if `mySet` contains the value `10`
3. Use the `Remove` method to remove the value `2` from `mySet`
4. Use the `Union`, `Intersection` and `Difference` methods to display the union, intersection and difference between `mySet` and `myOtherSet`

## Task 2:

You have been given a **map** containing course codes.

```cs
Map myMap = new Map();
myMap.Add("ID511001", 1);
myMap.Add("ID607001", 2);
myMap.Add("ID608001", 3);
myMap.Add("ID721001", 4);
myMap.Add("ID737001", 5);
```

Implement the following:

1. Use the `Lookup` method to lookup the value associated with the key "ID721001" in `myMap`
2. Use the `Remove` method to remove the key-value pair with the key "ID607001" from `myMap`.
3. Use the `Lookup` method to lookup the value associated with the key "ID607001" in `myMap`. **Note:** This will thrown an `Exception`. Comment this line of code to continue the execution of your program.

## Task 3:

You have been given a **stack** containing course names.

```cs
Stack myStack = new Stack(10);
myStack.Push("Programming 2");
myStack.Push("Introductory Application Development Concepts");
myStack.Push("Intermediate Application Development Concepts");
```

Just note that you will have to update the `Stack` class.

Implement the following:

1. Use the `Peek` method to display the top item on `myStack` without removing it
2. Use the `Push` method to add two items to `myStack`
3. Use the `Pop` method to remove and return the top item from `myStack`

## Task 4:

You have been given a **queue** containing course names.

```cs
Queue<string> myQueue = new Queue<string>();
myQueue.Enqueue("Programming 2");
myQueue.Enqueue("Introductory Application Development Concepts");
myQueue.Enqueue("Intermediate Application Development Concepts");
```

Implement the following:

1. Use the `Peek` method to display the top item on `myQueue` without removing it
2. Use the `Count` property to return the size of `myQueue`

## Task 5:

In this task, you will create a console program that prompts the user to enter their favourite day of the week.

Here are steps you should consider:

1. Declare an `enum` called `Days` with the following days: `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, and `Sunday`.
2. Parse the user's input and convert it into a `Day` enum value.
3. Use a `switch` statement to output a message to the console based on the user's input. For example, if the user enters "Friday", the program should output "You like Fridays!".
4. Add error handling to handle an invalid input. If the user enters an invalid day, the program should output "Invalid input. Please try again." and prompt the user to enter a valid day of the week.

```cs
// Expected output:

Enter your favourite day of the week: Tuesday
You like Tuesdays!

Enter your favourite day of the week: Monday
You like Mondays!

Enter your favourite day of the week: Blah
Invalid input. Please try again.

Enter your favourite day of the week: Wednesday
You like Wednesdays!
```

## Task 6 - Research (Hard):

Modify the program to allow the user to enter multiple days of the week separated by commas. The program should output a message for each day of the week entered by the user.

## Task 7 - Research (Hard):

In this task, you will create a console program that prompts the user to select a colour and output some text in that selected colour.

Here are steps you should consider:

1. Declare an `enum` called `Colour` with the following values: `Red`, `Green`, `Blue`, and `Yellow`.
2. Display all the available colours to the user before prompting them to select a colour.
3. Prompts the user to select a colour from the list of colors.
4. Parse the user's input and convert it into a `Colour` enum value. **Hint:** Use `Enum.TryParse`.
5. Use a `switch` statement to set the text colour based on the user's input, and output a message to the console based on the user's input. For example, if the user selects Red, the program should set the console text colour to red and output "You selected red".
6. Add error handling to the program to handle invalid input. If the user enters an invalid colour, the program should output "Invalid input. Please try again." and prompt the user to select a valid colour.

```cs
// Expected output:

Available colours:
* Red
* Green
* Blue
* Yellow
Please select a colour: green
You selected green

Available colours:
* Red
* Green
* Blue
* Yellow
Please select a colour: purple
Invalid input. Please try again.
```

## Submission

Push your code to your **GitHub** repository.
