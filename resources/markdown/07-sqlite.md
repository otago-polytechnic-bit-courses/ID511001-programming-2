# 07: Databases

## Introduction to Databases

A database is a structured collection of data that is stored and organized in a way that allows for efficient retrieval, updating, and management. In C# applications, databases are commonly used to persist data beyond the lifetime of the application. When working with databases in C#, we typically use **ADO.NET** (ActiveX Data Objects .NET), which provides a set of classes for accessing data sources.

## Connection Strings

A connection string is a string that specifies information about a data source and the means of connecting to it. It contains parameters such as the server name, database name, authentication information, and other settings required to establish a connection.

Here is an example of connecting to a SQLite database:

```cs
string connectionString = "Data Source=MyDatabase.db;";
```

```cs
using System.Data.SqlClient;
```

## Core Database Classes

### SqlConnection

The `SqlConnection` class represents a connection to a SQL Server database. It is used to establish a connection to the database before executing any commands.

```cs
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Perform database operations
    // Connection automatically closed when using block ends
}
```

### SqlCommand

The `SqlCommand` class represents a SQL statement or stored procedure to execute against a SQL Server database.

```cs
using (SqlCommand command = new SqlCommand("SELECT * FROM Users", connection))
{
    // Execute the command
}
```

### SqlDataReader

The `SqlDataReader` class provides a way to read a forward-only stream of rows from a SQL Server database. It is the most efficient way to retrieve data when you only need to read data sequentially.

```cs
using (SqlDataReader reader = command.ExecuteReader())
{
    while (reader.Read())
    {
        string name = reader["Name"].ToString();
        int age = Convert.ToInt32(reader["Age"]);
    }
}
```

## Basic Database Operations

### Reading Data (SELECT)

```cs
private void LoadUsers()
{
    string connectionString = "Server=localhost;Database=MyApp;Integrated Security=true;";
    string query = "SELECT Id, Name, Email FROM Users";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string email = reader["Email"].ToString();
                    
                    // Process the data (e.g., add to a list, display in UI)
                    Console.WriteLine($"ID: {id}, Name: {name}, Email: {email}");
                }
            }
        }
    }
}
```

### Inserting Data (INSERT)

```cs
private void AddUser(string name, string email)
{
    string connectionString = "Server=localhost;Database=MyApp;Integrated Security=true;";
    string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Email", email);
            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            
            if (rowsAffected > 0)
            {
                MessageBox.Show("User added successfully!");
            }
        }
    }
}
```

### Updating Data (UPDATE)

```cs
private void UpdateUser(int userId, string newName, string newEmail)
{
    string connectionString = "Server=localhost;Database=MyApp;Integrated Security=true;";
    string query = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", newName);
            command.Parameters.AddWithValue("@Email", newEmail);
            command.Parameters.AddWithValue("@Id", userId);
            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            
            if (rowsAffected > 0)
            {
                MessageBox.Show("User updated successfully!");
            }
        }
    }
}
```

### Deleting Data (DELETE)

```cs
private void DeleteUser(int userId)
{
    string connectionString = "Server=localhost;Database=MyApp;Integrated Security=true;";
    string query = "DELETE FROM Users WHERE Id = @Id";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Id", userId);
            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            
            if (rowsAffected > 0)
            {
                MessageBox.Show("User deleted successfully!");
            }
        }
    }
}
```

## SQL Parameters

Always use SQL parameters when working with user input to prevent SQL injection attacks. Parameters are placeholders in SQL statements that are replaced with actual values at runtime.

**Bad Practice (Vulnerable to SQL Injection):**
```cs
string query = $"SELECT * FROM Users WHERE Name = '{userName}'";
```

**Good Practice (Using Parameters):**
```cs
string query = "SELECT * FROM Users WHERE Name = @UserName";
command.Parameters.AddWithValue("@UserName", userName);
```

## Error Handling

Always implement proper error handling when working with databases:

