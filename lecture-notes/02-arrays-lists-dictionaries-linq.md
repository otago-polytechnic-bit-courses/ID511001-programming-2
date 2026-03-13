# Week 02 — Arrays, Lists, Dictionaries & LINQ

## Navigation

|            | Link                                                                                 |
| ---------- | ------------------------------------------------------------------------------------ |
| ← Previous | [Week 01 — GitHub & C# Fundamentals](./lecture-notes/01-github-and-c#.md)              |
| → Next     | [Week 03 - Windows Forms Application](./lecture-notes/03-windows-forms-application.md) |

---

## 1. Arrays

An **array** is a data structure that stores a fixed-size sequence of elements of the same type. Elements are stored in contiguous memory locations and accessed by a zero-based index.

| Characteristic | Detail                                                      |
| -------------- | ----------------------------------------------------------- |
| Size           | Fixed at creation — cannot be changed                       |
| Indexing       | Zero-based — first element at `[0]`, last at `[Length - 1]` |
| Type safety    | All elements must be of the same type                       |
| Memory         | Reference type — stored on the heap                         |

---

### 1.1 Creating and Using Arrays

```cs
// Method 1 — declare with size, then assign values
int[] numbers = new int[5]; // elements default to 0
numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
numbers[3] = 40;
numbers[4] = 50;

// Method 2 — initialise with values at declaration
int[] values = new int[] { 10, 20, 30, 40, 50 };

// Method 3 — simplified initialisation
string[] fruits = { "Apple", "Banana", "Cherry" };

// Accessing elements
int first  = numbers[0];       // 10
int length = numbers.Length;   // 5

// Iterating — for loop (when you need the index)
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"Element at index {i}: {numbers[i]}");
}

// Iterating — foreach (when you only need the value)
foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

---

### 1.2 Common Array Operations

```cs
string[] fruits = { "Banana", "Apple", "Cherry", "Date" };

// Find the index of an element
int idx = Array.IndexOf(fruits, "Banana");     // 0

// Sort in ascending order (modifies the original array)
Array.Sort(fruits);
Console.WriteLine(string.Join(", ", fruits));  // Apple, Banana, Cherry, Date

// Reverse (modifies the original array)
Array.Reverse(fruits);
Console.WriteLine(string.Join(", ", fruits));  // Date, Cherry, Banana, Apple

// Check whether an element satisfying a condition exists
bool hasApple = Array.Exists(fruits, fruit => fruit == "Apple"); // true
```

---

### 1.3 Multi-dimensional Arrays

```cs
// 2D array (rows × columns)
int[,] matrix = new int[3, 3]
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

int element = matrix[1, 2]; // row 1, column 2 → 6

// Jagged array — each row can have a different length
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
jagged[2] = new int[] { 6, 7, 8, 9 };
```

| Key terms           |                                                                     |
| ------------------- | ------------------------------------------------------------------- |
| Array               | Fixed-size, zero-indexed sequence of elements of the same type      |
| `Array.Sort`        | Sorts the array in place in ascending order                         |
| `Array.Reverse`     | Reverses the array in place                                         |
| `Array.IndexOf`     | Returns the index of the first matching element, or -1 if not found |
| 2D array `[,]`      | Rectangular grid where all rows have the same number of columns     |
| Jagged array `[][]` | Array of arrays where each inner array can have a different length  |

---

## 2. Lists

A **`List<T>`** is a generic, resizable collection from the `System.Collections.Generic` namespace. Unlike arrays, lists grow and shrink dynamically at runtime.

| Characteristic | Detail                                                             |
| -------------- | ------------------------------------------------------------------ |
| Size           | Dynamic — grows or shrinks as needed                               |
| Indexing       | Zero-based, like arrays                                            |
| Type safety    | Generic `<T>` parameter enforces a single type                     |
| Functionality  | Rich set of built-in methods for searching, sorting, and filtering |

---

### 2.1 Creating Lists

```cs
using System.Collections.Generic;

// Empty list
List<string> names = new List<string>();

// List with initial values
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// List with a reserved initial capacity (avoids repeated resizing for large collections)
List<string> cities = new List<string>(100);
```

---

### 2.2 Common List Operations

```cs
List<string> fruits = new List<string>();

// --- Adding ---
fruits.Add("Apple");              // append to the end
fruits.Add("Banana");
fruits.Insert(1, "Orange");       // insert at index 1 → Apple, Orange, Banana

// --- Accessing and modifying ---
string first = fruits[0];         // "Apple"
fruits[0] = "Green Apple";        // overwrite element at index 0

// --- Removing ---
fruits.Remove("Banana");                          // remove first matching value
fruits.RemoveAt(1);                               // remove by index
fruits.RemoveAll(f => f.StartsWith("A"));         // remove all matching a condition

// --- Searching ---
bool hasBanana   = fruits.Contains("Banana");
int  appleIndex  = fruits.IndexOf("Apple");
string longFruit = fruits.Find(f => f.Length > 5);           // first match
List<string> longFruits = fruits.FindAll(f => f.Length > 5); // all matches

// --- Properties ---
int count    = fruits.Count;      // number of elements currently in the list
int capacity = fruits.Capacity;   // allocated capacity (may be larger than Count)

// --- Sorting and manipulation ---
fruits.Sort();     // sort ascending in place
fruits.Reverse();  // reverse in place
fruits.Clear();    // remove all elements
```

---

### 2.3 Array vs List — When to Use Which

|              | Array                   | List                                   |
| ------------ | ----------------------- | -------------------------------------- |
| Size         | Fixed                   | Dynamic                                |
| Access speed | Slightly faster         | Slightly slower (bounds checking)      |
| Memory       | More efficient          | Higher overhead (capacity management)  |
| Methods      | Basic                   | Rich (`Find`, `Sort`, `RemoveAll`, …)  |
| Best for     | Size known and constant | Size varies or unknown at compile time |

| Key terms             |                                                                             |
| --------------------- | --------------------------------------------------------------------------- |
| `List<T>`             | Generic resizable collection — the most commonly used collection type in C# |
| `Add`                 | Appends an element to the end of the list                                   |
| `Insert`              | Inserts an element at a specified index                                     |
| `Remove` / `RemoveAt` | Removes an element by value or by index                                     |
| `Contains`            | Returns `true` if the value is present in the list                          |
| `Find` / `FindAll`    | Returns the first / all elements matching a predicate                       |
| `Count`               | The number of elements currently in the list                                |

---

## 3. Dictionaries

A **`Dictionary<TKey, TValue>`** is a collection of key-value pairs. Each key is unique and maps directly to a value. Internally it uses a hash table, giving O(1) average-case lookup.

| Characteristic | Detail                                     |
| -------------- | ------------------------------------------ |
| Structure      | Key-value pairs                            |
| Lookup speed   | O(1) average                               |
| Keys           | Must be unique                             |
| Order          | Unordered — do not rely on insertion order |

---

### 3.1 Creating Dictionaries

```cs
using System.Collections.Generic;

// Empty dictionary
Dictionary<string, int> ages = new Dictionary<string, int>();

// With initial values — object initialiser syntax
Dictionary<string, string> capitals = new Dictionary<string, string>
{
    { "USA",    "Washington D.C." },
    { "France", "Paris" },
    { "Japan",  "Tokyo" }
};

// Indexed initialiser syntax (alternative)
Dictionary<int, string> grades = new Dictionary<int, string>
{
    [90] = "A",
    [80] = "B",
    [70] = "C"
};
```

---

### 3.2 Common Dictionary Operations

```cs
Dictionary<string, int> scores = new Dictionary<string, int>();

// --- Adding ---
scores.Add("Alice", 95);
scores["Bob"] = 87;       // indexer — adds if key absent, updates if present
scores["Charlie"] = 92;

// --- Accessing ---
int alice = scores["Alice"];  // direct access — throws KeyNotFoundException if absent

// Safe access with TryGetValue (preferred)
if (scores.TryGetValue("David", out int david))
    Console.WriteLine($"David's score: {david}");
else
    Console.WriteLine("David not found");

// --- Updating ---
scores["Alice"] = 98;     // overwrite existing value

// --- Removing ---
scores.Remove("Bob");
bool removed = scores.Remove("Eve"); // false if key does not exist

// --- Checking existence ---
bool hasAlice    = scores.ContainsKey("Alice");
bool hasScore90  = scores.ContainsValue(90);

// --- Properties ---
int  count  = scores.Count;
var  keys   = scores.Keys;    // ICollection of all keys
var  values = scores.Values;  // ICollection of all values

// --- Iterating ---
foreach (KeyValuePair<string, int> kvp in scores)
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");

// Shorthand with var
foreach (var entry in scores)
    Console.WriteLine($"{entry.Key}: {entry.Value}");
```

---

### 3.3 Safe Access Best Practices

```cs
// Always prefer TryGetValue when the key may be absent
if (inventory.TryGetValue("apples", out int appleCount))
    Console.WriteLine($"We have {appleCount} apples");

// Or check with ContainsKey first if you need two separate operations
if (inventory.ContainsKey("oranges"))
    Console.WriteLine(inventory["oranges"]);

// Avoid: direct access on an unverified key — throws KeyNotFoundException
// int apples = inventory["apples"];
```

| Key terms                  |                                                                             |
| -------------------------- | --------------------------------------------------------------------------- |
| `Dictionary<TKey, TValue>` | Key-value collection with O(1) average lookup via hashing                   |
| `TryGetValue`              | Safe key lookup — returns `false` instead of throwing if the key is absent  |
| `ContainsKey`              | Returns `true` if the key exists                                            |
| `ContainsValue`            | Returns `true` if the value exists (O(n) — scans all values)                |
| `KeyNotFoundException`     | Exception thrown when accessing a dictionary with a key that does not exist |

---

## 4. LINQ

**LINQ** (Language-Integrated Query) provides a consistent, readable way to query and transform data from any collection. LINQ is available after adding `using System.Linq`.

---

### 4.1 Query Syntax vs Method Syntax

LINQ can be written in two styles. Both produce identical results — method syntax is more commonly used in practice.

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Query syntax (similar to SQL)
var evenQ = from num in numbers
            where num % 2 == 0
            orderby num descending
            select num;

// Method syntax (equivalent)
var evenM = numbers
    .Where(num => num % 2 == 0)
    .OrderByDescending(num => num);

// Both produce: 10, 8, 6, 4, 2
```

---

### 4.2 Filtering — `Where`

```cs
List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };

var longNames         = names.Where(n => n.Length > 4);
var namesStartWithA   = names.Where(n => n.StartsWith("A"));
```

---

### 4.3 Projection — `Select`

```cs
List<string> words = new List<string> { "apple", "banana", "cherry" };

var lengths    = words.Select(w => w.Length);          // { 5, 6, 6 }
var upperWords = words.Select(w => w.ToUpper());        // { "APPLE", ... }

// Project to anonymous objects
var wordInfo = words.Select(w => new
{
    Word      = w,
    Length    = w.Length,
    FirstChar = w[0]
});
```

---

### 4.4 Sorting — `OrderBy` / `ThenBy`

```cs
var ascending  = numbers.OrderBy(n => n);
var descending = numbers.OrderByDescending(n => n);

// Multiple sort keys
var sorted = people
    .OrderBy(p => p.Age)
    .ThenBy(p => p.Name);  // secondary sort within equal ages
```

---

### 4.5 Aggregation

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

int    sum       = numbers.Sum();               // 15
double average   = numbers.Average();           // 3.0
int    min       = numbers.Min();               // 1
int    max       = numbers.Max();               // 5
int    count     = numbers.Count();             // 5
int    evenCount = numbers.Count(n => n % 2 == 0); // 2
```

---

### 4.6 Set Operations

```cs
List<int> a = new List<int> { 1, 2, 3, 4, 5 };
List<int> b = new List<int> { 4, 5, 6, 7, 8 };

var distinct      = a.Distinct();            // removes duplicates within a
var union         = a.Union(b);              // all unique elements from both
var intersection  = a.Intersect(b);          // common elements: 4, 5
var except        = a.Except(b);             // in a but not b: 1, 2, 3
```

---

### 4.7 Element Operations

```cs
int first          = numbers.First();                    // throws if empty
int firstOrDefault = numbers.FirstOrDefault();           // returns 0 if empty
int last           = numbers.Last();
bool any           = numbers.Any(n => n > 3);            // true
bool all           = numbers.All(n => n > 0);            // true
int  single        = numbers.Single(n => n == 3);        // throws if 0 or >1 matches
```

---

### 4.8 Partitioning — `Take` / `Skip`

```cs
var firstThree       = numbers.Take(3);                    // 1, 2, 3
var skipFirstThree   = numbers.Skip(3);                    // 4, 5, … 10
var takeWhileLt5     = numbers.TakeWhile(n => n < 5);     // 1, 2, 3, 4
var skipWhileLt5     = numbers.SkipWhile(n => n < 5);     // 5, 6, … 10
```

---

### 4.9 LINQ with Complex Objects

```cs
public class Student
{
    public string      Name   { get; set; }
    public int         Age    { get; set; }
    public List<int>   Grades { get; set; }
    public string      Major  { get; set; }
}

// CS students whose average grade exceeds 85, highest average first
var topCS = students
    .Where(s => s.Major == "CS" && s.Grades.Average() > 85)
    .OrderByDescending(s => s.Grades.Average())
    .Select(s => new { s.Name, Average = s.Grades.Average() });

// Group students by major
var byMajor = students
    .GroupBy(s => s.Major)
    .Select(g => new { Major = g.Key, Count = g.Count(), Students = g.ToList() });
```

---

### 4.10 Deferred Execution

Most LINQ operations are **not** executed when the query is defined — they run when you iterate over the result.

```cs
var query = numbers.Where(n => n > 5); // query defined but not yet run

// Execution happens here — at the point of enumeration
foreach (var n in query) { ... }

// ToList() forces immediate execution and stores results in memory
var list = query.ToList(); // safe to enumerate multiple times
```

| Key terms            |                                                                                 |
| -------------------- | ------------------------------------------------------------------------------- |
| LINQ                 | Language-Integrated Query — a set of extension methods for querying collections |
| Lambda expression    | Anonymous function written as `param => expression`, used in LINQ predicates    |
| Deferred execution   | LINQ query logic runs only when the result is enumerated, not when declared     |
| `Where`              | Filters elements that satisfy a predicate                                       |
| `Select`             | Projects each element to a new form                                             |
| `OrderBy` / `ThenBy` | Sorts by one or more keys                                                       |
| `GroupBy`            | Groups elements by a key selector                                               |
| `ToList()`           | Forces immediate execution and returns a concrete `List<T>`                     |

---

## Exercises

Before you start, create a new **C# Console** application with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Combine Lists

You have been given two lists of programming languages:

```cs
List<string> progLangsOne = new List<string> { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangsTwo = new List<string> { "C++", "Go", "Swift", "TypeScript" };
```

1. Create a new `List<string>` called `allProgLangs`
2. Use `AddRange` to add all elements from `progLangsOne`, then all from `progLangsTwo`
3. Use `Add` to append `"Rust"`
4. Use `Remove` to remove `"Swift"`
5. Display each language with a `foreach` loop

**Expected output:** C#, JavaScript, Kotlin, Python, C++, Go, TypeScript, Rust

---

### Task 2 — List Operations

You have been given the following list:

```cs
List<int> nums = new List<int> { 65, 35, 79, 101, 35 };
```

| Step | Operation                                                      | Expected result         |
| ---- | -------------------------------------------------------------- | ----------------------- |
| 1    | `Insert` 25 at index 1                                         | 65, 25, 35, 79, 101, 35 |
| 2    | `Contains` 35 → store in `hasNumber35`                         | `True`                  |
| 3    | `Find` first number > 30 → store in `firstNumberGreaterThan30` | `65`                    |
| 4    | `Sort` ascending                                               | 25, 35, 35, 65, 79, 101 |

---

### Task 3 — Book List

You have been given the following list:

```cs
List<string> bookTitles = new List<string> { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Brave New World" };
```

| Step | Operation                                                  | Expected result |
| ---- | ---------------------------------------------------------- | --------------- |
| 1    | `Count` → store in `totalBooks`                            | `4`             |
| 2    | `Contains` "Brave New World" → store in `hasBraveNewWorld` | `True`          |
| 3    | `IndexOf` "1984" → store in `index1984`                    | `2`             |
| 4    | `Clear`, then display `Count`                              | `0`             |

---

### Task 4 — Sum of Even Numbers

Given the following list, use LINQ to find and display the sum of all even numbers:

```cs
List<int> numbers = new List<int> { 1, 4, 7, 8, 11, 12, 15, 16, 19, 20 };
```

**Expected output:** `Sum of even numbers: 60`

> **Hint:** chain `Where(n => n % 2 == 0)` and `Sum()`.

---

### Task 5 — Filter Countries

Given the following list of countries, use LINQ to display all countries beginning with the letter `"I"` (case-insensitive):

```cs
List<string> countries = new List<string>
{
    "Argentina", "Australia", "Brazil", "Canada", "Egypt",
    "France", "India", "Italy", "Mexico", "Netherlands",
    "South Africa", "United States"
};
```

**Expected output:** India, Italy

> **Hint:** use `Where` with `StartsWith("I", StringComparison.OrdinalIgnoreCase)`.

---

### Task 6 — Temperature Analysis

Given a week of daily temperatures in Celsius:

```cs
List<double> temperatures = new List<double> { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

1. Calculate and display the average temperature
2. Find and display the highest temperature
3. Find all temperatures above 25 °C, store them in a new list, and display them

> **Hint:** use `Average()`, `Max()`, and `Where(...).ToList()`.

---

### Task 7 — Exam Scores

Given the following scores:

```cs
List<int> scores = new List<int> { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

1. Find and display the highest score
2. Remove duplicates, sort the remaining scores in ascending order, and display them

> **Hint:** chain `Distinct().OrderBy(n => n).ToList()`.

---

### Task 8 — Word Filter

Given the following list of words:

```cs
List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

1. Find all words that contain `"a"` **and** end with `"e"` (case-insensitive), and store them in a new list
2. Find the longest word in the list

| Expected result                          | Value                           |
| ---------------------------------------- | ------------------------------- |
| Words containing "a" and ending with "e" | apple, orange, grape, pineapple |
| Longest word                             | pineapple                       |

> **Hint:** for the longest word, use `OrderByDescending(w => w.Length).First()`.

---

### Task 9 — City Populations

Given the following city populations:

```cs
List<int> cityPopulations = new List<int> { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

1. Find the top 3 highest populations and store them in a new list
2. Calculate the total population of all cities

| Expected result   | Value                     |
| ----------------- | ------------------------- |
| Top 3 populations | 8000000, 6000000, 5000000 |
| Total population  | 29700000                  |

> **Hint:** use `OrderByDescending(...).Take(3).ToList()` and `Sum()`.

---

### Task 10 — Student Grades Dictionary

You have been given the following dictionary:

```cs
Dictionary<string, int> studentGrades = new Dictionary<string, int>
{
    { "Alice",   92 },
    { "Bob",     87 },
    { "Charlie", 95 },
    { "Diana",   88 },
    { "Eve",     91 }
};
```

1. Add `"Frank"` with grade `89`
2. Update Bob's grade to `90`
3. Check if `"Alice"` exists and display the result
4. Use `TryGetValue` to look up `"Grace"` and display an appropriate message
5. Display all students with grades above 90
6. Calculate and display the average grade of all students

> **Hint:** for steps 5 and 6, iterate over `studentGrades` and use LINQ on `studentGrades.Values`.

---

### Task 11 — Product LINQ

Create the following record and list:

```cs
public record Product(string Name, decimal Price, string Category, int Stock);

List<Product> products = new List<Product>
{
    new Product("Laptop",  999.99m, "Electronics", 15),
    new Product("Mouse",    25.50m, "Electronics", 50),
    new Product("Desk",    199.99m, "Furniture",    8),
    new Product("Chair",   149.99m, "Furniture",   12),
    new Product("Monitor", 299.99m, "Electronics", 20)
};
```

Implement the following using LINQ:

1. Find all Electronics products with stock > 15
2. Calculate the average price of all products
3. Group products by category and display the count in each group
4. Find the most expensive product in each category
5. Find all products priced between $100 and $500

> **Hint:** for step 4, use `GroupBy` then `MaxBy(p => p.Price)` (or `OrderByDescending(...).First()` per group).

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
