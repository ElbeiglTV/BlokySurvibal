using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour,IDamageable
{
    float _life;
    public float maxLife;

    public delegate void Kill();
    public event Kill onKill;

    private void Start()
    {
        //_life = maxLife;
    }

    public void Damage(float damage)
    {
        maxLife -= damage;
        if (maxLife <= 0)
        {
            onKill?.Invoke();
            gameObject.SetActive(false);
        }
           
    }
}
