# 06: Interfaces and Enumerations

## Interfaces

An interface is a reference type that contains only abstract members. It defines a contract that a class must implement. An interface can contain properties and methods. An interface does not provide any implementation of the members it defines—it merely specifies the members that must be supplied by classes that implement the interface.

An interface is defined using the `interface` keyword, followed by the name of the interface, and a list of members. Here is an example:

```cs
public interface IShape
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
        _width = width;
        _height = height;
    }

    public double Area() => _width * _height;
    public double Perimeter() => 2 * (_width + _height);
}
```

```cs
public class Circle : IShape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public double Area() => Math.PI * Math.Pow(_radius, 2);
    public double Perimeter() => 2 * Math.PI * _radius;
}
```

**Note:** In terms of naming conventions, interfaces should be prefixed with the letter `I`.

## Enumerations

An enumeration (or enum for short) is a value type that is used to define a set of named constants. Enumerations are useful when you have a fixed set of values that a variable can take on, such as the days of the week or the suits in a deck of cards.

An enumeration is defined using the `enum` keyword, followed by the name of the enumeration, and a list of enumerators, which are the named constants. Each enumerator is separated by a comma, and each enumerator is assigned an integer value starting from 0 by default. Here is an example:

```cs
enum EDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

The enumerators in the example above are Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday and their respective values will be 0, 1, 2, 3, 4, 5, 6.

You can also give explicit values to the enumerators, for example:`

```cs
enum EDays { Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
```

In this example, Monday is assigned the value 1, and the rest of the enumerators are assigned the value of the previous enumerator plus one.

You can use an enumeration like any other variable. You can assign a value or compare it to other enumeration values. For example:

```cs
EDays today = EDays.Monday;
if (today == EDays.Friday)
{
    MessageBox.Show("It is Friday!");
}
else
{
    MessageBox.Show("It is not Friday!");
}
```

What about parsing a string to an enumeration value? You can use the `Enum.Parse` method to parse a string to an enumeration value. For example:

```cs
EDays today = (Days)Enum.Parse(typeof(Days), "Monday");

// or

EDays today;

Enum.TryParse("Monday", out today);

if (today == EDays.Friday)
{
    MessageBox.Show("It is Friday!");
}
else
{
    MessageBox.Show("It is not Friday!");
}
```

What is the difference between `Enum.Parse` and `Enum.TryParse`? `Enum.Parse` will throw an exception if the string cannot be parsed to an enumeration value. `Enum.TryParse` will return a boolean value indicating whether the string can be parsed to an enumeration value. If it can be parsed, the out parameter will contain the parsed value. If it cannot be parsed, the out parameter will contain the default value of the enumeration.

What is the `out` keyword? The `out` keyword is used to pass a parameter by reference. It is similar to the `ref` keyword, except that the parameter does not have to be initialised before it is passed to the method. The method is responsible for initialising the parameter before it returns.

# Formative Assessment

Before you start, create a new **Windows Forms Application** called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

In this task, you will create an application that simulates an inventory system. 

Here are steps you should consider:
1. Create an `interface` called `IInventoryItem` with the following members 
   - `void Display()`
   - `int Quantity { get; set; }`

2. Create a `class` called `Product` that implements the `IInventoryItem` interface. The `InventoryItem` class should have the following members:
   - `private string _name`
   - `private double _price`
   - `public int Quantity { get; set; }`
   - `public void Display()`
   - `public double TotalPrice()` - This method should return the total price of the item, which is the price multiplied by the quantity
  
3. In the `Form1` class, create a `List<IInventoryItem>` called `inventory`. Add the following items to the list:
   - 10 x `Product` with the name "Apple" and price 0.99
   - 5 x `Product` with the name "Orange" and price 1.99
   - 2 x `Product` with the name "Banana" and price 2.99

4. Also, im the `Form1` class, create a `private void DisplayInventory()` method that displays the inventory in a `MessageBox.Show()`. The output should be similar to the following:

```cs
Apple: 10
Orange: 5
Banana: 2
```

## Task 2:

In this task, you will create an application that prompts the user to enter their favourite day of the week.

Here are steps you should consider:

1. Create an `enum` called `EDays` with the following days: `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, and `Sunday`.
2. Parse the user's input using a `TextBox` and convert it into a `Day` enum value.
3. Use a `switch` statement to output a message based on the user's input in a `Label`. For example, if the user enters "Friday", the application should output "You like Fridays!".
4. Add error handling to handle an invalid input. If the user enters an invalid day, the application should output "Invalid input. Please try again." and prompt the user to enter a valid day of the week.

## Submission

Push your code to your **GitHub** repository.
