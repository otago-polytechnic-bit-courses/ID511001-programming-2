# 02: Arrays, Lists, Dictionaries and LINQ

## Arrays

An **array** is a data structure that stores a fixed-size sequence of elements of the same type. Arrays are reference types in C# where elements are stored in contiguous memory locations. Each element is accessed by its index, starting from 0. The size of an array is determined when it's created and cannot be changed.

### Key Characteristics of Arrays:
- **Fixed size**: Once created, the size cannot be modified
- **Zero-indexed**: First element is at index 0, last element at index `Length - 1`
- **Type-safe**: All elements must be of the same type
- **Reference type**: Arrays are stored on the heap

### Creating and Using Arrays

Here's how to create and work with arrays:

```cs
// Method 1: Declare with specific size, then assign values
int[] numbers = new int[5]; // Creates array with 5 elements (all initialized to 0)
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
numbers[3] = 40;
numbers[4] = 50;

// Method 2: Initialize with values at declaration
int[] values = new int[] { 10, 20, 30, 40, 50 };

// Method 3: Simplified initialization syntax
string[] fruits = { "Apple", "Banana", "Cherry" };

// Accessing elements
int firstNumber = numbers[0];    // Gets 10
int arrayLength = numbers.Length; // Gets 5

// Iterating through arrays
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"Element at index {i}: {numbers[i]}");
}

// Using foreach loop
foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

### Common Array Operations

```cs
string[] fruits = { "Banana", "Apple", "Cherry", "Date" };

// Find index of an element
int bananaIndex = Array.IndexOf(fruits, "Banana");
Console.WriteLine($"Banana is at index: {bananaIndex}"); // Output: 0

// Sort array (modifies original array)
Array.Sort(fruits);
Console.WriteLine($"Sorted fruits: {string.Join(", ", fruits)}");
// Output: Apple, Banana, Cherry, Date

// Reverse array (modifies original array)
Array.Reverse(fruits);
Console.WriteLine($"Reversed fruits: {string.Join(", ", fruits)}");
// Output: Date, Cherry, Banana, Apple

// Check if element exists
bool hasApple = Array.Exists(fruits, fruit => fruit == "Apple");
Console.WriteLine($"Contains Apple: {hasApple}");
```

### Multi-dimensional Arrays

```cs
// 2D array (matrix)
int[,] matrix = new int[3, 3] 
{
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Access element at row 1, column 2
int element = matrix[1, 2]; // Gets 6

// Jagged arrays (array of arrays)
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] { 1, 2, 3 };
jaggedArray[1] = new int[] { 4, 5 };
jaggedArray[2] = new int[] { 6, 7, 8, 9 };
```

## Lists

A **List<T>** is a generic collection that provides a resizable array. Unlike arrays, Lists can grow or shrink dynamically during runtime. Lists are part of the `System.Collections.Generic` namespace and are one of the most commonly used collections in C#.

### Key Characteristics of Lists:
- **Dynamic size**: Can grow or shrink during runtime
- **Zero-indexed**: Like arrays, first element is at index 0
- **Type-safe**: Generic implementation ensures type safety
- **Rich functionality**: Many built-in methods for manipulation

### Creating and Using Lists

```cs
using System.Collections.Generic;

// Create empty list
List<string> names = new List<string>();

// Create list with initial values
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// Create list with initial capacity (performance optimization)
List<string> cities = new List<string>(100);
```

### Common List Operations

```cs
List<string> fruits = new List<string>();

// Adding elements
fruits.Add("Apple");           // Add to end
fruits.Add("Banana");
fruits.Insert(1, "Orange");    // Insert at specific index

// Accessing elements
string firstFruit = fruits[0];     // Get first element
fruits[0] = "Green Apple";          // Modify element

// Removing elements
fruits.Remove("Banana");            // Remove by value
fruits.RemoveAt(1);                // Remove by index
fruits.RemoveAll(f => f.StartsWith("A")); // Remove all matching

