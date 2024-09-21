using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecorderSliderSnap : MonoBehaviour, IPointerUpHandler
{
    private Slider slider;
    [HideInInspector] public int divisions = 5;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Snap(slider.value);
    }

    public void Snap(float value)
    {
        float snapped = Mathf.Round(value * (divisions - 1)) / (divisions - 1);
        slider.value = Mathf.Clamp(snapped, 0f, 1f);
    }
}
