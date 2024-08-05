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
    [SerializeField] List<Material> _standardMats, _archerMats, _workerMats;
    private List<Material> currentMat;
    public bool equiped, unlocked;
    private int _skinID = default;

    void Update()
    {
        if (Statics.currentSkin == Skin.Standard) { currentMat = _standardMats; }
        else if (Statics.currentSkin == Skin.Archer) { currentMat = _archerMats; }
        else if (Statics.currentSkin == Skin.Worker) { currentMat = _workerMats; }

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
                var mats = _standardMats;
                if (currentMat[0] == mats[0]) { equiped = true; }
                else { equiped = false; }
                break;
            case 1:
                //Archer
                _skinViewerAnimator.SetBool("StandardActive", false);
                _skinViewerAnimator.SetBool("ArcherActive", true);
                _skinViewerAnimator.SetBool("WorkerActive", false);
                _bonusAttackStat.SetActive(true);
                _bonusMiningStat.SetActive(false);
                if (Statics.GachaInventory.ContainsKey(2)) 
                { 
                    if (Statics.GachaInventory.Get(2) >= 20) { unlocked = true; _blocked.SetActive(false); }
                    else { unlocked = false; _fragments.text = $"{Statics.GachaInventory.Get(2)}/20"; }
                }
                else { unlocked = false; _fragments.text = "0/20"; }
                var mats2 = _archerMats;
                if (currentMat[0] == mats2[0]) { equiped = true; }
                else { equiped = false; }
                break;
            case 2:
                //Worker
                _skinViewerAnimator.SetBool("StandardActive", false);
                _skinViewerAnimator.SetBool("ArcherActive", false);
                _skinViewerAnimator.SetBool("WorkerActive", true);
                _bonusAttackStat.SetActive(false);
                _bonusMiningStat.SetActive(true);
                if (Statics.GachaInventory.ContainsKey(1))
                {
                    if (Statics.GachaInventory.Get(1) >= 10) { unlocked = true; _blocked.SetActive(false); }
                    else { unlocked = false; _fragments.text = $"{Statics.GachaInventory.Get(1)}/10"; }
                }
                else { unlocked = false; _fragments.text = "0/10"; }
                var mats3 = _workerMats;
                if (currentMat[0] == mats3[0]) { equiped = true; }
                else { equiped = false; }
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
            _equipButton.GetComponent<Image>().color = _equipableColor;
            _equipButton.interactable = true;
        }
        else if (unlocked && equiped)
        {
            _blocked.SetActive(false);
            _equipButton.GetComponent<Image>().color = _activeColor;
            _equipButton.interactable = true;
        }
    }

    public void EquipSkin() 
    {
        equiped = true;
        switch (_skinID)
        {
            case 0:
                Statics.currentSkin = Skin.Standard;
                break;
            case 1:
                Statics.currentSkin = Skin.Archer;
                break;
            case 2:
                Statics.currentSkin = Skin.Worker;
                break;
        }
    }
}

public enum Skin
{
    Standard,
    Archer,
    Worker
}