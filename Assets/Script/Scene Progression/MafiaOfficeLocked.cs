using Assets.Script;
using UnityEngine;

public class MafiaOfficeLocked : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        GetComponent<DoorController>().SetLock(!playerData.steps.Contains(GameSteps.CutsceneWatched));
    }

    public void Unlock()
    {
        if (!playerData.steps.Contains(GameSteps.CutsceneWatched))
            playerData.steps.Add(GameSteps.CutsceneWatched);

        GetComponent<DoorController>().SetLock(false);
    }
}
