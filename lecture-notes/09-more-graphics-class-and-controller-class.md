# 09: More Graphics Class and Controller Class

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

How can we extract business logic code from `Form1.cs` into `Controller.cs`?

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

In the `Controller` class

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.
