using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public TMP_Text WoodUi;
    #region Singleton
    private static ResourcesManager _instance;
    public static ResourcesManager instance { get { return _instance; } private set { } }
    private void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(gameObject);
    }
    #endregion
    #region ResourcesInfo
    int _wood=default;
    int _currency=default;
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
                if (WoodUi != null)
                {
                    WoodUi.text = _wood.ToString();
                }
            }
            else
            {
                _wood += value;
                if (WoodUi != null)
                {
                    WoodUi.text = _wood.ToString();
                }
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
