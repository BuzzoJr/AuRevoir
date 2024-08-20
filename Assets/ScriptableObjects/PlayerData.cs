using Assets.Script;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public SceneRef currentScene;
    public SceneRef previousScene;

    public List<SceneRef> visitedScenes = new();

    [SerializeField]
    public List<GameSteps> steps = new();

    [Header("Scenes Player Can't Run")]
    public List<SceneRef> IndoorScenes = new();

    public void ResetData()
    {
        visitedScenes.Clear();
        steps.Clear();
    }

    public void AddStep(GameSteps step)
    {
        if (step == GameSteps.None)
            return;

        if (steps.Contains(step))
            return;

        steps.Add(step);
    }

    public bool HasStep(GameSteps step)
    {
        if (step == GameSteps.None)
            return true;

        return steps.Contains(step);
    }
}