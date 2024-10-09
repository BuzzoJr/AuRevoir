using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangSelect : MonoBehaviour
{
    public List<Button> flags;
    public List<Lang> languages;
    public Color colorEnabled;
    public Color colorDisabled;

    void Awake()
    {
        if (flags.Count != languages.Count)
            Debug.LogWarning("TEM QUE COLOCAR A MESMA QUANTIDADE DE BANDEIRAS E IDIOMAS NO LangSelect!");
    }

    void Start()
    {
        for (int i = 0; i < languages.Count; i++)
            SetSelected(flags[i], languages[i] == Locale.Lang);
    }

    private void SetSelected(Button btn, bool selected)
    {
        btn.interactable = !selected;

        ColorBlock cb = btn.colors;
        cb.normalColor = selected ? colorEnabled : colorDisabled;
        // TODO: Arrumar todas as cores
        btn.colors = cb;
    }

    public void ChangeLang(int index)
    {
        if (index >= languages.Count)
            return;

        Locale.LoadLang(languages[index]);

        for (int i = 0; i < languages.Count; i++)
            SetSelected(flags[i], languages[i] == Locale.Lang);
    }
}
