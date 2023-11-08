using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void ToPtBr() {
        Locale.LoadLang(Lang.ptBR);
    }

    public void ToEnUs() {
        Locale.LoadLang(Lang.enUS);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("C1Bedroom");
    }
}
