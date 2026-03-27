using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        // for Testing purposes
        // AudioHandler.PlayMusic("Audio/gameplay.ogg", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