// Searching
bool hasBanana = fruits.Contains("Banana");
int appleIndex = fruits.IndexOf("Apple");
string foundFruit = fruits.Find(f => f.Length > 5); // First match
List<string> longFruits = fruits.FindAll(f => f.Length > 5); // All matches

// Properties
int count = fruits.Count;        // Number of elements
int capacity = fruits.Capacity;  // Current capacity

// Sorting and manipulation
fruits.Sort();                   // Sort in ascending order
fruits.Reverse();               // Reverse order
fruits.Clear();                 // Remove all elements
```

### List vs Array: When to Use Which

| Feature | Array | List |
|---------|-------|------|
| Size | Fixed | Dynamic |
| Performance | Slightly faster access | Slightly slower due to bounds checking |
| Memory | More memory efficient | Uses more memory due to capacity management |
| Functionality | Basic operations | Rich set of methods |
| Use Case | When size is known and won't change | When size varies or unknown |

## Dictionaries

A **Dictionary<TKey, TValue>** is a collection of key-value pairs where each key is unique. It provides fast lookup based on keys using hash table implementation. Dictionaries are ideal when you need to associate values with unique identifiers.

### Key Characteristics of Dictionaries:
- **Key-value pairs**: Each entry consists of a unique key and associated value
- **Fast lookup**: O(1) average time complexity for access operations
- **Unique keys**: Each key can appear only once
- **Unordered**: Elements are not stored in any particular order

### Creating and Using Dictionaries

```cs
using System.Collections.Generic;

// Create empty dictionary
Dictionary<string, int> ages = new Dictionary<string, int>();

// Create dictionary with initial values
Dictionary<string, string> capitals = new Dictionary<string, string>
{
    {"USA", "Washington D.C."},
    {"France", "Paris"},
    {"Japan", "Tokyo"}
};

// Alternative initialization syntax
Dictionary<int, string> grades = new Dictionary<int, string>
{
    [90] = "A",
    [80] = "B",
    [70] = "C"
};
```

### Common Dictionary Operations

```cs
Dictionary<string, int> studentScores = new Dictionary<string, int>();

// Adding elements
studentScores.Add("Alice", 95);
studentScores["Bob"] = 87;        // Alternative way to add/update
studentScores["Charlie"] = 92;

// Accessing elements
int aliceScore = studentScores["Alice"];     // Direct access (throws exception if key doesn't exist)

// Safe access
if (studentScores.TryGetValue("David", out int davidScore))
{
    Console.WriteLine($"David's score: {davidScore}");
}
else
{
    Console.WriteLine("David not found");
}

// Updating elements
studentScores["Alice"] = 98;      // Update existing value

// Removing elements
studentScores.Remove("Bob");      // Remove by key
bool removed = studentScores.Remove("Eve"); // Returns false if key doesn't exist

// Checking existence
bool hasAlice = studentScores.ContainsKey("Alice");
bool hasScore90 = studentScores.ContainsValue(90);

// Properties
int count = studentScores.Count;
var keys = studentScores.Keys;      // Collection of all keys
var values = studentScores.Values;  // Collection of all values

// Iteration
foreach (KeyValuePair<string, int> kvp in studentScores)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Alternative iteration syntax
foreach (var student in studentScores)
{
    Console.WriteLine($"{student.Key}: {student.Value}");
}
```

### Dictionary Best Practices

```cs
// Use TryGetValue for safe access
Dictionary<string, int> inventory = new Dictionary<string, int>();

// Good: Safe access
if (inventory.TryGetValue("apples", out int appleCount))
{
    Console.WriteLine($"We have {appleCount} apples");
}

// Avoid: Direct access that can throw exceptions
// int apples = inventory["apples"]; // Throws KeyNotFoundException if key doesn't exist

