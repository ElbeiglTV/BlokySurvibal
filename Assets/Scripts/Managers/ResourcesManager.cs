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
 
    #region ResourcesGeter/Seters;
    public int wood
    {
        set
        {
            if (Statics.wood + value <= 0)
            {
                Statics.wood = 0;
                if (WoodUi != null)
                {
                    WoodUi.text = Statics.wood.ToString();
                }
            }
            else
            {
                Statics.wood += value;
                if (WoodUi != null)
                {
                    WoodUi.text = Statics.wood.ToString();
                }
            }

        }
    }
    public int stone
    {
        set
        {
            if (Statics.stone + value <= 0)
            {
                Statics.stone = 0;
                if (StoneUi != null)
                {
                    StoneUi.text = Statics.stone.ToString();
                }
            }
            else
            {
                Statics.stone += value;
                if (StoneUi != null)
                {
                    StoneUi.text = Statics.stone.ToString();
                }
            }
        }
    }
    public int gold
    {
       
        set
        {
            if (Statics.gold + value <= 0)
            {
                Statics.gold = 0;
                if (GoldUi != null)
                {
                    GoldUi.text = Statics.gold.ToString();
                }
            }
            else
            {
                Statics.gold += value;
                if (GoldUi != null)
                {
                    GoldUi.text = Statics.gold.ToString();
                }
            }
        }
    }
    public int currency
    {
       
        set
        {
            if (Statics.currency + value <= 0)
            {
                Statics.currency = 0;
            }
            //if (_currency + value >= maxValue)
            //{
            // _currency = maxValue;
            //}
        }
    }
    #endregion
}
