using Assets.Script;
using Assets.Script.Locale;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public SceneRef currentScene;
    public SceneRef previousScene;

    [Header("Visited Scenes")]
    public List<SceneRef> visitedScenes = new();

    [Header("Game Steps - Progression")]
    public List<GameSteps> steps = new();

    [Header("Items Collected")]
    public List<ItemGroup> items = new();

    [Header("Teddybears Collected")]
    public List<SceneRef> teddybearScenes = new();

    [Header("Scenes Player Can't Run")]
    public List<SceneRef> IndoorScenes = new();

    public void ResetData()
    {
        visitedScenes.Clear();
        steps.Clear();
        items.Clear();
    }

    public void AddStep(GameSteps step)
    {
        if (step == GameSteps.None)
            return;

        if (steps.Contains(step))
            return;

        steps.Add(step);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");
    }

    public void RemoveStep(GameSteps step)
    {
        steps.Remove(step);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");
    }

    public bool HasStep(GameSteps step)
    {
        if (step == GameSteps.None)
            return true;

        return steps.Contains(step);
    }

    public bool AddItem(ItemGroup item)
    {
        if (items.Contains(item))
            return false;

        items.Add(item);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");

        return true;
    }

    public bool RemoveItem(ItemGroup item)
    {
        if (!items.Contains(item))
            return false;

        items.Remove(item);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");

        return true;
    }

    public void AddTeddybear(SceneRef scene)
    {
        if (teddybearScenes.Contains(scene))
            return;

        teddybearScenes.Add(scene);

        // AutoSave
        if (SaveManager.Instance != null)
            SaveManager.Instance.SaveGame("autosave");
    }
}