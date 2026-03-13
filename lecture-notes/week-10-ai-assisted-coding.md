# Week 10 — AI-Assisted Coding

## Navigation

|            | Link                        |
| ---------- | --------------------------- |
| ← Previous | [Week 09 — Serialisation]() |

---

## 1. What is AI-Assisted Coding?

AI coding tools use large language models (LLMs) to help developers write, explain, review, and refactor code. They do not replace developers — they act as a knowledgeable assistant that can accelerate routine tasks, surface alternatives, and help you get unstuck.

Common AI coding tools include:

| Tool              | Where it lives                                                   |
| ----------------- | ---------------------------------------------------------------- |
| GitHub Copilot    | Visual Studio, VS Code — inline suggestions as you type          |
| ChatGPT / Claude  | Browser or API — conversational, good for explanation and design |
| Microsoft Copilot | Integrated into Windows and Microsoft 365                        |
| Cursor            | AI-first code editor built on VS Code                            |

This course does not require a specific tool. The principles in this week apply to all of them.

---

## 2. What AI Tools Are Good At

Understanding where AI assistance adds real value helps you use it deliberately rather than reflexively.

| Task                                  | Why AI helps                                                             |
| ------------------------------------- | ------------------------------------------------------------------------ |
| Generating boilerplate                | Constructors, properties, `ToString()`, `Equals()` — repetitive patterns |
| Explaining unfamiliar code            | Paste a snippet and ask "what does this do?"                             |
| Suggesting method names and structure | Useful when designing a class for the first time                         |
| Writing unit test scaffolding         | AAA structure, test method names, common edge cases                      |
| Translating between formats           | Converting CSV to JSON, XML to C# classes, etc.                          |
| Debugging with context                | Describe the error and paste relevant code for suggestions               |
| Documenting code                      | Generating XML doc comments (`///`) from existing methods                |

---

## 3. What AI Tools Are Not Good At

AI tools have real limitations. Knowing them prevents you from shipping broken code with confidence.

| Limitation           | Practical risk                                                                    |
| -------------------- | --------------------------------------------------------------------------------- |
| Hallucination        | Inventing method names, library APIs, or behaviour that does not exist            |
| Outdated knowledge   | Training data has a cutoff — newer .NET APIs or packages may be wrong             |
| No runtime context   | The model cannot run your code — it cannot know what will actually happen         |
| Context blindness    | A short prompt produces generic code that may not fit your architecture           |
| Overconfident tone   | AI presents wrong answers as confidently as correct ones                          |
| Security blind spots | Generated code may contain SQL injection, unvalidated input, or insecure defaults |

> **Rule of thumb:** treat every AI-generated code block as code written by a capable but unfamiliar colleague. Review it, test it, and own it before committing it.

---

## 4. Writing Effective Prompts

The quality of AI output depends almost entirely on the quality of the prompt. Vague prompts produce generic, often useless code. Specific prompts produce targeted, useful responses.

---

### 4.1 The Anatomy of a Good Prompt

A good prompt includes four components:

| Component         | Purpose                                       | Example                                                                                       |
| ----------------- | --------------------------------------------- | --------------------------------------------------------------------------------------------- |
| **Context**       | What you are building and what already exists | "I have a `BankAccount` class with `Deposit` and `Withdraw` methods"                          |
| **Task**          | What you want the AI to do                    | "Write unit tests using MSTest"                                                               |
| **Constraints**   | Rules, frameworks, or patterns to follow      | "Follow the AAA pattern, one assertion per test, use `Assert.ThrowsException` for exceptions" |
| **Output format** | How you want the response structured          | "Return only the test class — no explanation"                                                 |

---

### 4.2 Prompt Examples — Weak vs Strong

**Generating a class:**

|           | Prompt                                                                                                                                                                                                                                                                                                                                                                                                           |
| --------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ❌ Weak   | "Write a C# class for a student"                                                                                                                                                                                                                                                                                                                                                                                 |
| ✅ Strong | "Write a C# class called `Student` with private fields `name` (string), `age` (int), and `grade` (double). Include a constructor, public properties with validation (`age` must be between 0 and 150, `grade` between 0 and 100), and an overridden `ToString()` that returns the student's name and grade. Use the naming conventions: private fields use camelCase with no prefix, properties use PascalCase." |

**Explaining code:**

|           | Prompt                                                                                                                                                                                     |
| --------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ❌ Weak   | "Explain this code"                                                                                                                                                                        |
| ✅ Strong | "Explain the following C# method to a student who understands loops and arrays but has not seen LINQ before. Focus on what `Where`, `Select`, and `OrderBy` do and why each is used here." |

**Debugging:**

