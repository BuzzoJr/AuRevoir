using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool allow;

    void Start()
    {
        allow = true;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (allow)
            CursorController.instance.inButton = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (allow)
            CursorController.instance.inButton = false;
    }
}
