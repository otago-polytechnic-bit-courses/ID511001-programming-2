# 04: Classes, Objects and Encapsulation

In **ID510001: Programming 1**, you learned about **structs**. Before we take a look at **classes**, let us first recap what a **struct** is.

## Struct

A **struct** is a data structure that can contain **fields** and **methods**. It is similar to a **class**, but it cannot be inherited from or used as a base class. It is often used to group related data together, such as the properties of a person or the attributes of a product.

Here is an example of a simple **struct**:

```cs
public struct Dog
{
    // Fields
    public string name;
    public int age;

    // Methods
    public string Bark() => "Woof woof!";
}
```

Look familiar?

## Class

So what is the difference? **class** is a blueprint for creating **objects** (a particular data structure), providing initial values for state (member **variables** or **fields**), and implementations of behaviour (member functions or **methods**). A **class** can be defined using the `class` keyword, followed by the **class** name.

Here is an example of a simple **class**:

```cs
public class Dog
{
    // Fields
    public string name;
    public int age;

    // Methods
    public string Bark() => "Woof woof!";
}
```

In this example, the **class** `Dog` has two **fields**, `name` and `age`, which represent the name and age of a dog, respectively. The **class** also has one **method**, `Bark()`, which causes the dog to bark by display "Woof woof!".

## When to use a struct vs a class?

Reading - <https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct>

## Objects

To create an **object** from this **class**, you can use the `new` keyword and the **class** constructor like this:

```cs
public Form1()
{
    InitializeComponent();

    Dog myDog = new Dog(); // Create a new object of type Dog. Alternative syntax is Dog myDog = new Dog("Max", 3);
    myDog.name = "Max"; // Set the name field to "Max"
    myDog.age = 3; // Set the age field to 3
    MessageBox.Show(myDog.Bark()); // Call the Bark() method which outputs - "Woof woof!"
}
```

This code creates a new **object** of type `Dog` named `myDog`, assigns values to its `name` and `age` **fields**, and then calls the `Bark()` **method** on the **object**.

Classes can also have **constructors**, which are special **methods** that are called when an **object** is created and can be used to initialise the **object's** state. For example:

```cs
public class Dog
{
    // Fields
    public string name;
    public int age;

    // Constructor
    public Dog(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Methods
    public string Bark() => "Woof woof!";
}
```

In this example, the **class** `Dog` has a constructor that takes two parameters, `name` and `age`, and assigns them to the corresponding **fields**. To create an **object** from this **class**, you can use the **constructor** and pass in the required parameters like this:

```cs
public Form1()
{
    InitializeComponent();

    Dog myDog = new("Max", 3); // Alternative syntax is Dog myDog = new Dog("Max", 3);
    MessageBox.Show(myDog.Bark()); // Output: "Woof woof!"
}
```

This code creates a new **object** of type `Dog` named "myDog" and assigns values to its `name` and `age` **fields** via the constructor. Then it calls the `Bark()` **method** on the **object**, which causes it to bark.

If you see the following error, it means you are using an older version of **C#**.

![alt text](../resources/img/07/syntax.png)



## this

In the previous example, we used the `this` keyword. The `this` keyword is used to refer to the current **object** in a **class** or **struct**. For example:

```cs
public class Dog
{
    // Fields
    public string name;
    public int age;

    // Constructor
    public Dog(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Methods
    public string Bark() => "Woof woof!";
    public string DisplayInfo() => $"Name: {name}, Age: {age}";

    // Instead of DisplayInfo(), you can also use ToString() method
    public override string ToString() => $"Name: {name}, Age: {age}";
}
```

## ToString()

The `ToString()` method is a special **method** that is called when an **object** is converted to a string. It is often used to provide a string representation of an **object**. For example:

```cs
public Form1()
{
    InitializeComponent();

    Dog myDog = new("Max", 3);
    MessageBox.Show(myDog.ToString()); // Output: "Name: Max, Age: 3"
}
```

## What is the difference between a struct and a class?

| Feature                          | Struct                                   | Class                                      |
| -------------------------------- | ---------------------------------------- | ------------------------------------------ |
| **Value Type vs Reference Type** | Value type                               | Reference type                             |
| **Memory Allocation**            | Stack or inline                          | Heap                                       |
| **Default Constructor**          | No parameterless constructor             | Allows parameterless constructor           |
| **Inheritance**                  | Cannot inherit                           | Supports inheritance                       |
| **Nullability**                  | Cannot be null (unless nullable)         | Can be null                                |
| **Performance**                  | Efficient for small, immutable types     | Provides more flexibility, slight overhead |
| **Usage Scenarios**              | Small, lightweight, single-value objects | Larger, complex objects with shared state  |
| **Copying**                      | Copy involves entire value               | Copy involves reference                    |

**Glossary:**

- **Value type**: A type whose value is copied when it is assigned to a variable or passed as a parameter. Examples include `int`, `double`, `bool`, `char`, `struct`, and `enum`.
- **Reference type**: A type whose value is passed by reference. Examples include `string`, `class`, `interface`, `delegate`, and `object`.
- **Stack**: A region of memory that is used to store local variables and parameters.
- **Heap**: A region of memory that is used to store objects.
- **Immutable**: An object whose state cannot be changed after it has been created.
- **Nullable**: A type that can be assigned `null`.
- **Parameterless constructor**: A constructor that takes no parameters.
- **Inheritance**: The ability to create a new class from an existing class. We will talk more about this in `04-inheritance-and-polymorphism.md`.

