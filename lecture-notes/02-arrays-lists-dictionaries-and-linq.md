# 02: Arrays, Lists, Dictionaries and LINQ

## Arrays

An array is a data structure that stores a fixed-size sequence of elements of the same type. It is a linear data structure, which means that the elements are stored in a sequence. Each element in the array is identified by its position in the array, which is called its index. The first element in the array has an index of 0, the second element has an index of 1, and so on. The last element in the array has an index of `n - 1`, where `n` is the total number of elements in the array.

Here are some common operations that can be performed on arrays:

- Accessing elements in the array: You can access an element by its position using an index number.
- Modifying elements in the array: You can change the value of an element by its position
- Searching the array: You can search the array for a specific element and find its position.
- Sorting the array: You can sort the elements in the array in ascending or descending order.

Here is an example of how to create and use an array:

```cs
int[] numbers = new int[5]; // Create an array of integers with a size of 5
numbers[0] = 10; // Assign a value to the first element in the array
numbers[1] = 20; // Assign a value to the second element in the array
numbers[2] = 30; // Assign a value to the third element in the array
numbers[3] = 40; // Assign a value to the fourth element in the array
numbers[4] = 50; // Assign a value to the fifth element in the array

int firstNumber = numbers[0]; // Access the first element in the array
int secondNumber = numbers[1]; // Access the second element in the array

int count = numbers.Length; // Get the total number of elements in the array
```

Here are more complex examples of how to create and use arrays:

```cs
// Create an array of strings with initial values
string[] fruits = new string[] { "Apple", "Banana", "Cherry"};

// Search the array for a specific element
int indexOfBanana = Array.IndexOf(fruits, "Banana"); // Find the position of "Banana" in the array
Console.WriteLine($"Index of Banana: {indexOfBanana}");

// Sort the array in ascending order
Array.Sort(fruits); // Sort the elements in the array
Console.WriteLine($"Sorted fruits: {string.Join(", ", fruits)}"); 
```

## Lists

A list is a data structure that stores a collection of items. It is a linear data structure, which means that the items are stored in a sequence. Each item in the list is identified by its position in the list, which is called its index. The first item in the list has an index of 0, the second item has an index of 1, and so on. The last item in the list has an index of `n - 1`, where `n` is the total number of items in the list. A list is a dynamic data structure, which means that it can grow or shrink in size during the execution of a program.

Here are some common operations that can be performed on lists:

- Adding items to the list: You can add new items to the end of the list or insert them at a specific position.
- Removing items from the list: You can remove them from the list by their position or value.
- Accessing items in the list: You can access an item by its position using an index number.
- Searching the list: You can search the list for a specific item and find its position.
- Sorting the list: You can sort the items in the list in ascending or descending order.

Here is an example of how to create and use a list:

```cs
List<string> names = new List<string>(); // Create an empty list

names.Add("Alice"); // Add a new name to the list
names.Add("Bob");
names.Add("Charlie");

string firstName = names[0];  // Access the first name in the list
string secondName = names[1]; // Access the second name in the list

names.Remove("Charlie"); // Remove a name from the list by its value

int count = names.Count; // Get the total number of names in the list
```

**Questions:**

1. What is the output if you print `firstName`?
2. What is the output if you print `count`?

How do you iterate over the items in a list? You can use a `for` loop or a `foreach` loop. Here are some examples:

```cs
List<string> names = new List<string>() { "Alice", "Bob", "Charlie" }; // Create a list with initial values

for (int i = 0; i < names.Count; i++) // Iterate over the names in the list using a for loop
{
    Console.WriteLine(names[i]);
}

foreach (string name in names) // Iterate over the names in the list using a foreach loop
{
    Console.WriteLine(name);
}
```

There are other useful methods that can be used to manipulate lists. Here are some examples:

```cs
List<string> names = new List<string>() { "Alice", "Bob", "Charlie" }; // Create a list with initial values

names.Insert(1, "Eve"); // Insert a new name at a specific position in the list
names.RemoveAt(2); // Remove a name from the list by its position
names.Contains("Alice"); // Check if a name exists in the list
names.IndexOf("Alice"); // Find the position of a name in the list
names.Sort(); // Sort the names in the list in ascending order
names.Reverse(); // Reverse the order of the names in the list
names.Clear(); // Remove all names from the list

foreach (string name in names) // Iterate over the names in the list using a foreach loop
{
    Console.WriteLine(name); // What is the output?
}
```

