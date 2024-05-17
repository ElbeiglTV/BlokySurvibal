using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>:MonoBehaviour where T : MonoBehaviour
{
    Factory _factory;
    protected int _initialCount = 5;
    [SerializeField]
    List<T> _stock = new List<T>();

    public void Start()
    {
        _factory = new Factory();

        for (int i = 0; i < _initialCount; i++)
        {
            var obj = _factory.Create<T>();
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
            _stock.Add(obj);
        }
    }

    public T Get()
    {
        T obj = default;

        foreach (var item in _stock)
        {
            if (!item.gameObject.activeSelf)
            {
                Debug.Log("Reusing object");
                return item;
                
            }
        }
        obj = _factory.Create<T>();
        obj.transform.SetParent(transform);
        _stock.Add(obj);   
        return obj;
    }

}


