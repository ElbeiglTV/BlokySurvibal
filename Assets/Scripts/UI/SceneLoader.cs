using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<GameObject> tutorialGameObjectsDeactivate;
    public List<GameObject> tutorialGameObjectsActivate;

    public void LoadScene(string sceneName)
    {
        if ((Statics.Stamina <= 2 && SceneManager.GetActiveScene().buildIndex == 0))
        {
            Debug.Log("Not enough stamina");
            return;
        }
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void LoadAndCheckFirsTimeScene(string sceneName)
    {
        if (Statics.FirstTime)
        {
            Statics.FirstTime = false;
            foreach (GameObject go in tutorialGameObjectsActivate)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in tutorialGameObjectsDeactivate)
            {
                go.SetActive(false);
            }
            SaveSystem.instance.Save();
        }
        else
        {
            
        LoadScene(sceneName);
        }
    }
    public void Reset()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
