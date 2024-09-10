using Assets.Script.Dialog;
using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

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

        var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

        Ray ray = mainCamera.ScreenPointToRay(viewportPos);
        if (Physics.Raycast(ray, out RaycastHit hitPoint))
        {
            useItem = hitPoint.transform.GetComponentInChildren<IUseItem>();

            if (useItem is not null)
                transform.localScale = Vector3.one / 2;
            else
                transform.localScale = Vector3.one;

            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
                if (useItem is not null)
                {
                    if (!CheckInteractionLimit(hitPoint.transform))
                        useItem.UseItem(gameObject);

                    Destroy(this.gameObject);
                }

                StartCoroutine(WrongItem());
            }
        }
    }

    private bool CheckInteractionLimit(Transform target)
    {
        // Limitar interação
        foreach (ILimit limiter in target.GetComponentsInChildren<ILimit>())
        {
            if (limiter.ShouldLimit(gameObject))
            {
                limiter.Limited(gameObject);
                return true;
            }
        }

        return false;
    }

    IEnumerator WrongItem()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        while (Input.GetMouseButtonDown(0))
            yield return null;

        Dialog dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(TextGroup.WrongItemUse, TextInteractionType.Sequence);

        yield return StartCoroutine(dialog.Execute(gameObject, (value) => { }));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        Destroy(this.gameObject);
    }
}
