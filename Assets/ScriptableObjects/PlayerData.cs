using Assets.Script;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string previousScene;

    public List<string> visitedScenes = new();

    public List<GameSteps> steps = new();

    [Header("Scenes Player Can't Run")]
    public List<string> IndoorScenes = new();

    public void ResetData()
    {
        visitedScenes.Clear();
        steps.Clear();
    }
}