using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : Controller
{
    public override Vector3 GetMovementInput()
    {
        return input;
    }
}
