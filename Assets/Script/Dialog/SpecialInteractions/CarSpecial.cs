using Assets.Script.Interaction;
using UnityEngine;

public class CarSpecial : MonoBehaviour, IUseSpecial
{
    public GameObject allMap, directLight, mainCamera;

    public void UseSpecial(GameObject who)
    {
        allMap.SetActive(true);

        if(directLight != null)
            directLight.SetActive(false);

        mainCamera.SetActive(false);
    }
}
