using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private Scene previousScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        StartCoroutine(LoadSceneRoutine(path, free));
    }

    private IEnumerator LoadSceneRoutine(string path, bool free)
    {
        if (previousScene.IsValid())
        {
            yield return SceneManager.UnloadSceneAsync(previousScene);
        }
        else
        {
            // Deactivate all root objects to hide the scene
            foreach (GameObject obj in previousScene.GetRootGameObjects())
            {
                obj.SetActive(false);
            }
        }

        // Load the new scene asynchronously
        yield return SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive);
        Scene loadedScene = SceneManager.GetSceneByName(path);

        // Set the new scene as active
        SceneManager.SetActiveScene(loadedScene);

        previousScene = loadedScene;
    }
}
