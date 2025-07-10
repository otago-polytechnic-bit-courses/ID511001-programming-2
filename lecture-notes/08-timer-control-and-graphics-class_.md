# 08: Timer Control and Graphics Class

## Timer Control

The `Timer` controls provides a way to execute code at specified intervals. It is commonly used in Windows Forms Apps to performs tasks such as updating the UI, refreshing data or executing specific code at regular intervals.

To use the `Timer` control, you must first drag it from the toolbox onto the form. Once you have done this, you can set properties such as `Interval` and `Enabled`. The `Timer` control exposes several events. The most commonly used event is the `Tick` event. This event is raised each time the `Interval` elapses.

## Graphics Class

The `Graphics` class provides methods for drawing shapes, text, images and other objects onto the form.

To get started, above the `Form1`'s constructor, declare a `Graphics` variable:

```csharp
private Graphics graphics;
```

In the `Form1`'s constructor, create a new instance of the `Graphics` class by calling the `CreateGraphics` method:

```csharp
public Form1()
{
    InitializeComponent();

    graphics = CreateGraphics();
}
```

Create a new `Form` event called `Paint`. In the `Form1_Paint` method, add the following:

```csharp
private void Form1_Paint(object sender, PaintEventArgs e)
{
    // Draw a line
    graphics.DrawLine(Pens.Red, new Point(10, 10), new Point(20, 20));

    // Draw a rectangle
    graphics.DrawRectangle(Pens.Blue, new Rectangle(10, 20, 100, 50));

    // Fill a rectangle with a colour
    graphics.FillRectangle(Brushes.Red, new Rectangle(10, 20, 100, 50));

    // Set the font
    Font font = new Font("Consolas", 55, FontStyle.Italic);

    // Draw text
    graphics.DrawString("Hello, World!", font, Brushes.SkyBlue, new Point(20, 45));
}
```

# Formative Assessment

Before you start, create a new **Windows Forms Application** application called **08-formative-assessment**.

Learning to use AI tools is an important skill. While AI tools are powerful, you **must** be aware of the following:

- If you provide an AI tool with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust the AI tool's responses blindly. You **must** still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge what AI tool you have used. In the assessment's repository **README.md** file, please include what prompt(s) you provided to the AI tool and how you used the response(s) to help you with your work

## Task 1:

1. Start a new project.
2. Place three `PictureBox` controls on the form.
3. Place a `Button` directly above each `PictureBox`.

![](../resources/img/08/01-image.png)

4. Write a `button1_Click` handler so that, when the `button1` is clicked, the first image moves 10 pixels down the page:

```csharp
pictureBox1.Top += 10;
```

5. When you have checked that this code works, rewrite the code using constants and the += operator. More about constants here - <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants>.
6. Write a `button2_Click` handler so that, when the `button2` is clicked, the second image moves 10 pixels across the page.
7. Write a `button3_Click` handler so that, when the `button3` is clicked, a timer is enabled and the third image moves down and across the page, from top right corner to bottom left of the screen.
8. What other properties could you change?

## Task 2:

1. Create a new project.
2. On the form, draw a green cross, a red rectangle with a black border a yellow ellipse with a blue shadowing ellipse and the slogan "Hi there!" as shown below.

![](../resources/img/08/02-image.png)

## Task 3:

1. Create a new project.
2. Most of your work with `Graphics` will involve thinking about your forms as a grid of (x, y) coordinates. Here is the skeleton to build the grid shown below. Fill in the missing parts.

```csharp
private void Form1_MouseClick(object sender, MouseEventArgs e)
{
    Font font = new Font("Tahoma", 6, FontStyle.Regular);

    for (int x = 0; x < Width; x += 20)
    {
        // Write your code here
    }

    for (int y = 0; y < Height; y += 20)
    {
        // Write your code here
    }
}
```

When you run the program and click on the form, the following should appear.

![](../resources/img/08/03-image.png)

Note: You need to create the `Form1_MouseClick` event handler via the `Events` tab in the `Properties` window.

## Task 4:

1. What will be drawn when you run the code below? Notice that a curve is defined by an array of connected points.

