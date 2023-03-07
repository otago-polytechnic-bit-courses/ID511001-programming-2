# 03: Abstract Data Types (ADTs)

Lecture video can found here - https://bit.ly/3JfCb4c

## What is an abstract data type?

An abstract data type (ADT) is a mathematical model for a certain class of data structures with similar behaviour. An ADT specifies a set of operations that can be performed on the data and the behaviour of those operations. It is called "abstract" because it is not tied to any specific data structure implementation. It does not specify how the data is stored or organised in memory.

The main advantage of using an ADT is that it provides a clear and consistent interface for working with the data structure, regardless of the underlying implementation. It makes it easier to use the data structure and reduces the risk of errors or bugs in the code.

An ADT is typically defined by a set of function prototypes or method signatures that specify the name of the operation, the input parameters, and the return value. For example, a stack ADT might include operations such as "push" and "pop", which allow the user to insert and remove items from the stack.

It is important to note that an ADT does not specify the actual implementation of the operations. It means that different implementations of the same ADT may use different algorithms or data structures to achieve the same behaviour. For example, a stack ADT could be implemented using an array or a linked list, depending on the specific needs and constraints of the application.

Abstract data types are a useful tool for designing and organising data structures in computer science. They allow developers to think about the high-level behaviour of the data structure rather than the low-level details of its implementation, making it easier to write and maintain code.

## List

A list is a collection of items stored as an array and can be accessed by an index number. Lists are similar to arrays, but they can be resized dynamically, which means that you can add or remove items from the list after it is created.

There are different types of lists in different programming languages, but they all have some basic features. Here are some common operations that can be performed on lists:

* Adding items to the list: You can add new items to the end of the list or insert them at a specific position.
* Removing items from the list: You can remove them from the list by their position or value.
* Accessing items in the list: You can access an item by its position using an index number.
* Searching the list: You can search the list for a specific item and find its position.
* Sorting the list: You can sort the items in the list in ascending or descending order.

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

## Set

A set is a collection of distinct items that are unordered and have no duplicate items. Sets are often used to store and manipulate data collections in which the order of the items is not important, and the items themselves are the primary focus. Sets are commonly used to test membership, remove duplicate items from a list, and perform mathematical set operations such as union, intersection, and difference.

In most programming languages, sets are implemented using a hash table or a tree data structure, which allows them to provide fast and efficient membership testing and set operations. Sets typically support the following operations:

* Insertion: Adding a new item to the set
* Deletion: Removing an item from the set
* Membership testing: Checking if an item is in the set
* Set union: Creating a new set that includes all the items from both sets
* Set intersection: Creating a new set that includes only the items that are present in both sets
* Set difference: Creating a new set that includes only the items that are present in one set but not the other

Here is an example of a simple set class implemented using a hash table:

```cs
public class Set
{
    private HashSet<int> items;

    public Set()
    {
        items = new HashSet<int>();
    }

    public void Add(int item)
    {
        items.Add(item);
    }

    public void Remove(int item)
    {
        items.Remove(item);
    }

    public bool Contains(int item)
    {
        return items.Contains(item);
    }

    public Set Union(Set other)
    {
        Set result = new Set();
        result.items = new HashSet<int>(items);
        result.items.UnionWith(other.items);
        return result;
    }

    public Set Intersection(Set other)
    {
        Set result = new Set();
        result.items = new HashSet<int>(items);
        result.items.IntersectWith(other.items);
        return result;
    }

    public Set Difference(Set other)
    {
        Set result = new Set();
        result.items = new HashSet<int>(items);
        result.items.ExceptWith(other.items);
        return result;
    }
}
```

One of the main advantages of using a set is that it allows you to quickly and easily test membership and perform set operations. Because sets are implemented using a hash table or a tree, these operations can be performed in constant time or logarithmic time, depending on the implementation.

However, sets have some limitations as well. Because they do not preserve the order of the items, sets are not suitable for storing data that needs to be accessed in a specific order. Additionally, sets do not allow duplicate items, meaning they cannot be used to store data that requires multiple copies of the same item.

Sets are a useful data structure that can be used to store and manipulate data collections in which the order of the items is not important, and the focus is on the items themselves.

## Map

