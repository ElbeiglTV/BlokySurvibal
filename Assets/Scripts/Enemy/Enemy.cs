using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class Enemy : Resource, IreColectable
{
    public TMP_Text num;
    public GameObject Particle;
    public GameObject Select;
    private int _orginalLife;
    private ResourceController _resourceController;

    private void Awake()
    {
        _orginalLife = life;
        _resourceController = Resources.Load<ResourceController>("ResourceManager");
    }
    private void OnEnable()
    {
        life = _orginalLife;
    }
    public bool ActiveSelf()
    {
        return gameObject.activeSelf;
    }

    public void Colect(int Damage)
    {
        life -= Damage;
        if (life <= 0)
        {
            value = Random.Range(_resourceController.goldRandomRangeMinAmount, _resourceController.goldRandomRangeMaxAmount + 1);
            ResourcesManager.instance.gold = value;
            num.text = "+" + value.ToString();
            Particle.SetActive(false);
            Particle.SetActive(true);
            gameObject.SetActive(false);
            SaveSystem.instance.Save();
        }
    }

    public void TogleSelect(bool mbool)
    {
        Select.SetActive(mbool);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