```csharp
Pen pen = new Pen(Brushes.Black, 3.0F);
graphics.DrawCurve(pen, new Point[] { new Point(80, 60), new Point(200, 40), new Point(180, 60), new Point(300, 40) });
graphics.DrawCurve(pen, new Point[] { new Point(300, 180), new Point(180, 200), new Point(200, 180), new Point(80, 200) });
graphics.DrawLine(pen, new Point(300, 40), new Point(300, 180));
graphics.DrawLine(pen, new Point(80, 60), new Point(80, 200));
graphics.DrawEllipse(pen, 40, 40, 20, 20);
graphics.DrawRectangle(pen, 40, 60, 20, 300);
graphics.DrawLine(pen, new Point(60, 60), new Point(80, 60));
graphics.DrawLine(pen, new Point(60, 200), new Point(80, 200));
```

2. Draw the output on the grid.

![](../resources/img/08/04-image.png)

## Task 5:

1. What will be drawn when you run the code below? Notice that a polygon is defined by an array of connected lines.

```csharp
graphics.FillPolygon(Brushes.Black, new Point[] { new Point(60, 40), new Point(140, 80), new Point(200, 40), new Point(300, 80), new Point(380, 60), new Point(340, 140), new Point(320, 180), new Point(380, 240), new Point (320, 300), new Point(340, 340), new Point(240, 320), new Point(180, 340), new Point(20, 320), new Point(60, 280), new Point(100, 240), new Point(40, 220), new Point(80, 160) });

Font font = new Font("Times New Roman", 24, FontStyle.Italic);

graphics.DrawString("Pow!", font, Brushes.White, new Point(80, 80));
graphics.DrawString("Pow!", font, Brushes.White, new Point(120, 120));
graphics.DrawString("Pow!", font, Brushes.White, new Point(160, 160));
graphics.DrawString("Pow!", font, Brushes.White, new Point(200, 200));
graphics.DrawString("Pow!", font, Brushes.White, new Point(240, 240));
```

2. Draw the output on the grid.

3. Could you rewrite the DrawString statements with a variable and a loop?

![](../resources/img/08/05-image.png)

## Task 6:

1. Create a new project.
2. Write a `Timer1_tick` handler to draw three circles on the form. Use a different colour for each circle.
3. Place a `Timer` on the form. Modify your application so that, when the application starts, the figures are drawn automatically, and each 100 msec, the figures shift 20 pixels to the right. The example below shows the screen after several `Timer` cycles.

![](../resources/img/08/06-image.png)

4. Add a `CheckBox` control to your form. As the application runs, the user can turn the screen refresh feature on and off by checking and unchecking this `CheckBox`.

When the `CheckBox` is checked, the screen refreshes.

![](../resources/img/08/07-image.png)

When the `CheckBox` is unchecked, the screen does not refresh.

![](../resources/img/08/08-image.png)

5. Modify your application so that when the drawings reach the right edge of the screen, they "wrap around" and come back in from the left edge.

![](../resources/img/08/09-image.png)

## Task 7:
In this task, you will create a bouncing ball. Feel free to create a project. You will need to create a `Ball` class and a `Controller` class. 

The `Ball` class will need to have the following fields:
- A `private` `const` `int` field called `SIZE` that is set to `25`
- A `private` `Point` field called `speed`
- A `private` `Point` field called `position`
- A `private` `Color` field called `colour`
- A `private` `Graphics` field called `graphics`
- A `private` `Brush` field called `brush`
- A private `Size` field called `clientSize`

The `Ball` class will need to have a constructor that takes in a `Point` called `position`, a `Point` called `speed`, a `Color` called `colour`, a `Graphics` called `graphics`, and a `Size` called `clientSize`. Also, you will need to create a new `SolidBrush` object and assign it to the `brush` field. For example:

```cs
public Ball(Point speed, Point position, Color colour, Graphics graphics, Size clientSize)
{
    this.speed = speed;
    this.position = position;
    this.colour = colour;
    this.graphics = graphics;
    this.clientSize = clientSize;
    brush = new SolidBrush(colour);
}
```

The `Ball` class will have three other methods:
- A `public void` method called `Draw` that takes in no parameters. In the `Draw` method, you will need to call the `FillEllipse` method on the `graphics` field and pass in the `brush` object and a new `Rectangle` object that takes in the `position.X`, `position.Y`, `SIZE`, and `SIZE` fields.
- A `public void` method called `Move` that takes in no parameters. In the `Move` method, you will need to set the `position.X` property to the `position.X` property plus the `speed.X` property. You will also need to set the `position.Y` property to the `position.Y` property plus the `speed.Y` property.
- A `public void` method called `BounceSide` that takes in no parameters. In the `BounceSide` method, you will need to check if the `position.X` property is less than 0 or greater than the `clientSize.Width` property. If it is, you will need to set the `speed.X` property to the negative of the `speed.X` property. You will also need to do something similar for the `position.Y` property.

