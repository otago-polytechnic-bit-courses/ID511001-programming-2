# Module 04: Windows Forms Applications

## Navigation

|              | Link                                                                                       |
| ------------ | ------------------------------------------------------------------------------------------ |
| ← Previous   | [Module 03: Classes, Objects and Encapsulation](./03-classes-objects-and-encapsulation.md) |
| → Next       | [Module 05: File Management](./05-file-management.md)            |

---

_(This module uses the same recurring labels explained in Module 01: why it matters, design first, quick check, and task.)_

Everything you've built so far has run top-to-bottom and stopped. This module, that changes: you'll build applications that sit and wait for the _user_ to decide what happens next. That shift, from "run in order" to "respond to whatever happens", is called **event-driven programming**, and it's the core idea behind every GUI application you'll ever build.

---

## 1. Visual Studio and Windows Forms

**Visual Studio** is the IDE you'll build these in. You design an application by dragging pre-built **controls** (buttons, text boxes, labels) onto a **Form**, then write code describing what happens when the user interacts with them.

### 1.1 Creating a project

**Create a new project → Windows Forms App**, not **Windows Forms App (.NET Framework)**. The plain **Windows Forms App** template targets modern .NET (currently .NET 8 or later) rather than the older .NET Framework, and that's the one this course uses throughout. Pick the latest .NET version offered. Name the project and solution something descriptive.

You'll see three panels: **Design View**, **Output**, and **Solution Explorer**. The central `Form1.cs (Design)` panel is your canvas, and this becomes the window your user sees when the app runs.

### 1.2 Adding controls

**View → Toolbox → Common Controls.**

1. Add two `Buttons`, a `TextBox`, a `PictureBox`, and a `Label`
2. Run the app. Click, type. Nothing happens yet, because you haven't told anything to respond
3. Change each Button's **Size**, **Text**, and **Name**
4. Change the Label's **Text**, **Font**, and **Visible** properties
5. Add an image to the PictureBox and try resizing it
6. Change the Form's background colour

---

## 2. Design first: sketch before you drag controls

It's tempting to open the designer and start dragging controls straight away. Resist that for thirty seconds. Before building any screen this module, sketch it on paper first: boxes for each control, roughly where it sits, and a label for what it does. This is a **wireframe**, and it's standard practice in real UI work for a good reason. It's much faster to erase a badly-placed box on paper than to rearrange six controls that are already wired up with code.

Once the layout is settled, do the same for behaviour: for every button, write one sentence, something like _"when clicked, this should validate the two number inputs, add them, and show the result in the label."_ That sentence becomes your event handler, almost word for word.

---

## 3. Design-time vs run-time

**Design-time**: changing a property in the Properties panel while building the app.

**Run-time**: changing a property from code while the app is actually running, using dot notation:

```cs
textBox1.Text = "Here is my new text";
```

| Statement                     | Effect                                  |
| ----------------------------- | --------------------------------------- |
| `button1.Width = 400;`        | Sets the button's width to 400px        |
| `label1.Visible = false;`     | Hides the label                         |
| `textBox1.Text = "Go Otago";` | Replaces the TextBox's content          |
| `button1.Text = label1.Text;` | Copies the Label's text onto the Button |

| Key terms    |                                                |
| ------------ | ---------------------------------------------- |
| Design-time  | Editing a property via the Properties panel    |
| Run-time     | Editing a property via code while the app runs |
| Dot notation | `controlName.PropertyName`                     |

---

## 4. Responding to events

Controls have **Properties** (what they look like) and **Events** (things that can happen to them, such as a click, a hover, or a drag). Nothing happens on an event until you write an **event handler** for it. Naming convention: `controlName_EventName`.

```cs
private void button1_Click(object sender, EventArgs e) { ... }
```

> **Never type this signature by hand.** In the Properties panel, click the **Events** tab (⚡), then double-click next to the event you want. Visual Studio generates the correct method and drops your cursor right inside it.

| Key terms     |                                                              |
| ------------- | ------------------------------------------------------------ |
| Event         | Something the user or app does that a control can respond to |
| Event handler | The method that runs when the event fires                    |
| `sender`      | The control that raised the event                            |
| `EventArgs e` | Extra data about the event                                   |

