using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class ManualSpecialInteraction : MonoBehaviour, ISpecial
{
    [SerializeField] private GameObject Key;
    public void Special(GameObject who)
    {
        Key.SetActive(true);
        Destroy(gameObject);
    }
}
