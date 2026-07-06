# Module 02: Collections and LINQ

## Navigation

|            | Link                                                                                       |
| ---------- | ------------------------------------------------------------------------------------------ |
| ← Previous | [Module 01: Git, GitHub and C#](./01-github-and-csharp-foundations.md)                     |
| → Next     | [Module 03: Classes, Objects and Encapsulation](./03-classes-objects-and-encapsulation.md) |

---

_(This week uses the same recurring labels explained in Week 01: why it matters, design first, quick check, and task.)_

Last week you stored single values in variables. This week is about storing **groups** of values, and querying them without writing loops for every little thing.

---

## 1. Arrays: a quick recap

You met arrays briefly last week. As a reminder: an array is a **fixed-size**, zero-indexed sequence of elements, all of the same type.

```cs
int[] numbers = new int[5];         // all zeros to start
numbers[0] = 10;

int[] values = { 10, 20, 30, 40, 50 };   // initialise inline
string[] fruits = { "Apple", "Banana", "Cherry" };

int first = numbers[0];
int length = numbers.Length;
```

A few operations you'll use often:

```cs
string[] fruits = { "Banana", "Apple", "Cherry", "Date" };

int idx = Array.IndexOf(fruits, "Banana");  // 0
Array.Sort(fruits);                         // sorts in place
Array.Reverse(fruits);                      // reverses in place
bool hasApple = Array.Exists(fruits, f => f == "Apple");
```

And two-dimensional / jagged arrays, if your data is grid-shaped:

```cs
int[,] matrix = new int[3, 3]
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};
int element = matrix[1, 2]; // row 1, col 2 → 6

// Jagged: each row can be a different length
int[][] jagged = new int[3][];
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
```

**Why this matters.** Arrays are fast and memory-efficient, but that fixed size is a real limitation. You can't add a sixth item to a five-item array. That's exactly the gap `List<T>` fills.

### 1.1 A modern shorthand: collection expressions

Recent C# offers a single, unified square-bracket syntax for building an array, a `List<T>`, or several other collection types, all with the same-looking literal:

```cs
int[] values = [10, 20, 30, 40, 50];          // an array
List<string> fruits = ["Apple", "Banana"];    // a List<T>, using the same [ ] syntax
```

This does the same thing as `int[] values = { 10, 20, 30, 40, 50 };` and `new List<string> { "Apple", "Banana" }` respectively; it's just a newer, shorter way to write it, and the compiler works out which collection type to build from the variable's declared type. This course's own examples stick with the older, more explicit forms shown above, since they make it clearer which specific type you're creating while you're still learning the difference between an array and a `List<T>`. Recognise the square-bracket form when you see it though, since it's becoming increasingly common in modern C# code.

---

## 2. Lists

`List<T>` is a generic, resizable collection. It grows and shrinks as you add and remove items. This is the collection you'll reach for by default; arrays are for the specific case where the size genuinely never changes.

```cs
using System.Collections.Generic;

List<string> names = new List<string>();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
```

### 2.1 The operations you'll use constantly

```cs
List<string> fruits = new List<string>();

// Adding
fruits.Add("Apple");
fruits.Add("Banana");
fruits.Insert(1, "Orange");        // Apple, Orange, Banana

// Accessing / modifying
string first = fruits[0];
fruits[0] = "Green Apple";

// Removing
fruits.Remove("Banana");                    // first matching value
fruits.RemoveAt(1);                         // by index
fruits.RemoveAll(f => f.StartsWith("A"));   // every match

// Searching
bool hasBanana = fruits.Contains("Banana");
int appleIndex = fruits.IndexOf("Apple");
string longFruit = fruits.Find(f => f.Length > 5);            // first match
List<string> longFruits = fruits.FindAll(f => f.Length > 5);  // all matches

// Properties
int count = fruits.Count;

// Sorting
fruits.Sort();
fruits.Reverse();
fruits.Clear();
```

|          | Array                   | List                                  |
| -------- | ----------------------- | ------------------------------------- |
| Size     | Fixed                   | Dynamic                               |
| Best for | Size known and constant | Size varies at runtime                |
| Methods  | Basic                   | Rich (`Find`, `Sort`, `RemoveAll`, …) |

| Key terms                       |                                                                            |
| ------------------------------- | -------------------------------------------------------------------------- |
| `List<T>`                       | Generic resizable collection, and your default choice for a group of items |
| `Add` / `Insert`                | Append, or insert at a specific index                                      |
| `Remove` / `RemoveAt`           | Remove by value, or by index                                               |
| `Contains` / `Find` / `FindAll` | Search for a match                                                         |

### 2.2 `List<T>.ForEach` versus `foreach`

`List<T>` has its own `ForEach` method, as an alternative to the `foreach` loop from Week 01. They look similar, but they're not quite the same thing:

```cs
List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };

// foreach: a loop, one of C#'s built-in control structures
foreach (string fruit in fruits)
    Console.WriteLine(fruit);

// List<T>.ForEach: a method on the list itself, taking a lambda expression
fruits.ForEach(fruit => Console.WriteLine(fruit));
```

Both print the same three lines. `foreach` works on any collection at all, reads clearly to almost anyone, and is easy to step through with the debugger, one line at a time. `ForEach` only exists on `List<T>` specifically, and packs the same idea into a single expression.

**Rule of thumb for this course:** default to `foreach`. It's the more general tool, it's what you'll see most often in other people's code, and it's the one this course's examples will keep using from here on. `ForEach` is worth recognising when you come across it, but it isn't something you need to reach for yourself.

| Key terms         |                                                                                   |
| ----------------- | --------------------------------------------------------------------------------- |
| `foreach`         | A loop construct, works on any collection type                                    |
| `List<T>.ForEach` | A method specific to `List<T>`, taking a lambda expression instead of a loop body |

**Design first.** Before Task 1, sketch the final list on paper, something like "start empty, add all of list one, then all of list two, then Rust, then take Swift out," in that order. It's easy to get `AddRange` and `Add` mixed up if you code first and think second.

### Task 1: Combine Lists

```cs
List<string> progLangsOne = new List<string> { "C#", "JavaScript", "Kotlin", "Python" };
List<string> progLangsTwo = new List<string> { "C++", "Go", "Swift", "TypeScript" };
```

1. Create `allProgLangs` as a new `List<string>`
2. `AddRange` everything from `progLangsOne`, then `progLangsTwo`
3. `Add` `"Rust"`
4. `Remove` `"Swift"`
5. Display each language with `foreach`

**Expected:** C#, JavaScript, Kotlin, Python, C++, Go, TypeScript, Rust

### Task 2: List Operations

```cs
List<int> nums = new List<int> { 65, 35, 79, 101, 35 };
```

| Step | Operation                                             | Expected result         |
| ---- | ----------------------------------------------------- | ----------------------- |
| 1    | `Insert` 25 at index 1                                | 65, 25, 35, 79, 101, 35 |
| 2    | `Contains` 35 → `hasNumber35`                         | `True`                  |
| 3    | `Find` first number > 30 → `firstNumberGreaterThan30` | `65`                    |
| 4    | `Sort` ascending                                      | 25, 35, 35, 65, 79, 101 |

### Task 3: Book List

```cs
List<string> bookTitles = new List<string> { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Brave New World" };
```

| Step | Operation                                         | Expected result |
| ---- | ------------------------------------------------- | --------------- |
| 1    | `Count` → `totalBooks`                            | `4`             |
| 2    | `Contains` "Brave New World" → `hasBraveNewWorld` | `True`          |
| 3    | `IndexOf` "1984" → `index1984`                    | `2`             |
| 4    | `Clear`, then display `Count`                     | `0`             |

---

## 3. Dictionaries

A `Dictionary<TKey, TValue>` maps unique keys to values, backed by a hash table, so lookups are, on average, instant regardless of how big the dictionary gets. Use one whenever you're thinking "I want to look this up _by name_," rather than by position.

```cs
using System.Collections.Generic;

Dictionary<string, int> ages = new Dictionary<string, int>();

Dictionary<string, string> capitals = new Dictionary<string, string>
{
    { "USA", "Washington D.C." },
    { "France", "Paris" },
    { "Japan", "Tokyo" }
};
```

### 3.1 Operations

```cs
Dictionary<string, int> scores = new Dictionary<string, int>();

// Adding / updating
scores.Add("Alice", 95);
scores["Bob"] = 87;         // indexer: adds if absent, updates if present

// Safe access: always prefer this over scores["David"], which throws if the key is missing
if (scores.TryGetValue("David", out int david))
    Console.WriteLine($"David's score: {david}");
else
    Console.WriteLine("David not found");

// Removing
scores.Remove("Bob");

// Checking
bool hasAlice = scores.ContainsKey("Alice");

// Iterating
foreach (var entry in scores)
    Console.WriteLine($"{entry.Key}: {entry.Value}");
```

| Key terms                  |                                                                             |
| -------------------------- | --------------------------------------------------------------------------- |
| `Dictionary<TKey, TValue>` | Key-value collection, near-instant lookup by key                            |
| `TryGetValue`              | Safe lookup, returning `false` instead of an exception if the key's missing |
| `ContainsKey`              | Checks whether a key exists                                                 |

### Task 4: Student Grades Dictionary

```cs
Dictionary<string, int> studentGrades = new Dictionary<string, int>
{
    { "Alice", 92 }, { "Bob", 87 }, { "Charlie", 95 }, { "Diana", 88 }, { "Eve", 91 }
};
```

1. Add `"Frank"` with grade `89`
2. Update Bob's grade to `90`
3. Check if `"Alice"` exists and display the result
4. `TryGetValue` for `"Grace"` and display an appropriate message
5. Display every student with a grade above 90
6. Calculate and display the average grade

> **Hint:** for 5 and 6, iterate over `studentGrades` and use LINQ (coming up next) on `studentGrades.Values`.

---

## 4. LINQ

**LINQ** (Language-Integrated Query) is a set of methods for filtering, transforming, and summarising _any_ collection, in a consistent and readable way. No more hand-rolled loops for "give me everything over 18." Add `using System.Linq` to unlock it.

**Why this matters.** Compare a hand-written loop that filters and sorts a list against the LINQ version below. The LINQ version reads almost like the English sentence describing what you want, and that readability is the entire point.

```cs
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Method syntax: what you'll use almost all the time
var evens = numbers.Where(n => n % 2 == 0).OrderByDescending(n => n);
// → 10, 8, 6, 4, 2

// Query syntax exists too (SQL-like), and produces an identical result. You'll see it
// occasionally, but method syntax is the industry default.
var evensQuery = from n in numbers where n % 2 == 0 orderby n descending select n;
```

**Design first.** LINQ chains are pipelines: data flows through each `.Method()` in order. Before writing a chain longer than one method, write the pipeline as a short list, such as _filter, then sort, then limit_. If you can name each stage in English, the C# is just translation.

### 4.1 Filtering and projecting

```cs
List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };

var longNames = names.Where(n => n.Length > 4);           // filter
var upper = names.Select(n => n.ToUpper());      // transform each element
```

### 4.2 Sorting

```cs
var ascending = numbers.OrderBy(n => n);
var descending = numbers.OrderByDescending(n => n);
var sorted = people.OrderBy(p => p.Age).ThenBy(p => p.Name); // secondary sort key
```

### 4.3 Aggregating

```cs
int sum = numbers.Sum();
double average = numbers.Average();
int min = numbers.Min();
int max = numbers.Max();
int evenCount = numbers.Count(n => n % 2 == 0);
```

### Task 5: Sum of Even Numbers

```cs
List<int> numbers = new List<int> { 1, 4, 7, 8, 11, 12, 15, 16, 19, 20 };
```

Use `Where` and `Sum` to find and display the sum of all even numbers. **Expected:** `60`.

### Task 6: Filter Countries

```cs
List<string> countries = new List<string> { "Argentina", "Australia", "Brazil", "Canada", "Egypt", "France", "India", "Italy", "Mexico", "Netherlands", "South Africa", "United States" };
```

Display every country starting with `"I"`, case-insensitive. **Expected:** India, Italy.

> **Hint:** `Where(c => c.StartsWith("I", StringComparison.OrdinalIgnoreCase))`.

### Task 7: Temperature Analysis

```cs
List<double> temperatures = new List<double> { 24.5, 23.8, 25.3, 22.6, 26.1, 27.5, 21.9 };
```

1. Display the average
2. Display the highest
3. Find all above 25°C, store in a new list, and display them

> **Hint:** `Average()`, `Max()`, `Where(...).ToList()`.

### Task 8: Exam Scores

```cs
List<int> scores = new List<int> { 78, 89, 92, 65, 70, 85, 92, 78, 93, 80 };
```

1. Display the highest score
2. Remove duplicates, sort ascending, and display

> **Hint:** `Distinct().OrderBy(n => n).ToList()`.

### 4.4 Set and element operations, and partitioning

```cs
List<int> a = new List<int> { 1, 2, 3, 4, 5 };
List<int> b = new List<int> { 4, 5, 6, 7, 8 };

var distinct = a.Distinct();
var union = a.Union(b);
var intersection = a.Intersect(b);   // 4, 5
var except = a.Except(b);            // 1, 2, 3

bool any = numbers.Any(n => n > 3);
bool all = numbers.All(n => n > 0);

var firstThree = numbers.Take(3);
var skipFirstThree = numbers.Skip(3);
```

### Task 9: Word Filter

```cs
List<string> words = new List<string> { "apple", "banana", "orange", "grape", "kiwi", "pineapple" };
```

1. Find every word containing `"a"` **and** ending with `"e"` (case-insensitive) → new list
2. Find the longest word

| Expected                                 | Value                           |
| ---------------------------------------- | ------------------------------- |
| Words containing "a" and ending with "e" | apple, orange, grape, pineapple |
| Longest word                             | pineapple                       |

> **Hint:** for the longest word, `OrderByDescending(w => w.Length).First()`.

### Task 10: City Populations

```cs
List<int> cityPopulations = new List<int> { 5000000, 3000000, 1200000, 8000000, 2000000, 4500000, 6000000 };
```

1. Top 3 populations → new list
2. Total population of all cities

| Expected | Value                     |
| -------- | ------------------------- |
| Top 3    | 8000000, 6000000, 5000000 |
| Total    | 29700000                  |

> **Hint:** `OrderByDescending(...).Take(3).ToList()` and `Sum()`.

### 4.5 LINQ with your own objects

LINQ isn't limited to primitives. This is where it gets genuinely useful, because you'll spend most of this course querying lists of _your own classes_.

```cs
public record Product(string Name, decimal Price, string Category, int Stock);

List<Product> products = new List<Product>
{
    new Product("Laptop", 999.99m, "Electronics", 15),
    new Product("Mouse", 25.50m, "Electronics", 50),
    new Product("Desk", 199.99m, "Furniture", 8),
};

var topCS = products
    .Where(p => p.Category == "Electronics" && p.Stock > 15)
    .OrderByDescending(p => p.Price)
    .Select(p => new { p.Name, p.Price });

var byCategory = products
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, Count = g.Count() });
```

> Deferred execution: most LINQ queries don't actually run until you enumerate them (with `foreach`, or by calling `.ToList()`). Call `.ToList()` once you're happy with a result and want to reuse it safely.

| Key terms          |                                                                             |
| ------------------ | --------------------------------------------------------------------------- |
| LINQ               | Language-Integrated Query, giving consistent querying across any collection |
| Lambda expression  | `param => expression`, an anonymous function, used everywhere in LINQ       |
| `Where` / `Select` | Filter / transform                                                          |
| `GroupBy`          | Groups elements by a key                                                    |
| Deferred execution | The query runs when enumerated, not when declared                           |

### Task 11: Product LINQ

```cs
public record Product(string Name, decimal Price, string Category, int Stock);

List<Product> products = new List<Product>
{
    new Product("Laptop", 999.99m, "Electronics", 15),
    new Product("Mouse", 25.50m, "Electronics", 50),
    new Product("Desk", 199.99m, "Furniture", 8),
    new Product("Chair", 149.99m, "Furniture", 12),
    new Product("Monitor", 299.99m, "Electronics", 20)
};
```

1. All Electronics products with stock > 15
2. Average price of all products
3. Group by category, display the count per group
4. The most expensive product in each category
5. All products priced between $100 and $500

> **Hint:** for 4, `GroupBy` then `MaxBy(p => p.Price)` (or `OrderByDescending(...).First()` inside each group).

---

## Before you submit

- [ ] All 11 tasks complete and tested
- [ ] `README.md` updated with any AI prompts used
- [ ] Pushed to your GitHub repository
