using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class TypeList
{
    public enum types
    {
        FRQ = 0,
        AMP = 1,
        SPD = 2
    }

    public static readonly string[] typesStrings = {"Frequency", "Amplitude", "Speed"};
};

public class SyncButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SyncController controller;
    public SyncWave syncEditLine;
    public SyncWave mainLine;
    public TypeList.types selectedType;
    public GameObject sucessoLabel, blockLabel;
    public TMP_Text valueFrq, valueAmp, valueSpd;
    public Material finalLine;
    public float rotationSpeed = 10f;
    public float minValue;
    public float maxValue;
    private float currentRotation = 0f;
    private float valorAtual;
    private bool isPressed = false;
    private string selected;

    private void Start()
    {
        selected = TypeList.typesStrings[(int)selectedType];
    }

    private void Update()
    {
        if (isPressed)
        {
            // Captura o movimento do mouse
            float mouseX = Input.GetAxis("Mouse X");

            // Calcula o ângulo de rotação baseado no movimento do mouse
            float rotationAmount = mouseX * rotationSpeed; // Inverter a direção da rotação

            // Atualiza o ângulo de rotação
            currentRotation += rotationAmount;

            // Limita a rotação entre 0 e 360 graus
            currentRotation = Mathf.Clamp(currentRotation, 0f, 360f);

            // Aplica a rotação ao botão
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

            valorAtual = GetValueBasedOnAngle(currentRotation);
            float normalizedValue = NormalizeToRange(valorAtual, minValue, maxValue, 0f, 100f);

            if (selected == "Frequency") {
                syncEditLine.frequency = valorAtual;
                valueFrq.text = normalizedValue.ToString("F2");
            }
            else if (selected == "Amplitude") {
                syncEditLine.amplitude = valorAtual;
                valueAmp.text = normalizedValue.ToString("F2");
            }
            else if (selected == "Speed") {
                syncEditLine.speed = valorAtual;
                valueSpd.text = normalizedValue.ToString("F2");
            }

            if((Mathf.Round(syncEditLine.frequency * 100f) / 100f >= mainLine.frequency - 0.025f && Mathf.Round(syncEditLine.frequency * 100f) / 100f <= mainLine.frequency + 0.025f) &&
            (Mathf.Round(syncEditLine.amplitude * 100f) / 100f == mainLine.amplitude) &&
            (Mathf.Round(syncEditLine.speed * 100f) / 100f >= mainLine.speed - 0.01f && Mathf.Round(syncEditLine.speed * 100f) / 100f <= mainLine.speed + 0.01f)) {

                blockLabel.SetActive(true);
                sucessoLabel.SetActive(true);
                isPressed = false;
                syncEditLine.frequency = mainLine.frequency;
                syncEditLine.amplitude = mainLine.amplitude;
                syncEditLine.speed = mainLine.speed;
                syncEditLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
                mainLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
                controller.EndSync();
            }
        }
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
