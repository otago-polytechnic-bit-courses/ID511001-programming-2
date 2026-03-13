# Week 09 — Serialisation

## Navigation

|            | Link                                                                               |
| ---------- | ---------------------------------------------------------------------------------- |
| ← Previous | [Week 08 — Code Smells & Refactoring](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/s1-26/lecture-notes/08-code-smells-refactoring.md) |
| → Next     | [Week 10 — AI-Assisted Coding](https://github.com/otago-polytechnic-bit-courses/ID511001-programming-2/blob/s1-26/lecture-notes/week-10-ai-assisted-coding.md)        |

---

## 1. What is Serialisation?

**Serialisation** is the process of converting an object into a format that can be stored (to a file or database) or transmitted (over a network). **Deserialisation** is the reverse — converting that stored format back into an object.

| Direction       | Process         | Example                                          |
| --------------- | --------------- | ------------------------------------------------ |
| Object → format | Serialisation   | Save a `Student` object to a JSON file           |
| Format → object | Deserialisation | Load that JSON file back into a `Student` object |

Serialisation is essential any time your application needs to **persist state** between sessions or **exchange data** with another system. C# supports several formats — the three most common are JSON, XML, and binary.

| Format | Human-readable | Common use case                                             |
| ------ | -------------- | ----------------------------------------------------------- |
| JSON   | ✓ Yes          | Web APIs, configuration files, cross-platform data exchange |
| XML    | ✓ Yes          | Legacy systems, configuration, document-oriented data       |
| Binary | ✗ No           | High-performance internal storage, not human-readable       |

---

## 2. JSON Serialisation

**JSON** (JavaScript Object Notation) is the most widely used format for serialising objects today. It is compact, human-readable, and supported by virtually every programming language.

C# provides JSON serialisation through `System.Text.Json` (built into .NET) and the popular third-party library **Newtonsoft.Json** (also called `Json.NET`). This course uses `System.Text.Json`.

---

### 2.1 Setup

`System.Text.Json` is included in .NET — no installation required. Add the namespace at the top of any file that uses it:

```cs
using System.Text.Json;
```

---

### 2.2 Serialising an Object to JSON

```cs
public class Student
{
    public string Name  { get; set; }
    public int    Age   { get; set; }
    public double Grade { get; set; }
}
```

```cs
Student student = new Student { Name = "Alice", Age = 20, Grade = 88.5 };

// Serialise — convert the object to a JSON string
string json = JsonSerializer.Serialize(student);

// json = {"Name":"Alice","Age":20,"Grade":88.5}
MessageBox.Show(json);
```

To produce indented, human-readable JSON:

```cs
string prettyJson = JsonSerializer.Serialize(student, new JsonSerializerOptions
{
    WriteIndented = true
});

// {
//   "Name": "Alice",
//   "Age": 20,
//   "Grade": 88.5
// }
```

---

### 2.3 Deserialising JSON to an Object

```cs
string json = "{\"Name\":\"Alice\",\"Age\":20,\"Grade\":88.5}";

// Deserialise — convert the JSON string back into a Student object
Student student = JsonSerializer.Deserialize<Student>(json);

MessageBox.Show($"{student.Name} — Age: {student.Age}, Grade: {student.Grade}");
```

---

### 2.4 Saving and Loading JSON from a File

Serialising to a file:

```cs
Student student = new Student { Name = "Alice", Age = 20, Grade = 88.5 };

string json = JsonSerializer.Serialize(student, new JsonSerializerOptions
{
    WriteIndented = true
});

File.WriteAllText("student.json", json);
```

Deserialising from a file:

```cs
if (File.Exists("student.json"))
{
    string json    = File.ReadAllText("student.json");
    Student student = JsonSerializer.Deserialize<Student>(json);
    MessageBox.Show($"Loaded: {student.Name}");
}
```

---

### 2.5 Serialising a List

`JsonSerializer` handles collections the same way it handles single objects:

```cs
List<Student> students = new List<Student>
{
    new Student { Name = "Alice", Age = 20, Grade = 88.5 },
    new Student { Name = "Bob",   Age = 22, Grade = 74.0 },
    new Student { Name = "Carol", Age = 21, Grade = 91.3 }
};

string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
{
    WriteIndented = true
});

File.WriteAllText("students.json", json);
```

Loading the list back:

```cs
string json = File.ReadAllText("students.json");
List<Student> students = JsonSerializer.Deserialize<List<Student>>(json);

foreach (Student s in students)
    listBox1.Items.Add($"{s.Name} — {s.Grade}");
```

---

### 2.6 Controlling Serialisation with Attributes

The `System.Text.Json.Serialization` namespace provides attributes that control how properties are serialised.

```cs
using System.Text.Json.Serialization;

public class Student
{
    [JsonPropertyName("full_name")]   // serialises as "full_name" instead of "Name"
    public string Name { get; set; }

    public int Age { get; set; }

    [JsonIgnore]                      // this property is excluded from serialisation
    public string PasswordHash { get; set; }
}
```

Resulting JSON:

```json
{
  "full_name": "Alice",
  "Age": 20
}
```

| Key terms                       |                                                                         |
| ------------------------------- | ----------------------------------------------------------------------- |
| `JsonSerializer.Serialize`      | Converts an object or collection to a JSON string                       |
| `JsonSerializer.Deserialize<T>` | Converts a JSON string back to an object of type `T`                    |
| `JsonSerializerOptions`         | Configuration object — controls indentation, casing, and other settings |
| `[JsonPropertyName]`            | Attribute that maps a C# property to a different JSON key name          |
| `[JsonIgnore]`                  | Attribute that excludes a property from serialisation entirely          |

---

## 3. XML Serialisation

**XML** (eXtensible Markup Language) is an older but still widely used format — particularly in enterprise systems, configuration files, and interoperability scenarios. C# provides XML serialisation through `System.Xml.Serialization`.

---

### 3.1 Setup

Add the namespace:

```cs
using System.Xml.Serialization;
using System.IO;
```

For XML serialisation to work, the class must have a **public parameterless constructor** and all serialised members must be `public` properties.

---

### 3.2 Serialising an Object to XML

```cs
[XmlRoot("Student")]               // controls the root element name in the XML
public class Student
{
    [XmlElement("FullName")]        // controls the element name in the XML
    public string Name  { get; set; }

    public int    Age   { get; set; }

    [XmlIgnore]                     // excludes this property from the XML output
    public string PasswordHash { get; set; }

    public Student() { }            // parameterless constructor required by XmlSerializer
    public Student(string name, int age) { Name = name; Age = age; }
}
```

```cs
Student student = new Student("Alice", 20);

XmlSerializer serializer = new XmlSerializer(typeof(Student));

using (StreamWriter writer = new StreamWriter("student.xml"))
{
    serializer.Serialize(writer, student);   // write XML to file
}
```

Output file `student.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Student>
  <FullName>Alice</FullName>
  <Age>20</Age>
</Student>
```

---

### 3.3 Deserialising XML to an Object

```cs
XmlSerializer serializer = new XmlSerializer(typeof(Student));

using (StreamReader reader = new StreamReader("student.xml"))
{
    Student student = (Student)serializer.Deserialize(reader);
    MessageBox.Show($"Loaded: {student.Name}, Age: {student.Age}");
}
```

---

### 3.4 Serialising a List to XML

XML does not serialise a bare `List<T>` directly — wrap it in a container class:

```cs
[XmlRoot("Students")]
public class StudentList
{
    [XmlElement("Student")]
    public List<Student> Students { get; set; } = new List<Student>();
}
```

```cs
StudentList data = new StudentList();
data.Students.Add(new Student("Alice", 20));
data.Students.Add(new Student("Bob",   22));

XmlSerializer serializer = new XmlSerializer(typeof(StudentList));
using (StreamWriter writer = new StreamWriter("students.xml"))
    serializer.Serialize(writer, data);
```

| Key terms                 |                                                               |
| ------------------------- | ------------------------------------------------------------- |
| `XmlSerializer`           | Converts objects to and from XML                              |
| `[XmlRoot]`               | Attribute that sets the root element name in the XML document |
| `[XmlElement]`            | Attribute that maps a property to a specific XML element name |
| `[XmlIgnore]`             | Attribute that excludes a property from XML serialisation     |
| Parameterless constructor | Required by `XmlSerializer` — must be `public`                |

---

## 4. JSON vs XML

|                     | JSON                  | XML                           |
| ------------------- | --------------------- | ----------------------------- |
| Verbosity           | Compact               | More verbose                  |
| Human-readable      | ✓                     | ✓ (but more syntax)           |
| Comments            | ✗ Not supported       | ✓ Supported                   |
| Schema / validation | JSON Schema           | XSD (XML Schema Definition)   |
| .NET support        | `System.Text.Json`    | `System.Xml.Serialization`    |
| Best for            | Web APIs, modern apps | Legacy systems, document data |

---

## 5. Error Handling in Serialisation

Serialisation and deserialisation can fail in several ways — always wrap file operations in a `try-catch` block.

```cs
try
{
    string json = File.ReadAllText("students.json");
    List<Student> students = JsonSerializer.Deserialize<List<Student>>(json);

    foreach (Student s in students)
        listBox1.Items.Add(s.Name);
}
catch (FileNotFoundException)
{
    MessageBox.Show("Save file not found. Starting with an empty list.");
}
catch (JsonException ex)
{
    MessageBox.Show($"Could not read save file: {ex.Message}");
}
catch (Exception ex)
{
    MessageBox.Show($"Unexpected error: {ex.Message}");
}
```

| Exception                     | Common cause                                                       |
| ----------------------------- | ------------------------------------------------------------------ |
| `FileNotFoundException`       | The file path does not exist                                       |
| `JsonException`               | The JSON is malformed or does not match the target type            |
| `InvalidOperationException`   | XML structure does not match the expected type                     |
| `UnauthorizedAccessException` | The application does not have permission to read or write the file |

---

## 6. Practical Pattern — Save and Load Application State

A common use of serialisation is persisting application state between sessions. The pattern below saves a list to a JSON file when the form closes and reloads it when the form opens.

```cs
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public partial class Form1 : Form
{
    private List<Student> students = new List<Student>();
    private const string SaveFilePath = "students.json";

    public Form1()
    {
        InitializeComponent();
        LoadStudents();
    }

    private void LoadStudents()
    {
        try
        {
            if (!File.Exists(SaveFilePath)) return;   // nothing to load yet

            string json = File.ReadAllText(SaveFilePath);
            students    = JsonSerializer.Deserialize<List<Student>>(json)
                          ?? new List<Student>();

            RefreshListBox();
        }
        catch (JsonException)
        {
            MessageBox.Show("Save file is corrupted. Starting fresh.");
            students = new List<Student>();
        }
    }

    private void SaveStudents()
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(SaveFilePath, json);
    }

    private void RefreshListBox()
    {
        listBox1.Items.Clear();
        foreach (Student s in students)
            listBox1.Items.Add($"{s.Name} — {s.Grade}");
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        // Add student logic here ...
        SaveStudents();        // persist after every change
        RefreshListBox();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveStudents();        // also save when the form closes
    }
}
```

| Key terms              |                                                               |
| ---------------------- | ------------------------------------------------------------- |
| Serialisation          | Converting an object to a storable/transmittable format       |
| Deserialisation        | Converting a stored format back into an object                |
| Persistence            | Saving application state so it survives between sessions      |
| `File.WriteAllText`    | Writes a string to a file — creates or overwrites             |
| `File.ReadAllText`     | Reads the entire contents of a file as a string               |
| `??` (null-coalescing) | Returns the right-hand value if the left-hand value is `null` |

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Serialise a Single Object

Create a `Book` class with the following properties:

| Property | Type     |
| -------- | -------- |
| `Title`  | `string` |
| `Author` | `string` |
| `Year`   | `int`    |
| `Price`  | `double` |

Add a `Button` to your form. When clicked, create a `Book` object, serialise it to a JSON file called `book.json` using `JsonSerializer`, and display the resulting JSON string in a `TextBox`. Add a second `Button` that reads `book.json`, deserialises it back into a `Book` object, and displays its properties in a `Label`.

> **Hint:** use `JsonSerializerOptions { WriteIndented = true }` so the JSON is readable in the TextBox. Wrap both operations in `try-catch` blocks.

---

### Task 2 — Persist a List

Extend the `Student` class from the notes (or create your own) and build a simple student register:

1. Add a `TextBox` for name, a `TextBox` for grade, and an **Add** `Button`
2. Display all students in a `ListBox`
3. When a student is added, serialise the full list to `students.json`
4. When the form loads, deserialise `students.json` (if it exists) and populate the `ListBox`

The list should persist between application restarts.

> **Hint:** follow the save/load pattern from Section 6. Use `File.Exists` before attempting to read the file.

---

### Task 3 — JSON Attributes

Create a `UserProfile` class with the following properties and apply the attributes shown:

| Property       | Type     | Attribute                  |
| -------------- | -------- | -------------------------- |
| `FullName`     | `string` | Serialise as `"full_name"` |
| `EmailAddress` | `string` | Serialise as `"email"`     |
| `Age`          | `int`    | No attribute               |
| `PasswordHash` | `string` | Exclude from serialisation |

Serialise a `UserProfile` object to a JSON string and display it in a `MessageBox`. Verify that `PasswordHash` does not appear in the output and that the key names match the specified attribute values.

> **Hint:** use `[JsonPropertyName("full_name")]` and `[JsonIgnore]` from `System.Text.Json.Serialization`.

---

### Task 4 — XML Serialisation

Using the `Book` class from Task 1, add a `public Book() { }` parameterless constructor and apply XML attributes so the output matches the structure below. Serialise a list of three books to `books.xml` and then deserialise them back, displaying each book's title and author in a `ListBox`.

```xml
<?xml version="1.0" encoding="utf-8"?>
<BookCatalogue>
  <Book>
    <Title>The Pragmatic Programmer</Title>
    <Author>Andrew Hunt</Author>
    <Year>1999</Year>
    <Price>45.99</Price>
  </Book>
</BookCatalogue>
```

> **Hint:** create a `BookCatalogue` wrapper class with `[XmlRoot("BookCatalogue")]` and a `List<Book>` property marked `[XmlElement("Book")]`.

---

### Task 5 — Inventory Manager

Build a small inventory management application that uses JSON serialisation to persist its data.

The application should allow the user to:

1. Add a product (name, price, quantity) via `TextBox` controls and an **Add** `Button`
2. Remove a selected product from a `ListBox` via a **Remove** `Button`
3. Display all products in a `ListBox` showing name, price, and quantity
4. Automatically save the inventory to `inventory.json` after every add or remove
5. Automatically load from `inventory.json` when the application starts

Include error handling for a missing or corrupted save file. Display an appropriate message to the user in each case.

> **Hint:** reuse the `Product` class and `IInventoryItem` interface from Week 06, or define a new `InventoryItem` record. Use `[JsonIgnore]` on any property that should not be persisted.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