The `Controller` class will need to have the following field: a `private` `Ball` field called `ball`.

The `Controller` class will need to have a constructor that takes in a `Graphics` called `graphics`, and a `Size` called `clientSize`. In the constructor, you will need to create a new `Ball` object and assign it to the `ball` field. For example:

```cs
ball = new Ball(new Point(10, 10), new Point(100, 100), Color.Black, graphics, clientSize);
```

The `Controller` class will have one other methods:
- A `public void` method called `Run` that takes in no parameters. In the `Run` method, you will need to call the `Move`, `BounceSide` and `Draw` methods on the `ball` field. For example:

```cs
public void Run()
{
    ball.Move();
    ball.Draw();
    ball.BounceSide();
}
```

- In the `Form1` class:
  - Declare `Graphics graphics` and `Controller controller`
  - In the `Form1` constructor, initialise `graphics` and create a new instance of `Controller`, i.e., `controller = new Controller(graphics, ClientSize);`.
  - Call the `Controller's` `Run` method in the `timer1_Tick` method.	

## Task 8:

When you run the application, you will notice the ball is flickering. In this task, you will implement double buffering. 

What is double buffering? Double buffering is a technique that involves drawing to an off-screen buffer and then copying the off-screen buffer to the screen. This technique is used to prevent flickering.

In the `Form1` class, you will need to create two new fields: a `private` `Bitmap` field called `offScreenBitmap` and a `private` `Graphics` field called `offScreenGraphics`.

In the `Form1` constructor, replace the existing code with the following:

```cs	
public Form1()
{
    InitializeComponent();

    offScreenBitmap = new Bitmap(Width, Height); // An image used as a buffer for rendering
    offScreenGraphics = Graphics.FromImage(offScreenBitmap); // Enables you to draw on the offScreenBitmap
    graphics = CreateGraphics(); // Used to rendering the form
    controller = new Controller(offScreenGraphics, ClientSize);     
    timer1.Enabled = true;
}
```

In the `timer1_Tick` method, replace the existing code with the following:

```cs
private void timer1_Tick(object sender, EventArgs e)
{
    // Clears the buffer by filling the entire image with a black rectangle. This prevents the previous frame from being displayed
    offScreenGraphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
    controller.Run();
    graphics.DrawImage(offScreenBitmap, 0, 0); // Eliminates flickering and ensures the frame is displayed without partial updates
}
```

Buffer graphics refers to a technique where drawing operations are performed off-screen on a buffer, i.e., image before being displayed on the screen. This approach is often used to reduce flickering and improve rendering performance in graphical applications.

## Task 9:

In this exercise, when the user clicks on a button, a circle, square or triangle is drawn and its area is calculated. The choice of shape is randomly selected on each `button1_Click()` event.

![](../resources/img/09/image-01.png)

![](../resources/img/09/image-02.png)

![](../resources/img/09/image-03.png)

My UML class diagram is:

![](../resources/img/09/image-04.png)

1. Set up the `Form1` with a `Button` and a `Label`. 

2. Define a base class `Polygon`. Since we will never create an instance of this base class, we declare the class as `abstract`.

```cs
public abstract class Polygon
```

