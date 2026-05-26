# Project 2

<img src="../../resources (ignore)/img/logo.jpg" alt="Otago Polytechnic Logo" width="200" height="auto" />

# ID511001: Programming 2

## Assessment Information

| Level | Credits | Assessment Type | Weighting |
| ----- | ------- | --------------- | --------- |
| 5     | 15      | Individual      | 35%       |

## Assessment Overview

In this individual assessment, you will design and develop a Guess Who game as a Windows Forms Application using C#. Unlike a prescriptive project, you are expected to make your own design decisions about how to structure and implement the application. Character data will be provided by the course lecturer in a file; you are responsible for reading it in and building your solution around it.

## Learning Outcomes

At the successful completion of this course, learners will be able to:

1. Build interactive, event-driven GUI applications using pre-built components.
2. Declare and implement user-defined classes using encapsulation, inheritance and polymorphism.

---

## Assessments

| Assessment              | Weighting | Due Date                                                            | Type       | Learning Outcomes |
| ----------------------- | --------- | ------------------------------------------------------------------- | ---------- | ----------------- |
| Project 1               | 35%       | 10 May at 11:59 PM                                                  | Individual | 1, 2              |
| Project 2               | 35%       | 21 June at 11:59 PM                                                 | Individual | 1, 2              |
| Skills-Based Assessment | 30%       | 21 May 1:00–2:45 PM / 19 May 3:00–4:45 PM                          | Individual | 1, 2              |

## Conditions of Assessment

You will complete this assessment mostly during your learner-managed time. However, there will be time during class to discuss the requirements and your progress on this assessment. This assessment will need to be completed by 21 June at 11:59 PM.

## Pass Criteria

This assessment is criterion-referenced (CRA) with a cumulative pass mark of 50% across all assessments in ID511001: Programming 2.

## Submission

You must submit all application files via GitHub Classroom.