### 4.1 A first handler

```cs
private void button1_Click(object sender, EventArgs e)
{
    label1.Text = "My text has changed";
}
```

### 4.2 Counting clicks safely

```cs
private void button1_Click(object sender, EventArgs e)
{
    // TryParse never throws. If the text isn't a number, nClicks just becomes 0
    if (!int.TryParse(textBox1.Text, out int nClicks))
        nClicks = 0;

    nClicks++;
    textBox1.Text = nClicks.ToString();
}
```

> You can't assign an `int` straight to `TextBox.Text`, since the types have to match, which is why `.ToString()` shows up so often in GUI code.

### 4.3 Copying between controls

```cs
private void button1_Click(object sender, EventArgs e)
{
    label1.Text = textBox1.Text;
}
```

---

## 5. Keep your business logic separate from the UI

As your event handlers start doing real work like calculating totals, validating orders, or checking eligibility, it's tempting to write a separate method for that calculation and just have it read straight from the controls itself. Resist this. It causes more pain later in this course than almost anything else, so it's worth getting right from the start.

```cs
// Don't do this
private double CalculateTotal()
{
    // This method reaches directly into the form's controls
    double price = double.Parse(textBoxPrice.Text);
    double quantity = double.Parse(textBoxQuantity.Text);
    double discount = checkBoxMember.Checked ? 0.1 : 0;
    return price * quantity * (1 - discount);
}
```

This looks harmless, but it quietly causes three separate problems. `CalculateTotal` can't run, or be tested, without a form open with controls named exactly `textBoxPrice`, `textBoxQuantity`, and `checkBoxMember`. It can't be reused anywhere else, like a console app or a different form. And if a designer ever renames one of those controls, the calculation breaks even though the maths inside it never changed at all.

The fix is a simple division of labour. The **event handler** is the only thing allowed to talk to controls: it reads values out of them, and writes results back into them. Any actual calculation happens in a **separate, plain method** that only ever sees ordinary values, ints, doubles, strings, bools, or your own classes, and never a `TextBox`, `Label`, `Button`, or any other control type.

```cs
private void buttonCalculate_Click(object sender, EventArgs e)
{
    // Step 1: read values out of controls, right here, and nowhere else
    double price = double.Parse(textBoxPrice.Text);
    double quantity = double.Parse(textBoxQuantity.Text);
    bool isMember = checkBoxMember.Checked;

    // Step 2: hand plain values to a plain method
    double total = CalculateTotal(price, quantity, isMember);

    // Step 3: write the plain result back into a control, right here, and nowhere else
    labelResult.Text = total.ToString("C");
}

// No Control type appears anywhere in this method's signature or body
private double CalculateTotal(double price, double quantity, bool isMember)
{
    double discount = isMember ? 0.1 : 0;
    return price * quantity * (1 - discount);
}
```

`CalculateTotal` now reads like ordinary maths, because that's all it is. You could paste it into a console app, call it from a completely different form, and, importantly for later in the course, write a unit test for it directly, with no form running at all.

A quick way to check your own code: look at every method that isn't an event handler. If its parameter list or its body mentions a control type anywhere, the UI and the logic have become tangled together, and it's worth pulling them apart before it gets any bigger.

While you're separating things out like this, it's also worth overriding `ToString()` (Module 03) on any class involved. A quick `MessageBox.Show(myObject.ToString())` while debugging is far faster than checking each field by hand, and it costs one extra method to set up.

### 5.1 Naming keeps the separation visible

A method called `DoStuff()` or `Process()` can hide exactly this kind of tangling, because a vague name doesn't tell you, or anyone reading it later, what the method is actually responsible for.

```cs
// What does this even do? You have to read the whole body to find out
private void button1_Click(object sender, EventArgs e)
{
    DoStuff();
}
```

Name event handlers for what they respond to (`controlName_EventName`, as in Section 4), and name your plain methods for exactly what they calculate or decide, using a verb and a noun: `CalculateTotal`, `ValidateOrder`, `IsEligibleForDiscount`. A good name should let you guess the return type and roughly what happens inside, without opening the method at all. If you're struggling to name a method clearly, that's often a sign it's still doing more than one job, and splitting it into two well-named methods is usually the fix.

