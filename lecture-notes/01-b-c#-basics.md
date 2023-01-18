# 01 B: C# Basics

## What is C#?

C# is a programming language developed by Microsoft for building web, mobile and desktop applications as well as games. It is a modern, object-oriented language that is designed to be easy to use and is similar in syntax to other popular programming languages such as C++ and Java. C# is commonly used to build applications on the Microsoft .NET Framework, but it can also be used to build cross-platform applications using frameworks like Xamarin and .NET Core.

## Variables

A variable is a named storage location that holds a value of a specific data type. Variables are used to store values that can change during the execution of a program. A variable is declared by specifying the data type, followed by the variable name. For example:

```cs
int x;
string name;
bool isTrue;
```

In the above example, `x` is a variable of type `int`, `name` is a variable of type `string`, and `isTrue` is a variable of type `bool`. Once a variable is declared, you can assign a value to it using the assignment operator (`=`). For example:

```cs
x = 5;
name = "John Doe";
isTrue = true;
```

You can also declare and assign a value to a variable in a single statement like this:

```cs
int x = 5;
string name = "John Doe";
bool isTrue = true;
```

It is also possible to use the var keyword to declare a variable, the compiler will then infer the type based on the value assigned to it.

```cs
var x = 5;
var name = "John Doe";
var isTrue = true;
```

Note that variables declared with `var` keyword can only be initialized at the time of declaration, it cannot be reassigned with different type.

## If-Else Statements

An if-else statement in C# is a type of control flow statement that allows the program to make decisions based on a certain condition. The basic syntax of an if-else statement is:

```cs
if (condition)
{
    // code to be executed if the condition is true
}
else
{
    // code to be executed if the condition is false
}
```

The condition is a Boolean expression that is evaluated as either true or false. If the condition is true, the code inside the first set of curly braces ({ }) is executed. If the condition is false, the code inside the second set of curly braces is executed.

For example, the following code checks if the variable x is greater than the variable y, and if so, it prints "x is greater than y" to the console. If not, it prints "x is less than or equal to y" to the console.

```cs
if (x > y) 
{
    Console.WriteLine("x is greater than y");
}
else
{
    Console.WriteLine("x is less than or equal to y");
}
```

You can also chain multiple conditions using 'else if' like the following example:

```cs
if (x > y) 
{
    Console.WriteLine("x is greater than y");
}
else if (x == y)
{
    Console.WriteLine("x is equal to y");
}
else
{
    Console.WriteLine("x is less than y");
}
```

You can chain as many else if you need.

## Switch Statement

A switch statement is a control flow statement that allows a program to select one of many code blocks to be executed based on the value of a given expression. The basic syntax of a switch statement is:

```cs
switch (expression)
{
    case value1:
        // code to be executed if expression equals value1
        break;
    case value2:
        // code to be executed if expression equals value2
        break;
    ...
    default:
        // code to be executed if expression does not match any of the values
        break;
}
```

The expression is evaluated and its value is compared to the values specified in each case. If a match is found, the code block associated with that case is executed. It's important to include a break statement at the end of each case block to exit the switch statement after the code block has been executed.

For example, the following code uses a switch statement to check the value of the variable x and prints a message to the console based on its value:


```cs
switch (x)
{
    case 1:
        Console.WriteLine("x is 1");
        break;
    case 2:
        Console.WriteLine("x is 2");
        break;
    default:
        Console.WriteLine("x is not 1 or 2");
        break;
}
```

The default case is optional, and it will be executed if the value of the expression does not match any of the values specified in the case statements. You can also use the switch statement with string, like the following example:

```cs
string day = "Monday";
switch (day)
{
    case "Monday":
        Console.WriteLine("Today is Monday");
        break;
    case "Tuesday":
        Console.WriteLine("Today is Tuesday");
        break;
    default:
        Console.WriteLine("Today is not Monday nor Tuesday");
        break;
}
```

## Loops

There are several types of loops in C#, including:

1. `for` loops: These loops are used to execute a block of code a specified number of times. The basic syntax of a `for` loop is:

```cs
for (initialization; condition; increment)
{
    // code to be executed
}
```

For example, the following code uses a `for` loop to print the numbers 0 to 9 to the console:

```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

2. `while` loops: These loops are used to execute a block of code while a certain condition is true. The basic syntax of a `while` loop is:

```cs
while (condition)
{
    // code to be executed
}
```

For example, the following code uses a `while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}
```

3. `do-while` loops: These loops are similar to while loops, but the code inside the loop is guaranteed to be executed at least once. The basic syntax of a `do-while` loop is:

```cs
do
{
    // code to be executed
} while (condition);
```

For example, the following code uses a `do-while` loop to print the numbers 0 to 9 to the console:

```cs
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 10);
```

4. `foreach` loops: These loops are used to iterate over the elements in a collection, such as an array or list. The basic syntax of a `foreach` loop is:

```cs
foreach (var item in collection)
{
    // code to be executed
}
```

For example, the following code uses a foreach loop to print the elements of an array to the console:

```


## Methods

## Error Handling

## File Processing

## Visual Studio
