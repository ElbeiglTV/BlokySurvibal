using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject UITimeUpdater;
    [SerializeField] private int daysToSurvive;
    public event Action Survive;


    
    void Update()
    {
        if (UITimeUpdater.GetComponent<UITimeUpdater>().DayTracker >= daysToSurvive) Survive?.Invoke();
        
    }
}