**Resource:** [List\<T> Class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0)

## Dictionaries

A dictionary is a data structure that stores a collection of key-value pairs. It is a linear data structure, which means that the items are stored in a sequence. Each item in the dictionary is identified by its key, which is unique within the dictionary. The value associated with the key can be of any type.

Here are some common operations that can be performed on dictionaries:

- Adding key-value pairs to the dictionary: You can add new key-value pairs to the dictionary.
- Removing key-value pairs from the dictionary: You can remove a key-value pair from the dictionary
- Accessing values in the dictionary: You can access a value by its key.
- Searching the dictionary: You can search the dictionary for a specific key and find its value.
- Checking if a key exists in the dictionary: You can check if a key exists in the dictionary.

Here is an example of how to create and use a dictionary:

```cs
Dictionary<string, int> ages = new Dictionary<string, int>(); // Create an empty dictionary

ages.Add("Alice", 30); // Add a new key-value pair to the dictionary
ages.Add("Bob", 25);
ages.Add("Charlie", 35);

int aliceAge = ages["Alice"]; // Access the value associated with the key "Alice"
int bobAge = ages["Bob"]; // Access the value associated with the key "Bob" 

ages.Remove("Charlie"); // Remove a key-value pair from the dictionary by its key

int count = ages.Count; // Get the total number of key-value pairs in the dictionary
``` 

**Resource:** [Dictionary\<TKey, TValue> Class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0)

## Language Integrated Query

**Language Integrated Query** or **LINQ** provides a set of features that extends the **C#** language to support queries against data sources. It provides a consistent way to query data from different data sources, i.e., in-memory collections, databases, etc.

To get started with **LINQ**, you need to include the following directive at the top of your file:

```cs
using System.Linq;
```

**LINQ** queries are written using **query expressions**. A query expression is a query that is written in a declarative syntax, similar to **SQL**. It consists of a **from** clause, a **where** clause, a **orderby** clause, a **select** clause, and a **groupby** clause.

```cs
List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

IEnumerable<string> query = from name in names
            where name.Length > 4 // Where name length is greater than 4
            orderby name // Order by name in ascending order
            select name; 

foreach (string name in query)
{
    Console.WriteLine(name);
}
```

The above query is equivalent to the following:

```cs
List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

IEnumerable<string> query = names.Where(name => name.Length > 4)
                 .OrderBy(name => name)
                 .Select(name => name);

foreach (string name in query)
{
    Console.WriteLine(name);
}
```

How would you do this without using **LINQ**?

```cs
List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

List<string> query = new List<string>();

foreach (string name in names)
{
    if (name.Length > 4)
    {
        query.Add(name);
    }
}

query.Sort();

foreach (string name in query)
{
    Console.WriteLine(name);
}
```

Feel free to choose whichever syntax you prefer.

**Resources:**

