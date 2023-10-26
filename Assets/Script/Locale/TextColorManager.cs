using UnityEngine;
using System.Collections.Generic;
using Assets.Script.Locale;
using System.Runtime.ConstrainedExecution;

public class TextColorManager : MonoBehaviour
{
    public static Dictionary<TextType, Color> textTypeColors = new Dictionary<TextType, Color>
    {
        { TextType.System, Color.white },
        { TextType.Player, new Color(0.6f, 0.6f, 0.6f, 1f)},
        { TextType.PlayerThinking, new Color(0.6f, 0.6f, 0.6f, 1f)},
        { TextType.Daughter,  new Color(0.7f, 0f, 0.7f, 1f)},
        { TextType.ExWife, new Color(0.7f, 0.4f, 0.15f, 1f)},
        { TextType.Boss, new Color(0.78f, 0.08f, 0.08f, 1f)},
        { TextType.CEO, new Color(0.404f, 0.624f, 0.631f, 1f)},
        { TextType.Revolutionary, new Color(0.404f, 0.624f, 0.631f, 1f)},
        { TextType.RevolutionaryBrother, new Color(0.749f, 0.737f, 0.38f, 1f) },
        { TextType.NewsAnchor, new Color(0.71f, 0.49f, 0.255f, 1f)},
        { TextType.Guard, new Color(0.71f, 0.49f, 0.255f, 1f)},
        { TextType.Beggar, new Color(0.71f, 0.49f, 0.255f, 1f)},
    };
}
