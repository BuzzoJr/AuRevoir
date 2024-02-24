using Assets.Script.Locale;
using TMPro;
using UnityEngine;

public class TranslateMe : MonoBehaviour, ILangConsumer
{
    public TextGroup textGroup = TextGroup.FinalDecision;
    public int index = 0;

    private TMP_Text text;

    public void UpdateLangTexts()
    {
        text.text = Locale.Texts[textGroup][index].Text;
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        if (text)
        {
            Locale.RegisterConsumer(this);
            UpdateLangTexts();
        }
    }
}
