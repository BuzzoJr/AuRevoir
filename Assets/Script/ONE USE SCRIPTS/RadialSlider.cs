using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class RadialSlider : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Image fillImage, copyFillImage;
    public RectTransform handle;
    public RectTransform copyhandle;
    public float fillAmount = 0;
    public float maxValue = 360f;
    public float radius = 100f;
    private float currentValue = 0f;
    private bool isDragging = false;
    private float angle = 0;
    public bool finish = false;

    private void Start()
    {
        UpdateHandleAndFill();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            UpdateSlider(eventData);
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
        Debug.Log("Exit");
    }

    private void UpdateSlider(PointerEventData eventData)
    {
        if (finish)
            return;

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
        fillAmount = currentValue / 180;
        fillImage.fillAmount = fillAmount;

        if(copyFillImage != null)
            copyFillImage.fillAmount = fillAmount;

        float angleInRadians = (angle - 180) * Mathf.Deg2Rad; 
        float x = Mathf.Cos(angleInRadians) * radius;
        float y = Mathf.Sin(angleInRadians) * radius;

        if (copyhandle != null)
            copyhandle.localPosition = new Vector3(x, y, 0);

        handle.localPosition = new Vector3(x, y, 0);
    }
}
