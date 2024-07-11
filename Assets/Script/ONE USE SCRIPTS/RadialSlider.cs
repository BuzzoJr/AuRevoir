using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RadialSlider : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public Image fillImage;
    public RectTransform handle;
    public float fillAmount = 0;
    public float maxValue = 360f;
    public float radius = 100f;
    private float currentValue = 0f; // Start at 180 degrees, which is left
    private bool isDragging = false; // Variable to control drag state
    private float angle = 0;

    private void Start()
    {
        // Adjust the initial position of the handle to the left (180 degrees in our logic)
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
            else
            {
                isDragging = false; // Stop dragging if the mouse leaves the handle
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

        float angleInRadians = (angle - 180) * Mathf.Deg2Rad; 
        float x = Mathf.Cos(angleInRadians) * radius;
        float y = Mathf.Sin(angleInRadians) * radius;
        handle.localPosition = new Vector3(x, y, 0);
    }

    public float GetValue()
    {
        return currentValue;
    }
}
