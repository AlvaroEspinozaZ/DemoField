using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CargaTest : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject asd;
    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            asd.SetActive(false);
            yield return null;
        }
        asd.SetActive(false);
    }
}
