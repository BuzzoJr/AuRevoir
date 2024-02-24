using Assets.Script.Locale;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrainMiniGame : MonoBehaviour, ILangConsumer
{
    public GameObject camMain;
    public GameObject camMiniGame;
    public GameObject canvas;
    public GameObject canvasColision;
    public GameObject interactObj;
    public GameObject player;
    public GameObject interactNpc;
    public TMP_Text title;
    public TMP_Text quit;
    public GameObject menus;
    public GameObject instructions;
    public AudioSource clickAudio;
    public AudioSource failAudio;
    public AudioSource successAudio;
    public Animator body;
    public List<Light> bodyLight;

    private bool success = false;
    private GameObject enlarged;
    private List<GameObject> selected;
    private readonly List<string> selectOrder = new()
    {
        "FrontalLobeRight",
        "OccipitalLobe",
        "TemporalLobe",
        "FrontalLobeLeft",
        "ParietalLobe",
        "Cerebellum",
    };

    public void UpdateLangTexts()
    {
        title.text = Locale.Texts[TextGroup.BrainHUD][0].Text;
        quit.text = Locale.Texts[TextGroup.BrainHUD][1].Text;

        TMP_Text[] menuLabels = menus.GetComponentsInChildren<TMP_Text>();
        for (int i = 0; i < menuLabels.Length; i++)
            menuLabels[i].text = Locale.Texts[TextGroup.BrainMenu][i].Text;

        menuLabels = instructions.transform.GetChild(0).GetComponentsInChildren<TMP_Text>();
        for (int i = 0; i < menuLabels.Length; i++)
            menuLabels[i].text = Locale.Texts[TextGroup.BrainMenu][i + 1].Text;

        for (int i = 1; i < instructions.transform.childCount; i++)
        {
            TMP_Text instruction = instructions.transform.GetChild(i).GetComponentInChildren<TMP_Text>();
            if (instruction != null)
                instruction.text = Locale.Texts[TextGroup.BrainInstructions][i].Text;
        }
    }

    void Awake()
    {
        selected = new();

        Locale.RegisterConsumer(this);
        UpdateLangTexts();
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Update()
    {
        if (!success && enlarged != null)
        {
            if (!selected.Contains(enlarged))
                enlarged.transform.localScale = Vector3.one * 0.2f;

            enlarged = null;
        }

        var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(viewportPos), out RaycastHit raycastHit, 100f))
        {
            if (raycastHit.transform != null)
            {
                if (!success && raycastHit.transform.CompareTag("MiniGame"))
                    MiniGameInteractable(raycastHit.transform.gameObject, Input.GetMouseButtonDown(0));
                else if (raycastHit.transform.CompareTag("Button") && Input.GetMouseButtonDown(0))
                    MiniGameUI(raycastHit.transform.gameObject);
            }
        }
    }

    public void MiniGameInteractable(GameObject obj, bool clicked)
    {
        if (clicked)
        {
            clickAudio.Play();
            if (obj.name == selectOrder[selected.Count])
            {
                selected.Add(obj);
                obj.transform.localScale = Vector3.one * 0.5f;

                if (selected.Count >= selectOrder.Count)
                    MiniGameSuccess();
            }
            else
            {
                foreach (GameObject s in selected)
                    s.transform.localScale = Vector3.one * 0.2f;

                selected.Clear();
                failAudio.Play();
            }
        }
        else if (!selected.Contains(obj))
        {
            obj.transform.localScale = Vector3.one * 0.3f;
            enlarged = obj;
        }
    }
    public void MiniGameUI(GameObject obj)
    {
        if (obj.name == "Quit")
        {
            EndMiniGame();
            return;
        }

        if (success)
            return;

        switch (obj.name)
        {
            case "Zones":
                SelectPage(0);
                return;

            case "Temporal":
                SelectPage(1);
                return;

            case "Frontal":
                SelectPage(2);
                return;

            case "Parietal":
                SelectPage(3);
                return;

            case "Occipital":
                SelectPage(4);
                return;

            case "Cerebellum":
                SelectPage(5);
                return;
        }
    }

    public void MiniGameSuccess()
    {
        SelectPage(7);
        success = true;
        interactNpc.SetActive(true);
        successAudio.Play();
    }

    public void SelectPage(int page)
    {
        if (success)
            return;

        TMP_Text[] menuLabels = menus.GetComponentsInChildren<TMP_Text>();
        for (int i = 0; i < menuLabels.Length; i++)
        {
            if (i == page)
                menuLabels[i].fontStyle |= FontStyles.Underline;
            else
                menuLabels[i].fontStyle &= ~FontStyles.Underline;
        }

        for (int i = 0; i < instructions.transform.childCount; i++)
            instructions.transform.GetChild(i).gameObject.SetActive(i == page);
    }

    public void EndMiniGame()
    {
        camMiniGame.SetActive(false);
        camMain.SetActive(true);
        canvas.SetActive(false);
        canvasColision.SetActive(false);
        interactObj.SetActive(true);
        player.SetActive(true);
        body.SetBool("dead", true);
        foreach (Light light in bodyLight)
            light.color = Color.red;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
