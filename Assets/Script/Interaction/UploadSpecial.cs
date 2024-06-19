using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class UploadSpecial : MonoBehaviour, IUseSpecial
{
    public void UseSpecial(GameObject who)
    {
        Invoke("GetUp", 5f);
    }

    void GetUp()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        PlayerController.anim.SetBool("Sit", false);
        PlayerController.anim.SetBool("SitIdle2", false);
    }
}
