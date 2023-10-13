using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class LangTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Test());
    }

    void Update()
    {
    }

    IEnumerator Test()
    {
        Locale.LoadLang(Lang.enUS);

        foreach (TextData text in Locale.Texts[TextGroup.Intro])
        {
            Debug.Log(text.Type.ToString() + ": " + text.Text);
            yield return new WaitForSeconds((text.Delay > 0) ? text.Delay : 5);
        }

        Locale.LoadLang(Lang.ptBR);

        foreach (TextData text in Locale.Texts[TextGroup.Intro])
        {
            Debug.Log(text.Type.ToString() + ": " + text.Text);
            yield return new WaitForSeconds((text.Delay > 0) ? text.Delay : 5);
        }
    }
}
