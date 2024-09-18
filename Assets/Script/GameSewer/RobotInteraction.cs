using Assets.Script.Interaction;
using System.Collections;
using UnityEngine;
using Assets.Script;

public class RobotInteraction : MonoBehaviour, IUseItem
{
    public bool shouldWalk = false;
    public string targetItem;
    public GameObject puzzleActive;
    public PlayerData playerData;
    [SerializeField] private Transform targetTransform = null;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public bool UseItem(GameObject who)
    {
        if (targetItem == who.name)
        {
            StartCoroutine(CoroutineExample());
            return true;
        }

        return false;
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), targetTransform));

            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

        playerData.AddStep(GameSteps.PuzzleSewerActive);
        puzzleActive.SetActive(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        gameObject.SetActive(false);
    }

    void OnDestroy() {
        puzzleActive.SetActive(true);
    }
}
