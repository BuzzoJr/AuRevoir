using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;

public class ExampleTalk : MonoBehaviour, ITalk
{
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;

    public void Talk(GameObject who)
    {
        StartCoroutine(CoroutineExample());
    }

    IEnumerator CoroutineExample()
    {
        foreach (TextData data in Locale.Texts[textGroup])
        {
            Debug.Log(data.Text);
            yield return new WaitForSeconds(data.Delay > 0 ? data.Delay : 1.5f);
        }
    }
}
