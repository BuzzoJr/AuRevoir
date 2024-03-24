using Assets.Script.Locale;
using UnityEngine;

public class UpdateRevolutionaryInAlley : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject revolutionary;

    void Awake()
    {
        if (playerData.steps.Contains(Assets.Script.GameSteps.CutsceneWatched))
            revolutionary.SetActive(false);
        else if (playerData.steps.Contains(Assets.Script.GameSteps.LaundryVisited))
            revolutionary.GetComponent<DialogInteraction>().textGroup = TextGroup.DirectionsToMorgue;
    }
}
