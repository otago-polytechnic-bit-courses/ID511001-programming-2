# Week 03 — Windows Forms Application

## Navigation

|            | Link                                                                                                   |
| ---------- | ------------------------------------------------------------------------------------------------------ | --- |
| ← Previous | [Week 02 — Arrays, Lists, Dictionaries & LINQ](lecture-notes/02-arrays-lists-dictionaries-linq.md) |
| → Next     | [Week 04 — Classes, Objects & Encapsulation](lecture-notes/04-classes-objects-encapsulation.md)    |     |

---

## 1. Windows Forms and Visual Studio

**Visual Studio** is an IDE (Integrated Development Environment) for building GUI (Graphical User Interface) applications — those with windows, buttons, menus, and graphics. You design an application by dragging pre-built **controls** onto a **Form** and then writing code to describe what should happen when the user interacts with them. Visual Studio handles the underlying operating system plumbing so you can focus on application logic.

---

### 1.1 Creating a Windows Forms Project

**Step 1** — Open **Visual Studio** and select **Create a new project**.

**Step 2** — Select **Windows Forms App (.NET Framework)** — choose the latest version available on your machine.

**Step 3** — Fill in the project details:

| Field             | Value                       |
| ----------------- | --------------------------- |
| **Project name**  | `03WindowsFormsApplication` |
| **Location**      | `<path-to-repository>`      |
| **Solution name** | `03WindowsFormsApplication` |

After the project is created you should see three panels: **Design View**, **Output**, and **Solution Explorer**. All panels are moveable.

The central panel is named `Form1.cs (Design)`. This is the **design canvas** — where you add and arrange controls at design time. When the application runs, this becomes the main window the user sees. Projects can contain multiple Forms, but we start with one.

---

### 1.2 Adding Controls

Open **View > Toolbox > Common Controls**.

1. Add two `Buttons`, a `TextBox`, a `PictureBox`, and a `Label` to the Form.
2. Run the application. Click a Button and type in the TextBox — nothing happens yet because no event handlers have been written.
3. Change the **Size**, **Text**, and **Name** of each Button.
4. Change the **Text**, **Font**, and **Visible** properties of the Label.
5. Add an image to the PictureBox and experiment with resizing it.
6. Change the background colour of the Form.

---

## 2. Design-Time vs Run-Time

**Design-time** — modifying a property using the Properties panel while you are building the application.

**Run-time** — modifying a property from code while the application is executing. You use **dot notation** to access a control's property:

```cs
textBox1.Text = "Here is my new text";
```

Given controls `button1`, `label1`, and `textBox1` on your Form, predict the effect of each statement at run-time:

| Statement                     | Effect                                       |
| ----------------------------- | -------------------------------------------- |
| `button1.Width = 400;`        | Sets the button's width to 400 pixels        |
| `label1.Visible = false;`     | Hides the label                              |
| `textBox1.Text = "Go Otago";` | Replaces the TextBox content with "Go Otago" |
| `button1.Text = label1.Text;` | Copies the Label's text onto the Button      |

| Key terms    |                                                                                 |
| ------------ | ------------------------------------------------------------------------------- |
| Design-time  | Modifying a property in the Properties panel while building the app             |
| Run-time     | Modifying a property via code while the application is running                  |
| Dot notation | Syntax for accessing a control's property or method: `controlName.PropertyName` |

---

## 3. Responding to Events

Controls have **Properties** and **Events**. Events are things the user (or the application) can do — clicking a button, hovering the mouse, dragging a control, and so on. You can write a block of C# code — called an **event handler** — that runs whenever a specific event occurs.

Until you write a handler, nothing happens when the event fires. Each handler is a C# method. The naming convention is `controlName_EventName` — for example, a Click handler on `button1` is:

```cs
private void button1_Click(object sender, EventArgs e) { ... }
```

> **Tip:** Never type this method signature yourself. In the Properties panel, click the **Events** tab (⚡ lightning bolt icon), then **double-click** the space beside the event you want. Visual Studio will generate the correct method name, switch to the code view, and place the cursor inside the method body ready for you to type.

| Key terms     |                                                                                                   |
| ------------- | ------------------------------------------------------------------------------------------------- |
| Event         | Something the user or application does that a control can respond to (e.g. `Click`, `MouseHover`) |
| Event handler | The C# method that runs when a specific event fires                                               |
| `sender`      | The control that raised the event                                                                 |
| `EventArgs e` | Additional data about the event (varies by event type)                                            |

---

## 4. Event Handler Examples

---

### 4.1 Changing a Label on Button Click

Place a `Button` and a `Label` on the Form. In the Events tab, double-click **Click** on the Button. Add:

```cs
using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        label1.Text = "My text has changed";
    }
}
```

