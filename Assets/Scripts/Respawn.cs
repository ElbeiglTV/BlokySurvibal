using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.transform.position = respawnPoint.position;
        }
    }
}
