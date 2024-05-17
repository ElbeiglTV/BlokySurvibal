using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : ObjectPool<Arrow>
{
  public static ArrowPool Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
