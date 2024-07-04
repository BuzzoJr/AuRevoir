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
        public static Dictionary<Lang, Dictionary<TextType, string>> TitleOptions => new()
        {
            { Lang.enUS, Locale_enUS.Titles },
            { Lang.ptBR, Locale_ptBR.Titles },
        };
        public static Dictionary<Lang, Dictionary<ItemGroup, ItemData>> ItemOptions => new()
        {
            { Lang.enUS, Locale_enUS.Item },
            { Lang.ptBR, Locale_ptBR.Item },
        };

        public static Lang Lang { get; set; }
        public static Dictionary<TextGroup, List<TextData>> Texts { get; set; }
        public static Dictionary<TextType, string> Titles { get; set; }
        public static Dictionary<ItemGroup, ItemData> Item { get; set; }

        private static List<ILangConsumer> consumers = new();

        static Locale()
        {
            Lang = Lang.enUS;
            Texts = Locale_enUS.Texts;
            Titles = Locale_enUS.Titles;
            Item = Locale_enUS.Item;
        }

        public static void LoadLang(Lang newLang)
        {

            Lang = newLang;
            Texts = Options[newLang];
            Item = ItemOptions[newLang];
            Titles = TitleOptions[newLang];

            consumers.RemoveAll(item => item == null);

            foreach (ILangConsumer consumer in consumers)
                consumer.UpdateLangTexts();

            Debug.Log(Lang.ToString() + " lang loaded!");
        }

        public static void RegisterConsumer(ILangConsumer consumer)
        {
            consumers.Add(consumer);
        }

        public static void UnregisterConsumer(ILangConsumer consumer)
        {
            consumers.Remove(consumer);
        }
    }
}
