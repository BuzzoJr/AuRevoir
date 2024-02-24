using Assets.Script.Locale;
using TMPro;
using UnityEngine;

public class InventoryLang : MonoBehaviour, ILangConsumer
{
    public Selected selected = Selected.ITEMS;
    public TMP_Text items;
    public TMP_Text documents;
    public TMP_Text notes;
    public TMP_Text map;
    public TMP_Text date;
    public TMP_Text close;

    public void UpdateLangTexts()
    {
        date.text = Locale.Texts[TextGroup.Inventory][4].Text;
        close.text = Locale.Texts[TextGroup.Inventory][3].Text;
        items.text = Locale.Texts[TextGroup.Inventory][5].Text;
        documents.text = Locale.Texts[TextGroup.Inventory][6].Text;
        notes.text = Locale.Texts[TextGroup.Inventory][7].Text;
        map.text = Locale.Texts[TextGroup.Inventory][8].Text;
        switch (selected)
        {
            case (Selected.ITEMS):
                items.text = "> " + Locale.Texts[TextGroup.Inventory][5].Text;
                break;
            case (Selected.DOCUMENTS):
                documents.text = "> " + Locale.Texts[TextGroup.Inventory][6].Text;
                break;
            case (Selected.NOTES):
                notes.text = "> " + Locale.Texts[TextGroup.Inventory][7].Text;
                break;
            case (Selected.MAP):
                map.text = "> " + Locale.Texts[TextGroup.Inventory][8].Text;
                break;
        }
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Awake()
    {
        Locale.RegisterConsumer(this);

        UpdateLangTexts();
    }

    public enum Selected
    {
        ITEMS,
        DOCUMENTS,
        NOTES,
        MAP,
    }
}
