using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Linq;
using UnityEngine;

public class ExampleUseAndLook : MonoBehaviour, IUse, ILook
{
    public TextGroup textGroup = TextGroup.Intro;

    public void Use(GameObject who)
    {
        Debug.Log(Locale.Texts[textGroup].First().Text);
    }

    public void Look(GameObject who)
    {
        Debug.Log(Locale.Texts[textGroup].Last().Text);
    }
}