```cs
private void SafeDatabaseOperation()
{
    string connectionString = "Server=localhost;Database=MyApp;Integrated Security=true;";
    
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            // Database operations here
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show($"Database error: {ex.Message}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"General error: {ex.Message}");
    }
}
```

## Working with SQLite

SQLite is a lightweight, file-based database that's perfect for desktop applications. To use SQLite, you need to install the `System.Data.SQLite` NuGet package.

```cs
private void CreateSQLiteDatabase()
{
    string connectionString = "Data Source=MyApp.db;Version=3;";
    
    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    {
        connection.Open();
        
        string createTable = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL
            )";
            
        using (SQLiteCommand command = new SQLiteCommand(createTable, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
```

## Best Practices

1. **Always use `using` statements** - This ensures proper disposal of database connections and resources.

2. **Use parameterized queries** - This prevents SQL injection attacks and improves performance.

3. **Handle exceptions appropriately** - Database operations can fail for various reasons (network issues, permission problems, etc.).

4. **Keep connections short-lived** - Open connections only when needed and close them as soon as possible.

5. **Store connection strings securely** - Don't hardcode connection strings in your source code. Use configuration files or environment variables.

6. **Validate input data** - Check data before sending it to the database.

# Exercises

Before you start, create a new **C# Windows Form Application** application with a descriptive name.

**Important Note About AI Tools:**

Learning to use AI tools is valuable, but you **must** be aware of the following:

- Refine your prompts to get useful responses
- Don't trust AI responses blindly - verify and test the code
- Acknowledge AI tool usage in your assessment's repository **README.md** file, including what prompts you used and how you applied the responses

## Task 1

In this task, you will create a simple student management system using SQLite.

Here are steps you should consider:

1. Install the `System.Data.SQLite` NuGet package to your project.

2. Create a SQLite database file called `Students.db` with a table called `Students` that has the following columns:
   - `Id` (INTEGER PRIMARY KEY AUTOINCREMENT)
   - `FirstName` (TEXT NOT NULL)
   - `LastName` (TEXT NOT NULL)
   - `Age` (INTEGER NOT NULL)
   - `Grade` (TEXT NOT NULL)

3. Design a Windows Form with the following controls:
   - `TextBox` controls for FirstName, LastName, Age, and Grade
   - `Button` controls for Add, Update, Delete, and Load
   - `ListBox` or `DataGridView` to display students
   - `TextBox` for entering Student ID for update/delete operations

4. Implement the following methods:
   - `CreateDatabase()` - Creates the database and table if they don't exist
   - `AddStudent()` - Adds a new student to the database
   - `LoadStudents()` - Loads all students and displays them
   - `UpdateStudent()` - Updates an existing student's information
   - `DeleteStudent()` - Deletes a student from the database

5. Add proper error handling for all database operations.

## Task 2

In this task, you will create a book library management system.

Here are steps you should consider:

1. Create a SQLite database called `Library.db` with two tables:
   
   **Authors table:**
   - `AuthorId` (INTEGER PRIMARY KEY AUTOINCREMENT)
   - `FirstName` (TEXT NOT NULL)
   - `LastName` (TEXT NOT NULL)
   
   **Books table:**
   - `BookId` (INTEGER PRIMARY KEY AUTOINCREMENT)
   - `Title` (TEXT NOT NULL)
   - `AuthorId` (INTEGER, FOREIGN KEY referencing Authors.AuthorId)
   - `PublicationYear` (INTEGER)
   - `IsAvailable` (BOOLEAN DEFAULT 1)

2. Create a Windows Form application with tabs or separate forms for:
   - Managing Authors (Add, View, Update, Delete)
   - Managing Books (Add, View, Update, Delete)
   - Search functionality (search books by title or author)

3. Implement the following features:
   - Add new authors and books
   - View all authors and books
   - Search for books by title or author name (use LIKE operator)
   - Mark books as borrowed/returned (toggle IsAvailable)
   - Display books with their author names (use JOIN operation)

4. Use parameterized queries for all database operations and implement comprehensive error handling.

## Submission

Push your completed code to your **GitHub** repository. Ensure your code is well-commented and follows proper naming conventions.