3. `Polygon`s should know their X and Y positions (these are the upper left corners of the square and circle’s bounding rectangle; they are the coordinates of the apex of the triangle, their size and their colour. They need a constructor so that polygon objects can be created. They should also have a `Draw()` method, and a `CalculateArea()` method. In this example, the `Draw()` and `CalculateArea()` methods will always be overridden by the subclasses of `Polygon`. We won’t ever use the base class version of `Draw()` or `CalculateArea()`, so these methods are declared as abstract. 

```cs
public abstract void Draw();
```

**Note:** If the methods could be used by the base class as well as the subclass, the keyword would be `virtual` rather than `abstract`. 

4. Descend three classes from `Polygon`: `Square`, `Circle` and `Triangle`. These descendants have no new fields, properties or methods, they simply declare their overrides of `Draw()` and `CalculateArea()`. For example:

```cs
public override void Draw()
```

5. Write the code for the base class and its subclasses. You can draw the `Triangle` using the `graphics` `DrawPolygon()` method, which accepts an array of `Points`, and "connects the dots". 
		
```cs
graphics.DrawPolygon(Pens.Black, new Point[] { position, new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
```

Similarly you can colour in the `Triangle` using the `graphics` `FillPolygon()` method, which accepts an array of `Points`, and "connects the dots". 

```cs
graphics.FillPolygon(brush, new Point[] { position, new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
```

6. Create a `Controller` class that has a field called polygon of type Polygon:

```cs
private Polygon polygon;
```

Note, you can declare a polygon of type `Polygon`, and then instantiate it as any of `Polygon's` subclasses by calling the correct constructor. 

You need to declare `private Graphics graphics` and `private Random random`. The `Controller` constructor should initialise these two fields.

Make a `CreatePolygon()` method that randomly creates either a `Square`, a `Triangle` or a `Circle`: 
    
```cs
public void CreatePolygon()
{
    int randomNumber = random.Next(3);
    switch (randomNumber)
    {
    case 0:
        polygon = new Circle(new SolidBrush(Color.Blue), graphics, new Point(200, 100), 150);
        break;
    case 1:
        polygon = new Square(new SolidBrush(Color.Red), graphics, new Point(200, 100), 150);
        break;
    case 2:
        polygon = new Triangle(new SolidBrush(Color.Yellow), graphics, new Point(275, 100), 150);
        break;
    default:
        polygon = null;
        break;
    }
} 
```

Write a method that tells the chosen polygon to draw itself on the form.

Write a method that tells the polygon to calculate its area and return this value to the form where it will be displayed in the label.

7.	Write a `button1_Click` handler for the button so that when it is clicked, it calls the `Controller's` `CreatePolygon()`, `DrawPolygon()`, `CalculatePolygonArea()` methods for the newly created polygon.  

# Summative Assessment

The following task are part of the **Classroom Tasks** assessment worth 10%. This part is worth 2%. **Note:** Partial marks **will not** be given for incomplete functionality.

## Task 1:

Once you have declared a class structure like `Polygon`, you can use it in any application where it might be needed. We will build a screen saver that fills the screen with a random assortment of squares, circles and triangles of different sizes and colours. This is my computer screen after the application has been running for about a minute:

To build this application:

![](../resources/img/09/image-05.png)

1. You need a `Timer` that, on each tick, generates some Polygons in assorted colours, sizes and locations. In my solution, in the `Controller`, I generate one `Circle`, one `Square` and one `Triangle` at each timer interval. To generate a nice variety of colours, remember that type `Color` is not restricted to values of `Color.Blue`, `Color.Red`, etc., but the red, green and blue elements can each be any integer between 0 and the number of colours your screen can display, usually 256. Create your `Polygons` with their `color` property set to 

```cs
Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
```

2.	When we create a large number of objects and draw them to the screen, we will be consuming a large amount of RAM. To conserve our resources, after we have drawn an object, we should then destroy it, by writing:

```cs
polygon = null;
```

3. You need to set the `Form` size equal to the screen size, by setting it’s `WindowState` to `Maximized` in the Properties window.

4. To make the `Form` invisible, so that the window behind shows through:

- Check that the `Opacity` is set to `100%`.
- Select a colour value for the `Form's` `TransparencyKey` from the drop down box. Choose any colour you like. This means that you will be nominating a colour such that any pixels in that colour will be invisible.
- Set the `Form's` `BackColor` property (still in the Properties window) to whatever you selected as the `TransparencyKey`. This will cause all the pixels of the `Form` to be invisible; only the window bar at the top of the `Form` will show.

5. Experiment with the parameters of your application until you get a performance you like. Then modify your `timer1_Tick()` handler so that after some number of ticks (enough to let the screen get pretty full), it clears the screen and starts again.

6. One of the advantages of the Object-Oriented approach is that the resulting code is easily extensible. Satisfy yourself of this by extending your screensaver to also draw hexagons and pentagons. 
Did you have to modify your `Timer` handler? If so, how might you have written it so that no modification would be required?

# Formative Assessment Submission

Push your code to your **GitHub** repository.