**Design first.** Before writing a Click handler that calculates anything, plan it as exactly three steps: read values out of controls into plain variables, hand those values to a plain method, write the plain result back into a control. Only the first and third step should ever mention a control by name.

| Key terms        |                                                                                                 |
| ---------------- | ----------------------------------------------------------------------------------------------- |
| Business logic   | The actual rules and calculations an application performs, independent of how they're displayed |
| UI-coupled logic | A method that reaches directly into a control, instead of receiving plain values                |

The two tasks below, and every calculation task from here on, are expected to follow this pattern: no control type anywhere except inside the event handler itself.

---

## 6. TextBox and ListBox

A `TextBox` can be single- or multi-line (dropdown, top-right of the control in the designer).

```cs
textBox1.Clear();
textBox1.AppendText(s);
```

A `ListBox`'s content lives in its `Items` property, which has its own methods:

```cs
listBox1.Items.Add("A new line of text");
int n = listBox1.Items.Count;

if (listBox1.Items.Contains("A new line of text"))
    MessageBox.Show("Found!");

int index = listBox1.Items.IndexOf("Something");
listBox1.Items.RemoveAt(index);   // safe removal by value: check first, then remove by index
```

| Key terms |                                                                              |
| --------- | ---------------------------------------------------------------------------- |
| `Items`   | The ListBox's content, itself with its own `.Add`, `.Remove`, `.Count`, etc. |

### Task 1: Five-Number Calculator

Five `TextBox` controls for number entry, and two `Buttons`: one shows the **sum**, one shows the **average**, in a result `Label` or `TextBox`.

> **Hint:** convert `TextBox.Text` to a number before doing arithmetic, and back to a string before displaying it. Use `int.TryParse` for safety.

### Task 2: Arithmetic Calculator

1. Set the Form's `Text` to `Calculator`
2. Two input `TextBoxes`, one `ReadOnly` `TextBox` for the result
3. Buttons for `+`, `-`, `×`, `÷`, and **mod**, each with its own `Click` handler
4. A `Panel` or `Label` as a visual divider

> **Hint:** assume valid integer input for now. Full validation is a stretch goal, not a requirement here.

---

## 7. RadioButton and grouping

`RadioButtons` are mutually exclusive **within their container**: one Form-level group, or a separate group per `GroupBox`/`Panel`.

```cs
private void radioButton1_CheckedChanged(object sender, EventArgs e)
{
    listBox1.Items.Clear();
    listBox1.Items.Add("Option A - Line 1");
}
```

| Key terms            |                                                 |
| -------------------- | ----------------------------------------------- |
| `RadioButton`        | On/off, mutually exclusive within its container |
| `CheckedChanged`     | Fires when a RadioButton's state changes        |
| `GroupBox` / `Panel` | Defines independent RadioButton sets            |

---

## 8. DataGridView

`DataGridView` shows data in rows and columns. This is where your Module 03 classes and this module's controls meet.

```cs
using System.Collections.Generic;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private List<string> names;

    public Form1()
    {
        InitializeComponent();
        names = new List<string> { "John", "Mary", "Bob", "Jane" };

        dataGridView1.Columns.Add("Col1", "Name"); // id, then visible header

        foreach (string name in names)
        {
            int rowIdx = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIdx].Cells["Col1"].Value = name;
        }
    }
}
```

| Key terms              |                                            |
| ---------------------- | ------------------------------------------ |
| `DataGridView`         | Resizable, tabular display of data         |
| `Rows.Add()`           | Appends a new empty row, returns its index |
| `Rows[i].Cells["Col"]` | Accesses a specific cell                   |

**Design first.** This task combines a class you design yourself with a control you just learned. Write the class's "knows / does" summary (Module 03, Section 4) before you write a line of it.

### Task 3: Dogs from File

Create `dogs.txt`, one dog per line, comma-separated:

```
Scooby-Doo,2
Astro,5
Bolt,10
Augie,6
Dixie,9
```

Create a `Dog` class (private fields `name`, `age`, a constructor with `this`, and public properties). Read the file with `StreamReader` or `File.ReadAllLines`, split each line on `','`, build a `Dog` object per line, and add it to a `List<Dog>`. Display every dog's name and age in a `DataGridView`. Handle a missing file and malformed lines without crashing.

