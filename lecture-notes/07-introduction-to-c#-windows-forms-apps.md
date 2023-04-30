# 07: Introduction to C# Windows Forms App

## Overview

The **Microsoft Visual Studio IDE** (integrated development environment) is made up of several tools that are used to build **GUI** (Graphical User Interface) applications – those with windows, buttons menus, graphics, etc., by dragging and dropping these pre-built controls onto an existing form as we want it to appear. We build applications that will respond to events – when the user clicks on a button, when a form is closed, etc. **Visual Studio** fills in all the necessary code for how to make these events happen when it compiles our program. We concentrate on writing the code to describe what should happen when the user clicks on a button, selects a menu-item, closes a window, and so on. We don’t have to worry about all the complex operating system programming underneath – **Visual Studio** takes care of that for us.

## Creating a Windows Forms App

1. Open **Visual Studio**
2. Select **Create a new project**
3. Select **Windows Forms App (.NET Framework)**
4. Click **Next**
5. Fill in the following fields:
   - **Project name:** `FirstProgram`
   - **Location:** `<path-to-repository>`
   - **Solution name:** `FirstProgram`

Ensure that these four windows are visible on your screen. Note they are all dockable.

![](../resources/img/07-introduction-to-c-sharp-windows-forms-apps/01-image.png)

The main part is named `Form1.cs (Design)`. This is where, at design time, you create the **GUI**; it is used as a drawing canvas to resize the main form, add the buttons, labels etc that you will use in your application. This will be the main window that the user sees when your application is run. Your application can contain multiple windows (or **Forms**) that are displayed in response to user input, data values, etc. To start with, we will build projects that have only one Form.

## Adding Controls

Open View/Toolbox/Common Controls.

1.	Add two `Buttons`, a `TextBox`, a `PictureBox` and a `Label` to the `Form`.
2. Run the program. Click on one of the `Buttons`, write in the `TextBox`. What happens?
3. Change the **size**, **text** and **name** of each of your `Buttons`.
4.	Change the text, font and visibility of the `Label`.
5. Add an image to the `PictureBox`. How can you resize the image?
6. Change the colour of the `Form`.

## Design-Time or Run-Time?

We said earlier that `TextBoxes` could be used to show messages to the user of your program. For this to be useful, you need to be able to change the `Text` property while the program is running, when you won’t be able to get at the **Properties** list. Changing a property while you are creating your application is called *"modifying at design-time"*. Changing the property from within the program while the program is running is called *"modifying at run-time"*.

Modifying at run-time is very easy: you simply write an assignment statement to assign a new value to the property. To refer to an object’s property at run-time you use *"dot notation"*, which you have seen before when referring to elements of records at runtime. For example, to assign the text *"Here is my new text"* to your `TextBox`, you put this statement in your code:

```cs
textBox1.Text  = "Here is my new text"; 
```

Assume you have three controls `button1`, `label1` and `textBox1` on your `Form`. What will be the effect of each of these statements at run-time?

1.	`button1.Width = 400;`
2.	`label1.Visible = false;`
3.	`textBox1.Text  = "Go Otago";`
4.	`button1.Text = label1.Text;`





# Formative Assessment

Before you start, create a new branch called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.