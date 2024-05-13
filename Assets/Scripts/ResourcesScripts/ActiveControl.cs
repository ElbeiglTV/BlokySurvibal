using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveControl : MonoBehaviour
{
    public GameObject ObjectToRespawn;
    private bool _OneTimer;
    [SerializeField] int _RespawnCooldownTimer;

    void Update()
    {
        if (!ObjectToRespawn.activeSelf && !_OneTimer)
        {
            _OneTimer = true;
            StartCoroutine("RespawnCooldown");
        }
    }

    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(_RespawnCooldownTimer);
        ObjectToRespawn.SetActive(true);
        _OneTimer = false;
    }
}
