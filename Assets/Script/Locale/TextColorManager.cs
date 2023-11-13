using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

public static class TextColorManager
{
    public static Dictionary<TextType, Color> textTypeColors = new Dictionary<TextType, Color>
    {
        { TextType.System, Color.white },
        { TextType.Player, new Color(0.6f, 0.6f, 0.6f, 1f) },
        { TextType.PlayerThinking, new Color(0.6f, 0.6f, 0.6f, 1f) },
        { TextType.Daughter,  new Color(0.7f, 0f, 0.7f, 1f) },
        { TextType.ExWife, new Color(0.7f, 0.4f, 0.15f, 1f) },
        { TextType.Boss, new Color(0.78f, 0.08f, 0.08f, 1f) },
        { TextType.CEO, new Color(0.404f, 0.624f, 0.631f, 1f) },
        { TextType.Revolutionary, new Color(0.404f, 0.624f, 0.631f, 1f) },
        { TextType.RevolutionaryBrother, new Color(0.749f, 0.737f, 0.38f, 1f) },
        { TextType.NewsAnchor, new Color(0.71f, 0.49f, 0.255f, 1f) },
        { TextType.Guard, new Color(0.71f, 0.49f, 0.255f, 1f) },
        { TextType.Robot, new Color(0.71f, 0.49f, 0.255f, 1f) },
        { TextType.Beggar, new Color(0.71f, 0.49f, 0.255f, 1f) },
    };

    public static string TextSpeaker(TextType type, string text)
    {
        switch (type)
        {
            case TextType.PlayerThinking:
                return "* " + text + " *";

            case TextType.Daughter:
                return "Julie: " + text;

            case TextType.ExWife:
                return "Vivian (Ex): " + text;

            case TextType.Boss:
                return "Béatrice: " + text;

            case TextType.CEO:
                return "René Revoir: " + text;

            case TextType.Revolutionary:
                return "Philippe: " + text;

            case TextType.RevolutionaryBrother:
                return "Vincent: " + text;

            case TextType.NewsAnchor:
                return (Locale.Lang == Lang.enUS ? "News" : "Jornal") + ": " + text;

            case TextType.Guard:
                return (Locale.Lang == Lang.enUS ? "Guard" : "Guarda") + ": " + text;

            case TextType.Robot:
                return (Locale.Lang == Lang.enUS ? "Robot" : "Robô") + ": " + text;

            case TextType.Beggar:
                return (Locale.Lang == Lang.enUS ? "Beggar" : "Mendigo") + ": " + text;

            case TextType.System:
            case TextType.Player:
            default:
                return text;
        }
    }
}
