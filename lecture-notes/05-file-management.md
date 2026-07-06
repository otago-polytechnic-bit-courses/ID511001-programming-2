# Module 05: File Management with Different File Types

## Navigation

|              | Link                                                                                                     |
| ------------ | -------------------------------------------------------------------------------------------------------- |
| ← Previous | [Module 04: Windows Forms Applications](./04-windows-forms-applications.md)                              |
| → Next       | [Module 06: Abstraction, Inheritance and Polymorphism](./06-abstraction-inheritance-and-polymorphism.md) |

---

_(This week uses the same recurring labels explained in Week 01: why it matters, design first, quick check, and task.)_

Back in Week 01 you read and wrote plain text files. Real applications usually need more structure than that: a spreadsheet of contacts, a settings file, a saved game. This week looks at two of the most common structured formats, CSV and JSON, and at handling files and folders more carefully than "hope the path is right."

---

## 1. Choosing a file format

Before writing any code, it's worth knowing what you're choosing between, since each format trades off readability against structure.

| Format              | Structure                 | Human-readable                   | Good for                                                                                                           |
| ------------------- | ------------------------- | -------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| Plain text (`.txt`) | None, just lines          | Very                             | Logs, simple lists, one value per line                                                                             |
| CSV (`.csv`)        | Flat rows and columns     | Yes, especially in a spreadsheet | Tabular data: contacts, product lists, grades                                                                      |
| JSON (`.json`)      | Nested objects and arrays | Yes                              | Structured or nested data: settings, an object with a list inside it, data you'll also send over a network one day |

**Design first.** Before saving anything to disk, ask what shape the data actually is. A flat list of records with the same few fields on every row (contacts, products) fits CSV naturally. Anything with optional fields, nested objects, or lists inside objects (a `Student` with a `List<Course>` inside it) is a much better fit for JSON. Picking the wrong format doesn't stop your code from working, but it usually means fighting the format later to represent something it wasn't designed for.

| Key terms       |                                                                                   |
| --------------- | --------------------------------------------------------------------------------- |
| CSV             | Comma-Separated Values: a flat, row-and-column text format                        |
| JSON            | JavaScript Object Notation: a nested, structured text format                      |
| Serialization   | Converting an object in memory into a format that can be saved or sent, like JSON |
| Deserialization | Converting saved or sent data back into an object in memory                       |

---

## 2. CSV files

A CSV file is just a text file with a predictable shape: one record per line, fields separated by commas. You already have every tool you need to read and write one, from Week 01's string methods.

```
Name,Phone,Email
Aroha Ngata,027 123 4567,aroha@example.com
Liam Chen,021 987 6543,liam@example.com
```

### 2.1 Reading a CSV into objects

```cs
public class Contact
{
    private string name;
    private string phone;
    private string email;

    public Contact(string name, string phone, string email)
    {
        this.name = name;
        this.phone = phone;
        this.email = email;
    }

    public string Name { get => name; }
    public string Phone { get => phone; }
    public string Email { get => email; }

    // A CSV line representing this contact, matching the format it was read from
    public string ToCsvLine() => $"{name},{phone},{email}";
}
```

```cs
public static List<Contact> LoadContacts(string filePath)
{
    List<Contact> contacts = new List<Contact>();
    string[] lines = File.ReadAllLines(filePath);

    // Skip the header row (index 0), and turn every other row into a Contact
    for (int i = 1; i < lines.Length; i++)
    {
        string[] fields = lines[i].Split(',');
        contacts.Add(new Contact(fields[0], fields[1], fields[2]));
    }

    return contacts;
}
```

### 2.2 Writing objects back to CSV

```cs
public static void SaveContacts(string filePath, List<Contact> contacts)
{
    List<string> lines = new List<string> { "Name,Phone,Email" };
    lines.AddRange(contacts.Select(c => c.ToCsvLine()));
    File.WriteAllLines(filePath, lines);
}
```