A map, also known as a dictionary or an associative array, is a data structure that stores a collection of key-value pairs. Each key is associated with a single value, and the key-value pairs are stored in a specific order. Maps are commonly used to store and manipulate data in which the key is used to identify the value, and the value is the data being stored.

In most programming languages, maps are implemented using a hash table or a tree data structure, which allows them to provide fast and efficient lookups and updates. Maps typically support the following operations:

* Insertion: Adding a new key-value pair to the map
* Deletion: Removing a key-value pair from the map
* Lookup: Retrieving a value associated with a given key
* Update: Modifying a value associated with a given key

Here is an example of a simple map class implemented using a hash table:

```cs
public class Map
{
    private Dictionary<string, int> items;

    public Map()
    {
        items = new Dictionary<string, int>();
    }

    public void Add(string key, int value)
    {
        items[key] = value;
    }

    public int Remove(string key)
    {
        int value;
        if (!items.TryGetValue(key, out value))
        {
            throw new Exception("Key not found");
        }
        items.Remove(key);
        return value;
    }

    public int Lookup(string key)
    {
        int value;
        if (!items.TryGetValue(key, out value))
        {
            throw new Exception("Key not found");
        }
        return value;
    }
    
    public void Update(string key, int newValue)
    {
        if (!items.ContainsKey(key))
        {
            throw new Exception("Key not found");
        }
        items[key] = newValue;
    }
}
```

This map class uses a `Dictionary` object from the C# standard library to store the key-value pairs. The Add method adds a new key-value pair to the map by simply assigning the value to the corresponding key in the dictionary. The `Remove` method removes a key-value pair from the map using the `TryGetValue` method to retrieve the value associated with the key and then calls the `Remove` method on the dictionary. The `Lookup` method retrieves the value associated with a given key by using the `TryGetValue` method to look up the value in the dictionary.

Maps are a useful data structure that can be used to store and manipulate data in which the key is used to identify the value, and the value is the data being stored. They are especially useful when working with large data collections and when the data needs to be accessed quickly using a specific identifier.

## Stack

A stack is a linear data structure that stores items in a last-in, first-out (LIFO) order. Stacks are often used to store and manipulate data that needs to be processed in a specific order, such as the undo/redo history in a text editor or the call stack in a program.

In most programming languages, stacks are implemented using an array or a linked list, which allows them to provide fast and efficient access to the items they contain. Stacks typically support the following operations:

* Push: Adding a new item to the top of the stack
* Pop: Removing the top item from the stack
* Peek: Retrieving the top item from the stack without removing it

Here is an example of a simple stack class implemented:

```cs
public class Stack
{
    private int[] items;
    private int top;

    public Stack(int capacity)
    {
        items = new int[capacity];
        top = -1;
    }

    public void Push(int item)
    {
        if (top == items.Length - 1)
        {
            throw new Exception("Stack is full");
        }
        items[++top] = item;
    }

    public int Pop()
    {
        if (top == -1)
        {
            throw new Exception("Stack is empty");
        }
        return items[top--];
    }

    public int Peek()
    {
        if (top == -1)
        {
            throw new Exception("Stack is empty");
        }
        return items[top];
    }
}
```

This stack class uses an array to store the items in the stack, and the `top` variable keeps track of the index of the top item in the stack. The `Push` method adds a new item to the top of the stack by incrementing the `top` variable and storing the item at the new index. The `Pop` method removes the top item from the stack by returning the item at the current `top` index and then decrementing the `top` variable. The `Peek` method retrieves the top item from the stack without removing it by simply returning the item at the current `top` index.

Stacks are useful data structures that can store and manipulate data that needs to be processed in a specific order. They are especially useful for implementing undo/redo functionality and maintaining a program's call stack.

## Queue

A queue is a linear data structure that follows a first-in, first-out (FIFO) principle. It means that the first item added to the queue will be the first one to be removed.

In computer programming, a queue can be implemented using an array or a linked list. The basic operations that can be performed on a queue include enqueue, which adds an item to the end of the queue, and dequeue, which removes the item from the front of the queue.

For example, consider a queue of customers waiting to check out at a grocery store. The first customer in line will be the first to reach the cashier and complete their transaction. As each customer finishes and leaves, the next customer in line will be able to check out. It is an example of the FIFO principle in action.

