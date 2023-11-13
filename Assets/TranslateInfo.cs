using System.Collections;
using System.Collections.Generic;
using Assets.Script.Locale;
using TMPro;
using UnityEngine;

public class TranslateInfo : MonoBehaviour
{
    public List<TMP_Text> textMeshProUGUIs;
    public List<int> index;
    private TextGroup textGroupList = TextGroup.Places;
    // Start is called before the first frame update
    void Start()
    {
        int current = 0;
        foreach(TMP_Text text in textMeshProUGUIs)
        {
            text.text = Locale.Texts[textGroupList][index[current]].Text;
            current++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
