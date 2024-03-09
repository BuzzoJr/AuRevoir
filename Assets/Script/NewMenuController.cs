using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMenuController : MonoBehaviour
{
    public PlayerData playerData;
    public Animator animTextIntro;
    public Image brBtn, enBtn;
    public TMP_Text checkFulls;
    public AudioSource menuSong;
    public Color c1, c2;
    public GameObject panelTxt, loadingObj;
    public float timeFade;
    private bool btnPressed = false;
    private bool btnFulls = true;

    void Awake()
    {
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

        brBtn.color = c1;
        enBtn.color = c2;
    }

    public void ToEnUs()
    {
        PlayerPrefs.SetString("Language", "ENG");
        Locale.LoadLang(Lang.enUS);

        brBtn.color = c2;
        enBtn.color = c1;
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

    public void ChangeFullScreen() {
        btnFulls = !btnFulls;

        if(btnFulls) {
            checkFulls.text = "(  X  )";
        }
        else {
            checkFulls.text = "(      )";
        }
    }

    public void SpeedUpText()
    {
        if (btnPressed)
            animTextIntro.SetFloat("SpeedText", 1f);
        else
            animTextIntro.SetFloat("SpeedText", 5f);

        btnPressed = !btnPressed;
    }

    public void PlayButton() {
        StartCoroutine(AnimPcPlay());
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

    IEnumerator AnimPcPlay()
    {
        yield return new WaitForSeconds(3f);
        panelTxt.SetActive(true);
        loadingObj.SetActive(false);
    }
}
