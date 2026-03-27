using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // test
    public bool free;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        // for Testing purposes
        // AudioHandler.PlayMusic("Audio/gameplay.ogg", 20f);
        Global.sceneHandler.LoadScene("TestScene1", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
