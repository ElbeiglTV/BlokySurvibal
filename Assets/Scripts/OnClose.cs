using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClose : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnApplicationQuit()
    {
        SaveSystem.instance.Save();
    }
}
