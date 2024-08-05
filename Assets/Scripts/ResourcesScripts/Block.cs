using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UserModel user;
        if (other.TryGetComponent(out user))
        {
           ResourcesManager.instance.currency = 10;
            Destroy(gameObject);
        }
    }
}
