# Project 2 - Marking Rubric

## Functionality — Learning Outcomes 1, 2 (60%)

### Part 1 — Data Model (10%)

| Criteria | Excellent <br>10–8 | Good <br>7.5–6.5 | Developing <br>6–5 | Beginning <br>4.5–0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Character and Attribute Classes [5 marks] | All classes correctly designed with appropriate fields, methods and properties. | Minor issues in class design or implementation. | Significant issues in class design or implementation. | Major errors or classes are missing. | |
| Data Loading [5 marks] | Characters and attributes are correctly loaded from the provided data file. All characters have a full and unique set of attributes. | Minor issues in how data is loaded or parsed. | Significant issues in data loading or attribute completeness. | Major errors in data loading, or functionality is missing. | |

---

### Part 2 — Game Logic (15%)

| Criteria | Excellent <br>15–12 | Good <br>11.5–9.5 | Developing <br>9–7.5 | Beginning <br>7–0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Question Class and Matches Method [3 marks] | Question is correctly implemented with appropriate fields. Matches() correctly evaluates a character against the question. | Minor issues in the class or method. | Significant issues in the class or method. | Major errors or missing. | |
| Question Set [3 marks] | A complete set of questions is provided, covering every attribute value present in the character pool. | Minor gaps in question coverage. | Significant gaps in question coverage. | Questions are largely missing or do not match attributes. | |
| EliminateCharacters Method [3 marks] | Correctly eliminates all characters that do not match the given answer. | Minor issues in elimination logic. | Significant issues in elimination logic. | Major errors or missing. | |
| GetRemainingCharacters Method [3 marks] | Correctly returns only non-eliminated characters. | Minor issues in filtering logic. | Significant issues in filtering logic. | Major errors or missing. | |
| IsOnlyOneRemaining Method [3 marks] | Correctly returns true when exactly one character has not been eliminated. | Minor issues in logic. | Significant issues in logic. | Major errors or missing. | |

---

### Part 3 — Players (15%)

| Criteria | Excellent <br>15–12 | Good <br>11.5–9.5 | Developing <br>9–7.5 | Beginning <br>7–0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Base Player Class [5 marks] | Abstract base class correctly defined with shared fields and an abstract TakeTurn() method. | Minor issues in base class design. | Significant issues in base class design. | Major errors or missing. | |
| HumanPlayer Class [5 marks] | Correctly inherits from the base class. TakeTurn() is properly overridden to allow the user to select a question and receive an answer via the UI. | Minor issues in class or override. | Significant issues in class or override. | Major errors or missing. | |
| ComputerPlayer Class [5 marks] | Correctly inherits from the base class. TakeTurn() is properly overridden to automatically select the most useful question and apply the answer. | Minor issues in class or override. | Significant issues in class or override. | Major errors or missing. | |

---

### Part 4 — Windows Forms UI (20%)

| Criteria | Excellent <br>20–16 | Good <br>15.5–13 | Developing <br>12.5–10 | Beginning <br>9.5–0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Form Functionality | All specified UI functionality is correctly implemented and the game plays end-to-end without errors. | Some functionality is missing or has minor issues. | Several elements are incomplete or have significant issues. | Most functionality is missing or not working. | |

Marking breakdown:

- Load characters from the provided data file in the form constructor [1 mark]
- Display character grid on the human player's board, including names [1 mark]
- Visual elimination by clicking [1 mark]
- Display remaining non-eliminated characters for computer [1 mark]
- Question selection via ComboBox [1 mark]
- Human player asks a question and board updates [2 marks]
- Computer player's turn with Yes/No prompt and board update [4 marks]
- Human player final guess with win/loss message [3 marks]
- Computer player final guess with win/loss message [3 marks]
- Display list of features for player's card [1 mark]
- New Game button [1 mark]
- Quit button [1 mark]

Comments — Functionality

---

## Code Quality and Best Practices — Learning Outcome 2 (40%)

| Criteria | Excellent <br>38-29| Good<br>28.5-17.5 | Developing<br>17-8 | Beginning<br>7.5-0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Naming Conventions [5 marks] | File, class, method, variable, constant and property names are clear, descriptive and consistent across the codebase. | Minor inconsistencies in naming conventions. | Significant inconsistencies in naming conventions. | Naming conventions are not followed. | |
| Comments [8 marks] | Code is well-commented using XML documentation format that explains complex logic and clarifies the purpose of classes, methods and complex sections. | Minor issues in XML documentation comments. | Significant issues in XML documentation comments. | Missing or incorrect XML documentation comments. | |
| Code Formatting [5 marks] | Consistent indentation and spacing used across the codebase with proper indentation for code blocks, standard format for braces and appropriate blank lines between sections. | Minor inconsistencies in code formatting. | Significant inconsistencies in code formatting. | Poor or non-consistent code formatting. | |
| Dead Code [5 marks] | No dead or unused code is present in the application. | Minor instances of dead or unused code. | Significant instances of dead or unused code. | Widespread presence of dead or unused code. | |
| Performance and Scalability [15 marks] | Code is optimised for performance using OOP principles, efficient algorithms and data structures, and error handling to minimise bottlenecks. | Minor inefficiencies in the performance and scalability approach. | Significant inefficiencies in the performance and scalability approach. | Poor or non-efficient performance and scalability approach. | |

Error handling examples:

- Question selection should be validated — the player must select a question before submitting their turn
- Final guess validation — the player must select a character name before submitting a guess
- The data file should be read gracefully — if the file is missing or malformed, the application should handle the error without crashing

Comments — Code Quality and Best Practices

---

| Criteria | Excellent <br>2–1.5 | Good <br>1.5 | Developing <br>1 | Beginning <br>0.5–0 | Mark |
| --- | --- | --- | --- | --- | --- |
| Class Diagram [2 marks] | A clear and accurate class diagram generated using Visual Studio's built-in tools, showing all classes, their methods and properties. | Minor issues or inaccuracies in the class diagram. | Significant issues or inaccuracies in the class diagram. | Class diagram is missing or unclear. | |

Comments — Class Diagram
