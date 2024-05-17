using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>:MonoBehaviour where T : MonoBehaviour
{
    Factory factory;
    protected int initialCount = 5;
    [SerializeField]
    List<T> _stock = new List<T>();

    public void Start()
    {
        factory = new Factory();

        for (int i = 0; i < initialCount; i++)
        {
            var obj = factory.Create<T>();
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
        obj = factory.Create<T>();
        obj.transform.SetParent(transform);
        _stock.Add(obj);   
        return obj;
    }

}