## Static Class

A **static** class cannot be instantiated and can only contain **static** members. It is often used to group related **static** members together, such as **constants** and **utility methods**. For example:

```cs
public static class Utils
{
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool isSwapped;

        for (int i = 0; i < n - 1; i++)
        {
            isSwapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    isSwapped = true;
                }
            }

            // If no two members were swapped by inner loop, then break
            if (!isSwapped) break;
        }
    }
}
```

How do we use a **static** class? Let us take a look at the following example:

```cs
public Form1()
{
    InitializeComponent();

    int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
    MessageBox.Show($"Original array: {string.Join(", ", arr)}");
    Utils.BubbleSort(arr);
    MessageBox.Show($"Sorted array: {string.Join(", ", arr)}");
}
```

**Note**: There is no need to create an **object** of type `Utils` because all the members of the **class** are **static**.

## Scoping

There are several keywords that can be used to define the scope of **variables**, **methods**, and other members of a **class** or **struct**. The most commonly used scope keywords are:

- `public`: Members defined as public can be accessed from anywhere within the application, both inside and outside the **class** or **struct** in which they are defined.

- `private`: Members defined as private can only be accessed within the **class** or **struct** in which they are defined.

- `protected`: Members defined as protected can be accessed within the **class** or **struct** in which they are defined and any derived **classes**.

- `internal`: Members defined as internal can be accessed within the same assembly, i.e., `.exe` file in which they are defined, but not from other assemblies.

- `protected internal`: Members defined as protected internal can be accessed within the same assembly in which they are defined and from derived **classes** in other assemblies.

- `static`: Members defined as static are associated with the **class** or **struct** rather than with a specific instance of the **class** or **struct**. They can be accessed without creating an instance of the **class** or **struct**.

It is also worth noting that there are other keywords, such as `abstract`, `sealed`, `override` and `virtual`, are used in the context of **inheritance** and **polymorphism** to define the behaviour of the **classes** and **methods**.

It is important to choose the right scope keyword depending on the intended use of the element in question, as it can affect the visibility, accessibility and overall design of the application.

## Encapsulation

Encapsulation is the process of hiding the implementation details of a class from the outside world and exposing only the necessary information and functionality through a public interface. Encapsulation is one of the fundamental principles of object-oriented programming, and it is used to promote the principles of abstraction, modularity, and information hiding.

What is a real-world example?

A good example of encapsulation is a bank account. A bank account has a balance, which is a private field that can only be accessed by the bank itself. The bank provides a public interface for accessing the balance, such as a website or mobile app, which allows customers to view their balance and make transactions. The bank also provides a public interface for making deposits and withdrawals, which allows customers to add or remove money from their account.

You will see below that encapsulation is achieved through access modifiers, such as `public`, `private`, and `protected`, which control the visibility and accessibility of class members (fields and methods).

For example, a class can have a `private` field that holds some important data and a public property that allows the data to be accessed, like this:

```cs
public class BankAccount
{
    private decimal _balance;

    public decimal Balance { get => _balance; set => _balance = value; }
}
```

In this example, the `_balance` field is defined as `private`, meaning it can only be accessed within the class. On the other hand, the `Balance` property is defined as `public`, meaning it can be accessed from outside the class. It allows the class to control how the `_balance` field is modified and accessed and to ensure that the data is always in a consistent state.

Encapsulation also allows you to change the implementation of a class without affecting the code that uses it, as long as the public interface remains the same. For example, you could change how the `_balance` field is stored, without affecting the code that accesses it through the `Balance` property.

We can extend the `Balance` property to include some validation logic, like this:

```cs
public class BankAccount
{
    private decimal _balance;

    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                throw new Exception("Balance cannot be negative");
            _balance = value;
        }
    }
}
```

So how do we use properties? Let us take a look at the following example:

```cs
public Form1()
{
    InitializeComponent();

    BankAccount accountOne = new BankAccount();
    accountOne.Balance = 1000;
    MessageBox.Show($"Balance: {accountOne.Balance}");

    BankAccount accountTwo = new BankAccount();
    accountTwo.Balance = -1000;
    MessageBox.Show($"Balance: {accountTwo.Balance}"); // Throws an exception
}
```

How do I display the exception?

