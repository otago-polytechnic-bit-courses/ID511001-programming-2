# 05: Inheritance

Inheritance is a mechanism that allows a new class to inherit the properties and methods of an existing class, called the base class or the parent class. The new class, called the derived class or the child class, can inherit all or some of the base class members and can also add new members or override existing members.

Inheritance is one of the fundamental principles of object-oriented programming, along with encapsulation and polymorphism. It allows you to create a hierarchy of classes, where a derived class inherits the properties and methods of its base class and can add new properties and methods or override existing ones.

Here's an example of inheritance:

```cs
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat() { /*...*/ }
    public void Sleep() { /*...*/ }
}

public class Dog : Animal
{
    public void Bark() { /*...*/ }
}
```

In this example, the `Animal` class is the base class. It has two properties, `Name` and `Age`, and two methods `Eat()` and `Sleep()`. The `Dog` class is the derived class. It inherits the base class's properties and methods and has a new method, `Bark()`.

A derived class can also override the base class's methods, properties or events. It can implement a method or property already defined in the base class using the `override` keyword.

```cs
public class Dog : Animal
{
    public override string Name { get; set; }
    public void Bark() { /*...*/ }
}
```

In this example, the `Dog` class overrides the `Name` property of the `Animal` class, to provide its implementation of the property.

Inheritance is a powerful concept that allows you to reuse existing code and to model relationships between classes and objects naturally and intuitively. It also enables you to create a hierarchical structure of classes that allows you to define common behaviour and characteristics in a base class and then extend or specialize that behaviour in derived classes.

# Formative Assessment

Before you start, create a new branch called **05-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work