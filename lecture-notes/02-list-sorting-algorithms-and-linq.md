# 02: List and LINQ

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

You have been given the following list of integers:

```c#
List<int> nums = new List<int>() { 10, 20, 30, 40, 50 };
```

Implement the following:

1. Use the `Insert` method to insert the number 25 at the second position in `nums`. Display the contents of `nums` after inserting the number 25.
2. Use the `Contains` method to check if the number 35 exists in `nums`. Assign the result to a variable called `hasNumber35`. Display the value of `hasNumber35`.
3. Use the `Find` method to find the first number in `nums` that is greater than 30 and assign it to a variable called `firstNumberGreaterThan30`. Display the value of `firstNumberGreaterThan30`.
4. Use the `Sort` method to sort `nums` in ascending order. Display the contents of `nums` after sorting it.

# Task 3:

You have been given the following list of strings representing book titles:

```c#
List<string> bookTitles = new List<string>() { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Brave New World" };
```

Implement the following:

1. Use the `Count` method to get the total number of book titles in `bookTitles` and assign it to a variable called `totalBooks`. Display the value of `totalBooks`.
2. Use the `Contains` method to check if the title "Brave New World" exists in `bookTitles`. Assign the result to a variable called `hasBraveNewWorld`. Display the value of `hasBraveNewWorld`.
3. Use the `FindIndex` method to find the index of the book title "1984" in `bookTitles` and assign it to a variable called `index1984`. Display the value of `index1984`.
4. Use the `Clear` method to remove all elements from `bookTitles`. Display the contents of `bookTitles` after clearing it.

# Task 4:

You have been given a list of `int` containing even numbers. Write a **LINQ** query that displays the sum of all even numbers in the list of `int`.

```cs
List<int> numbers = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
```

# Task 5:

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

# Task 6:

You have been given a list of temperatures in celsius for a week. 

```cs
List<double> temperatures = new List<double>() { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

Implement the following:

1. Calculate the average temperature for the week.
2. Find the highest temperature recorded during the week.
3. Find all the temperatures that are above 25 degrees celsius and store them in a new list.

# Task 7:

You have been given a list of integers representing exam scores of learners. 

```cs
List<int> scores = new List<int>() { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

Implement the following:

1. Find the highest score in the list.
2. Find all the distinct scores (remove duplicates) and store them in a new list.

# Task 8:

You have been given a list of strings representing words. Implement the following:

```cs
List<string> words = new List<string>() { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

Implement the following:

1. Find all words that contain the letter "a" and end with the letter "e" (case-insensitive) and store them in a new list.
2. Find the longest word in the list.

# Task 9:

You have been given a list of integers representing the population of cities. 

```cs	
List<int> cityPopulations = new List<int>() { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

Implement the following:

1. Find the top 3 cities with the highest populations and store their populations in a new list.
2. Calculate the total population of all cities.

# Task 10:

Using `LINQ`, solve the following tasks from the previous formative assessment:

- Task 3
- Task 10

# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please do not your own pull request.
