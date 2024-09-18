using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using Assets.Script;

public class NormalMapChanger : MonoBehaviour
{
    public PlayerData playerData;
    public GameSteps step;
    public Material material;
    public float startValue = 0f;
    public float endValue = 1f;
    public float duration = 2f;

    void Start() {
        if (playerData.steps.Contains(step)) {
            material.SetFloat("_BumpScale", endValue);
            gameObject.tag = "Door";
        }
        else {
            material.SetFloat("_BumpScale", startValue);
            gameObject.tag = "Untagged";
        }
    }

    public void CleanDoor()
    {
        gameObject.tag = "Door";
        material.SetFloat("_BumpScale", startValue);

        DOTween.To(() => material.GetFloat("_BumpScale"), 
                   x => material.SetFloat("_BumpScale", x), 
                   endValue, 
                   duration);
    }
}
