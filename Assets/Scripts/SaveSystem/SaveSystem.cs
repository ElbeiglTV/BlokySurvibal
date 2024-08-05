using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Load();
    }

    public StaticsData staticsData = new StaticsData(false);

    public void Save()
    {
        staticsData = new StaticsData(true);
        string JsonData = JsonUtility.ToJson(staticsData);
        PlayerPrefs.SetString("StaticsData", JsonData);
    }
    public void Load()
    {
        staticsData = new StaticsData(false);
        if(!PlayerPrefs.HasKey("StaticsData")) return;
        string JsonData = PlayerPrefs.GetString("StaticsData");
        staticsData =  JsonUtility.FromJson<StaticsData>(JsonData);
        staticsData.ActualizeStatics();
    }
    [ContextMenu("ResetData")]
    public void ResetData()
    {
        staticsData = new StaticsData(false);
        PlayerPrefs.DeleteKey("StaticsData");
        PlayerPrefs.DeleteAll();
        staticsData.ActualizeStatics();
        Statics.Reset();
    }
}
