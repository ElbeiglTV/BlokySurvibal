using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Voxel
{
    public byte Id;
    public bool isSolid 
    {
        get
        {
            return Id != 0;
        }
    }
    public bool isTransparent;


}
