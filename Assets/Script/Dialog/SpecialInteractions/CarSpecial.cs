using Assets.Script.Interaction;
using UnityEngine;

public class CarSpecial : MonoBehaviour, ILookSpecial
{
    public GameObject allMap, directLight, mainCamera;

    public void LookSpecial(GameObject who)
    {
        allMap.SetActive(true);
        directLight.SetActive(false);
        mainCamera.SetActive(false);
    }
}
