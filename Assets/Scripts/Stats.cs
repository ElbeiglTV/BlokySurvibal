using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
   public Stadistics stats;
}

[System.Serializable]
public class Stadistics
{
    [SerializeField] int life = 100;
    [SerializeField] int amor = 100;
    [SerializeField] int damage = 20;
}