Run the application and click the Button — the Label text updates.

---

### 4.2 Counting Button Clicks

Add a `TextBox` and set its initial `Text` to `0`. The handler below increments the count each time the button is clicked.

The preferred approach uses `int.TryParse` — it does not throw an exception if the TextBox contains invalid text:

```cs
private void button1_Click(object sender, EventArgs e)
{
    // TryParse returns false and sets nClicks to 0 if the text is not a valid integer
    if (!int.TryParse(textBox1.Text, out int nClicks))
    {
        nClicks = 0;
    }

    nClicks++;
    textBox1.Text = nClicks.ToString();
}
```

An equivalent approach using `Convert.ToInt16` — simpler, but throws `FormatException` if the text is invalid:

```cs
private void button1_Click(object sender, EventArgs e)
{
    int nClicks = Convert.ToInt16(textBox1.Text); // converts string → 16-bit int
    nClicks++;
    textBox1.Text = nClicks.ToString();           // converts int → string for display
}
```

> **Note:** `Convert.ToInt16(s)` converts a string to a 16-bit integer. `nClicks.ToString()` converts an integer back to a string. You cannot assign an `int` directly to a `TextBox.Text` property — the types must match.

---

### 4.3 Copying TextBox Content to a Label

Modify `button1_Click` so that clicking the button copies whatever is in `textBox1` into `label1`:

```cs
private void button1_Click(object sender, EventArgs e)
{
    label1.Text = textBox1.Text;
}
```

---

## 5. TextBox and ListBox Controls

---

### 5.1 TextBox Methods

A `TextBox` can be single-line or multi-line (set via the dropdown at the top-right of the control in the designer). Key methods:

| Method                   | Effect                                     |
| ------------------------ | ------------------------------------------ |
| `textBox1.Clear()`       | Erases all text in the TextBox             |
| `textBox1.AppendText(s)` | Appends string `s` to the existing content |

---

### 5.2 ListBox and the `Items` Property

A `ListBox` displays multiple lines of text. Its content is managed through the `Items` property — itself an object with its own methods and properties.

```cs
// Add a line
listBox1.Items.Add("This is a new line of text");

// Count lines
int n = listBox1.Items.Count;
MessageBox.Show($"The ListBox contains {n} lines of text");
```

---

### 5.3 Common ListBox Operations

**`Contains`** — check whether a string is present:

```cs
if (listBox1.Items.Contains("This is a new line of text"))
    MessageBox.Show("Found!");
```

**`Remove`** — remove a string by value:

```cs
listBox1.Items.Remove("This is a new line of text");
```

**`RemoveAt`** — remove a string by index:

```cs
listBox1.Items.RemoveAt(0); // removes the first item
```

**`IndexOf`** — find the index of a string:

```cs
int index = listBox1.Items.IndexOf("This is a new line of text 2"); // returns 1
```

**Combining `Contains`, `IndexOf`, and `RemoveAt`** — safe removal by value:

```cs
if (listBox1.Items.Contains("This is a new line of text 2"))
{
    int index = listBox1.Items.IndexOf("This is a new line of text 2");
    listBox1.Items.RemoveAt(index);
}
```

| Key terms           |                                                                                              |
| ------------------- | -------------------------------------------------------------------------------------------- |
| `Items`             | The `ListBox` property that stores all its text content — has its own methods and properties |
| `Items.Add(s)`      | Appends string `s` to the ListBox                                                            |
| `Items.Clear()`     | Removes all items from the ListBox                                                           |
| `Items.Count`       | Returns the number of items currently in the ListBox                                         |
| `Items.Contains(s)` | Returns `true` if string `s` exists in the ListBox                                           |
| `Items.Remove(s)`   | Removes the first occurrence of string `s`                                                   |
| `Items.RemoveAt(i)` | Removes the item at index `i`                                                                |
| `Items.IndexOf(s)`  | Returns the index of the first occurrence of string `s`, or -1 if not found                  |

---

## 6. RadioButton Controls

`RadioButtons` are on/off controls that work in **mutually exclusive sets** — selecting one automatically deselects all others in the same container. If you place RadioButtons directly on the Form, they form one set. To create multiple independent sets, place each set inside a separate **GroupBox** or **Panel**.

The event to handle is `CheckedChanged`, which fires whenever a RadioButton's selected state changes:

```cs
private void radioButton1_CheckedChanged(object sender, EventArgs e)
{
    listBox1.Items.Clear();
    listBox1.Items.Add("Option A - Line 1");
    listBox1.Items.Add("Option A - Line 2");
}

private void radioButton2_CheckedChanged(object sender, EventArgs e)
{
    listBox1.Items.Clear();
    listBox1.Items.Add("Option B - Line 1");
    listBox1.Items.Add("Option B - Line 2");
}
```

