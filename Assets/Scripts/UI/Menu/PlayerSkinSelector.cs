using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSkinSelector : MonoBehaviour
{
    [SerializeField] GameObject _blocked, _bonusAttackStat, _bonusMiningStat;
    [SerializeField] TextMeshProUGUI _fragments;
    [SerializeField] Button _equipButton;
    [SerializeField] Color _blockedColor, _activeColor, _equipableColor;
    [SerializeField] Animator _skinViewerAnimator;
    public bool equiped, unlocked;
    private int _skinID = default;

    void Update()
    {
        switch (_skinID)
        {
            case 0:
                //Standard
                _skinViewerAnimator.SetBool("StandardActive", true);
                _skinViewerAnimator.SetBool("ArcherActive", false);
                _skinViewerAnimator.SetBool("WorkerActive", false);
                _bonusAttackStat.SetActive(false);
                _bonusMiningStat.SetActive(false);
                unlocked = true;
                equiped = true;
                break;
            case 1:
                //Archer
                _skinViewerAnimator.SetBool("StandardActive", false);
                _skinViewerAnimator.SetBool("ArcherActive", true);
                _skinViewerAnimator.SetBool("WorkerActive", false);
                _bonusAttackStat.SetActive(true);
                _bonusMiningStat.SetActive(false);
                unlocked = false;
                equiped = false;
                break;
            case 2:
                //Worker
                _skinViewerAnimator.SetBool("StandardActive", false);
                _skinViewerAnimator.SetBool("ArcherActive", false);
                _skinViewerAnimator.SetBool("WorkerActive", true);
                _bonusAttackStat.SetActive(false);
                _bonusMiningStat.SetActive(true);
                unlocked = false;
                equiped = false;
                break;
        }
        SkinUnlocked();
    }

    public void ChangeSkin(int ID)
    {
        _skinID += ID;
        if (_skinID > 2) { _skinID = 0; }
        else if (_skinID < 0) { _skinID = 2; }
    }

    public void SkinUnlocked()
    {
        if (!unlocked)
        {
            _blocked.SetActive(true);
            _equipButton.GetComponent<Image>().color = _blockedColor;
            _equipButton.interactable = false;
        }
        else if (unlocked && !equiped)
        {
            _blocked.SetActive(false);
            _equipButton.GetComponent<Image>().color = _activeColor;
            _equipButton.interactable = true;
        }
        else if (unlocked && equiped)
        {
            _blocked.SetActive(false);
            _equipButton.GetComponent<Image>().color = _equipableColor;
            _equipButton.interactable = true;
        }
    }
}
