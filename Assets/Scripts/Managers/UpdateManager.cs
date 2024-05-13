using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private static UpdateManager _instance;
    public static UpdateManager instance
    {
        get { return _instance; }
        private set { }
    }

    public static event Action OnUpdate;
    public static event Action OnFixedUpdate;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        OnUpdate?.Invoke();
    }
    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}