In a computer program, a queue might be used to store data that needs to be processed in a specific order, such as the tasks in a to-do list or the messages in a messaging app. For example, a task queue might store tasks that need to be processed by a group of worker threads, with the worker threads taking tasks from the front of the queue and processing them in the order they were received.

There are several variations of the basic queue data structure, including priority queues, which allow items to be added with a priority level that determines the order in which they are dequeued, and circular queues, which reuse space at the end of the queue when new items are added.

Here is an example of a queue:

```cs
Queue<int> myQueue = new Queue<int>();
myQueue.Enqueue(1);
myQueue.Enqueue(2);
myQueue.Enqueue(3);
int firstItem = myQueue.Dequeue();
foreach (int item in myQueue)
{
  Console.WriteLine(item);
}
```

In this example, we create a queue of integers and add three items to it. Then, we remove the first item (1) and print the remaining items (2 and 3).

This code creates a new queue of integers using the `Queue<int>` class, and adds three items to the queue using the `Enqueue` method. It then removes the first item from the queue using the `Dequeue` method, and stores it in the `firstItem` variable. Finally, it uses a `foreach` loop to iterate over the remaining items in the queue and print them to the console.

Note that the `Enqueue` and `Dequeue` methods are part of the `Queue<T>` class, a generic class that can be used to create queues of any type. To create a queue of a different type, such as a queue of strings, you can use `Queue<string>` instead.

In addition to the basic enqueue and dequeue operations, queues may also support additional operations such as peek, which allows you to view the item at the front of the queue without removing it, and clear, which removes all items from the queue.

Queues can also be implemented using other data structures, such as stacks or linked lists. Stack-based queues, for example, use a stack to store items that are waiting to be dequeued, while linked list-based queues use a linked list to store the items in the queue.

Queues are useful for storing and processing data that needs to be handled in a specific order or storing data that multiple consumers will use. They are commonly used in computer systems to manage tasks, communications, and data flow.

# Formative Assessment

Before you start, create a new branch called **03-formative-assessment**.

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

## Task 2:

You have been given two **sets** containing some numbers.

```cs
Set mySet = new Set();
mySet.Add(1);
mySet.Add(2);
mySet.Add(3);

Set myOtherSet = new Set();
myOtherSet.Add(3);
myOtherSet.Add(4);
```

Implement the following:

1. In the `Set` class, create a `Print` method that uses a loop to display each item in the `items` collection.
2. Use the `Contains` method to check if `mySet` contains the value `10`
3. Use the `Remove` method to remove the value `2` from `mySet`
4. Use the `Union`, `Intersection` and `Difference` methods to display the union, intersection and difference between `mySet` and `myOtherSet`

## Task 3:

You have been given a **map** containing course codes.

```cs
Map myMap = new Map();
myMap.Add("ID511001", 1);
myMap.Add("ID607001", 2);
myMap.Add("ID608001", 3);
myMap.Add("ID721001", 4);
myMap.Add("ID737001", 5);
```

Implement the following:

1. Use the `Lookup` method to lookup the value associated with the key "ID721001" in `myMap`
2. Use the `Remove` method to remove the key-value pair with the key "ID607001" from `myMap`.
3. Use the `Lookup` method to lookup the value associated with the key "ID607001" in `myMap`. **Note:** This will thrown an `Exception`. Comment this line of code to continue the execution of your program.

## Task 4:

You have been given a **stack** containing course names.

```cs
Stack myStack = new Stack(10);
myStack.Push("Programming 2");
myStack.Push("Introductory Application Development Concepts");
myStack.Push("Intermediate Application Development Concepts");
```

Just note that you will have to update the `Stack` class.

Implement the following:

1. Use the `Peek` method to display the top item on `myStack` without removing it
2. Use the `Push` method to add two items to `myStack`
3. Use the `Pop` method to remove and return the top item from `myStack`

## Task 5:

You have been given a **queue** containing course names.

```cs
Queue<string> myQueue = new Queue<string>();
myQueue.Enqueue("Programming 2");
myQueue.Enqueue("Introductory Application Development Concepts");
myQueue.Enqueue("Intermediate Application Development Concepts");
```

Implement the following:

1. Use the `Peek` method to display the top item on `myQueue` without removing it
2. Use the `Count` property to return the size of `myQueue`

# Formative Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.
