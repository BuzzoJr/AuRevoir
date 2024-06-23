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
    public SyncWave syncEditLine;
    public SyncWave mainLine;
    public TypeList.types selectedType;
    public GameObject sucessoLabel, blockLabel;
    public TMP_Text valueFrq, valueAmp, valueSpd;
    public Material finalLine;
    public Animator mapAnim;
    public float rotationSpeed = 10f;
    public float minValue = 1f;
    public float maxValue = 10f;
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

            if (selected == "Frequency") {
                syncEditLine.frequency = valorAtual;
                valueFrq.text = syncEditLine.frequency.ToString("F2");
            }
            else if (selected == "Amplitude") {
                syncEditLine.amplitude = valorAtual;
                valueAmp.text = syncEditLine.amplitude.ToString("F2");
            }
            else if (selected == "Speed") {
                syncEditLine.speed = valorAtual;
                valueSpd.text = syncEditLine.speed.ToString("F2");
            }
        }

        if((Mathf.Round(syncEditLine.frequency * 100f) / 100f >= mainLine.frequency - 0.025f && Mathf.Round(syncEditLine.frequency * 100f) / 100f <= mainLine.frequency + 0.025f) &&
           (Mathf.Round(syncEditLine.amplitude * 100f) / 100f == mainLine.amplitude) &&
           (Mathf.Round(syncEditLine.speed * 100f) / 100f >= mainLine.speed - 0.01f && Mathf.Round(syncEditLine.speed * 100f) / 100f <= mainLine.speed + 0.01f)) {

            sucessoLabel.SetActive(true);
            blockLabel.SetActive(true);
            isPressed = false;
            syncEditLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
            mainLine.gameObject.GetComponent<LineRenderer>().material = finalLine;
            StartCoroutine(ExitCoroutine());
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

    IEnumerator ExitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        mapAnim.SetTrigger("Exit");
        //Add Step
    }
}
