using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagetriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var lifeSystem = other.GetComponent<IDamageable>();
            lifeSystem.Damage(20);
        }
    }
}
