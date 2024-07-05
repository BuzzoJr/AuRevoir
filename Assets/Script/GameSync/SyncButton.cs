using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class TypeList
{
    public enum types
    {
        FRQ = 0,
        AMP = 1,
        SPD = 2
    }

    public static readonly string[] typesStrings = { "Frequency", "Amplitude", "Speed" };
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
            }
            else if (selected == "Amplitude")
            {
                syncEditLine.amplitude = valorAtual;
                valueAmp.text = normalizedValue.ToString("F2");
            }
            else if (selected == "Speed")
            {
                syncEditLine.speed = valorAtual;
                valueSpd.text = normalizedValue.ToString("F2");
            }

            if ((Mathf.Round(syncEditLine.frequency * 100f) / 100f >= mainLine.frequency - 0.025f && Mathf.Round(syncEditLine.frequency * 100f) / 100f <= mainLine.frequency + 0.025f) &&
            (Mathf.Round(syncEditLine.amplitude * 100f) / 100f == mainLine.amplitude) &&
            (Mathf.Round(syncEditLine.speed * 100f) / 100f >= mainLine.speed - 0.025f && Mathf.Round(syncEditLine.speed * 100f) / 100f <= mainLine.speed + 0.025f))
            {

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
