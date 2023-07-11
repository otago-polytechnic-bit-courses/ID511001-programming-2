# 02: List, Sorting Algorithms and LINQ

## List

A list is a collection of items stored as an array and can be accessed by an index number. Lists are similar to arrays, but they can be resized dynamically, which means that you can add or remove items from the list after it is created.

There are different types of lists in different programming languages, but they all have some basic features. Here are some common operations that can be performed on lists:

- Adding items to the list: You can add new items to the end of the list or insert them at a specific position.
- Removing items from the list: You can remove them from the list by their position or value.
- Accessing items in the list: You can access an item by its position using an index number.
- Searching the list: You can search the list for a specific item and find its position.
- Sorting the list: You can sort the items in the list in ascending or descending order.

Here is an example of how to create and use a list:

```cs
List<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
names.Add("Charlie");
string firstName = names[0];
string secondName = names[1];
names.Remove("Charlie");
int count = names.Count;
```

**Questions:**

1. What is the output if you print `firstName`?
2. What is the output if you print `count`?

One of the main advantages of using a list is that it provides fast and efficient access to the items it contains. Since each item in a list is identified by its index, it is possible to access any item in the list in constant time by simply specifying its index. It makes lists an ideal data structure for storing and accessing large data collections, especially when the order of the items is important.

Inserting or deleting items from the middle of a list can be expensive, as it may require shifting the items around to make room for the new item or filling the gap left by the deleted item.

Lists are a very useful and widely-used data structure that can be used to store and manage large data collections in various applications.

## Sorting Algorithms

In the **Maths for IT** course, you learned about sorting algorithms. We are going to look at how to implemented a few of them in **C#**.

### Bubble Sort

```cs
static void BubbleSort(int[] arr)
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

// Usage:

int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine("Original array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}

BubbleSort(arr);

Console.WriteLine("\nSorted array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}
```

### Selection Sort

```cs
static void SelectionSort(int[] arr)
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }

        int temp = arr[minIndex];
        arr[minIndex] = arr[i];
        arr[i] = temp;
    }
}

// Usage:

int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine("Original array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}

SelectionSort(arr);

Console.WriteLine("\nSorted array");
for (int i = 0; i < arr.Length; ++i)
{
    Console.Write(arr[i] + " ");
}
```

### Insertion Sort

```cs
static void InsertionSort(List<int> arr)
{
    int n = arr.Count;

    for (int i = 1; i < n; i++)
    {
        int key = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j = j - 1;
        }

        arr[j + 1] = key;
    }
}

// Usage:

List<int> arr = new List<int> { 64, 34, 25, 12, 22, 11, 90 };

Console.WriteLine("Original array");
foreach (int i in arr)
{
    Console.Write(i + " ");
}

InsertionSort(arr);

Console.WriteLine("\nSorted array");
foreach (int i in arr)
{
    Console.Write(i + " ");
}
```	

What is the time complexity of each of the sorting algorithms? Which one is the most efficient? Which one is the least efficient? Why?

## LINQ

**LINQ** stands for **Language Integrated Query**. It is a set of features that extends the **C#** language to support queries against data sources. It provides a consistent way to query data from different data sources, i.e., in-memory collections, databases, etc.

**LINQ** queries are written using **query expressions**. A query expression is a query that is written in a declarative syntax, similar to **SQL**. It consists of a **from** clause, a **where** clause, a **orderby** clause, a **select** clause, and a **groupby** clause.

```cs
List<string> names = new List<string>() { "Bob", "Charlie", "Alice", "Eve" };

var query = from name in names
            where name.Length > 4
            orderby name
            select name;

foreach (string name in query)
{
    Console.WriteLine(name);
}
```

The above query is equivalent to the following:

```cs
List<string> names = new List<string>() { "Bob", "Charlie", "Alice", "Eve" };

var query = names.Where(name => name.Length > 4)
                 .OrderBy(name => name)
                 .Select(name => name);
            
foreach (string name in query)
{
    Console.WriteLine(name);
}
```

What is the output?

# Formative Assessment

Before you start, create a new branch called **02-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

You have been given two **lists** containing some of my favourite programming languages.

```cs
List<string> progLangOne = new List<string>() { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangTwo = new List<string>() { "C++", "Go", "Swift", "TypeScript" };
```

Implement the following:

1. Use the `AddRange` method to add the elements of `progLangOne` to `progLangTwo` and assign the resulting combined list to a variable called `allProgLanguages`
2. Use the `Add` method to add "Rust" to `allProgLanguages`
3. Use the `Remove` method to remove "Swift" from `allProgLanguages`
4. Use a loop to display each language in `allProgLanguages`

# Task 2:

Reactor the `BubbleSort` method to sort a list of `int` in **descending** order instead of **ascending** order.

# Task 3:

Refactor the `InsertionSort` method to sort a list of `string` instead of a list of `int`. **Hint:** You will need to change the method signature and the type of the `key` variable. Also, you might find the `string.Compare` method useful.

# Task 4:

You have seen three sorting algorithms, i.e., bubble, selection and insertion sorts. Research and implement a fourth sorting algorithm of your choice. Comment your code to explain how the algorithm works.

# Task 5:

You have been given a list of `int` containing even numbers. Write a **LINQ** query that displays the sum of all even numbers in the list of `int`.

```cs
List<int> numbers = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
```

# Task 6:

You have been given a list of `string` containing countries. Write a **LINQ** query that displays all countries starting with the letter "I" or "i".

```cs
List<string> countries = new List<string>
{
    "Argentina",
    "Australia",
    "Brazil",
    "Canada",
    "Egypt",
    "France",
    "India",
    "Italy",
    "Mexico",
    "Netherlands",
    "South Africa",
    "United States",
};
```

# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please do not your own pull request.
