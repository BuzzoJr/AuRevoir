using Assets.Script.Interaction;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MouseFollower : MonoBehaviour
{
    private Camera mainCamera;
    private IUseItem useItem;

    private void Awake()
    {
        mainCamera = Camera.main;
        this.transform.parent = mainCamera.transform;
    }

    private void Update()
    {
        Vector3 mousePosition = new Vector3((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height, 3f);
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0))
        {
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

            Ray ray = mainCamera.ScreenPointToRay(viewportPos);
            if (Physics.Raycast(ray, out RaycastHit hitPoint))
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
                useItem = hitPoint.transform.GetComponentInChildren<IUseItem>();
                if (useItem is not null)
                {
                    useItem.UseItem(gameObject);
                }
                Destroy(this.gameObject);
            }
        }

    }
}
