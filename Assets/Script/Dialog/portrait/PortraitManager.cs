using UnityEngine;
using System.Collections.Generic;
using Assets.Script;
using System;

public static class PortraitManager
{
    private static Dictionary<string, Dictionary<SceneRef, Sprite>> portraitDictionary;

    static PortraitManager()
    {
        LoadCharacterPortraits();
    }

    private static void LoadCharacterPortraits()
    {
        if (portraitDictionary == null)
        {
            portraitDictionary = new Dictionary<string, Dictionary<SceneRef, Sprite>>();

            //---------------DA LOAD EM TODOS NA PASTA RESOURCES
            CharacterPortraits[] allCharacterPortraits = Resources.LoadAll<CharacterPortraits>(""); 

            //Debug.Log($"Loaded {allCharacterPortraits.Length} CharacterPortraits from Resources");

            foreach (var characterPortraits in allCharacterPortraits)
            {
                if (!portraitDictionary.ContainsKey(characterPortraits.characterName))
                {
                    portraitDictionary[characterPortraits.characterName] = new Dictionary<SceneRef, Sprite>();
                }

                foreach (var scenePortrait in characterPortraits.scenePortraits)
                {
                    portraitDictionary[characterPortraits.characterName][scenePortrait.sceneName] = scenePortrait.portrait;
                    //Debug.Log($"Added portrait for character: {characterPortraits.characterName}, scene: {scenePortrait.sceneName}");
                }
            }
        }
    }

    public static Sprite GetPortrait(string scene, string character)
    {
        if (portraitDictionary == null)
        {
            return null;
        }

        if (portraitDictionary.ContainsKey(character) && portraitDictionary[character].ContainsKey((SceneRef)Enum.Parse(typeof(SceneRef), scene)))
        {
            return portraitDictionary[character][(SceneRef)Enum.Parse(typeof(SceneRef), scene)];
        }
        else
        {
            //Debug.LogWarning($"Portrait not found for character: {character} in scene: {scene}");
            return null;
        }
    }
}
