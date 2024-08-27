using Assets.Script;
using Assets.Script.Locale;
using UnityEngine;

public class UpdateRevolutionaryInAlley : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject revolutionary;

    void Awake()
    {
        if (playerData.HasStep(GameSteps.CutsceneWatched))
            revolutionary.SetActive(false);
        else if (playerData.visitedScenes.Contains(SceneRef.CC_InteriorLavanderia))
            revolutionary.GetComponent<DialogInteraction>().textGroup = TextGroup.DirectionsToMorgue;
    }
}