// Use ContainsKey before accessing if unsure
if (inventory.ContainsKey("oranges"))
{
    int oranges = inventory["oranges"];
}
```

## Language Integrated Query (LINQ)

**LINQ** (Language-Integrated Query) provides a powerful, consistent way to query data from various sources including collections, databases, XML, and more. LINQ integrates query capabilities directly into the C# language.

### LINQ Namespace

```cs
using System.Linq; // Required for LINQ extension methods
```

### Query Syntax vs Method Syntax

LINQ can be written in two ways: **Query Syntax** (similar to SQL) and **Method Syntax** (using extension methods).

#### Query Syntax Example:

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evenNumbers = from num in numbers
                  where num % 2 == 0
                  orderby num descending
                  select num;

foreach (int num in evenNumbers)
{
    Console.WriteLine(num); // Output: 10, 8, 6, 4, 2
}
```

#### Method Syntax Example (Equivalent):

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evenNumbers = numbers
    .Where(num => num % 2 == 0)
    .OrderByDescending(num => num);

foreach (int num in evenNumbers)
{
    Console.WriteLine(num); // Output: 10, 8, 6, 4, 2
}
```

### Common LINQ Operations

#### Filtering with Where

```cs
List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };

// Find names longer than 4 characters
var longNames = names.Where(name => name.Length > 4);

// Find names starting with 'A'
var namesStartingWithA = names.Where(name => name.StartsWith("A"));
```

#### Projection with Select

```cs
List<string> words = new List<string> { "apple", "banana", "cherry" };

// Project to lengths
var lengths = words.Select(word => word.Length);

// Project to uppercase
var upperWords = words.Select(word => word.ToUpper());

// Project to anonymous objects
var wordInfo = words.Select(word => new { 
    Word = word, 
    Length = word.Length, 
    FirstChar = word[0] 
});
```

#### Sorting

```cs
List<int> numbers = new List<int> { 5, 2, 8, 1, 9 };

var ascending = numbers.OrderBy(n => n);
var descending = numbers.OrderByDescending(n => n);

// Multiple sort criteria
List<Person> people = new List<Person> 
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 30 }
};

var sorted = people.OrderBy(p => p.Age).ThenBy(p => p.Name);
```

#### Aggregation Operations

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

int sum = numbers.Sum();                    // 15
double average = numbers.Average();         // 3.0
int min = numbers.Min();                   // 1
int max = numbers.Max();                   // 5
int count = numbers.Count();               // 5
int evenCount = numbers.Count(n => n % 2 == 0); // 2
```

#### Set Operations

```cs
List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
List<int> list2 = new List<int> { 4, 5, 6, 7, 8 };

var distinct = list1.Distinct();           // Remove duplicates
var union = list1.Union(list2);           // All unique elements from both
var intersection = list1.Intersect(list2); // Common elements: 4, 5
var except = list1.Except(list2);         // Elements in list1 but not list2: 1, 2, 3
```

#### Element Operations

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

int first = numbers.First();                    // 1 (throws if empty)
int firstOrDefault = numbers.FirstOrDefault();  // 1 (returns default if empty)
int last = numbers.Last();                      // 5
bool any = numbers.Any(n => n > 3);            // true
bool all = numbers.All(n => n > 0);            // true
int single = numbers.Single(n => n == 3);      // 3 (throws if 0 or >1 matches)
```

#### Partitioning

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var firstThree = numbers.Take(3);              // 1, 2, 3
var skipFirstThree = numbers.Skip(3);          // 4, 5, 6, 7, 8, 9, 10
var takeWhileLessThan5 = numbers.TakeWhile(n => n < 5); // 1, 2, 3, 4
var skipWhileLessThan5 = numbers.SkipWhile(n => n < 5); // 5, 6, 7, 8, 9, 10
```

### LINQ with Complex Objects

