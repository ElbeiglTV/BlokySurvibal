using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Statics
{
    public static int wood = default;
    public static int stone = default;
    public static int gold = default;
    public static int currency = default;

    public static void Reset()
    {
        wood = 0;
        stone = 0;
        gold = 0;
        currency = 0;
    }
}
