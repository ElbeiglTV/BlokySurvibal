using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Vector3 input;

    public abstract Vector3 GetMovementInput();


}
