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
    public GameObject panelTxt, loadingObj, mainCanvas;
    public GameObject[] allCircles;
    public Slider volumeScreen, volumeOpt, musicScreen, musicOpt;
    public float timeFade;
    private bool btnPressed = false;
    private bool btnFulls = true;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("FullS")) {
            PlayerPrefs.SetInt("FullS", 1);
        }
        else {
            if(PlayerPrefs.GetInt("FullS") == 0) {
                ChangeFullScreen();
            }
        }

        if(!PlayerPrefs.HasKey("Resolution")) {
            PlayerPrefs.SetInt("Resolution", 0);
        }
        else {
            ChangeResolution(PlayerPrefs.GetInt("Resolution"));
        }

        if(!PlayerPrefs.HasKey("Volume")) {
            ChangeVolume();
        }
        else {
            volumeOpt.value = (PlayerPrefs.GetFloat("Volume") - 1) *-1;
            volumeScreen.value = (PlayerPrefs.GetFloat("Volume") - 1) *-1;
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
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
            PlayerPrefs.SetInt("FullS", 1);
            Screen.fullScreen = true;
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else {
            checkFulls.text = "(      )";
            PlayerPrefs.SetInt("FullS", 0);
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
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

    public void ChangeResolution(int value) {
        bool fulls = true;

        if(PlayerPrefs.GetInt("FullS") == 0)
            fulls = false;

        for(int i = 0; i < allCircles.Length; i++) {
            if(i == value)
                allCircles[i].SetActive(true);
            else
                allCircles[i].SetActive(false);
        }

        Screen.fullScreen = false;

        if(value == 0) {
            Screen.SetResolution(1920, 1080, fulls);
            //mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
        }
        else if(value == 1) {
            Screen.SetResolution(1600, 900, fulls);
            //mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1600, 900);
        }
        else if(value == 2) {
            Screen.SetResolution(1366, 768, fulls);
            //mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1366, 768);
        }
        else {
            Screen.SetResolution(1280, 720, fulls);
            //mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1280, 720);
        }

        PlayerPrefs.SetInt("Resolution", value);
    }

    public void ChangeVolume() {
        volumeScreen.value = volumeOpt.value;
        AudioListener.volume = 1f - volumeOpt.value;

        PlayerPrefs.SetFloat("Volume", 1f - volumeOpt.value);
    }

    public void ChangeMusic() {
        musicScreen.value = musicOpt.value;
        //music.volume = musicSlider.value;
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
