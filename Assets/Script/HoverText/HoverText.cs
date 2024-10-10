using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Script.Interaction;
using System.Diagnostics.Tracing;

public class HoverText : MonoBehaviour
{
    public TextMeshProUGUI hoverText; // Referência ao Text Mesh Pro no Canvas
    //public TextMeshProUGUI hoverTextMap; // Referência ao Text Mesh Pro no Canvas

    private Camera mainCamera;
    public Vector2 offset;
    public RenderTexture renderTexture;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        // Converte a posição do mouse para coordenadas da Render Texture
        Vector2 mousePosition = Input.mousePosition;
        Vector2 scaledMousePosition = new Vector2(
            (mousePosition.x * renderTexture.width) / Screen.width,
            (mousePosition.y * renderTexture.height) / Screen.height
        );

        Vector2 scaledOffset = new Vector2(
            (offset.x * Screen.width) / renderTexture.width,
            (offset.y * Screen.height) / renderTexture.height
        );

        hoverText.transform.position = new Vector2(mousePosition.x + scaledOffset.x, mousePosition.y + scaledOffset.y);

        if (GameManager.Instance.State != GameManager.GameState.Playing)
        {
            //hoverTextMap.transform.position = new Vector2(mousePosition.x + scaledOffset.x, mousePosition.y + scaledOffset.y);

            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y )
            };

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, raycastResults);

            List<string> buttonNames = new List<string> {"SelectButton" };
            foreach (var result in raycastResults)
            {
                // Ensure we hit the UI layer
                if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
                {
                    if (buttonNames.Contains(result.gameObject.name))
                    {
                        Debug.Log(result.gameObject.name);
                        if (result.gameObject.TryGetComponent(out HoverTextTranslate translated))
                        {
                            //hoverTextMap.text = translated.text;
                            return;
                        }

                        Debug.LogWarning(result.gameObject.name + " ESTÁ SEM TRADUÇÃO!!!!! COLOQUE UM SCRIPT HoverTextTranslate!!!!!");
                        //hoverTextMap.text = result.gameObject.name;
                        return;
                    }
                }
            }
            //hoverTextMap.text = "";
            hoverText.text = "";

            return;
        }

        // Verifica se o cursor está sobre um objeto com as tags desejadas
        Ray ray = mainCamera.ScreenPointToRay(scaledMousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Interactable") || hitObject.CompareTag("Character") || hitObject.CompareTag("Door"))
            {
                if (hitObject.TryGetComponent(out HoverTextTranslate translated))
                {
                    hoverText.text = translated.text;
                    return;
                }

                Debug.LogWarning(hitObject.name + " ESTÁ SEM TRADUÇÃO!!!!! COLOQUE UM SCRIPT HoverTextTranslate!!!!!");
                hoverText.text = hitObject.name;
                return;
            }
        }

        //hoverTextMap.text = "";
        hoverText.text = "";

    }
}
