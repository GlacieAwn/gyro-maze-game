using System;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// [RequireComponent(typeof(musicSource))]
public class AudioHandler : MonoBehaviour
{
    [Tooltip("Loop point in seconds")]
    [SerializeField] private float loopStart = 0f;
    [SerializeField] private int currentPosition;

    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip sfxClip;
    
    private int loopStartSamples;
    private int clipLength;

    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicClip;
        
        
    }
    private void Start()
    {
        loopStartSamples = Mathf.FloorToInt(loopStart * musicSource.clip.frequency);

        // subtract the amount of samples in the clip by the frequency divided by framerate. This calculates how many samples were passed in a given frame, to avoid the loop check to pass the clip length before the next frame.
        clipLength = musicSource.clip.samples - Mathf.CeilToInt(musicSource.clip.frequency / Application.targetFrameRate);

    }

    private void Update()
    {

        currentPosition = musicSource.timeSamples; // for debug purposes
        if (musicSource == null)
        {
            Debug.LogError("Error! musicSource not found");
            return;
        }
        else if (musicClip == null)
        {
            Debug.LogError("Error! Clip not assigned to AudioSource Component. Audio will not play.");
        }
        else if (musicSource.timeSamples >= clipLength) 
        { 
            musicSource.timeSamples = loopStartSamples;
        }
    }

    private void PlayMusic(String path, float loopPoint)
    {
        musicSource.loop = false; // this needs to be here to override the default, otherwise unity will loop from the start regardless

        musicClip = Resources.Load<AudioClip>(path);
        loopStart = loopPoint;
        musicSource.Play();
    }

    private void PlaySFX(string path)
    {
        // TODO: SFX Handling
    }
}
