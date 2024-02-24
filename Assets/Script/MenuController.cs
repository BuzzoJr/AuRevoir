using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour, ILangConsumer
{
    public PlayerData playerData;
    public Animator animTextIntro;
    public Button brBtn, enBtn;
    public TMP_Text textIntro, textPlay, textQuit, textContinue;
    public float timeFade;
    public AudioSource menuSong;
    public Color c1, c2;
    private bool btnPressed = false;

    public void UpdateLangTexts()
    {
        textIntro.text = "\t" + Locale.Texts[TextGroup.Intro][0].Text +
                         "\n\n\t" + Locale.Texts[TextGroup.Intro][1].Text +
                         "\n\n\t" + Locale.Texts[TextGroup.Intro][2].Text;

        textPlay.text = Locale.Texts[TextGroup.Menu][0].Text;
        textQuit.text = Locale.Texts[TextGroup.Menu][1].Text;
        textContinue.text = Locale.Texts[TextGroup.Menu][2].Text;
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            if (PlayerPrefs.GetString("Language") == "PTBR")
                ToPtBr();
            else if (PlayerPrefs.GetString("Language") == "ENG")
                ToEnUs();
        }

        Locale.RegisterConsumer(this);
        UpdateLangTexts();
    }

    private void Start()
    {
        Destroy(GameObject.Find("MusicEnd"));
        GameManager.Instance.visitedScenes.Clear();
    }

    public void ToPtBr()
    {
        PlayerPrefs.SetString("Language", "PTBR");
        Locale.LoadLang(Lang.ptBR);
        brBtn.interactable = false;
        enBtn.interactable = true;

        ColorBlock cb = brBtn.colors;
        cb.disabledColor = c2;
        brBtn.colors = cb;

        ColorBlock cb2 = enBtn.colors;
        cb2.disabledColor = c1;
        enBtn.colors = cb2;
    }

    public void ToEnUs()
    {
        PlayerPrefs.SetString("Language", "ENG");
        Locale.LoadLang(Lang.enUS);
        brBtn.interactable = true;
        enBtn.interactable = false;

        ColorBlock cb = brBtn.colors;
        cb.disabledColor = c1;
        brBtn.colors = cb;

        ColorBlock cb2 = enBtn.colors;
        cb2.disabledColor = c2;
        enBtn.colors = cb2;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        playerData.ResetData();
        StartCoroutine(WaitStartGame());
    }

    public void SpeedUpText()
    {
        if (btnPressed)
            animTextIntro.SetFloat("SpeedText", 1f);
        else
            animTextIntro.SetFloat("SpeedText", 5f);

        btnPressed = !btnPressed;
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitStartGame()
    {
        float startVolume = 0.8f;
        float targetVolume = 0f;
        float currentTime = 0f;

        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / 1f;

            if (menuSong != null)
            {
                menuSong.volume = Mathf.Lerp(startVolume, targetVolume, normalizedTime);
            }
            yield return null;
        }

        yield return new WaitForSeconds(timeFade);
        SceneManager.LoadScene("C1Bedroom");
    }
}
