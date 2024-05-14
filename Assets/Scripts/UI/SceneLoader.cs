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
            
        SceneManager.LoadSceneAsync(sceneName);
        }
    }
    public void Reset()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
