using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recording", menuName = "ScriptableObjects/Recording", order = 1)]
public class Recording : ScriptableObject
{
    public AudioClip clip;
    public TextGroup textGroup;
    public int textIndex = 0;
    public List<int> symbols = new() { 0, 0, 0, 0, 0 };
}