```cs
public Form1()
{
    InitializeComponent();

    BankAccount accountOne = new BankAccount();
    accountOne.Balance = 1000;
    MessageBox.Show($"Balance: {accountOne.Balance}");

    BankAccount accountTwo = new BankAccount();
    try
    {
        accountTwo.Balance = -1000;
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

## Class Diagram

A class diagram is a type of **UML** diagram that shows the structure of a class and its relationships with other classes. It is used to visualise the design of a system and to communicate the design to other developers.

The lab computers will already have the **Class Designer** tool installed. It will not be the case for your personal computer. To get started, do the following:

1. Click on the **Tools** tab. It is between the **Analyze** and **Extensions** at the top of the window.

2. Select **Get Tools and Features...**.

![](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/main-s1-24/resources/img/04/class-diagram-1.PNG?raw=true)

4. Change to the **Individual components** tab.

5. Search for **Class Designer**.

![](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/main-s1-24/resources/img/04/class-diagram-2.PNG?raw=true)

6. Check the **Class Designer** box.

![](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/main-s1-24/resources/img/04/class-diagram-3.PNG?raw=true)

7. Click on the **Modify** button. It may take a few minutes to install.

---

To create a class diagram in **Visual Studio**, do the following:

1. In the **Solution Explorer**, right-click on the project name and select **Add** > **New Item**.
2. In the **Add New Item** window, select **Class Diagram** and give it a name. Click **Add**.
3. The class diagram will open in the designer. You can start adding classes by dragging the **Class** item from the **Solution Explorer** onto the designer. **Note:** There might be a slight delay.
4. Once you have created your class diagram, you can save it and close the designer.
5. You can reopen the class diagram at any time by double-clicking on it in the **Solution Explorer**.

# Formative Assessment

Before you start, create a new **Windows Forms Application** called **04-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Choose an object in the classroom environment or even in the outside environment. Create a class for it. Include at least **three** fields. Feel free to add **methods** but this is not required.

## Task 2:

Create a `Car` class with `private` fields: `make`, `model`, and `year`. Add `public` **properties** for `Make`, `Model`, and `Year`. Include a **constructor** that sets the **make**, **model**, and **year** when the **object** is created. Create three `Car` **objects** and display their `Make`, `Model`, and `Year` **properties** in a `Label`.

## Task 3:

Create an `Employee` class with `private` fields for `name`, `age`, and `salary`. Add `public` **properties** for `Name`, `Age`, and `Salary`. Include a **constructor** that sets the **name**, **age**, and **salary** when the **object** is created. Create three `Employee` **objects** and display their `Name`, `Age`, and `Salary` **properties** in a `Label`.

## Task 4:

In this task, you will create four classes that communicate with each other. The first class is called `Institution` with `private` fields for `name`, `region` and `country`. All fields are of type `string`. The second class is called `Department` with `private` fields for `institution` of type `Institution` and `name` of type `string`. The third class is called `Course` with `private` fields for `department` of type `Department`, `code` of type `string`, `name` of type `string`, `description` of type `string`, `credits` of type `int` and `fees` of type `int`. Make sure you create a constructor for each class.

The fourth class is called `Utils`. This class has three `static` fields called `institutions`, `departments` and `courses`. These fields are `static` **lists** of `Institution`, `Department` and `Course` **objects** respectively. The `Utils` class also has three `static` methods called `SeedInstitutions`, `SeedDepartments` and `SeedCourses`. These methods are used to populate the `institutions`, `departments` and `courses` lists respectively.

For each of the `Seed` methods, you will need to create at least three **objects** and add them to the appropriate list. For example, the `SeedInstitutions` method will create three `Institution` **objects** and add them to the `institutions` list.

Here is an `Utils` class example to get you started:

```cs
public static class Utils
{
    private static List<Institution> s_institutions = new List<Institution>();

    public static List<Institution> SeedInstitutions()
    {
        s_institutions.Add(new("Otago Polytechnic", "Otago", "New Zealand"));

        // Add two more institutions

        return s_institutions;
    }
}

// Usage in Form1.cs
private static List<Institution> s_institutions; // Declare this above the Form1() constructor

s_institutions = Utils.SeedInstitutions(); // Declare this inside the Form1() constructor
```

For each `course`, display its information and which `department` and `institution` it belongs to in a `Label`.

## Task 5:

You have been given the following **class** and **list** of `Product` **objects**:

```cs
// Create a new file called Product.cs. Copy and paste the following code into it
public class Product
{
    private string _name;
    private double _price;

    public Product(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public string Name { get => _name; set => _name = value; }
    public double Price { get => _price; set => _price = value; }
}

// Usage in Form1.cs
private static List<Product> products; // Declare this above the the Form1() constructor

products = new List<Product>() // Declare this inside the Form1() constructor
{
    new("Apple", 1.99),
    new("Banana", 2.99),
    new("Orange", 3.99)
};
```

Write a **LINQ** query that displays the average price of all products in the **list** of `Product`  in a `Label`.

## Task 6:

In this task, you will read data from a text file, create five `Dog` **objects** and display the `Dog` data in a `DataGridView`.

Use the `Dog` **class** above.

Create a text file called `dogs.txt` with the following data:

```
Scooby-Doo,2
Astro,5
Bolt,10
Augie,6
Dixie,9
```

Use the `StreamReader` or `File` **class** to read the contents of the `dogs.txt` file. For each line in the file, create a new `Dog` **object**. Add each `Dog` **object** to a **list**. Display the `name` and `age` for each item in the **list**. Add error handling to ensure that the application gracefully handles any issues with reading the file or parsing the data.

## Task 7:

Create a class diagram for two applications you have created.

## Submission

Push your code to your **GitHub** repository.
