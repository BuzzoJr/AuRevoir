using Assets.Script.Locale;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateInfo : MonoBehaviour, ILangConsumer
{
    public List<TMP_Text> textMeshProUGUIs;
    public List<int> index;

    public Transform obj;
    public Vector3 objSizePTBR;
    public Vector3 objSizeENUS;

    public TextGroup textGroupList = TextGroup.Places;

    public void UpdateLangTexts()
    {
        if (textMeshProUGUIs.Count > 0)
        {
            for (int i = 0; i < textMeshProUGUIs.Count; i++)
                textMeshProUGUIs[i].text = Locale.Texts[textGroupList][index[i]].Text;
        }

        if (obj != null)
        {
            if (Locale.Lang == Lang.ptBR)
                obj.localScale = objSizePTBR;
            else
                obj.localScale = objSizeENUS;
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Start()
    {
        Locale.RegisterConsumer(this);
        UpdateLangTexts();
    }
}
