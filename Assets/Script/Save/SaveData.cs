using Assets.Script;
using Assets.Script.Locale;
using System.Collections.Generic;

public class SaveData
{
    public string currentScene;
    public string previousScene;
    public List<string> visitedScenes;
    public List<GameSteps> steps;
    public List<ItemGroup> inventoryGroups;
}
