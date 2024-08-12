using Assets.Script.Dialog;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, ILangConsumer
{
    //Controla para qual cena vai ao colidir com a porta
    public SceneRef moveRef = SceneRef.B_BarBathroom;
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
        B_BarBathroom,
        B_Bar,
        B_Rua,
        O_OfficeGarage,
        O_HallOffice,
        O_Office,
        O_UploadRoom,
        AP_BedroomBadDream,
        AP_LivingroomBadDream,
        AP_Bedroom,
        AP_Livingroom,
        DB_GuardedWall,
        DB_SewersAccess,
        SW_Sewers,
        CR_Ap13,
        CR_Ap43,
        CR_ApartamentStreet,
        CR_FloorFour,
        CR_FloorOne,
        CR_Park,
        CC_Alley,
        CC_EscritorioMafia,
        CC_ExteriorLavanderia,
        CC_InteriorLavanderia,
        CC_RuaNecroterio,
        CC_Transicao,
        CC_Necroterio,
        CL_ClubExterior,
        CL_Clublnterior,
        LAB_LabCorridor,
        LAB_MainetenceDoor,
        LAB_ParkEntry,
        LAB_Laboratory,

        EndScene,
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
        if (globalObj != null)
            globalObj.SetActive(false);

        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(moveRef.ToString());
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