```cs
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> Grades { get; set; }
    public string Major { get; set; }
}

List<Student> students = new List<Student>
{
    new Student { Name = "Alice", Age = 20, Grades = new List<int> { 90, 85, 92 }, Major = "CS" },
    new Student { Name = "Bob", Age = 19, Grades = new List<int> { 78, 82, 85 }, Major = "Math" },
    new Student { Name = "Charlie", Age = 21, Grades = new List<int> { 95, 90, 88 }, Major = "CS" }
};

// Find CS students with average grade > 85
var topCSStudents = students
    .Where(s => s.Major == "CS" && s.Grades.Average() > 85)
    .OrderByDescending(s => s.Grades.Average())
    .Select(s => new { s.Name, Average = s.Grades.Average() });

// Group students by major
var studentsByMajor = students
    .GroupBy(s => s.Major)
    .Select(g => new { Major = g.Key, Count = g.Count(), Students = g.ToList() });
```

### LINQ Performance Considerations

1. **Deferred Execution**: Most LINQ operations are executed when enumerated, not when defined
2. **Chain Operations**: Multiple operations can be chained efficiently
3. **ToList() vs IEnumerable**: Use `ToList()` when you need to enumerate multiple times

```cs
var query = numbers.Where(n => n > 5); // Not executed yet
var list = query.ToList(); // Now executed and materialized
```

# Exercises

Before you start, create a new **C# Console** application with a descriptive name.

**Important Note About AI Tools:**

Learning to use AI tools is valuable, but you **must** be aware of the following:

- Refine your prompts to get useful responses
- Don't trust AI responses blindly - verify and test the code
- Acknowledge AI tool usage in your assessment's repository **README.md** file, including what prompts you used and how you applied the responses

## Task 1:

You have been given two **lists** containing programming languages:

```cs
List<string> progLangsOne = new List<string> { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangsTwo = new List<string> { "C++", "Go", "Swift", "TypeScript" };
```

Implement the following:

1. Create a new `List<string>` called `allProgLangs`
2. Use the `AddRange` method to add all elements from `progLangsOne` to `allProgLangs`
3. Use the `AddRange` method again to add all elements from `progLangsTwo` to `allProgLangs`
4. Use the `Add` method to add "Rust" to `allProgLangs`
5. Use the `Remove` method to remove "Swift" from `allProgLangs`
6. Display each language in `allProgLangs` using a foreach loop

**Expected Output:** C#, JavaScript, Kotlin, Python, C++, Go, TypeScript, Rust

## Task 2:

You have been given the following list of integers:

```cs
List<int> nums = new List<int> { 65, 35, 79, 101, 35 };
```

Implement the following:

1. Use the `Insert` method to insert the number 25 at index 1 (second position) in `nums`. Display the contents of `nums` after insertion.
2. Use the `Contains` method to check if the number 35 exists in `nums`. Store the result in a boolean variable called `hasNumber35` and display it.
3. Use the `Find` method to find the first number in `nums` that is greater than 30. Store it in a variable called `firstNumberGreaterThan30` and display it.
4. Use the `Sort` method to sort `nums` in ascending order. Display the contents after sorting.

**Expected Results:**
- After insertion: 65, 25, 35, 79, 101, 35
- hasNumber35: True
- firstNumberGreaterThan30: 65
- After sorting: 25, 35, 35, 65, 79, 101

## Task 3:

You have been given the following list of book titles:

```cs
List<string> bookTitles = new List<string> { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Brave New World" };
```

Implement the following:

1. Use the `Count` property to get the total number of book titles and store it in `totalBooks`. Display the value.
2. Use the `Contains` method to check if "Brave New World" exists in the list. Store the result in `hasBraveNewWorld` and display it.
3. Use the `IndexOf` method to find the index of "1984". Store it in `index1984` and display it.
4. Use the `Clear` method to remove all elements from `bookTitles`. Display the count after clearing.

**Expected Results:**
- totalBooks: 4
- hasBraveNewWorld: True
- index1984: 2
- Count after clearing: 0

## Task 4:

Given the following list of integers, use LINQ to find and display the sum of all even numbers:

```cs
List<int> numbers = new List<int> { 1, 4, 7, 8, 11, 12, 15, 16, 19, 20 };
```

