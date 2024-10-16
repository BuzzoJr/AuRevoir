using Assets.Script;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterPortraits", menuName = "ScriptableObjects/CharacterPortraits", order = 1)]
public class CharacterPortraits : ScriptableObject
{
    public string characterName;
    public ScenePortraits[] scenePortraits;
}

[System.Serializable]
public class ScenePortraits
{
    public SceneRef sceneName;
    public Sprite portrait;
}