**Why this matters.** Notice `LoadContacts` and `SaveContacts` take a file path and a list, and return a file path and a list. Neither one mentions a `TextBox` or any other control. This is the same rule from Week 04, applied to file access instead of a calculation: reading and writing files is exactly the kind of thing that belongs in a plain method, called from an event handler, never mixed into it.

A genuine limitation worth knowing about: this simple approach breaks if a field itself contains a comma (an address like `"Wellington, New Zealand"` would be split into two fields by mistake). Real-world CSV handling deals with this using quoted fields, and libraries like **CsvHelper** exist specifically to handle those edge cases correctly. For this course's data, where fields don't contain commas, the simple `Split(',')` approach above is fine, but it's worth knowing the simple version has that limit.

| Key terms            |                                                                       |
| -------------------- | --------------------------------------------------------------------- |
| `File.ReadAllLines`  | Reads an entire file into a `string[]`, one element per line          |
| `File.WriteAllLines` | Writes a `string[]` or `List<string>` to a file, one line per element |
| `Split(',')`         | Breaks a CSV line into its individual fields                          |

### Task 1: Contacts to CSV

Build the `Contact` class above. Create a `List<Contact>` with at least four contacts, and use `SaveContacts` to write them to `contacts.csv`. Then use `LoadContacts` to read them straight back into a new list, and display every contact in a `ListBox` or `DataGridView` to confirm the round trip worked.

---

## 3. JSON files

JSON represents the same idea as a class: named fields with values, and it can nest one object inside another. Modern .NET has JSON support built in, through `System.Text.Json`, so no extra package is needed.

```cs
using System.Text.Json;
```

### 3.1 Serializing an object to JSON

```cs
public class Settings
{
    public string UserName { get; set; }
    public int WindowWidth { get; set; }
    public int WindowHeight { get; set; }
    public bool DarkMode { get; set; }
}
```

```cs
Settings settings = new Settings
{
    UserName = "Aroha",
    WindowWidth = 1024,
    WindowHeight = 768,
    DarkMode = true
};

// WriteIndented makes the file readable by a human, not just a computer
JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(settings, options);
File.WriteAllText("settings.json", json);
```

That produces a file looking like this:

```json
{
  "UserName": "Aroha",
  "WindowWidth": 1024,
  "WindowHeight": 768,
  "DarkMode": true
}
```

### 3.2 Deserializing JSON back into an object

```cs
string json = File.ReadAllText("settings.json");
Settings settings = JsonSerializer.Deserialize<Settings>(json);

MessageBox.Show($"Welcome back, {settings.UserName}");
```

`Settings` above uses plain auto-implemented properties (Week 03), which is what `System.Text.Json` expects by default: it needs a public property with both a `get` and a `set` for each field it's reading into.

### 3.3 JSON handles nested objects naturally

This is where JSON earns its place over CSV: a class containing a list of other objects serializes exactly as you'd expect, with no flattening required.

```cs
public class Student
{
    public string Name { get; set; }
    public List<string> EnrolledCourses { get; set; }
}
```

```cs
Student student = new Student
{
    Name = "Liam",
    EnrolledCourses = new List<string> { "ID511001", "ID511002" }
};

string json = JsonSerializer.Serialize(student, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("student.json", json);
```

```json
{
  "Name": "Liam",
  "EnrolledCourses": ["ID511001", "ID511002"]
}
```

Representing this same data in a single flat CSV row would need a workaround, like squashing the courses into one field separated by semicolons. JSON just represents the list as a list.

| Key terms                       |                                                                               |
| ------------------------------- | ----------------------------------------------------------------------------- |
| `System.Text.Json`              | The JSON library built into modern .NET, no extra package required            |
| `JsonSerializer.Serialize`      | Converts an object into a JSON string                                         |
| `JsonSerializer.Deserialize<T>` | Converts a JSON string back into an object of type `T`                        |
| `WriteIndented`                 | An option that formats the JSON with line breaks and spacing, for readability |

### Task 2: Settings to JSON

Build the `Settings` class above. Create one instance, populate every field, and serialize it to `settings.json` with `WriteIndented` turned on. Open the file in a text editor to confirm it's readable. Then deserialize it back into a new `Settings` object and display its `UserName` in a `MessageBox.Show`, to confirm the round trip worked.

