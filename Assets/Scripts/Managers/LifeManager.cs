using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour,IDamageable
{
    float _life;
    public float maxLife;

    public delegate void Kill();
    public event Kill onKill;

    public void Damage(float damage)
    {
        _life -= damage;
        if (_life <= 0)
            onKill?.Invoke();
        gameObject.SetActive(false);
    }
}
