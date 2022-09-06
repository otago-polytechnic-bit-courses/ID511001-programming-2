# Unity

## Overview

## Project Creation

Open **Unity Hub**. You will be presented with the following:

<img src="../resources/13-unity-1/unity-1-project-creation.PNG" height="400" width="700"/>

Currently, you have no projects. To create a new project, click the **New project** button.

There are a variety of templates to choose from, i.e., 2D and 3D. Choose the **2D** template. In the **Project Settings**, you can set the project's name and location. Set the project's location to your **Class Tasks** repository path. Click the **Create project** button.

<img src="../resources/13-unity-1/unity-2-project-creation.PNG" height="400" width="700"/>

## Project Configuration

In might take about a minute or so to create a new project. Once the project is created, you will be presented with the following:

<img src="../resources/13-unity-1/unity-3-project-configuration.PNG" height="400" width="700"/>

At first, it might be overwhelming. Do not worry, you will become somewhat familiar with the environment as you progress through the lecture notes. 

In the **Hierarchy** window displays every **GameObject** in a **Scene**. For example, **Main Camera**. You can use the **Hierarchy** window to add, remove, sort and group **GameObjects** in a **Scene**.

**Resource:** <https://docs.unity3d.com/Manual/Hierarchy>

<img src="../resources/13-unity-1/unity-4-project-configuration.PNG" height="400" width="700"/>

In the **Assets** window, create three new folders - `Prefabs`, `Scripts` and `Sprites`. You will notice that each folder excluding `Scenes` are not solid grey. It indicates that these folders are empty.

<img src="../resources/13-unity-1/unity-5-project-configuration.PNG" height="400" width="700"/>

## Asset Creation

In the `lecture-notes` directory, you will find a directory called `13-unity-1`. This directory contains three assets - `background.png`, `obstacle.png` and `player.png`. Drag and drop these assets into the `Sprites` directory.

<img src="../resources/13-unity-1/unity-6-asset-creation.PNG" height="400" width="700"/>

## Player Controller

Drag and drop the `player` asset into the **Hierarchy** window. Rename the `player` asset (in the **Hierarchy** window) to `Player Sprite`. 

<img src="../resources/13-unity-1/unity-7-player-controller.PNG" height="400" width="700"/>

Create a new **GameObject** called `Player`. A **GameObject** is a base class for all entities, i.e., `Player Sprite` in a **Scene**. 

**Resource:** <https://docs.unity3d.com/ScriptReference/GameObject>

<img src="../resources/13-unity-1/unity-8-player-controller.PNG" height="400" width="700"/>

Drag and drop the `Player Sprite` into the `Player` **GameObject**. `Player Sprite` is a descendent or child of `Player` **GameObject**.

<img src="../resources/13-unity-1/unity-9-player-controller.PNG" height="400" width="700"/>

Click on the `Player` **GameObject**. In the **Inspector** window, click the **Add component** button. Search for **Rigidbody 2D** and press <kbd>Enter</kbd>. **Rigidbody 2D** places an object under the control of the physics engine, i.e., allow the `Player` **GameObject** to move. Set the **Scale X and Y** to 0.5, **Gravity scale** to zero (0) to ensure the `Player` **GameObject** stays in the air and **Constraints > Freeze Rotation** to checked to prevent the `Player` **GameObject** from rotating on the Z axis.

**Note:** a **GameObject** can only have one **Rigidbody 2D** component.

**Resources:** 

- <https://docs.unity3d.com/Manual/UsingTheInspector>
- <https://docs.unity3d.com/Manual/class-Rigidbody2D>

<img src="../resources/13-unity-1/unity-10-player-controller-2d-rigid-body.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-11-player-controller-cs-script.PNG" height="400" width="700"/>

Please read the comments in the code snippet below:

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ADD COMMENT
public class PlayerController : MonoBehaviour
{
    // ADD COMMENT
    public float speed;

    // ADD COMMENT
    private Rigidbody2D rb;

    // ADD COMMENT
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // ADD COMMENT
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ADD COMMENT
        float directionY = Input.GetAxisRaw("Vertical");

        // ADD COMMENT
        direction = new Vector2(0, directionY).normalized;
    }

    // ADD COMMENT
    void FixedUpdate()
    {
        // ADD COMMENT
        rb.velocity = new Vector2(0, direction.y * speed);
    }
}
```

<img src="../resources/13-unity-1/unity-11-player-controller-adding-cs-script.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-11-player-controller-testing.PNG" height="400" width="700"/>

## Camera Movement

## Game Loop

## Obstacles

## Box Colliders

## Destroying Obstacles

## Formative Assessment

## Additional Tasks

### Game Over

### Scoring System

### Background Sound
