# 09: More Graphics Class and Controller Class

A controller class is responsible for creating objects and calling their methods. 

Let us digest the following classes:

```cs
public class Molecule
{
    private const int SIZE = 10;

    private Point position;
    private Color colour;
    private Graphics graphics;
    private Random random; 
    private Brush brush;

    public Molecule(Point position, Color colour, Graphics graphics, Random random)
    {
        this.position = position;
        this.colour = colour;
        this.graphics = graphics;
        this.random = random;
    }

    public void Draw()
    {
        graphics.FillEllipse(new SolidBrush(colour), new Rectangle(position.X, position.Y, SIZE, SIZE));

        // or

        // graphics.FillEllipse(brush, position.X, position.Y, SIZE, SIZE);
    }
}
```

```cs
public partial class Form1 : Form
{
    private const int TOTAL = 50;
    private const int RED_POSITION = 180;
    private const int BLUE_POSITION = 280;
    private const int PURPLE_POSITION = 380;

    private Graphics graphics;
    private Random random;
    private List<Molecule> molecules;

    public Form1()
    {
        InitializeComponent();

        graphics = CreateGraphics();
        random = new Random();
        
        molecules = new List<Molecule>();

        for (int i = 0; i < TOTAL; i++)
        {
            molecules.Add(new Molecule(new Point(RED_POSITION, RED_POSITION), Color.Red, graphics, random));
            molecules.Add(new Molecule(new Point(BLUE_POSITION, BLUE_POSITION), Color.Blue, graphics, random));
            molecules.Add(new Molecule(new Point(PURPLE_POSITION, PURPLE_POSITION), Color.Purple, graphics, random));
        }

        timer1.Enabled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        Refresh();
        foreach (Molecule molecule in molecules)
        {
            molecule.Draw();
        }
    }
}
```

How can we extract ūn-related UI code from `Form1.cs` into `Controller.cs`?

```cs
public class Controller
{
    private const int TOTAL = 50;
    private const int RED_POSITION = 180;
    private const int BLUE_POSITION = 280;
    private const int PURPLE_POSITION = 380;

    private List <Molecule> molecules;

    public World(Graphics graphics, Random random)
    {
        molecules = new List<Molecule>();

        for (int i = 0; i < TOTAL; i++)
        {
            molecules.Add(new Molecule(new Point(RED_POSITION, RED_POSITION), Color.Red, graphics, random));
            molecules.Add(new Molecule(new Point(BLUE_POSITION, BLUE_POSITION), Color.Blue, graphics, random));
            molecules.Add(new Molecule(new Point(PURPLE_POSITION, PURPLE_POSITION), Color.Purple, graphics, random));
        }
    }

    public void Run()
    {
        foreach (Molecule molecule in molecules)
        {
            molecule.Draw();
        }
    }
}
```

```cs
public partial class Form1 : Form
{
    private Graphics graphics;
    private Random random;
    private Controller controller;

    public Form1()
    {
        InitializeComponent();

        graphics = CreateGraphics();
        random = new Random();

        controller = new Controller(graphics, random);

        timer1.Enabled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        Refresh();
        controller.Run();
    }
}
```

# Formative Assessment

Before you start, create a new branch called **06-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

In the `Molecule` class, create a new `public void` method called `Move`. In the `Move` method, you will need to:
1. Randomly generate an integer value between -10 (inclusive) and 11 (exclusive) using the `Random` class's `Next` method.
2. Get the `Molecule's` X and Y position and add the random integer value using the addition assignment operator (`+=`).

In the `Controller` class, call the `Molecule's` `Move` method in the `Run` method.

## Task 2:
In this task, you will create a bouncing ball. Feel free to create a project. You will need to create a `Ball` class and a `Controller` class. 

The `Ball` class will need to have the following fields:
- A `private` `const` `int` field called `SIZE` that is set to `25`
- A `private` `Point` field called `speed`
- A `private` `Point` field called `position`
- A `private` `Color` field called `colour`
- A `private` `Graphics` field called `graphics`
- A `private` `Brush` field called `brush`
- A private `Size` field called `clientSize``

The `Ball` class will need to have a constructor that takes in a `Point` called `position`, a `Point` called `speed`, a `Color` called `colour`, a `Graphics` called `graphics`, and a `Size` called `clientSize`. Also, you will need to create a new `SolidBrush` object and assign it to the `brush` field.

The `Ball` class will have three other methods:
- A `public void` method called `Draw` that takes in no parameters. In the `Draw` method, you will need to call the `FillEllipse` method on the `graphics` field and pass in the `brush` object and a new `Rectangle` object that takes in the `position.X`, `position.Y`, `SIZE`, and `SIZE` fields.
- A `public void` method called `Move` that takes in no parameters. In the `Move` method, you will need to set the `position.X` property to the `position.X` property plus the `speed.X` property. You will also need to set the `position.Y` property to the `position.Y` property plus the `speed.Y` property.
- A `public void` method called `BounceSide` that takes in no parameters. In the `BounceSide` method, you will need to check if the `position.X` property is less than 0 or greater than the `clientSize.Width` property. If it is, you will need to set the `speed.X` property to the negative of the `speed.X` property. You will also need to do something similar for the `position.Y` property.

The `Controller` class will need to have the following field: a `private` `Ball` field called `ball`.

The `Controller` class will need to have a constructor that takes in a `Graphics` called `graphics`, and a `Size` called `clientSize`. In the constructor, you will need to create a new `Ball` object and assign it to the `ball` field.

The `Controller` class will have one other methods:
- A `public void` method called `Run` that takes in no parameters. In the `Run` method, you will need to call the `Move`, `BounceSide` and `Draw` methods on the `ball` field.

In the `Form1` class, call the `Controller's` `Run` method in the `timer1_Tick` method.	

## Task 3:

When you run the application, you will notice the ball is flickering. In this task, you will implement double buffering. 

What is double buffering? Double buffering is a technique that involves drawing to an off-screen buffer and then copying the off-screen buffer to the screen. This technique is used to prevent flickering.


In the `Form1` class, you will need to create two new fields: a `private` `Bitmap` field called `offScreenBitmap` and a `private` `Graphics` field called `offScreenGraphics`.


In the `Form1` constructor, replace the existing code with the following:

```cs	
public Form1()
{
    InitializeComponent();

    offScreenBitmap = new Bitmap(Width, Height);
    offScreenGraphics = Graphics.FromImage(bufferImage);
    graphics = CreateGraphics();
    controller = new World(offScreenGraphics, ClientSize);     
    timer1.Enabled = true;
}
```

In the `timer1_Tick` constructor, replace the existing code with the following:

```cs
private void timer1_Tick(object sender, EventArgs e)
{
    bufferGraphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
    controller.Run();
    graphics.DrawImage(bufferImage, 0, 0);
}
```

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.
