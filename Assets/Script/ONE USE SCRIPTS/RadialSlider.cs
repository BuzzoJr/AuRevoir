using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class RadialSlider : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Image fillImage, copyFillImage;
    public RectTransform handle;
    public float fillAmount = 0;
    public float maxValue = 360f;
    public float radius = 100f;
    private float currentValue = 0f;
    private bool isDragging = false;
    private float angle = 0;

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
    public string typeValue;

    private void Start()
    {
        UpdateHandleAndFill();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(handle, eventData.position, eventData.pressEventCamera))
            {
                UpdateSlider(eventData);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(handle, eventData.position, eventData.pressEventCamera))
        {
            isDragging = true;
            UpdateSlider(eventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDragging = false;
    }

    private void UpdateSlider(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - (Vector2)fillImage.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;

        currentValue = Mathf.Clamp(0, (- angle), maxValue);
        if(-angle > 180 || -angle < 0)
        {
            return;
        }

        UpdateHandleAndFill();
    }

    private void UpdateHandleAndFill()
    {

        float fillAmount = currentValue / 180;
        fillImage.fillAmount = fillAmount;

        if(copyFillImage != null)
            copyFillImage.fillAmount = fillAmount;

        float angleInRadians = (angle - 180) * Mathf.Deg2Rad; 
        float x = Mathf.Cos(angleInRadians) * radius;
        float y = Mathf.Sin(angleInRadians) * radius;
        handle.localPosition = new Vector3(x, y, 0);

        float normalizedValue = NormalizeToRange(fillAmount, 0f, 1f, 0f, 100f);

        //IMPEDIR DE MEXER SLIDER APOS CONCLUSAO DO MINIGAME

        if(typeValue == "Freq") {
            syncEditLine.frequency = NormalizeToRange(fillAmount, 0f, 1f, 1f, 5f);
            valueFrq.text = normalizedValue.ToString("F2");
            audiosourceFreq.pitch = normalizedValue / 100 + 0.5f;
        }
        else if(typeValue == "Amp") {
            syncEditLine.amplitude = NormalizeToRange(fillAmount, 0f, 1f, 0.1f, 0.35f);
            valueAmp.text = normalizedValue.ToString("F2");
            audiosourceAmp.pitch = normalizedValue / 100 + 0.5f;
        }
        else if(typeValue == "Pos") {
            syncEditLine.position = NormalizeToRange(fillAmount, 0f, 1f, 0f, 0.3f);
            valuePos.text = normalizedValue.ToString("F2");
            audiosourcePos.pitch = normalizedValue / 100 + 0.5f;
        }

        if (Mathf.Abs(syncEditLine.frequency - mainLine.frequency) < sensibilityFreq &&
            Mathf.Abs(syncEditLine.amplitude - mainLine.amplitude) < sensibilityAmp &&
            Mathf.Abs(syncEditLine.position - mainLine.position) < sensibilityPos) {

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

            yield return null;
        }

        syncEditLine.frequency = mainLine.frequency;
        syncEditLine.amplitude = mainLine.amplitude;
        syncEditLine.position = mainLine.position;

        controller.EndSync();
    }

    public float GetValue()
    {
        return currentValue;
    }

    private float NormalizeToRange(float value, float min, float max, float newMin, float newMax)
    {
        return (value - min) / (max - min) * (newMax - newMin) + newMin;
    }
}