- [LINQ (Language-Integrated Query)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [Query Syntax and Method Syntax in LINQ (C#)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)

# Formative Assessment

Before you start, create a new **C# Console** application called **02-formative-assessment**.

Learning to use AI tools is an important skill. While AI tools are powerful, you **must** be aware of the following:

- If you provide an AI tool with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust the AI tool's responses blindly. You **must** still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge what AI tool you have used. In the assessment's repository **README.md** file, please include what prompt(s) you provided to the AI tool and how you used the response(s) to help you with your work

## Task 1:

You have been given two **lists** containing some programming languages.

```cs
List<string> progLangsOne = new List<string>() { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangsTwo = new List<string>() { "C++", "Go", "Swift", "TypeScript" };
```

Implement the following:

1. Create a new `List<string>` called `allProgLangs`. Use the `AddRange` method to add the elements of `progLangsOne` and `progLangsTwo` to `allProgLangs`
2. Use the `Add` method to add "Rust" to `allProgLangs`
3. Use the `Remove` method to remove "Swift" from `allProgLangs`
4. Use a loop to display each language in `allProgLangs`

## Task 2:

You have been given the following list of integers:

```c#
List<int> nums = new List<int>() { 65, 35, 79, 101, 35 };
```

Implement the following:

1. Use the `Insert` method to insert the number 25 at the second position in `nums`. Display the contents of `nums` after inserting the number 25.
2. Use the `Contains` method to check if the number 35 exists in `nums`. Assign the result to a variable called `hasNumber35`. Display the value of `hasNumber35`.
3. Use the `Find` method to find the first number in `nums` that is greater than 30 and assign it to a variable called `firstNumberGreaterThan30`. Display the value of `firstNumberGreaterThan30`.
4. Use the `Sort` method to sort `nums` in ascending order. Display the contents of `nums` after sorting it.

## Task 3:

You have been given the following list of strings representing book titles:

```c#
List<string> bookTitles = new List<string>() { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Brave New World" };
```

Implement the following:

1. Use the `Count` method to get the total number of book titles in `bookTitles` and assign it to a variable called `totalBooks`. Display the value of `totalBooks`.
2. Use the `Contains` method to check if the title "Brave New World" exists in `bookTitles`. Assign the result to a variable called `hasBraveNewWorld`. Display the value of `hasBraveNewWorld`.
3. Use the `FindIndex` method to find the index of the book title "1984" in `bookTitles` and assign it to a variable called `index1984`. Display the value of `index1984`.
4. Use the `Clear` method to remove all elements from `bookTitles`. Display the number of items in `bookTitles`.

## Task 4:

You have been given a list of `int` containing even numbers. Write a **LINQ** query that displays the sum of all even numbers in the list of `int`.

```cs
List<int> numbers = new List<int>() { 1, 4, 7, 8, 11, 12, 15, 16, 19, 20 };
```

> **Hint:** Filter the list with `Where` method to select only even numbers, then use `Sum` method to add them together. The result is a number so make sure you store this in the appropriate data type.

## Task 5:

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

> **Hint:** Use the `Where` method to filter countries that start with the letter "I" or "i" by checking if `country.StartsWith("I", StringComparison.OrdinalIgnoreCase)` is `true`.

## Task 6:

You have been given a list of temperatures in celsius for a week.

```cs
List<double> temperatures = new List<double>() { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

Implement the following:

1. Calculate the average temperature for the week.
2. Find the highest temperature recorded during the week.
3. Find all the temperatures that are above 25 degrees celsius and store them in a new list.

> **Hint:** Use methods like `Average` to calculate the week's average temperature, `Max` to find the highest temperature, and `Where` to filter temperatures above 25 degrees celsius and store them in a new list using `ToList`.

## Task 7:

You have been given a list of integers representing exam scores of learners.

```cs
List<int> scores = new List<int>() { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

Implement the following:

1. Find the highest score in the list.
2. Find all the distinct scores (remove duplicates) and store them in a new list.

> **Hint:** For **Task 7.2**, use the `Distinct` method, then convert the result into a `List`. If you get stuck on coverting the result into a `List`, refer to **Task 6's** hint.

## Task 8:

You have been given a list of strings representing words. Implement the following:

```cs
List<string> words = new List<string>() { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

Implement the following:

1. Find all words that contain the letter "a" and end with the letter "e" (case-insensitive) and store them in a new list.
2. Find the longest word in the list.

**Note:** You do not need to use **LINQ** for this task. However, the **Hint** below will state how to solve this task using **LINQ**.

> **Hint:** For **Task 8.1**, use the `Where` method with a condition like `word.ToLower().Contains("a") && word.ToLower().EndsWith("e")`. For **Task8.2**, use the `OrderByDescending` method. Here is an example, `OrderByDescending(word => word.Length)`.

## Task 9:

You have been given a list of integers representing the population of cities.

```cs
List<int> cityPopulations = new List<int>() { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

Implement the following:

1. Find the top 3 cities with the highest populations and store their populations in a new list.
2. Calculate the total population of all cities.

**Note:** You do not need to use **LINQ** for this task. However, the **Hint** below will state how to solve this task using **LINQ**.

> **Hint:** For **Task 9.1**, use `OrderByDescending` and `Take` methods, then convert the result into a `List`.

## Task 10:

Using `LINQ`, solve the following tasks from week 1's assessments:

- Task 3 in the formative assessment
- Task 4 in the summative assessment

## Submission

Push your code to your **GitHub** repository.
