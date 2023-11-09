using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class BossSpecial : MonoBehaviour, ISpecial
{
    [SerializeField] private DoorController door;
    [SerializeField] private GameObject rainObject;

    private ParticleSystem rain;
    private AudioSource rainSound;
    public float duration = 20f;
    private ParticleSystem.EmissionModule rainEmission; // To modify the emission rate
    public void Special(GameObject who)
    {
        rain = rainObject.GetComponent<ParticleSystem>();
        rainSound = rainObject.GetComponent<AudioSource>();
        if (rain != null)
        {
            rainEmission = rain.emission;
            rainEmission.rateOverTime = 0f; // Start with 0 emission rate
        }

        if (rainSound != null)
        {
            rainSound.volume = 0f; // Start with 0 volume
        }

        // Start the coroutine to change the rain intensity and sound volume
        StartCoroutine(ChangeRainIntensityAndSound());
        door.locked = false;
    }

    IEnumerator ChangeRainIntensityAndSound()
    {
        float currentTime = 0f;
        float startEmissionRate = 0f;
        float targetEmissionRate = 60f;
        float startVolume = 0f;
        float targetVolume = 0.55f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / duration;

            // Lerp the emission rate and volume based on the normalized time
            if (rain != null)
            {
                rainEmission.rateOverTime = Mathf.Lerp(startEmissionRate, targetEmissionRate, normalizedTime);
            }

            if (rainSound != null)
            {
                rainSound.volume = Mathf.Lerp(startVolume, targetVolume, normalizedTime);
            }

            yield return null;
        }

        // Ensure we set the final values after the loop
        if (rain != null)
        {
            rainEmission.rateOverTime = targetEmissionRate;
        }

        if (rainSound != null)
        {
            rainSound.volume = targetVolume;
        }
    }
}
