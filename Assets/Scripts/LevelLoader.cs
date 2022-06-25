using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadPannel;
    public Slider slider;
    public void Loadlevel(int sceneIndex)
    {

        StartCoroutine(LoadAsynchonously(sceneIndex));
    }

     IEnumerator  LoadAsynchonously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadPannel.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ .9f );
            slider.value  = progress;
            yield return null;  
        }
    }
}
