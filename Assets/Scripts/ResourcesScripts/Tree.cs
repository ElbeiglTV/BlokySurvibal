using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class Tree : Resource, IreColectable
{
    public TMP_Text num;
    public GameObject Particle;
    public GameObject Select;
    private int _orginalLife;

    private void Awake()
    {
        _orginalLife = life;
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
        if(life<= 0)
        {
            ResourcesManager.instance.wood = value;
            num.text = "+"+value.ToString();
            Particle.SetActive(false);
            Particle.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void TogleSelect(bool mbool)
    {
        Select.SetActive(mbool);
    }
}
