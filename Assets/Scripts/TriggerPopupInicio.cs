using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopupInicio : MonoBehaviour
{
    [SerializeField] private GameObject _triggerPopupInicio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<UserModel>()) 
        { 
            _triggerPopupInicio.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UserModel>())
        {
            _triggerPopupInicio.SetActive(false);
        }
    }
}
