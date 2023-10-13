using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Locale
{
    public static class Locale
    {
        public static Dictionary<LangType, List<Message>> Options => new()
        {
            { LangType.enUS, Locale_enUS.Messages },
            { LangType.ptBR, Locale_ptBR.Messages },
        };

        public static LangType Lang { get; set; }
        public static List<Message> Messages { get; set; }

        static Locale()
        {
            Lang = LangType.enUS;
            Messages = Locale_enUS.Messages;
        }

        public static void LoadLang(LangType newLang)
        {
            Lang = newLang;
            Messages = Options[newLang];
            Debug.Log(Lang.ToString() + " lang loaded!");
        }
    }
}