**Hint:** Use the `Where` method to filter even numbers, then use the `Sum` method.

**Expected Output:** Sum of even numbers: 60

## Task 5:

Given the following list of countries, use LINQ to display all countries starting with the letter "I" (case-insensitive):

```cs
List<string> countries = new List<string>
{
    "Argentina", "Australia", "Brazil", "Canada", "Egypt", 
    "France", "India", "Italy", "Mexico", "Netherlands", 
    "South Africa", "United States"
};
```

**Hint:** Use `Where` with `StartsWith` and `StringComparison.OrdinalIgnoreCase`.

**Expected Output:** India, Italy

## Task 6:

Given the following list of temperatures in Celsius for a week:

```cs
List<double> temperatures = new List<double> { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

Implement the following using LINQ:

1. Calculate and display the average temperature for the week
2. Find and display the highest temperature recorded
3. Find all temperatures above 25°C and store them in a new list, then display them

**Hint:** Use `Average()`, `Max()`, and `Where().ToList()` methods.

## Task 7:

Given the following exam scores:

```cs
List<int> scores = new List<int> { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

Implement the following using LINQ:

1. Find and display the highest score
2. Find all distinct scores (remove duplicates) and store them in a new list, then display them in ascending order

**Hint:** Use `Max()` and `Distinct().OrderBy().ToList()` methods.

## Task 8:

Given the following list of words:

```cs
List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

Implement the following using LINQ:

1. Find all words that contain the letter "a" AND end with the letter "e" (case-insensitive) and store them in a new list
2. Find the longest word in the list

**Hint:** 
- For part 1: Use `Where` with `Contains("a")` and `EndsWith("e")`
- For part 2: Use `OrderByDescending(word => word.Length).First()`

**Expected Results:**
- Words containing "a" and ending with "e": apple, orange, grape, pineapple
- Longest word: pineapple

## Task 9:

Given the following city populations:

```cs
List<int> cityPopulations = new List<int> { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

Implement the following using LINQ:

1. Find the top 3 cities with the highest populations and store their populations in a new list
2. Calculate the total population of all cities

**Hint:** 
- For part 1: Use `OrderByDescending().Take(3).ToList()`
- For part 2: Use `Sum()`

**Expected Results:**
- Top 3 populations: 8000000, 6000000, 5000000
- Total population: 29700000

## Task 10:

Create a dictionary to store student information where the key is the student name (string) and the value is their grade (int):

```cs
Dictionary<string, int> studentGrades = new Dictionary<string, int>
{
    {"Alice", 92},
    {"Bob", 87},
    {"Charlie", 95},
    {"Diana", 88},
    {"Eve", 91}
};
```

Implement the following:

1. Add a new student "Frank" with grade 89
2. Update Bob's grade to 90
3. Check if student "Alice" exists in the dictionary and display the result
4. Try to get "Grace's" grade safely using `TryGetValue` and display appropriate message
5. Display all students with grades above 90
6. Calculate and display the average grade of all students

## Task 11:

Create a list of `Product` objects and perform complex LINQ operations:

```cs
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}

List<Product> products = new List<Product>
{
    new Product { Name = "Laptop", Price = 999.99m, Category = "Electronics", Stock = 15 },
    new Product { Name = "Mouse", Price = 25.50m, Category = "Electronics", Stock = 50 },
    new Product { Name = "Desk", Price = 199.99m, Category = "Furniture", Stock = 8 },
    new Product { Name = "Chair", Price = 149.99m, Category = "Furniture", Stock = 12 },
    new Product { Name = "Monitor", Price = 299.99m, Category = "Electronics", Stock = 20 }
};
```

Implement the following using LINQ:

1. Find all products in the "Electronics" category with stock > 15
2. Calculate the average price of all products
3. Group products by category and display the count of products in each category
4. Find the most expensive product in each category
5. Find all products with price between $100 and $500

## Submission

Push your completed code to your **GitHub** repository. Ensure your code is well-commented and follows proper naming conventions.