using Assets.Script;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    //Controla para qual cena vai ao colidir com a porta
    public SceneRef moveRef = SceneRef.B_BarBathroom;
    public GameObject transObj, globalObj, allMap;
    public bool map = false;

    [Header("Lock Interaction")]
    public bool locked = false;
    public TextGroup textGroup = TextGroup.LockedDoor;
    public TextInteractionType textInteractionType = TextInteractionType.Sequence;
    private Dialog dialog;

    private Animator anim;

    void Start()
    {
        if (transform.parent.TryGetComponent(out anim))
            anim.SetBool("Locked", locked);

        dialog = gameObject.AddComponent<Dialog>();
        dialog.Configure(textGroup, textInteractionType);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!locked)
        {
            if (transObj != null)
                StartCoroutine(DelayTransition());
            else if (map)
                allMap.SetActive(true);
            else
                SceneManager.LoadScene(moveRef.ToString());
        }
        else if (locked)
        {
            StartCoroutine(LockedDialog());
        }
    }

    IEnumerator DelayTransition()
    {
        if (globalObj != null)
            globalObj.SetActive(false);

        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(moveRef.ToString());
    }

    IEnumerator LockedDialog()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        while (Input.GetMouseButtonDown(0))
            yield return null;

        yield return StartCoroutine(dialog.Execute(gameObject, (value) => { }));

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void SetLock(bool value)
    {
        locked = value;
        if (anim)
            anim.SetBool("Locked", locked);
    }
}