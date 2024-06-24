using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Statics.ResetBasicResources();
        sceneLoader.LoadScene("LoseScene");
    }
    public void Win()
    {

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("Level1",1);
        }
        else
        {
            PlayerPrefs.SetInt("Level2", 1);
        }
        Debug.Log("You Win");
        Statics.ResetBasicResources();
        sceneLoader.LoadScene("WinScene");
    }
    
    
}
