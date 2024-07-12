using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class SyncWavePuzzle : MonoBehaviour
{

    public SyncController controller;
    public SyncWave syncEditLine;
    public SyncWave mainLine;
    public GameObject sucessoLabel, blockLabel;
    public TMP_Text valueFrq, valueAmp, valuePos;
    public Material finalLine;
    public AudioSource audiosourceFreq;
    public AudioSource audiosourceAmp;
    public AudioSource audiosourcePos;
    public float sensibilityFreq = 0.2f;
    public float sensibilityAmp = 0.015f;
    public float sensibilityPos = 0.013f;

    public RadialSlider sliderFreq;
    public RadialSlider sliderAmp;
    public RadialSlider sliderPos;

    private bool finish = false;

    private void Update()
    {
        float normalizedFreq = NormalizeToRange(sliderFreq.fillAmount, 0f, 1f, 0f, 100f);
        syncEditLine.frequency = NormalizeToRange(sliderFreq.fillAmount, 0f, 1f, 1f, 5f);
        valueFrq.text = normalizedFreq.ToString("F2");
        audiosourceFreq.pitch = normalizedFreq / 100 + 0.5f;
        //50

        float normalizedAmp = NormalizeToRange(sliderAmp.fillAmount, 0f, 1f, 0f, 100f);
        syncEditLine.amplitude = NormalizeToRange(sliderAmp.fillAmount, 0f, 1f, 0.1f, 0.35f);
        valueAmp.text = normalizedAmp.ToString("F2");
        audiosourceAmp.pitch = (normalizedAmp - 10) / 100 + 0.5f;
        //60

        float normalizedPos = NormalizeToRange(sliderPos.fillAmount, 0f, 1f, 0f, 100f);
        syncEditLine.position = NormalizeToRange(sliderPos.fillAmount, 0f, 1f, 0f, 0.3f);
        valuePos.text = normalizedPos.ToString("F2");
        audiosourcePos.pitch = normalizedPos / 100 + 0.5f;
        //50

        if (Mathf.Abs(syncEditLine.frequency - mainLine.frequency) < sensibilityFreq &&
            Mathf.Abs(syncEditLine.amplitude - mainLine.amplitude) < sensibilityAmp &&
            Mathf.Abs(syncEditLine.position - mainLine.position) < sensibilityPos)
        {
            finish = true;
            sliderFreq.finish = true;
            sliderAmp.finish = true;
            sliderPos.finish = true;
            //Acertou a resposta
            syncEditLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
            mainLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
            blockLabel.SetActive(true);
            sucessoLabel.SetActive(true);
            StartCoroutine(TransitionToMainLineValues());
        }
    }

    private IEnumerator TransitionToMainLineValues()
    {
        float timer = 0f;
        float initialFreq = syncEditLine.frequency;
        float initialAmp = syncEditLine.amplitude;
        float initialPos = syncEditLine.position;

        while (timer < 3f)
        {
            timer += Time.deltaTime;

            float t = timer / 3f;

            syncEditLine.frequency = Mathf.Lerp(initialFreq, mainLine.frequency, t);
            syncEditLine.amplitude = Mathf.Lerp(initialAmp, mainLine.amplitude, t);
            syncEditLine.position = Mathf.Lerp(initialPos, mainLine.position, t);

            audiosourcePos.volume = Mathf.Lerp(0.3f, 0f, t);
            audiosourceAmp.volume = Mathf.Lerp(1, 0f, t);
            audiosourceFreq.volume = Mathf.Lerp(0.35f, 0f, t);

            yield return null;
        }

        syncEditLine.frequency = mainLine.frequency;
        syncEditLine.amplitude = mainLine.amplitude;
        syncEditLine.position = mainLine.position;

        controller.EndSync();
    }

    private float NormalizeToRange(float value, float min, float max, float newMin, float newMax)
    {
        return (value - min) / (max - min) * (newMax - newMin) + newMin;
    }
}
