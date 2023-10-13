using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D moveCursorRight;
    [SerializeField] private Texture2D moveCursorLeft;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hitPoint;
        if (Physics.Raycast(ray, out hitPoint))
        {
            if (hitPoint.transform.CompareTag("Door"))
            {
                if (mousePosition.x < Screen.width / 2)
                {
                    Cursor.SetCursor(moveCursorLeft, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(moveCursorRight, Vector2.zero, CursorMode.Auto);
                }
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }

    }
}
