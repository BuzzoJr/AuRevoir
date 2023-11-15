using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string previousScene;
    public bool missonReceived = false;
    public bool laundryVisited = false;
    public bool cutsceneWatched = false;
    public bool phoneAwnsered = false;
    public bool EndGame = false;

    public void ResetData()
    {
        previousScene = null;
        missonReceived = false;
        laundryVisited = false;
        cutsceneWatched = false;
        phoneAwnsered = false;
        EndGame = false;
    }
}