|           | Prompt                                                                                                                                                                             |
| --------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ❌ Weak   | "My code doesn't work"                                                                                                                                                             |
| ✅ Strong | "The following C# method throws an `IndexOutOfRangeException` when the input array has one element. Identify the bug and explain why it occurs, then provide a corrected version." |

**Refactoring:**

|           | Prompt                                                                                                                                                                                                 |
| --------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ❌ Weak   | "Refactor this"                                                                                                                                                                                        |
| ✅ Strong | "Refactor the following method to eliminate the long method smell. Extract logical steps into private methods. Do not change the observable behaviour. Add XML doc comments to each extracted method." |

---

### 4.3 Iterative Prompting

Rarely does the first prompt produce a perfect result. Treat AI conversation as iterative:

1. Start with a clear initial prompt
2. Review the output — identify what is right, what is wrong, and what is missing
3. Follow up with a correction or refinement: _"The constructor is missing validation for negative age values — add it"_
4. Ask for alternatives: _"Show me a version of this using a dictionary instead of a switch statement"_
5. Ask it to explain its own output: _"Why did you use `private set` here instead of a read-only property?"_

---

## 5. AI in the Development Workflow

AI tools are most valuable at specific points in the development cycle.

---

### 5.1 Design Phase

Use AI to explore options before writing code:

```
Prompt: "I need to design a class hierarchy for a library management system.
The system tracks Books, Magazines, and DVDs. Each item has a title, ID,
and availability status. Books have an author and ISBN. Magazines have an
issue number. DVDs have a runtime in minutes.
Suggest a class hierarchy using inheritance and interfaces in C#.
Explain the trade-offs of your design."
```

Evaluate the suggestions critically — ask follow-up questions about trade-offs, ask for an alternative using composition instead.

---

### 5.2 Implementation Phase

Use AI for boilerplate and to fill in known patterns you do not want to type manually:

```
Prompt: "Generate the C# class for the following design. Use private fields,
public properties with PascalCase names, a constructor that accepts all fields,
and an override of ToString(). Throw ArgumentNullException for null string
parameters and ArgumentOutOfRangeException for values outside valid ranges.

Class: Product
Fields: name (string), price (decimal, >= 0), stock (int, >= 0)
```

---

### 5.3 Testing Phase

AI is particularly good at generating test case scaffolding:

```
Prompt: "Write MSTest unit tests for the following C# method.
Include: happy path, boundary values, and all exception cases.
Use the naming convention MethodName_Scenario_ExpectedResult.
Follow the AAA pattern. One assertion per test method.

[paste method here]"
```

---

### 5.4 Review and Documentation Phase

Use AI to review code you have written:

```
Prompt: "Review the following C# class for code smells as covered in
Week 08 (Large Class, Data Class, Magic Numbers, Feature Envy).
Identify any smells present and suggest specific refactorings.
Do not rewrite the class — only provide a list of issues and recommendations."
```

And to generate documentation:

```
Prompt: "Add XML doc comments (/// <summary>, <param>, <returns>, <exception>)
to every public method in the following C# class. Match the existing
code style and do not change any implementation."
```

---

## 6. Verifying AI-Generated Code

Never commit AI-generated code without verification. Use this checklist:

| Check                              | How                                                                                         |
| ---------------------------------- | ------------------------------------------------------------------------------------------- |
| Does it compile?                   | Build the project — fix any errors before anything else                                     |
| Does it do what was asked?         | Read through it carefully against your requirements                                         |
| Are there hidden assumptions?      | Check for hardcoded values, missing null checks, or assumed input formats                   |
| Does it follow course conventions? | PascalCase properties, camelCase fields, XML doc comments, proper access modifiers          |
| Does it pass the unit tests?       | Run the test suite — if tests fail, the code is wrong regardless of how convincing it looks |
| Are there security concerns?       | Check for unvalidated input, hardcoded credentials, or insecure file paths                  |

---

## 7. Acknowledging AI Usage

Using AI tools is permitted and encouraged in this course. You must acknowledge it honestly.

In your repository `README.md`, record:

- Which tool you used (e.g. GitHub Copilot, ChatGPT, Claude)
- The exact prompts you used (or a summary if the conversation was long)
- How you used the output — did you use it directly, modify it, or only use it as inspiration?
- What you changed and why

In any AI-assisted source file, add the XML doc comment block at the top of the class:

```cs
/// <summary>
/// Brief description of what this class does.
/// </summary>
/// <remarks>
/// AI-Assisted: This file was developed with assistance from [AI Tool Name].
/// Prompts:
///   - "Your first prompt here"
///   - "Your second prompt here"
/// Usage: Describe how you used the AI responses and what you changed.
/// </remarks>
public class MyClass
{
    // ...
}
```

