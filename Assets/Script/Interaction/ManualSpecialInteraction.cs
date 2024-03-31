using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class ManualSpecialInteraction : MonoBehaviour, IUseSpecial
{
    [SerializeField] private GameObject Key;
    public void UseSpecial(GameObject who)
    {
        Key.SetActive(true);
        Destroy(gameObject);
    }
}
