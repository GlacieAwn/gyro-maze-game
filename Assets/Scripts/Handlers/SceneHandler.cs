using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private Scene previousScene;
    public Scene loadedScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Global.sceneHandler = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads a scene with the given name, and decides whether to destroy or hide the current scene depending on `free`.
    // If free is true, the scene is destroyed, only getting loaded again when called.
    // If false, the scene is merely hidden. Useful for menus where you might need to return to the previous scene.
    public void LoadScene(String path, bool free)
    {
        previousScene = SceneManager.GetActiveScene();
        if (free)
        {
            SceneManager.UnloadSceneAsync(previousScene);
        }
        else
        {
            SceneVisibilityManager.instance.Hide(previousScene);
        }

        SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive);
        loadedScene = SceneManager.GetSceneByName(path);

        SceneManager.SetActiveScene(loadedScene);
        previousScene = loadedScene;

    }
}
