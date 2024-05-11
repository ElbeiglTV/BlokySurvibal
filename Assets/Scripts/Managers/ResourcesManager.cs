using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public TMP_Text WoodUi;
    public TMP_Text StoneUi;
    public TMP_Text GoldUi;
    public TMP_Text CurrencyUi;
    #region Singleton
    private static ResourcesManager _instance;
    public static ResourcesManager instance { get { return _instance; } private set { } }
    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }
    #endregion
    #region ResourcesInfo
    int _wood = default;
    int _stone = default;
    int _gold = default;
    int _currency = default;
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
    public int stone
    {
        get
        {
            return _stone;
        }
        set
        {
            if (_stone + value <= 0)
            {
                _stone = 0;
                if (StoneUi != null)
                {
                    StoneUi.text = _stone.ToString();
                }
            }
            else
            {
                _stone += value;
                if (StoneUi != null)
                {
                    StoneUi.text = _stone.ToString();
                }
            }
        }
    }
    public int gold
    {
        get
        {
            return _gold;
        }
        set
        {
            if (_gold + value <= 0)
            {
                _gold = 0;
                if (GoldUi != null)
                {
                    GoldUi.text = _gold.ToString();
                }
            }
            else
            {
                _gold += value;
                if (GoldUi != null)
                {
                    GoldUi.text = _gold.ToString();
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
            if (_currency + value <= 0)
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
