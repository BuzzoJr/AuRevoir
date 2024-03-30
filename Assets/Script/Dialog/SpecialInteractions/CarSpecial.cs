using Assets.Script.Interaction;
using UnityEngine;

public class CarSpecial : MonoBehaviour, ISpecial
{
    public GameObject allMap, directLight, mainCamera;

    public void Special(GameObject who)
    {
        allMap.SetActive(true);
        directLight.SetActive(false);
        mainCamera.SetActive(false);
    }
}
