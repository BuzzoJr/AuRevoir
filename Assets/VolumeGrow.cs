using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeGrow : MonoBehaviour
{
    public AudioSource audioSource;
    public float initialVolume = 0f; // X
    public float targetVolume = 1f;  // Y
    public float duration = 5f;      // Z

    private float currentTime = 0f;

    void Start()
    {
        // Set the initial volume of the AudioSource
        audioSource.volume = initialVolume;
        // Start the volume growing coroutine
        StartCoroutine(GrowVolume());
    }

    private IEnumerator GrowVolume()
    {
        while (currentTime < duration)
        {
            // Calculate the new volume based on the elapsed time
            audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, currentTime / duration);
            // Increment the elapsed time
            currentTime += Time.deltaTime;
            // Wait for the next frame
            yield return null;
        }
        // Ensure the target volume is set at the end
        audioSource.volume = targetVolume;
    }
}
