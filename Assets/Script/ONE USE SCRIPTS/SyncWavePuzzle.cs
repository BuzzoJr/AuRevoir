using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using DG.Tweening;

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
            AjusteAllLine();
        }
    }

    public void AjusteAllLine() {
        float duration = 3f;

        DOTween.To(() => syncEditLine.frequency, x => syncEditLine.frequency = x, mainLine.frequency, duration)
        .SetEase(Ease.Linear);

        DOTween.To(() => syncEditLine.amplitude, x => syncEditLine.amplitude = x, mainLine.amplitude, duration)
            .SetEase(Ease.Linear);

        DOTween.To(() => syncEditLine.position, x => syncEditLine.position = x, mainLine.position, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() => controller.EndSync());
    }

    private float NormalizeToRange(float value, float min, float max, float newMin, float newMax)
    {
        return (value - min) / (max - min) * (newMax - newMin) + newMin;
    }
}