Conditionally removing an item when a RadioButton is selected:

```cs
private void radioButton1_CheckedChanged(object sender, EventArgs e)
{
    listBox1.Items.Add("Item 1");

    // Remove a specific item if it exists
    if (listBox1.Items.Contains("Item 12"))
        listBox1.Items.Remove("Item 12");
}
```

| Key terms            |                                                                       |
| -------------------- | --------------------------------------------------------------------- |
| `RadioButton`        | An on/off control — only one in a container can be selected at a time |
| `CheckedChanged`     | Event fired when a RadioButton's selected state changes               |
| `GroupBox` / `Panel` | Containers used to define independent sets of RadioButtons            |

---

## 7. DataGridView Control

The `DataGridView` control displays data in a tabular (rows and columns) format. It supports both read-only and editable views and can be bound to a variety of data sources.

```cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private List<string> names;

    public Form1()
    {
        InitializeComponent();

        names = new List<string> { "John", "Mary", "Bob", "Jane" };

        // First argument: column identifier (used in code)
        // Second argument: column header shown to the user
        dataGridView1.Columns.Add("Col1", "Name");

        foreach (string name in names)
        {
            int rowIdx = dataGridView1.Rows.Add();                    // add a new empty row
            dataGridView1.Rows[rowIdx].Cells["Col1"].Value = name;    // populate the cell
        }
    }
}
```

| Key terms                 |                                                                  |
| ------------------------- | ---------------------------------------------------------------- |
| `DataGridView`            | Control for displaying data in a resizable rows-and-columns grid |
| `Columns.Add(id, header)` | Adds a column with a code identifier and a visible header label  |
| `Rows.Add()`              | Appends a new empty row and returns its index                    |
| `Rows[i].Cells["Col"]`    | Accesses a specific cell by row index and column identifier      |

---

## 8. Creating and Managing Multiple Forms

Most applications contain more than one Form — for example, a main window alongside settings, help, or data-entry dialogs.

---

### 8.1 Adding a New Form

1. Right-click the project name in **Solution Explorer**.
2. Select **Add > Windows Form**.
3. Give the form a descriptive name (e.g. `SettingsForm.cs`, `AboutForm.cs`).
4. Click **Add**.

The new form can be designed and given event handlers exactly like the main form.

---

### 8.2 Showing a Form

**Modal** (`ShowDialog`) — the user must close this form before interacting with any other form:

```cs
private void button1_Click(object sender, EventArgs e)
{
    Form2 settingsForm = new Form2();
    settingsForm.ShowDialog();
    // Code here runs only after Form2 is closed
}
```
**Modeless** (`Show`) — the user can interact with multiple forms simultaneously:

```cs
private void button1_Click(object sender, EventArgs e)
{
    Form2 infoForm = new Form2();
    infoForm.Show();
    // Code here runs immediately — Form2 stays open
}
```

---

### 8.3 Passing Data to a Form

**Via properties** — set properties on the form instance before showing it:

```cs
// Form2.cs
public partial class Form2 : Form
{
    public string UserName { get; set; }
    public int    UserAge  { get; set; }

    public Form2() { InitializeComponent(); }

    private void Form2_Load(object sender, EventArgs e)
    {
        labelWelcome.Text = $"Welcome, {UserName}! Age: {UserAge}";
    }
}

// Form1.cs
private void button1_Click(object sender, EventArgs e)
{
    Form2 userForm = new Form2();
    userForm.UserName = textBoxName.Text;
    userForm.UserAge  = Convert.ToInt32(textBoxAge.Text);
    userForm.ShowDialog();
}
```

**Via constructor parameters** — pass data directly when the form is created:

```cs
// Form2.cs
public Form2(string name, int age)
{
    InitializeComponent();
    labelWelcome.Text = $"Welcome, {name}! Age: {age}";
}

// Form1.cs
private void button1_Click(object sender, EventArgs e)
{
    Form2 userForm = new Form2(textBoxName.Text, Convert.ToInt32(textBoxAge.Text));
    userForm.ShowDialog();
}
```

---

### 8.4 Getting Data Back from a Form

Expose the result as a public property, then read it after `ShowDialog` returns:

```cs
// Form2.cs
public partial class Form2 : Form
{
    public string EnteredText   { get; private set; }
    public bool   UserClickedOK { get; private set; }

    public Form2() { InitializeComponent(); }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        EnteredText   = textBox1.Text;
        UserClickedOK = true;
        this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        UserClickedOK = false;
        this.Close();
    }
}

// Form1.cs
private void button1_Click(object sender, EventArgs e)
{
    Form2 dataForm = new Form2();
    dataForm.ShowDialog();

    if (dataForm.UserClickedOK)
        MessageBox.Show($"User entered: {dataForm.EnteredText}");
    else
        MessageBox.Show("User cancelled");
}
```

