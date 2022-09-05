# Unity

## Overview

## Project Creation

<img src="../resources/13-unity-1/unity-1-project-creation.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-2-project-creation.PNG" height="400" width="700"/>

## Project Configuration

<img src="../resources/13-unity-1/unity-3-project-configuration.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-4-project-configuration.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-5-project-configuration.PNG" height="400" width="700"/>

## Asset Creation

<img src="../resources/13-unity-1/unity-6-asset-creation.PNG" height="400" width="700"/>

## Player Controller

<img src="../resources/13-unity-1/unity-7-player-controller.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-8-player-controller.PNG" height="400" width="700"/>

<img src="../resources/13-unity-1/unity-9-player-controller.PNG" height="400" width="700"/>

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
