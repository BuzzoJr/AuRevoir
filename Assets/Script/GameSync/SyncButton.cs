using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

[System.Serializable]
public class TypeList
{
    public enum types
    {
        FRQ = 0,
        AMP = 1,
        POS = 2,
    }

    public static readonly string[] typesStrings = { "Frequency", "Amplitude", "Position" };
};

public class SyncButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SyncController controller;
    public SyncWave syncEditLine;
    public SyncWave mainLine;
    public TypeList.types selectedType;
    public GameObject sucessoLabel, blockLabel;
    public TMP_Text valueFrq, valueAmp, valuePos;
    public Material finalLine;
    public float minValue;
    public float maxValue;
    private float currentRotation = 0f;
    private float valorAtual;
    private bool isPressed = false;
    private string selected;

    public float sensibilityFreq = 0.2f;
    public float sensibilityAmp = 0.015f;
    public float sensibilityPos = 0.013f;
    public AudioSource audiosourceFreq;
    public AudioSource audiosourceAmp;
    public AudioSource audiosourcePos;


    private void Start()
    {
        DOTween.Init();
        selected = TypeList.typesStrings[(int)selectedType];
    }

    private void Update()
    {
        if (isPressed)
        {
            // Encontra o angulo entre o knob e o mouse
            int angle = Mathf.FloorToInt(180f + Vector2.SignedAngle(Vector2.up, new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(transform.position.x, transform.position.y)));

            // Limita a rotação entre 0 e 360 graus
            currentRotation = Mathf.Clamp(angle, 0f, 360f);

            // Aplica a rotação ao botão
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            valorAtual = GetValueBasedOnAngle(currentRotation);
            float normalizedValue = NormalizeToRange(valorAtual, minValue, maxValue, 0f, 100f);

            if (selected == "Frequency")
            {
                syncEditLine.frequency = valorAtual;
                valueFrq.text = normalizedValue.ToString("F2");
                audiosourceFreq.pitch = normalizedValue / 100 + 0.5f;
                //50
            }
            else if (selected == "Amplitude")
            {
                syncEditLine.amplitude = valorAtual;
                valueAmp.text = normalizedValue.ToString("F2");
                audiosourceAmp.pitch = (normalizedValue - 10) / 100 + 0.5f;
                //60
            }
            else if (selected == "Position")
            {
                syncEditLine.position = valorAtual;
                valuePos.text = normalizedValue.ToString("F2");
                audiosourcePos.pitch = normalizedValue / 100 + 0.5f;
                //50
            }

            if (Mathf.Abs(syncEditLine.frequency - mainLine.frequency) < sensibilityFreq &&
                Mathf.Abs(syncEditLine.amplitude - mainLine.amplitude) < sensibilityAmp &&
                Mathf.Abs(syncEditLine.position - mainLine.position) < sensibilityPos)
            {
                //Acertou a resposta
                syncEditLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
                mainLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
                isPressed = false;
                blockLabel.SetActive(true);
                sucessoLabel.SetActive(true);
                AjusteAllLine();
            }
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

    private float GetValueBasedOnAngle(float angle)
    {
        // Calcula o valor adicional com base no ângulo atual
        float t = Mathf.Abs(angle / 360f);
        return Mathf.Lerp(minValue, maxValue, t);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private float NormalizeToRange(float value, float min, float max, float newMin, float newMax)
    {
        return (value - min) / (max - min) * (newMax - newMin) + newMin;
    }
}
