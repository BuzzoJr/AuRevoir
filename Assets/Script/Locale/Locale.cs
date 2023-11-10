using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Locale
{
    public static class Locale
    {
        public static Dictionary<Lang, Dictionary<TextGroup, List<TextData>>> Options => new()
        {
            { Lang.enUS, Locale_enUS.Texts },
            { Lang.ptBR, Locale_ptBR.Texts },
        };

        public static Lang Lang { get; set; }
        public static Dictionary<TextGroup, List<TextData>> Texts { get; set; }

        public static Dictionary<ItemGroup, List<ItemData>> Item { get; set; }
        static Locale()
        {
            Lang = Lang.enUS;
            Texts = Locale_enUS.Texts;
            Item = Locale_enUS.Item;
        }

        public static void LoadLang(Lang newLang)
        {
            Lang = newLang;
            Texts = Options[newLang];
            Debug.Log(Lang.ToString() + " lang loaded!");
        }
    }
}
