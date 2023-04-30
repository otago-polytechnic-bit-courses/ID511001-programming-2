# 07: Introduction to C# Windows Forms App

## Overview

The **Microsoft Visual Studio IDE** (integrated development environment) is made up of several tools that are used to build **GUI** (Graphical User Interface) applications – those with windows, buttons menus, graphics, etc., by dragging and dropping these pre-built controls onto an existing form as we want it to appear. We build applications that will respond to events – when the user clicks on a button, when a form is closed, etc. **Visual Studio** fills in all the necessary code for how to make these events happen when it compiles our program. We concentrate on writing the code to describe what should happen when the user clicks on a button, selects a menu-item, closes a window, and so on. We don’t have to worry about all the complex operating system programming underneath – **Visual Studio** takes care of that for us.

## Creating a Windows Forms App

1. Open **Visual Studio**
2. Select **Create a new project**
3. Select **Windows Forms App (.NET Framework)**
4. Click **Next**
5. Fill in the following fields:
   - **Project name:** `Calculator`
   - **Location:** `<path-to-repository>`
   - **Solution name:** `Calculator`

[label](../resources/img/07-introduction-to-c-sharp-windows-forms-apps.png)

Ensure that these four windows are visible on your screen. Note they are all dockable.
The main part is named `Form1.cs (Design)`. This is where, at design time, you create the **GUI**; it is used as a drawing canvas to resize the main form, add the buttons, labels etc that you will use in your application. This will be the main window that the user sees when your application is run. Your application can contain multiple windows (or **Forms**) that are displayed in response to user input, data values, etc. To start with, we will build projects that have only one Form.

# Formative Assessment

Before you start, create a new branch called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.