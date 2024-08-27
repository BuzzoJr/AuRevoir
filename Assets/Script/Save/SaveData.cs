using Assets.Script;
using Assets.Script.Locale;
using System.Collections.Generic;

public class SaveData
{
    public SceneRef currentScene;
    public SceneRef previousScene;
    public List<SceneRef> visitedScenes;
    public List<GameSteps> steps;
    public List<ItemGroup> items;
}
