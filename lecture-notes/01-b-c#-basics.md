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

## Loops

## Methods

## Error Handling

## File Processing

## Visual Studio
