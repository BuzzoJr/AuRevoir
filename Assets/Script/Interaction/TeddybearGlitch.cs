using Assets.Script;
using Assets.Script.Interaction;
using Assets.Script.PostProcessing;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class TeddybearGlitch : MonoBehaviour, ICursorOverTrigger
{
    public PlayerData playerData;

    public float durationMin = 0.65f;
    public float durationIncrement = 0.1f;

    private Volume globalVolume;
    private PostProcessingHelper helper;

    private AudioSource audioSource;

    private SceneRef scene;
    private bool triggered = false;

    void Awake()
    {
        scene = (SceneRef)Enum.Parse(typeof(SceneRef), SceneManager.GetActiveScene().name);
        if (playerData.teddybearScenes.Contains(scene))
        {
            Destroy(gameObject);
            return;
        }

        helper = new PostProcessingHelper();

        // Find global volume
        foreach (Volume volume in FindObjectsOfType<Volume>())
        {
            if (volume.isGlobal)
            {
                globalVolume = volume;
                break;
            }
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void Trigger()
    {
        if (triggered)
            return;

        triggered = true;

        float duration = durationMin + playerData.teddybearScenes.Count * durationIncrement;
        playerData.AddTeddybear(scene);

        StartCoroutine(ExecuteGlitch(duration));
        StartCoroutine(ExecuteAudio(duration));
    }

    IEnumerator ExecuteGlitch(float duration)
    {
        if (globalVolume == null)
            yield break;

        // Effect start
        // EDITAR AQUI O QUE QUISER DE EFEITO!

        // Get desired components
        if (!globalVolume.profile.TryGet(out Bloom bloom))
            bloom = globalVolume.profile.Add<Bloom>();

        if (!globalVolume.profile.TryGet(out Vignette vignette))
            vignette = globalVolume.profile.Add<Vignette>();

        if (!globalVolume.profile.TryGet(out DigitalGlitchVolume digitalGlitch))
            digitalGlitch = globalVolume.profile.Add<DigitalGlitchVolume>();

        if (!globalVolume.profile.TryGet(out AnalogGlitchVolume analogGlitch))
            analogGlitch = globalVolume.profile.Add<AnalogGlitchVolume>();

        // Save state
        bool dga = digitalGlitch.active;
        float dgi = digitalGlitch.intensity.value;

        bool va = vignette.active;
        float vi = vignette.intensity.value;
        Color vc = vignette.color.value;

        bool ba = bloom.active;
        float bi = bloom.intensity.value;

        bool aa = analogGlitch.active;
        float slj = analogGlitch.scanLineJitter.value;
        float vj = analogGlitch.verticalJump.value;
        float hs = analogGlitch.horizontalShake.value;
        float cd = analogGlitch.colorDrift.value;

        // Parameters change
        vignette.intensity.value = 0f;
        vignette.color.value = new Color(0, 0, 0);
        vignette.active = true;
        digitalGlitch.active = true;
        analogGlitch.active = true;
        bloom.active = true;

        StartCoroutine(helper.Lerp(digitalGlitch, duration, "intensity", .4f));
        StartCoroutine(helper.Lerp(analogGlitch, duration, "scanLineJitter", .4f));
        StartCoroutine(helper.Lerp(analogGlitch, duration, "verticalJump", .4f));
        StartCoroutine(helper.Lerp(analogGlitch, duration, "horizontalShake", .4f));
        StartCoroutine(helper.Lerp(analogGlitch, duration, "colorDrift", .4f));

        StartCoroutine(helper.Lerp(bloom, duration, "intensity", 5f));
        yield return StartCoroutine(helper.Lerp(vignette, 0.3f, "intensity", .3f));
        duration -= 0.3f;

        yield return StartCoroutine(helper.Lerp(vignette, duration, "intensity", 0f));

        // Return original sate
        digitalGlitch.active = dga;
        digitalGlitch.intensity.value = dgi;

        vignette.active = va;
        vignette.intensity.value = vi;
        vignette.color.value = vc;

        bloom.active = ba;
        bloom.intensity.value = bi;

        analogGlitch.active = aa;
        analogGlitch.scanLineJitter.value = slj;
        analogGlitch.verticalJump.value = vj;
        analogGlitch.horizontalShake.value = hs;
        analogGlitch.colorDrift.value = cd;

        // Effect end

        Destroy(gameObject);
    }

    IEnumerator ExecuteAudio(float duration)
    {
        audioSource.time = 32f;
        audioSource.volume = 0f;
        audioSource.Play();

        // Fade-in
        yield return StartCoroutine(AudioVolumeFade(0f, 1f, 0.2f));
        duration -= 0.2f;

        // Hold
        yield return new WaitForSeconds(duration / 2f);
        duration /= 2f;

        // Fade-out
        yield return StartCoroutine(AudioVolumeFade(1f, 0f, duration));

        audioSource.Stop();
    }

    IEnumerator AudioVolumeFade(float from, float to, float duration)
    {
        float totalDuration = duration;

        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            if (duration <= 0f)
            {
                audioSource.volume = to;
                yield break;
            }

            audioSource.volume = Mathf.Lerp(to, from, duration / totalDuration);

            yield return null;
        }
    }
}