### Task 3: Contacts to JSON, and a Comparison

Serialize the same `List<Contact>` from Task 1 to `contacts.json` instead of CSV, using `System.Text.Json`. Open both `contacts.csv` and `contacts.json` side by side, and write two or three sentences in a comment explaining which one you'd choose for this particular data, and why.

---

## 4. Handling files and folders robustly

Real applications don't control what's on the user's file system. A folder might not exist yet, a file might be missing, or the user might not have permission to write somewhere. This is Week 01's `try`/`catch` habit, applied more carefully to files specifically. You'll build on this further with custom, purpose-built exceptions once you reach the Debugging and Unit Testing week.

### 4.1 Building paths safely

Never build a file path by concatenating strings with `+`. Use `Path.Combine`, which picks the correct separator for whatever operating system the code is running on.

```cs
string folder = "SavedData";
string fileName = "contacts.csv";
string fullPath = Path.Combine(folder, fileName);   // "SavedData\contacts.csv" on Windows
```

### 4.2 Checking before you assume

```cs
string folder = "SavedData";

if (!Directory.Exists(folder))
    Directory.CreateDirectory(folder);

string fullPath = Path.Combine(folder, "contacts.csv");

if (File.Exists(fullPath))
{
    List<Contact> contacts = LoadContacts(fullPath);
}
else
{
    MessageBox.Show("No saved contacts found yet.");
}
```

### 4.3 Using the built-in file dialogs

WinForms provides ready-made dialogs for choosing where to open or save a file, rather than asking the user to type a path into a `TextBox`, which is both unfriendly and error-prone.

```cs
private void buttonOpen_Click(object sender, EventArgs e)
{
    using OpenFileDialog dialog = new OpenFileDialog();
    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

    if (dialog.ShowDialog() == DialogResult.OK)
    {
        List<Contact> contacts = LoadContacts(dialog.FileName);
        DisplayContacts(contacts);   // a separate method, not shown here
    }
}

private void buttonSave_Click(object sender, EventArgs e)
{
    using SaveFileDialog dialog = new SaveFileDialog();
    dialog.Filter = "CSV files (*.csv)|*.csv";
    dialog.FileName = "contacts.csv";

    if (dialog.ShowDialog() == DialogResult.OK)
    {
        SaveContacts(dialog.FileName, contacts);
    }
}
```

Both dialogs are controls, in the sense that they belong to the UI layer. The event handlers above still follow Week 04's rule: they gather a file path from the dialog, then hand it straight to a plain method (`LoadContacts`, `SaveContacts`) that does the actual work and has no idea a dialog was ever involved.

**Design first.** Before writing file-handling code, list every way it could fail: the folder doesn't exist, the file doesn't exist, the file exists but is empty or corrupted, the user cancels the dialog. Decide what should happen in each case before you write the `try-catch`. Getting into this habit now will make Week 08's more formal look at defensive coding feel like a small step, not a big one.

| Key terms                              |                                                                   |
| -------------------------------------- | ----------------------------------------------------------------- |
| `Path.Combine`                         | Builds a file path using the correct separator for the current OS |
| `Directory.Exists` / `CreateDirectory` | Checks for, or creates, a folder                                  |
| `OpenFileDialog` / `SaveFileDialog`    | Built-in dialogs for choosing a file to open or save              |

### Task 4: Robust Open and Save

Extend Task 1 or Task 3's contacts app with `OpenFileDialog` and `SaveFileDialog`, wired up as shown above. Handle the case where the user cancels the dialog (`DialogResult` won't be `OK`), and the case where a chosen file exists but can't be parsed as a valid contacts file, using a `try-catch` around the loading logic. Show a clear `MessageBox` message for each failure case rather than letting the app crash.

---

## Before you submit

- [ ] All 4 tasks complete and tested
- [ ] File-loading and file-saving methods take and return plain values or your own classes, never a control
- [ ] `README.md` updated with any AI prompts used
- [ ] Pushed to your GitHub repository
