using Assets.Script.Locale;
using UnityEngine;

public class UpdateRevolutionaryInAlley : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject revolutionary;

    void Awake()
    {
        if (playerData.cutsceneWatched)
            revolutionary.SetActive(false);
        else if (playerData.laundryVisited)
            revolutionary.GetComponent<DialogInteraction>().textGroup = TextGroup.DirectionsToMorgue;
    }
}