> Acknowledging AI use is not a penalty — it demonstrates professional practice and academic integrity. Submitting AI-generated code without acknowledgement is a form of academic dishonesty.

| Key terms           |                                                                                          |
| ------------------- | ---------------------------------------------------------------------------------------- |
| LLM                 | Large Language Model — the underlying technology behind AI coding tools                  |
| Prompt              | The instruction or question you give an AI tool                                          |
| Hallucination       | An AI generating plausible-sounding but incorrect information                            |
| Iterative prompting | Refining a prompt through a series of follow-up instructions                             |
| Context window      | The amount of text an AI can consider at once — larger context produces better responses |
| Prompt engineering  | The practice of crafting prompts to produce more accurate and useful AI output           |

---

## Exercises

Before you start, create a new **C# Windows Forms Application** with a descriptive name. For every task that involves AI-generated code, include the acknowledgement block from Section 7 in the relevant file.

**Important:** the goal of these exercises is not just to get working code — it is to practise using AI tools deliberately, critically, and honestly.

---

### Task 1 — Evaluate a Weak Prompt

Use an AI tool with the following weak prompt and record the output:

```
"Write a C# class for a bank account"
```

Then craft a strong prompt using the four-component structure from Section 4.1. Your strong prompt must specify: fields and their types, validation rules, required methods, and naming conventions. Record both prompts and both outputs in your `README.md`.

Write a short paragraph (4–6 sentences) comparing the two outputs. Address: what was missing from the weak prompt's output, what the strong prompt added, and whether you had to modify either output before it was usable.

---

### Task 2 — AI-Assisted Class Design

Use an AI tool to help you design and implement a `Library` system with the following requirements:

- A `LibraryItem` base class with `Title`, `ItemId`, and `IsAvailable`
- At least two derived classes (e.g. `Book`, `DVD`) each with their own additional properties
- A `Library` class that holds a `List<LibraryItem>` and exposes methods to add items, check out an item (sets `IsAvailable = false`), return an item (sets `IsAvailable = true`), and search by title
- JSON serialisation to persist the library to a file (Week 09)

Record your prompts in the acknowledgement block. After receiving the AI output, identify at least two things you changed and explain why.

> **Hint:** start with a design prompt asking for the class hierarchy, then follow up with implementation prompts for each class separately. Do not ask for everything in one prompt.

---

### Task 3 — AI-Generated Unit Tests

Take the `Calculator` class you wrote in Week 07 Task 2. Use an AI tool to generate an extended set of MSTest unit tests for it with the following prompt as a starting point — refine it before using it:

```
"Write MSTest unit tests for a static C# Calculator class with
Add, Subtract, Multiply, and Divide methods. [add your constraints here]"
```

After receiving the generated tests:

1. Identify any tests that are incorrect or that test behaviour your implementation does not have
2. Identify any important cases the AI missed
3. Add at least two tests the AI did not generate
4. Run all tests and fix any failures

Document which tests you kept unchanged, which you modified, and which you added yourself.

---

### Task 4 — Refactoring with AI Assistance

Take the `ShoppingCart` class from Week 08 Task 2 (or use the original unrefactored version). Use an AI tool to help you refactor it. Your prompt must ask the AI to:

- Identify specific code smells by name
- Suggest refactorings without rewriting the class
- Explain the reasoning behind each suggestion

Review the suggestions. Implement the refactorings yourself (do not ask the AI to rewrite the class for you). Run your Week 08 unit tests to confirm behaviour is unchanged.

Write a reflection in your `README.md`: did the AI identify all the smells you found in Week 08? Did it suggest anything you had not considered? Did it suggest anything incorrect?

---

### Task 5 — Full Feature with AI Assistance

Build a **Student Grade Tracker** application using AI assistance throughout. The application must:

1. Allow the user to add students with a name and a list of grades
2. Calculate and display each student's average, highest, and lowest grade
3. Display a letter grade based on the average (A/B/C/D/F)
4. Persist all data to a JSON file (using the pattern from Week 09)
5. Allow the user to remove a student

For each component (class design, UI wiring, serialisation, LINQ queries), write a prompt, record it, use the output as a starting point, and then modify and test it yourself.

Your `README.md` must include a section titled **AI Usage Log** with a table:

| Component         | Tool used | Prompt summary | What you changed |
| ----------------- | --------- | -------------- | ---------------- |
| Student class     |           |                |                  |
| Grade calculation |           |                |                  |
| Serialisation     |           |                |                  |
| UI wiring         |           |                |                  |

> **Hint:** keep each prompt focused on one component. A prompt that asks for the entire application at once will produce code that is harder to understand and verify.

---

## Submission

Push your completed code to your GitHub repository. Ensure every AI-assisted file contains the acknowledgement block from Section 7, and your `README.md` contains a complete AI Usage Log.
