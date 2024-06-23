using System.Collections;
using UnityEngine;

namespace Assets.Script.Interaction
{
    public class GoTo
    {
        public IEnumerator GoToRoutine(Vector3 dest, Transform lookAtTarget = null)
        {
            var state = GameManager.Instance.State;

            GameManager.Instance.UpdateGameState(GameManager.GameState.Walking);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(dest, lookAtTarget);

            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk") && !PlayerController.anim.GetBool("Run"));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Walking)
                yield break;

            GameManager.Instance.UpdateGameState(state);
        }
    }
}