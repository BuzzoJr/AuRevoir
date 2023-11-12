using System.Collections;
using Assets.Script.Dialog;
using Assets.Script.Locale;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public SceneRef moveRef = SceneRef.SampleScene;
    public GameObject transObj, globalObj;
    public bool locked = false;
    public TextGroup textGroup = TextGroup.LockedDoor;
    [SerializeField] private GameObject dialogBox = null;
    private TMP_Text dialogText;

    private Animator anim;

    public enum SceneRef
    {
        C1Bedroom,
        C2Livingroom,
        C3Office,
        C4GuardedWall,
        C5SewersAccess,
        C6Sewers,
        C7Alley,
        C8ExteriorLavanderia,
        C9InteriorLavanderia,
        C10Transicao,
        C11RuaNecroterio,
        C12Necroterio,
        C13EscritorioMafia,
        C15ExteriorLab,
        C16Laboratory,
        SampleScene
    }

    void Start()
    {
        if (transform.parent.TryGetComponent(out anim))
            anim.SetBool("Locked", locked);
        if(dialogBox != null)
            dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!locked)
        {
            if (transObj != null)
                StartCoroutine(DelayTransition());
            else
                SceneManager.LoadScene("Scenes/" + moveRef.ToString());
        }
        else if(locked)
        {
            StartCoroutine(CoroutineExample());
        }
    }

    IEnumerator DelayTransition()
    {
        globalObj.SetActive(false);
        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/" + moveRef.ToString());
    }

    IEnumerator CoroutineExample()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        dialogBox.SetActive(true);
        foreach (TextData data in Locale.Texts[textGroup])
        {
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;
            bool clicked = false;
            float delayTime = data.Delay > 0 ? data.Delay : AllDialogs.defaultDelay;
            float elapsedTime = 0;

            while (elapsedTime < delayTime && !clicked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clicked = true;
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void SetLock(bool value)
    {
        locked = value;
        if (anim)
            anim.SetBool("Locked", locked);
    }
}
