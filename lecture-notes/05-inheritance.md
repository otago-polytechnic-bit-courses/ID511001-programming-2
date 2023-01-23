# 05: Inheritance

Inheritance is a mechanism that allows a new class to inherit the properties and methods of an existing class, called the base class or the parent class. The new class, called the derived class or the child class, can inherit all or some of the members of the base class, and can also add new members or override existing members.

Inheritance is a key concept in object-oriented programming, and it is one of the fundamental principles of object-oriented programming, along with encapsulation and polymorphism. It allows you to create a hierarchy of classes, where a derived class inherits the properties and methods of its base class, and can add new properties and methods or override existing ones.

Here's an example of inheritance:

```cs
class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat() { /*...*/ }
    public void Sleep() { /*...*/ }
}

class Dog : Animal
{
    public void Bark() { /*...*/ }
}
```

In this example, the `Animal` class is the base class, it has two properties `Name` and `Age`, and two methods `Eat()` and `Sleep()`. The `Dog` class is the derived class, it inherits the properties and methods of the base class and also has a new method `Bark()`.

A derived class can also override the base class's methods, properties or events. This means that it can provide its own implementation of a method or property that is already defined in the base class, using the `override` keyword.

```cs
class Dog : Animal
{
    public override string Name { get; set; }
    public void Bark() { /*...*/ }
}
```

In this example, the `Dog` class overrides the `Name` property of the `Animal` class, to provide its own implementation of the property.

Inheritance is a powerful concept that allows you to reuse existing code, and to model relationships between classes and objects in a natural and intuitive way. It also enables you to create a hierarchical structure of classes, that allows you to define common behavior and characteristics in a base class and then extend or specialize that behavior in derived classes.

# Formative Assessment