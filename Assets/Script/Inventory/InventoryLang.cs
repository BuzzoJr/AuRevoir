using Assets.Script.Locale;
using TMPro;
using UnityEngine;

public class InventoryLang : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text date;
    public TMP_Text close;
    void Awake()
    {
        title.text = Locale.Texts[TextGroup.Inventory][1].Text;
        date.text = Locale.Texts[TextGroup.Inventory][2].Text;
        close.text = Locale.Texts[TextGroup.Inventory][5].Text;
    }
}
