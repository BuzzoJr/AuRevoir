using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    public TextMeshProUGUI hoverText; // Referência ao Text Mesh Pro no Canvas
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

        hoverText.transform.position = new Vector2 (mousePosition.x + scaledOffset.x, mousePosition.y + scaledOffset.y);

        // Verifica se o cursor está sobre um objeto com as tags desejadas
        Ray ray = mainCamera.ScreenPointToRay(scaledMousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Interactable") || hitObject.CompareTag("Character") || hitObject.CompareTag("Door"))
            {
                hoverText.text = hitObject.name;
            }
            else
            {
                hoverText.text = "";
            }
        }
        else
        {
            hoverText.text = "";
        }
    }
}
