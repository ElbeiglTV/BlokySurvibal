using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour,IDamageable
{
    float _life;
    public float myLife;

    public delegate void Kill();
    public event Kill onKill;

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        myLife = Statics.playerMaxHealth;
        Debug.Log(Statics.playerMaxHealth);
    }

    public void Damage(float damage)
    {
        myLife -= damage;
        if (myLife <= 0)
        {
            onKill?.Invoke();
            gameObject.SetActive(false);
        }
           
    }
}
