using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSkin : MonoBehaviour
{
    public List<Material> standardMats, archerMats, workerMats;
    public SkinnedMeshRenderer Head, Body, Hands, Legs;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (Statics.currentSkin)
        {
            case Skin.Standard:
                //Standard
                Head.material = standardMats[0];
                Body.material = standardMats[3];
                Hands.material = standardMats[1];
                Legs.material = standardMats[2];
                break;
            case Skin.Archer:
                //Archer
                Head.material = archerMats[0];
                Body.material = archerMats[3];
                Hands.material = archerMats[1];
                Legs.material = archerMats[2];
                break;
            case Skin.Worker:
                //Worker
                Head.material = workerMats[0];
                Body.material = workerMats[3];
                Hands.material = workerMats[1];
                Legs.material = workerMats[2];
                break;
        }
    }

    private void Start()
    {
        switch (Statics.currentSkin)
        {
            case Skin.Standard:
                //Standard
                Head.material = standardMats[0];
                Body.material = standardMats[3];
                Hands.material = standardMats[1];
                Legs.material = standardMats[2];
                break;
            case Skin.Archer:
                //Archer
                Head.material = archerMats[0];
                Body.material = archerMats[3];
                Hands.material = archerMats[1];
                Legs.material = archerMats[2];
                break;
            case Skin.Worker:
                //Worker
                Head.material = workerMats[0];
                Body.material = workerMats[3];
                Hands.material = workerMats[1];
                Legs.material = workerMats[2];
                break;
        }
    }
}
