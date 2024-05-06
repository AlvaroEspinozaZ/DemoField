using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "SceneManagementController", menuName = "ScriptableObject/SceneManagementController/Manager")]
public class SceneManagementController : ScriptableObject
{
    public int EscenaCarga=0;
    public bool SeCargo=false;
    private void OnEnable()
    {
        //Esta solo sirve para cuando se cargar escena y bota el modo de carga, no se para q usarlo
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Esta solo me dice si una escena se quita
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        //////////////////////////////////////////////////////////////////////
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SeCargo = true;
        LoadScene(EscenaCarga);
        if (SeCargo)
        {
            Debug.Log("Se cargó una nueva escena.");
            Debug.Log("Nombre de la escena: " + scene.name);
            Debug.Log("Modo de carga: " + mode);

            UnloadScene(EscenaCarga);
            SeCargo = false;
        }

    }
    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("Se descargó una escena.");
        Debug.Log("Nombre de la escena: " + scene.name);
    }
    public void LoadScene(int SeceneNext)
    {
        SceneManager.LoadSceneAsync(SeceneNext, LoadSceneMode.Additive);
    }
    public void LoadScene(string SeceneInitName)
    {
        SceneManager.LoadSceneAsync(SeceneInitName, LoadSceneMode.Additive);
    }
    public void UnloadScene(int SeceneInit)
    {
        SceneManager.UnloadSceneAsync(SeceneInit);
    }
    public void UnloadScene(string SeceneInitName)
    {
        SceneManager.UnloadSceneAsync(SeceneInitName);
    }
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);

    }
    private void OnDisable()
    {
        //Esta solo sirve para cuando se cargar escena y bota el modo de carga, no se para q usarlo
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //Esta solo me dice si una escena se quita
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
