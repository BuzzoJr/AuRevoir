using Assets.Script;
using UnityEngine;

public class MafiaOfficeLocked : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        GetComponent<DoorController>().SetLock(!playerData.HasStep(GameSteps.CutsceneWatched));
    }

    public void Unlock()
    {
        playerData.AddStep(GameSteps.CutsceneWatched);

        GetComponent<DoorController>().SetLock(false);
    }
}
