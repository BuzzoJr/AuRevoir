using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string previousScene;
    public bool phoneAwnsered = false;
    public bool EndGame = false;
}