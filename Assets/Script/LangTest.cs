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
        Locale.LoadLang(LangType.enUS);
        Debug.Log(Locale.Messages[0].Type.ToString() + ": " + Locale.Messages[0].Text);
        yield return new WaitForSeconds((Locale.Messages[0].Delay > 0) ? Locale.Messages[0].Delay : 5);
        Debug.Log(Locale.Messages[1].Type.ToString() + ": " + Locale.Messages[1].Text);
        yield return new WaitForSeconds((Locale.Messages[1].Delay > 0) ? Locale.Messages[1].Delay : 5);
        Debug.Log(Locale.Messages[2].Type.ToString() + ": " + Locale.Messages[2].Text);
        yield return new WaitForSeconds((Locale.Messages[2].Delay > 0) ? Locale.Messages[2].Delay : 5);
        Debug.Log(Locale.Messages[3].Type.ToString() + ": " + Locale.Messages[3].Text);
        yield return new WaitForSeconds((Locale.Messages[3].Delay > 0) ? Locale.Messages[3].Delay : 5);
        Locale.LoadLang(LangType.ptBR);
        Debug.Log(Locale.Messages[0].Type.ToString() + ": " + Locale.Messages[0].Text);
        yield return new WaitForSeconds((Locale.Messages[0].Delay > 0) ? Locale.Messages[0].Delay : 5);
        Debug.Log(Locale.Messages[1].Type.ToString() + ": " + Locale.Messages[1].Text);
        yield return new WaitForSeconds((Locale.Messages[1].Delay > 0) ? Locale.Messages[1].Delay : 5);
        Debug.Log(Locale.Messages[2].Type.ToString() + ": " + Locale.Messages[2].Text);
        yield return new WaitForSeconds((Locale.Messages[2].Delay > 0) ? Locale.Messages[2].Delay : 5);
        Debug.Log(Locale.Messages[3].Type.ToString() + ": " + Locale.Messages[3].Text);
    }
}
