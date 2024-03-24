using Assets.Script;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string previousScene;

    public List<string> visitedScenes = new();

    public List<GameSteps> Steps { get; set; }

    public void ResetData()
    {
        visitedScenes.Clear();
        Steps.Clear();
    }
}