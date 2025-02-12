# 10: Web Services

In your other courses, you may have learned about web services. Web services are a way for different applications to communicate with each other over the internet. They are a way to share data between different applications, even if they are written in different programming languages.

There are many different types of web services, but the most common type is called a **RESTful** web service. **REST** stands for **Representational State Transfer**, and it is a way of designing web services that is simple and easy to understand.

Let us have look at how to retrieve data from a **RESTful** web service using **C#**.

Here is a simple class:

```csharp
public class Person
{
    private int id;
    private string name;
    private string username;
    private string email;

    public Person(int id, string name, string username, string email)
    {
        this.id = id;
        this.name = name;
        this.username = username;
        this.email = email;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Username { get => username; set => username = value; }
    public string Email { get => email; set => email = value; }
}
```

In the `Form1` class, we will use the `HttpClient` class to retrieve data from a web service. The `HttpClient` class is used to send and receive data from a web service. It is part of the `System.Net.Http` namespace.

```csharp
public partial class Form1 : Form
{
    private HttpClient httpClient;

    public Form1()
    {
        InitializeComponent();

        httpClient = new HttpClient();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        string url = "https://jsonplaceholder.typicode.com/users";
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            List<Person>? people = JsonSerializer.Deserialize<List<Person>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (people != null)
            {
                listBox1.Items.Clear(); 
                foreach (Person person in people)
                {
                    listBox1.Items.Add($"{person.Id}: {person.Name} - {person.Email}");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

What is happening in the code above?

- Create an instance of the `HttpClient` class in the `Form1` constructor.
- Use the `HttpClient.GetAsync` method to send a `GET` request to the web service. `GET` is a method used to retrieve data from a web service.
- Use the `HttpResponseMessage.EnsureSuccessStatusCode` method to check if the response is successful. If the response is not successful, an exception is thrown.
- Use the `HttpResponseMessage.Content.ReadAsStringAsync` method to read the response body as a string.
- Use the `JsonSerializer.Deserialize` method to deserialize the JSON response into a list of `Person` objects.
- Display the list of `Person` objects in a `ListBox` control.
- Catch any exceptions that occur during the request and display an error message.

# Formative Assessment

No formative assessment provided in this topic.