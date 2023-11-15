using Assets.Script.Locale;
using TMPro;
using UnityEngine;

public class TranslateMe : MonoBehaviour
{
    public TextGroup textGroup = TextGroup.FinalDecision;
    public int index = 0;

    void Awake()
    {
        TMP_Text finalDecision = GetComponent<TMP_Text>();
        finalDecision.text = Locale.Texts[textGroup][index].Text;
    }
}
