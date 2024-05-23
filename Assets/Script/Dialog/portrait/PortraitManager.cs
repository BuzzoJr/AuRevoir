using UnityEngine;
using System.Collections.Generic;

public static class PortraitManager
{
    private static Dictionary<string, Dictionary<string, Sprite>> portraitDictionary;

    static PortraitManager()
    {
        LoadCharacterPortraits();
    }

    private static void LoadCharacterPortraits()
    {
        if (portraitDictionary == null)
        {
            Debug.Log("Initializing PortraitManager");
            portraitDictionary = new Dictionary<string, Dictionary<string, Sprite>>();

            CharacterPortraits[] allCharacterPortraits = Resources.LoadAll<CharacterPortraits>("");

            foreach (var characterPortraits in allCharacterPortraits)
            {
                if (!portraitDictionary.ContainsKey(characterPortraits.characterName))
                {
                    portraitDictionary[characterPortraits.characterName] = new Dictionary<string, Sprite>();
                }

                foreach (var scenePortrait in characterPortraits.scenePortraits)
                {
                    portraitDictionary[characterPortraits.characterName][scenePortrait.sceneName] = scenePortrait.portrait;
                    Debug.Log($"Added portrait for character: {characterPortraits.characterName}, scene: {scenePortrait.sceneName}");
                }
            }
        }
    }

    public static Sprite GetPortrait(string scene, string character)
    {
        if (portraitDictionary == null)
        {
            Debug.LogError("PortraitManager is not initialized. This should not happen.");
            return null;
        }

        if (portraitDictionary.ContainsKey(character) && portraitDictionary[character].ContainsKey(scene))
        {
            return portraitDictionary[character][scene];
        }
        else
        {
            Debug.LogWarning($"Portrait not found for character: {character} in scene: {scene}");
            return null;
        }
    }
}
