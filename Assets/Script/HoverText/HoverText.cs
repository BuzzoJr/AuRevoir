using TMPro;
using UnityEngine;

public class HoverText : MonoBehaviour
{
    public TextMeshProUGUI hoverText; // Refer�ncia ao Text Mesh Pro no Canvas
    private Camera mainCamera;
    public Vector2 offset;
    public RenderTexture renderTexture;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (GameManager.Instance.State != GameManager.GameState.Playing)
            return;

        // Converte a posi��o do mouse para coordenadas da Render Texture
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

        // Verifica se o cursor est� sobre um objeto com as tags desejadas
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

                Debug.LogWarning(hitObject.name + " EST� SEM TRADU��O!!!!! COLOQUE UM SCRIPT HoverTextTranslate!!!!!");
                hoverText.text = hitObject.name;
                return;
            }
        }

        hoverText.text = "";
    }
}