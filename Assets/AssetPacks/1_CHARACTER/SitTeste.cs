using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;

public class SitTeste : MonoBehaviour, ILookSpecial
{
    public void LookSpecial(GameObject who)
    {
        PlayerController.anim.SetBool("Sit", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