> **Hint:** wrap the read in `try-catch` for `FileNotFoundException` and `FormatException`.

---

## 9. Multiple forms

Most real applications have more than one window: a main form plus settings, help, or data-entry dialogs.

**Adding one:** right-click the project → **Add → Windows Form**, name it descriptively (`SettingsForm.cs`, not `Form2.cs`).

### 9.1 Modal vs modeless

```cs
// Modal: blocks interaction with everything else until closed
Form2 settingsForm = new Form2();
settingsForm.ShowDialog();

// Modeless: both forms stay usable at once
Form2 infoForm = new Form2();
infoForm.Show();
```

### 9.2 Passing data in

Via properties, set before showing:

```cs
// Form2.cs
public string UserName { get; set; }
public int UserAge { get; set; }

private void Form2_Load(object sender, EventArgs e)
{
    labelWelcome.Text = $"Welcome, {UserName}! Age: {UserAge}";
}
```

Or via constructor parameters, which is usually the cleaner option:

```cs
// Form2.cs
public Form2(string name, int age)
{
    InitializeComponent();
    labelWelcome.Text = $"Welcome, {name}! Age: {age}";
}

// Form1.cs
Form2 userForm = new Form2(textBoxName.Text, Convert.ToInt32(textBoxAge.Text));
userForm.ShowDialog();
```

### 9.3 Getting data back out

Expose the result as a public property and read it once `ShowDialog` returns:

```cs
// Form2.cs
public string EnteredText { get; private set; }
public bool UserClickedOK { get; private set; }

private void buttonOK_Click(object sender, EventArgs e)
{
    EnteredText = textBox1.Text;
    UserClickedOK = true;
    this.Close();
}

// Form1.cs
Form2 dataForm = new Form2();
dataForm.ShowDialog();

if (dataForm.UserClickedOK)
    MessageBox.Show($"User entered: {dataForm.EnteredText}");
```

### 9.4 Closing forms and form events

```cs
this.Close();          // closes the current form only
Application.Exit();    // ends the whole application, use only on the main form
```

| Event              | Fires                                                 |
| ------------------ | ----------------------------------------------------- |
| `Form_Load`        | When the form is first loaded                         |
| `Form_FormClosing` | Just before closing; set `e.Cancel = true` to stop it |

```cs
private void Form2_FormClosing(object sender, FormClosingEventArgs e)
{
    var result = MessageBox.Show("Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo);
    if (result == DialogResult.No)
        e.Cancel = true;
}
```

| Key terms     |                                                                    |
| ------------- | ------------------------------------------------------------------ |
| Modal form    | Must be closed before other forms are usable, using `ShowDialog()` |
| Modeless form | Coexists with other open forms, using `Show()`                     |
| `Form_Load`   | Fires when the form first loads                                    |
| `FormClosing` | Fires just before close, and is cancellable                        |

### Task 4: Two-Form Handoff

Build a small main form that collects a name and a favourite colour in two `TextBoxes`. On button click, open a second form **modally**, passing both values in through its constructor, and have the second form display a personalised message built from them. Add a `FormClosing` handler on the second form that asks "Are you sure you want to close?" before it closes.

---

## 10. Pulling it together

### Task 5: Pizza Parlour Order System

1. A Form for the order interface
2. At least **two pizza sizes** (Small, Large) with different prices, as `RadioButtons` inside a `GroupBox`. Clicking **Order** with nothing selected should show a polite message asking the user to choose one. Don't let it crash or silently do nothing
3. At least **five toppings** as `CheckBoxes`, any combination selectable
4. An **Order** `Button` that writes the full order to a `ListBox` and the total to a `TextBox`
5. Each new order clears the ← Previous one first

> **Hint:** `RadioButton.Checked` / `CheckBox.Checked` tell you what's selected. `listBox1.Items.Clear()` at the start of each calculation.

---

## Before you submit

- [ ] All 5 tasks complete and tested
- [ ] Every custom class you used follows the private-field + `this` + property pattern from Module 03
- [ ] No control type (Button, TextBox, Label, CheckBox, and so on) appears anywhere outside an event handler
- [ ] `README.md` updated with any AI prompts used
- [ ] Pushed to your GitHub repository
