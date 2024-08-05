using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           ResourcesManager.instance.currency = 10;
            Destroy(gameObject);
        }
    }
}
