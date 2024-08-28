using Assets.Script.Locale;
using UnityEngine;

public class HoverTextTranslate : MonoBehaviour, ILangConsumer
{
    public TextGroup textGroup = TextGroup.FinalDecision;
    public int index = 0;

    public string text = "";

    void Awake()
    {
        Locale.RegisterConsumer(this);
        UpdateLangTexts();
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    public void UpdateLangTexts()
    {
        text = Locale.Texts[textGroup][index].Text;
    }
}
