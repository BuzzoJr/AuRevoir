using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour {
    public Animator animTextIntro;
    public TMP_Text textIntro, textPlay, textQuit, textContinue;
    public float timeFade;
    public AudioSource menuSong;
    private bool btnPressed = false;

    void Awake() {
        ChangeTxt();
    }

    public void ToPtBr() {
        Locale.LoadLang(Lang.ptBR);
        ChangeTxt();
    }

    public void ToEnUs() {
        Locale.LoadLang(Lang.enUS);
        ChangeTxt();
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame() {
        StartCoroutine(WaitStartGame());
    }

    public void SpeedUpText() {
        if(btnPressed)
            animTextIntro.SetFloat("SpeedText", 1f);
        else
            animTextIntro.SetFloat("SpeedText", 5f);

        btnPressed = !btnPressed;
    }

    private void ChangeTxt() {
        textIntro.text = "\t"     + Locale.Texts[TextGroup.Intro][0].Text +
                         "\n\n\t" + Locale.Texts[TextGroup.Intro][1].Text +
                         "\n\n\t" + Locale.Texts[TextGroup.Intro][2].Text;

        textPlay.text     = Locale.Texts[TextGroup.Menu][0].Text;
        textQuit.text     = Locale.Texts[TextGroup.Menu][1].Text;
        textContinue.text = Locale.Texts[TextGroup.Menu][2].Text;
    }

    IEnumerator WaitStartGame() {
        float startVolume = 0.8f;
        float targetVolume = 0f;
        float currentTime = 0f;

        while (currentTime < 1f) {
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