- Repository URL: [http://classroom.github.com/a/Ury_53GW](http://classroom.github.com/a/Ury_53GW)
- Git Ignore: If you do not have one, create a .gitignore using this resource - [VisualStudio.gitignore](https://raw.githubusercontent.com/github/gitignore/main/VisualStudio.gitignore)
- Due Date: Sunday 21 June at 11:59 PM
- Late Penalty: 10% per day, rolling over at 12:00 AM

The latest application files in the main branch will be used to mark against the marking rubric. Please test your applications before you submit. Partial marks may be given for incomplete functionality.

## Authenticity

All parts of your submitted assessment must be completely your work. Do your best to complete this assessment without using AI tools. You need to demonstrate to the course lecturer that you can meet the learning outcome for this assessment.

### AI Tools

Learning to use AI tools is an important skill. While AI tools are powerful, you must be aware of the following:

- If you provide an AI tool with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust the AI tool's responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge what AI tool you have used. In the assessment's repository README.md file, please include what prompt(s) you provided to the AI tool and how you used the response(s) to help you with your work

This also applies to code snippets retrieved from StackOverflow and GitHub.

Failure to do this may result in a mark of zero for this assessment.

## Policy on Submissions, Extensions, Resubmissions and Resits

The school's process concerning submissions, extensions, resubmissions and resits complies with Otago Polytechnic policies. Learners can view policies on the Otago Polytechnic website located at [https://www.op.ac.nz/about-us/governance-and-management/policies](https://www.op.ac.nz/about-us/governance-and-management/policies).

## Extensions

Familiarise yourself with the assessment due date. Extensions will only be granted if you are unable to complete the assessment by the due date because of unforeseen circumstances outside your control. The length of the extension granted will depend on the circumstances and must be negotiated with the course lecturer before the assessment due date. A medical certificate or support letter may be needed. Extensions will not be granted on the due date and for poor time management or pressure of other assessments.

## Resits

Resits and reassessments are not applicable in ID511001: Programming 2.

---

## Game Overview

Guess Who is a two-player deduction game. Each player selects a secret character from a shared pool. Players take turns asking yes/no questions about attributes to eliminate characters from their board. The first player to correctly guess the other's secret character wins.

Your application should implement a **human vs. computer** version of the game. The computer opponent should ask questions and eliminate characters automatically based on the responses.

> **Note:** Character data will be provided by your course lecturer in a file. You are responsible for reading that file into your application. The format will be announced before the assessment is due — design your solution to be flexible enough to handle the data as given.

---

## Instructions

You will need to submit an application and documentation that meet the following requirements. The class and file structure is not prescribed — you must design your own object model. The requirements below describe behaviour and responsibilities; how you implement them is up to you, as long as the result is clean, well-structured, object-oriented C# code.

---

## Functionality - Learning Outcomes 1, 2 (60%)

### Part 1 - Data Model (10%)

Design a set of classes to represent the game's data. At a minimum your model must support:

- A representation of a character, including their name and a set of attributes, e.g. hair colour, eye colour, gender, has glasses, or has hat.
- A representation of a single attribute, with a name and a value.
- A way to load all characters from the data file provided by the course lecturer. This should be implemented as a method or class that reads the file and returns a populated list of characters ready for the game to use.

Each character must have at least five attributes. Attribute values should be binary (Yes/No) or use a small number of distinct values so that questions can effectively eliminate characters.

**Data order in text file:**
First is the id, second is the Name, third is hair colour, fourth is hair length, fifth is the style of hair, sixth is the eye colour, seventh is the skin tone, eighth is their top colour, ninth is any accessories, tenth if they have a beard, eleventh is if they have a moustache.


> **Hint:** Think carefully about your attribute design. Good attributes allow a single question to eliminate a meaningful number of characters from the board.

---

### Part 2 - Game Logic (15%)

Design and implement the logic that drives gameplay. At a minimum your implementation must support:

- A representation of a yes/no question, including the question text, which attribute it targets, and what value it expects. It must be possible to test a question against a character to determine whether that character matches.
- A set of questions that covers every attribute value present in the character pool. Every attribute value that appears on at least one character must have a corresponding question.
- A game board for each player that tracks which characters have been eliminated, can eliminate characters based on a question and answer, can return the list of remaining characters, and can detect when only one character remains.

---

### Part 3 - Players (15%)

Design and implement the player classes. At a minimum:

- There should be a common base for both player types that captures shared data, e.g. name and their game board, and defines the interface for taking a turn.
- **Human player:** taking a turn means selecting a question from the UI and receiving a yes/no answer.
- **Computer player:** taking a turn means automatically selecting the most useful question — the one that would eliminate the most remaining characters — and applying the answer.

---

### Part 4 - Windows Forms UI (20%)

Implement the game interface as a Windows Forms application. The following functionality is required:

- Load all characters from the provided data file when the form initialises. **[1 mark]**
- Display all characters on the human player's board as a grid of `Button` or `PictureBox` controls, and a way of showing each of the character's name. **[1 mark]**
- Allow the human player to visually eliminate characters by clicking on them, e.g. toggling a greyed-out or crossed-out state. **[1 mark]**
- Display for the computer player the current list of remaining non-eliminated characters on a `ListBox` or `Label`. **[1 mark]**
- Allow the human player to select a question from a `ComboBox` populated with all available questions. **[1 mark]**
- When the human player asks a question, query the computer player's secret character and display the answer — Yes or No — in a `Label`. Eliminate/turn the appropriate characters from the board. **[2 marks]**
- Implement the computer player's turn: automatically select and display the question the computer asks, prompt the human player for a Yes/No answer using `Button` controls, and eliminate characters from the computer's board accordingly. **[4 marks]**
- Allow the human player to make a final guess by selecting a character name. If correct, display a win message; if incorrect, display a loss message. **[3 marks]** 
- Allow the computer player to make a final guess when only one character remains on its board. If correct, the computer wins; display an appropriate message. **[3 marks]**
- To reduce errors for the computer, list the features for the player's card. **[1 mark]**
- Include a **New Game** button that resets both boards and starts a fresh game. **[1 mark]**
- Include a **Quit** button that closes the application. **[1 mark]**

---

## Code Quality and Best Practices - Learning Outcome 2 (40%)

### Naming Conventions (5%)

File, class, method, variable, constant and property names should be clear, descriptive and consistent across the codebase.

### Comments (8%)

The code should be well-commented using the XML documentation format that explains complex logic and clarifies the purpose of classes, methods or complex sections.

### Code Formatting (5%)

Consistent indentation and spacing should be used across the codebase. It includes ensuring proper indentation for code blocks, following a standard format for braces and adding blank lines between sections.

### Dead Code (5%)

The code should not contain unused or redundant files, classes, methods, variables, constants or properties. Keeping unnecessary code around can lead to confusion, clutter and potential bugs down the line.

### Performance and Scalability (15%)

The code should be optimised for performance, using object-oriented programming principles, efficient algorithms and data structures, and error handling to minimise bottlenecks.

Here are some examples, but not a complete list, of error handling:

- Question selection should be validated — the player must select a question before submitting their turn
- Final guess validation — the player must select a character name before submitting a guess
- The data file should be read gracefully — if the file is missing or malformed, the application should handle the error without crashing

### Class Diagram (2%)

Generate a class diagram using Visual Studio's built-in tools. This diagram should include all classes, methods and properties used in the application.

---

## Additional Information

- You may add additional classes and methods beyond those specified.
- The computer player must make at least one guess per game. It should guess when only one character remains on its board.
- The human player may eliminate characters manually on their own board by clicking, independently of the question/answer system. This represents the player's own bookkeeping.
- Do not rewrite your Git history. It is important that the course lecturer can see how you worked on your assessment over time.