---

### 8.5 Closing Forms

```cs
this.Close();          // close the current form
Application.Exit();    // close the entire application (use in the main form only)
```

---

### 8.6 Form Events

| Event              | When it fires                                                          |
| ------------------ | ---------------------------------------------------------------------- |
| `Form_Load`        | When the form is first loaded                                          |
| `Form_FormClosing` | Just before the form closes — set `e.Cancel = true` to prevent closing |

```cs
private void Form2_FormClosing(object sender, FormClosingEventArgs e)
{
    DialogResult result = MessageBox.Show(
        "Are you sure you want to close?",
        "Confirm Close",
        MessageBoxButtons.YesNo);

    if (result == DialogResult.No)
        e.Cancel = true;   // abort the close
}
```

---

### 8.7 Best Practices for Multiple Forms

**Naming** — use descriptive names: `LoginForm`, `SettingsForm`, `ReportForm`.

**Disposal** — `ShowDialog()` automatically disposes the form when it closes. For modeless forms shown with `Show()`, dispose manually if needed.

**Validation** — always validate user input before closing a data-entry form.

**Error handling** — wrap input conversions in `try-catch`:

```cs
private void button1_Click(object sender, EventArgs e)
{
    try
    {
        int age = Convert.ToInt32(textBoxAge.Text);
        Form2 userForm = new Form2("User", age);
        userForm.ShowDialog();
    }
    catch (FormatException)
    {
        MessageBox.Show("Please enter a valid age.");
    }
}
```

| Key terms            |                                                                                                      |
| -------------------- | ---------------------------------------------------------------------------------------------------- |
| Modal form           | A form that must be closed before the user can interact with other forms — shown with `ShowDialog()` |
| Modeless form        | A form that can coexist with other open forms — shown with `Show()`                                  |
| `this.Close()`       | Closes the current form                                                                              |
| `Application.Exit()` | Terminates the entire application                                                                    |
| `Form_Load`          | Event that fires when the form is first loaded — used to set up initial state                        |
| `FormClosing`        | Event that fires just before a form closes — set `e.Cancel = true` to abort                          |

---

## Exercises

Before you start, create a new **C# Windows Forms** application with a descriptive name.

**Important:** Learning to use AI tools is valuable, but you must:

- Refine your prompts to get useful responses
- Verify and test all AI-generated code before submitting
- Acknowledge AI tool usage in your repository `README.md`, including the prompts you used and how you applied the responses

---

### Task 1 — Five-Number Calculator

Write an application that lets the user enter a number into each of five `TextBox` controls. Provide two `Buttons` — one that calculates and displays the **sum**, and one that calculates and displays the **average**. Display results in a separate `TextBox` or `Label`.

> **Hint:** remember to convert `TextBox.Text` to a number before arithmetic, and convert the result back to a string before assigning it to `TextBox.Text` or `Label.Text`. Use `int.TryParse` for safe conversion.

---

### Task 2 — Arithmetic Calculator

Write a calculator application that accepts two numbers in `TextBox` controls, lets the user select an arithmetic operation, and displays the result.

1. Create a new Form and set its `Text` property to `Calculator`
2. Add two `TextBox` controls for input and one `ReadOnly` `TextBox` for the result (set `ReadOnly = true` to prevent the user from overwriting it)
3. Add `Buttons` for `+`, `-`, `×`, `÷`, **mod**, and **div** — implement a `Click` handler for each
4. Use a `Panel` or `Label` as a visual divider between the input fields and the result field

> **Hint:** set the result TextBox's `ReadOnly` property to `true` in the Properties panel. Assume the user always enters valid integers for now — full input validation is beyond the scope of this exercise.

---

### Task 3 — Pizza Parlour Order System

Write an application for a pizza parlour. The user builds an order and the application displays it with a total price.

1. Create a new Form for the order interface
2. Provide at least **two pizza sizes** (e.g. Small, Large) with different prices — use `RadioButtons` inside a `GroupBox`. If the user clicks **Order** without selecting a size, display a polite message asking them to choose one
3. Provide at least **five optional toppings** with associated prices — use `CheckBoxes` so the user can select any combination
4. Add an **Order** `Button` that writes the full order to a `ListBox` and displays the total in a `TextBox`
5. Each new order should clear the previous order from the `ListBox` and `TextBox` before displaying the new one

> **Hint:** use `RadioButton.Checked` to read which size is selected, and `CheckBox.Checked` to read which toppings are selected. Use `listBox1.Items.Clear()` at the start of each order calculation.

---

## Submission

Push your completed code to your GitHub repository. Ensure your code is well-commented and follows the naming conventions from Week 01.
