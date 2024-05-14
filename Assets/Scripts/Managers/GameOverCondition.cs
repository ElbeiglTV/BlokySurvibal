using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCondition : MonoBehaviour
{
    public LifeManager playerLife;
    public SceneLoader sceneLoader;
    public UpgradeButons upgradeButons;
    // Start is called before the first frame update
    void Start()
    {
        playerLife.onKill += GameOver;
        upgradeButons.OnFinishUpgrade += Win;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        sceneLoader.LoadScene("LoseScene");
    }
    public void Win()
    {
        Debug.Log("You Win");
        sceneLoader.LoadScene("WinScene");
    }
    
    
}
