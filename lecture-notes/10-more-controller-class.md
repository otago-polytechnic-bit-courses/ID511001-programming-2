# 10: More Controller Class

There is no new course materials.

# Formative Assessment

Before you start, create a new branch called **10-formative-assessment**.

If you get stuck on any of the following tasks, feel free to use **ChatGPT** permitting, you are aware of the following:

- If you provide **ChatGPT** with a prompt that is not refined enough, it may generate a not-so-useful response
- Do not trust **ChatGPT's** responses blindly. You must still use your judgement and may need to do additional research to determine if the response is correct
- Acknowledge that you are using **ChatGPT**. In the **README.md** file, please include what prompt(s) you provided to **ChatGPT** and how you used the response(s) to help you with your work

## Task 1:

In this exercise, when the user clicks on a button, a circle, square or triangle is drawn and its area is calculated. The choice of shape is randomly selected on each `button1_Click()` event.

![](../resources/img/10-more-controller-class/10-more-controller-class-1.png)

![](../resources/img/10-more-controller-class/10-more-controller-class-2.png)

![](../resources/img/10-more-controller-class/10-more-controller-class-3.png)

My UML class diagram is:

![](../resources/img/10-more-controller-class/10-more-controller-class-4.png)

1. Set up the `Form1` with a `Button` and a `Label`. 

2. Define a base class `Polygon`. Since we will never create an instance of this base class, we declare the class as `abstract`.

```cs
public abstract class Polygon
```

3. `Polygons` should know their X and Y positions (these are the upper left corners of the square and circle’s bounding rectangle; they are the coordinates of the apex of the triangle, their size and their colour. They need a constructor so that polygon objects can be created. They should also have a `Draw()` method, and a `CalculateArea()` method. In this example, the `Draw()` and `CalculateArea()` methods will always be overridden by the subclasses of `Polygon`. We won’t ever use the base class version of `Draw()` or `CalculateArea()`, so these methods are declared as abstract. 

```cs
public abstract void Draw();
```

Note: If the methods could be used by the base class as well as the subclass, the keyword would be `virtual` rather than `abstract`. 

4. Descend three classes from `Polygon`: `Square`, `Circle` and `Triangle`. These descendants have no new fields, properties or methods, they simply declare their overrides of `Draw()` and `CalculateArea()`. For example:

```cs
public override void Draw()
```

5. Write the code for the base class and its subclasses. You can draw the `Triangle` using the `graphics` `DrawPolygon()` method, which accepts an array of `Points`, and "connects the dots". 
		
```cs
graphics.DrawPolygon(pen, new Point[] { position, new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
```

Similarly you can colour in the `Triangle` using the `graphics` `FillPolygon()` method, which accepts an array of `Points`, and "connects the dots". 

```cs
graphics.FillPolygon(brush, new Point[] { position, new Point(position.X + size, position.Y + size), new Point(position.X - size, position.Y + size) });
```

6. Create a `Controller` class that has a field called polygon of type Polygon:

```cs
private Polygon? polygon;
```

Note, you can declare a polygon of type `Polygon`, and then instantiate it as any of `Polygon's` subclasses by calling the correct constructor. Make a `CreatePolygon()` method that randomly creates either a `Square`, a `Triangle` or a `Circle`: 
    
```cs
public void CreatePolygon()
{
    int randomNumber = random.Next(3);
    switch (randomNumber)
    {
    case 0:
        polygon = new Circle(new Point(200, 100), 150, Color.Blue, graphics);
        break;
    case 1:
        polygon = new Square(new Point(200, 100), 150, Color.Red, graphics);
        break;
    case 2:
        polygon = new Triangle(new Point(250, 100), 150, Color.Yellow, graphics);
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

## Task 2:

Once you have declared a class structure like `Polygon`, you can use it in any application where it might be needed. We will build a screen saver that fills the screen with a random assortment of squares, circles and triangles of different sizes and colours. This is my computer screen after the application has been running for about a minute:

To build this application:

![](../resources/img/10-more-controller-class/10-more-controller-class-5.png)

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
- Select a colour value for the Form’s TransparencyKey from the drop down box. Choose any colour you like. This means that you will be nominating a colour such that any pixels in that colour will be invisible.
- Set the `Form's` `BackColor` property (still in the Properties window) to whatever you selected as the `TransparencyKey`. This will cause all the pixels of the `Form` to be invisible; only the window bar at the top of the `Form` will show.

5. Experiment with the parameters of your application until you get a performance you like. Then modify your `timer1_Tick()` handler so that after some number of ticks (enough to let the screen get pretty full), it clears the screen and starts again.


6. One of the advantages of the Object-Oriented approach is that the resulting code is easily extensible. Satisfy yourself of this by extending your screensaver to also draw hexagons and pentagons. 
Did you have to modify your `Timer` handler? If so, how might you have written it so that no modification would be required?

# Formative and Research Assessment Submission

Create a new pull request and assign **grayson-orr** to review your submission. Please don't merge your own pull request.