using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, ILangConsumer
{
    //Controla para qual cena vai ao colidir com a porta
    public SceneRef moveRef = SceneRef.SampleScene;
    public GameObject transObj, globalObj;
    public bool locked = false;
    public TextGroup textGroup = TextGroup.LockedDoor;
    [SerializeField] private GameObject dialogBox = null;
    private TMP_Text dialogText;

    private Animator anim;

    private int currentIndex = -1;

    public void UpdateLangTexts()
    {
        if (currentIndex >= 0)
        {
            TextData data = Locale.Texts[textGroup][currentIndex];
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = "* " + data.Text + " *";
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    public enum SceneRef
    {
        C0Bar,
        C0Rua,
        C0HallOffice,
        C0OfficeGarage,
        C0UploadRoom,
        C0Livingroom,
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
        SampleScene,
        EndScene,
        C0Bedroom,
    }

    void Start()
    {
        if (transform.parent.TryGetComponent(out anim))
            anim.SetBool("Locked", locked);
        if (dialogBox != null)
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
                SceneManager.LoadScene(moveRef.ToString());
        }
        else if (locked)
        {
            StartCoroutine(LockedDialog());
        }
    }

    IEnumerator DelayTransition()
    {
        if(globalObj != null)
            globalObj.SetActive(false);

        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/" + moveRef.ToString());
    }

    IEnumerator LockedDialog()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        dialogBox.SetActive(true);
        Locale.RegisterConsumer(this);
        for (int i = 0; i < Locale.Texts[textGroup].Count; i++)
        {
            currentIndex = i;
            UpdateLangTexts();

            TextData data = Locale.Texts[textGroup][currentIndex];
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
        Locale.UnregisterConsumer(this);
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
