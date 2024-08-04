using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<GameObject> tutorialGameObjectsActivate;
    public GameObject warning;

    public void LoadScene(string sceneName)
    {
        if ((Statics.Stamina <= 2 && SceneManager.GetActiveScene().buildIndex == 0))
        {
            Debug.Log("Not enough stamina");
            warning.SetActive(true);
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
