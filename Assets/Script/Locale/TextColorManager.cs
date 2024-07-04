using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

public static class TextColorManager
{
    public static Dictionary<TextType, Color> textTypeColors = new Dictionary<TextType, Color>
    {
        {TextType.System, Color.white }, // White
        {TextType.Tristan, new Color(0.67f, 0.16f, 0.15f, 1f) }, // Light Gray
        {TextType.TristanThinking, new Color(0.6f, 0.6f, 0.6f, 1f) }, // Light Gray
        {TextType.Daughter, new Color(0.7f, 0f, 0.7f, 1f) }, // Purple
        {TextType.ExWife, new Color(0.7f, 0.4f, 0.15f, 1f) }, // Brownish
        {TextType.Boss, new Color(0.78f, 0.08f, 0.08f, 1f) }, // Red
        {TextType.CEO, new Color(0.404f, 0.624f, 0.631f, 1f) }, // Bluish Green
        {TextType.Revolutionary, new Color(0.404f, 0.624f, 0.631f, 1f) }, // Bluish Green
        {TextType.RevolutionaryBrother, new Color(0.749f, 0.737f, 0.38f, 1f) }, // Yellowish
        {TextType.NewsAnchor, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.Guard, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.Robot, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.Beggar, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.LabWorker2, new Color(1f, 0.32f, 0.84f, 1f) }, // Pink
        {TextType.LabWorker1, new Color(0.532f, 0.977f, 1f, 1f) }, // Light Blue
        {TextType.RevolutionaryHidden, new Color(0.404f, 0.624f, 0.631f, 1f) }, // Bluish Green
        // TODO - Definir as cores de fala dos novos tipos
        {TextType.TVCommercial, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.Hank, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.CellPhone, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.PoliceOfficer, new Color(0.71f, 0.49f, 0.255f, 1f) }, // Brownish
        {TextType.CarCrashClient, new Color(0.71f, 0.49f, 0.255f, 1f) } // Brownish

    };
}
