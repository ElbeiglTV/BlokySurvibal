using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    #region Singleton
    private static ResourcesManager _instance;
    public static ResourcesManager instance { get { return _instance; } private set { } }
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }
    #endregion
    #region ResourcesInfo
    int _wood;
    int _currency;
    #endregion
    #region ResourcesGeter/Seters;
    public int wood
    {
        get
        {
            return _wood;
        }
        set
        {
            if (_wood + value <= 0)
            {
                _wood = 0;
            }
            else
            {
                _wood += value;
            }
            
        }
    }
    public int currency
    {
        get 
        {
            return _currency;
        }
        set
        {
            if(_currency+value <= 0)
            {
                _currency = 0;
            }
            //if (_currency + value >= maxValue)
            //{
               // _currency = maxValue;
            //}
        }
    }


    #endregion

}
