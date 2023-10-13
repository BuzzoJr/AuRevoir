using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class LangTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
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
