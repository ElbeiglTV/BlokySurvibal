using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YunqueUpgradeTriguer : MonoBehaviour
{
    public GameObject UpgradeCamvas;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()._inputCheck = 0;
            UpgradeCamvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpgradeCamvas.SetActive(false);
        }
    }
}
