# 02: Classes & Objects

Lecture video can found here - [https://otagopoly.sharepoint.com/sites/id511001-programming-2-s1-23/_layouts/15/stream.aspx?id=%2Fsites%2Fid511001%2Dprogramming%2D2%2Ds1%2D23%2FShared%20Documents%2FRecordings%2FMeeting%20in%20%5Fs1%2D23%5F%2D20230227%5F150945%2DMeeting%20Recording%2Emp4](https://otagopoly.sharepoint.com/:v:/r/sites/id511001-programming-2-s1-23/Shared%20Documents/Recordings/Meeting%20in%20_s1-23_-20230227_150945-Meeting%20Recording.mp4?csf=1&web=1&e=Dg0pzD)

A **class** is a blueprint for creating **objects** (a particular data structure), providing initial values for state (member **variables** or **fields**), and implementations of behaviour (member functions or **methods**). A **class** can be defined using the `class` keyword, followed by the **class** name.

Here is an example of a simple **class**:

```cs
public class Dog
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

In this example, the **class** `Dog` has two **fields**, `name` and `age`, which represent the name and age of a dog, respectively. The **class** also has one **method**, `Bark()`, which causes the dog to bark by printing "Woof woof!" to the console.

To create an **object** from this **class**, you can use the `new` keyword and the **class** constructor like this:

```cs
Dog myDog = new Dog();
myDog.name = "Max";
myDog.age = 3;
myDog.Bark(); 
```

This code creates a new **object** of type `Dog` named `myDog`, assigns values to its `name` and `age` **fields**, and then calls the `Bark()` **method** on the **object**.

Classes can also have **constructors**, which are special **methods** that are called when an **object** is created and can be used to initialise the **object's** state. For example:

```cs
public class Dog
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

In this example, the **class** `Dog` has a constructor that takes two parameters, `name` and `age`, and assigns them to the corresponding **fields**. To create an **object** from this **class**, you can use the **constructor** and pass in the required parameters like this:

```cs
Dog myDog = new Dog("Max", 3);
myDog.Bark(); // Output: "Woof woof!"
```

This code creates a new **object** of type `Dog` named "myDog" and assigns values to its `name` and `age` **fields** via the constructor. Then it calls the `Bark()` **method** on the **object**, which causes it to bark.

## Class Diagram

To create a class diagram in **Visual Studio**, do the following:

1. In the **Solution Explorer**, right-click on the project name and select **Add** > **New Item**.
2. In the **Add New Item** window, select **Class Diagram** and give it a name. Click **Add**.
3. The class diagram will open in the designer. You can start adding classes by dragging the **Class** item from the toolbox onto the designer. **Note:** There might be a slight delay.
4. Once you have created your class diagram, you can save it and close the designer.
5. You can reopen the class diagram at any time by double-clicking on it in the **Solution Explorer**.

## Scoping

There are several keywords that can be used to define the scope of **variables**, **methods**, and other elements of a **class** or **struct**. The most commonly used scope keywords are:

- `public`: Elements defined as public can be accessed from anywhere within the program, both inside and outside the **class** or **struct** in which they are defined.

- `private`: Elements defined as private can only be accessed within the **class** or **struct** in which they are defined.

- `protected`: Elements defined as protected can be accessed within the **class** or **struct** in which they are defined and any derived **classes**.

- `internal`: Elements defined as internal can be accessed within the same assembly, i.e., `.exe` file in which they are defined, but not from other assemblies.

- `protected internal`: Elements defined as protected internal can be accessed within the same assembly in which they are defined and from derived **classes** in other assemblies.

- `static`: Elements defined as static are associated with the **class** or **struct** rather than with a specific instance of the **class** or **struct**. They can be accessed without creating an instance of the **class** or **struct**.

It is also worth noting that there are other keywords, such as `abstract`, `sealed`, `override` and `virtual`, are used in the context of **inheritance** and **polymorphism** to define the behaviour of the **classes** and **methods**.

It is important to choose the right scope keyword depending on the intended use of the element in question, as it can affect the visibility, accessibility and overall design of the program.

# 03: Encapsulation

Encapsulation is the process of hiding the implementation details of a class from the outside world and exposing only the necessary information and functionality through a public interface. Encapsulation is one of the fundamental principles of object-oriented programming, and it is used to promote the principles of abstraction, modularity, and information hiding.

Encapsulation is achieved through access modifiers, such as `public`, `private`, and `protected`, which control the visibility and accessibility of class members (fields and methods).

For example, a class can have a private field that holds some important data and a public property that allows the data to be accessed, like this:

```cs
public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }
}
```

In this example, the `balance` field is defined as private, meaning it can only be accessed within the class. On the other hand, the `Balance` property is defined as public, meaning it can be accessed from outside the class. It allows the class to control how the `balance` field is modified and accessed and to ensure that the data is always in a consistent state.

Encapsulation also allows you to change the implementation of a class without affecting the code that uses it, as long as the public interface remains the same. For example, you could change how the `balance` field is stored, without affecting the code that accesses it through the `Balance` property.

# Formative Assessment

Before you start, create a new branch called **02-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Choose an object in the classroom environment or even in the outside environment. Create a class for it. Include at least **three** fields. Feel free to add **methods** but this is not required.

## Task 2:

Create a `Car` class with `private` fields: `make`, `model`, and `year`. Add `public` properties for `Make`, `Model`, and `Year`. Include a constructor that sets the make, model, and year when the object is created. Create three `Car` objects and display their `Make`, `Model`, and `Year` properties. 

## Task 3:

You are asked to design a student enrolment system for this task. Let's start by noting some of the system's requirements in a Microsoft Word document. For example, the system should allow students to enrol in multiple courses, withdraw from a course and view the course timetables. Create a rough class diagram showing the classes' relationships. Consider what attributes and methods each class should have and how they should interact with each other.

## Task 4:

Create an `Employee` class with `private` fields for `name`, `age`, and `salary`. Add `public` properties for `Name`, `Age`, and `Salary` with a **setter** for the `Salary` property that checks for negative input and **throws** an `ArgumentException` with the message "Salary can not be negative." Include a **constructor** that sets the **name**, **age**, and **salary** when the **object** is created. Create three `Employee` objects and display their `Name`, `Age`, and `Salary` properties.

## Task 5:

Create a program that simulates a banking system. 

Create a `BankAccount` **class**, which should have **methods** for depositing and withdrawing money and checking the account balance.

Create a `Customer` **class**, which should have **fields** for the customer's name, address, and mobile number and a method for opening a new bank account.

Create a `Transaction` **class**, which should have **fields** for the amount of money transferred.

Use these classes to create a program allowing customers to open a bank account, deposit and withdraw money, and view their account balance. Also, create a log of all transactions made on the account.

## Task 6:

Create a program that simulates a movie rental system.

Create a `Movie` **class**, which should have **fields** for the movie's `title`, `genre`, `rating`, and `availability`.

Create a `Customer` **class**, which should have **fields** for the customer's `first name`, `last name`, `address`, and `mobile number`, as well as an **array** of the movies they have rented.

Create a `Rental` **class**, which should have **fields** for the movie rented, the customer who rented it, and the rental date.

Use these **classes** to create a program allowing customers to search for and rent a movie, view their rental history, and return a rented movie. The program should also have an inventory of available movies and a log of all rentals.

## Task 7:

Create a program that simulates an online store.

Create a `Product` **class**, which should have **fields** for the product's `name`, `description`, `price`, and `stock`.

Create a `Customer` **class**, which should have **fields** for the customer's `first name`, `last name`, `address`, and `mobile number`, as well as an **array** of the products they have purchased.

Create an `Order` **class**, which should have **fields** for the customer who placed the order, the products ordered, and the order date.

Use these **classes** to create a program that allows a customer to browse products, add them to a shopping cart, and place an order. The program should also have an inventory of available products, and it should update the inventory when a product is purchased.

## Task 8: 

Create a program that reads data from a text file and creates five `Dog` **objects**.

Use the `Dog` **class** above.

Create a text file called `dogs.txt` with the following data:

```
Scooby-Doo,2
Astro,5
Bolt,10
Augie,6
Dixie,9
```

Use the `StreamReader` **class** to read the contents of the `dogs.txt` file. For each line in the file, create a new `Dog` **object**. Add each `Dog` **object** to an array. Print out the `name` and `age` for each item in the array. Add error handling to ensure that the program gracefully handles any issues with reading the file or parsing the data.

## Task 9:

Create a class diagram for two programs you have created.

# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.
