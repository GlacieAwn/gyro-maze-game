using Mono.Cecil.Cil;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    [Tooltip("Loop point in seconds")]
    [SerializeField] private float loopStart = 0f;
    [SerializeField] private int currentPosition;

    private int loopStartSamples;
    private int clipLength;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = false; // this needs to be here to override the default, otherwise unity will loop from the start regardless
    }
    private void Start()
    {
        loopStartSamples = Mathf.FloorToInt(loopStart * audioSource.clip.frequency);

        // subtract the amount of samples in the clip by the frequency divided by framerate. This calculates how many samples were passed in a given frame, to avoid the loop check to pass the clip length before the next frame.
        clipLength = audioSource.clip.samples - Mathf.CeilToInt(audioSource.clip.frequency / Application.targetFrameRate);
    }

    private void Update()
    {

        currentPosition = audioSource.timeSamples; // for debug purposes
        
        if (audioSource.timeSamples >= clipLength) 
        { 
            audioSource.timeSamples = loopStartSamples;
        }
    }
}
