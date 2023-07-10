# 03: Classes, Objects and Encapsulation

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

## Static Class

A **static** class cannot be instantiated and can only contain **static** members. It is often used to group related **static** members together, such as **constants** and **utility methods**. For example:

```cs
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

            // If no two elements were swapped by inner loop, then break
            if (!isSwapped) break;
        }
    }
}

// Usage in Program.cs:

int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine("Original array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}

Utils.BubbleSort(arr);

Console.WriteLine("\nSorted array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}
```

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

# Encapsulation

Encapsulation is the process of hiding the implementation details of a class from the outside world and exposing only the necessary information and functionality through a public interface. Encapsulation is one of the fundamental principles of object-oriented programming, and it is used to promote the principles of abstraction, modularity, and information hiding.

Encapsulation is achieved through access modifiers, such as `public`, `private`, and `protected`, which control the visibility and accessibility of class members (fields and methods).

For example, a class can have a private field that holds some important data and a public property that allows the data to be accessed, like this:

```cs
public class BankAccount
{
    private decimal balance;
    public decimal Balance { get => balance; set => balance = value; }
}
```

In this example, the `balance` field is defined as private, meaning it can only be accessed within the class. On the other hand, the `Balance` property is defined as public, meaning it can be accessed from outside the class. It allows the class to control how the `balance` field is modified and accessed and to ensure that the data is always in a consistent state.

Encapsulation also allows you to change the implementation of a class without affecting the code that uses it, as long as the public interface remains the same. For example, you could change how the `balance` field is stored, without affecting the code that accesses it through the `Balance` property.

## Class Diagram

A class diagram is a type of UML diagram that shows the structure of a class and its relationships with other classes. It is used to visualise the design of a system and to communicate the design to other developers.

To create a class diagram in **Visual Studio**, do the following:

1. In the **Solution Explorer**, right-click on the project name and select **Add** > **New Item**.
2. In the **Add New Item** window, select **Class Diagram** and give it a name. Click **Add**.
3. The class diagram will open in the designer. You can start adding classes by dragging the **Class** item from the toolbox onto the designer. **Note:** There might be a slight delay.
4. Once you have created your class diagram, you can save it and close the designer.
5. You can reopen the class diagram at any time by double-clicking on it in the **Solution Explorer**.

# Formative Assessment

Before you start, create a new branch called **03-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

Choose an object in the classroom environment or even in the outside environment. Create a class for it. Include at least **three** fields. Feel free to add **methods** but this is not required.

## Task 2:

Create a `Car` class with `private` fields: `make`, `model`, and `year`. Add `public` **properties** for `Make`, `Model`, and `Year`. Include a **constructor** that sets the **make**, **model**, and **year** when the **object** is created. Create three `Car` **objects** and display their `Make`, `Model`, and `Year` **properties**. 

## Task 3:

Create an `Employee` class with `private` fields for `name`, `age`, and `salary`. Add `public` **properties** for `Name`, `Age`, and `Salary`. Include a **constructor** that sets the **name**, **age**, and **salary** when the **object** is created. Create three `Employee` **objects** and display their `Name`, `Age`, and `Salary` **properties**.

## Task 4: 

In this task, you will create four classes that communicate with each other. The first class is called `Institution` with `private` fields for `name`, `region` and `country`. The second class is called `Department` with `private` fields for `institution` and `name`. The third class is called `Course` with `private` fields for `department` and `code`, `name`, `description`, `credits` and `fees`.

The fourth class is called `Utils`. This class has three `static` fields called `institutions`, `departments` and `courses`. These fields are `static` **lists** of `Institution`, `Department` and `Course` **objects** respectively. The `Utils` class also has three `static` methods called `SeedInstitutions`, `SeedDepartments` and `SeedCourses`. These methods are used to populate the `institutions`, `departments` and `courses` lists respectively.

For each of the `Seed` methods, you will need to create at least three **objects** and add them to the appropriate list. For example, the `SeedInstitutions` method will create three `Institution` **objects** and add them to the `institutions` list.

Here is an `Utils` class example to get you started:

```cs
public static class Utils
{
    private static List<Institution> institutions = new List<Institution>();

    public static List<Institution> SeedInstitutions()
    {
        institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));

        // Add two more institutions
        
        return institutions;
    }
}

// Usage in Program.cs:
List<Institution> institutions = Utils.SeedInstitutions();
```

For each `course`, display its information and which `department` and `institution` it belongs to.

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

Create a new pull request and assign **grayson-orr** to review your submission. Please do not your own pull request.
