# 02: List and Language Integrated Query

## List

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

**Resource:**

- [List\<T> Class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0)

## Language Integrated Query

**Language Integrated Query** or **LINQ** provides a set of features that extends the **C#** language to support queries against data sources. It provides a consistent way to query data from different data sources, i.e., in-memory collections, databases, etc.

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

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

You have been given two **lists** containing some programming languages.

```cs
List<string> progLangsOne = new List<string>() { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangsTwo = new List<string>() { "C++", "Go", "Swift", "TypeScript" };
```

Implement the following:

1. Use the `AddRange` method to add the elements of `progLangsOne` to `progLangsTwo` and assign the resulting combined list to a variable called `allProgLangs`
2. Use the `Add` method to add "Rust" to `allProgLangs`
3. Use the `Remove` method to remove "Swift" from `allProgLangs`
4. Use a loop to display each language in `allProgLangs`

## Task 2:

You have been given the following list of integers:

```c#
List<int> nums = new List<int>() { 10, 20, 30, 40, 50 };
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
4. Use the `Clear` method to remove all elements from `bookTitles`. Display the contents of `bookTitles` after clearing it.

## Task 4:

You have been given a list of `int` containing even numbers. Write a **LINQ** query that displays the sum of all even numbers in the list of `int`.

```cs
List<int> numbers = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
```

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

## Task 6:

You have been given a list of temperatures in celsius for a week.

```cs
List<double> temperatures = new List<double>() { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

Implement the following:

1. Calculate the average temperature for the week.
2. Find the highest temperature recorded during the week.
3. Find all the temperatures that are above 25 degrees celsius and store them in a new list.

## Task 7:

You have been given a list of integers representing exam scores of learners.

```cs
List<int> scores = new List<int>() { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

Implement the following:

1. Find the highest score in the list.
2. Find all the distinct scores (remove duplicates) and store them in a new list.

## Task 8:

You have been given a list of strings representing words. Implement the following:

```cs
List<string> words = new List<string>() { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

Implement the following:

1. Find all words that contain the letter "a" and end with the letter "e" (case-insensitive) and store them in a new list.
2. Find the longest word in the list.

## Task 9:

You have been given a list of integers representing the population of cities.

```cs
List<int> cityPopulations = new List<int>() { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

Implement the following:

1. Find the top 3 cities with the highest populations and store their populations in a new list.
2. Calculate the total population of all cities.

## Task 10:

Using `LINQ`, solve the following tasks from the previous formative assessment:

- Task 3
- Task 11

# Formative Assessment Submission

Push your code to your **GitHub** repository.
