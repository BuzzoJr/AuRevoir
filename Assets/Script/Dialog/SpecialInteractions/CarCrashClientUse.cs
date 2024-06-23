using Assets.Script.Interaction;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarCrashClientUse : MonoBehaviour, IUse
{
    public GameObject mainCamera;
    public GameObject allSyncWave;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;

    public void Use(GameObject who)
    {
        // Abrir mini game de sync
        StartCoroutine(Execute(who));
    }

    IEnumerator Execute(GameObject who)
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), this.transform);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk") && !PlayerController.anim.GetBool("Run"));
        allSyncWave.SetActive(true);
        mainCamera.SetActive(false);
    }
}
