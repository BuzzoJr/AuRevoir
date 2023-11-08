using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interaction;

public class ItemInteraction : MonoBehaviour, IUseItem
{
    private AudioSource m_AudioSource;
    [SerializeField] private Animator animator;
    public void UseItem(GameObject who)
    {
        Debug.Log("ACHOU USE ITEM");
        Debug.Log(who);
        m_AudioSource.Play();
        animator.SetBool("OpenApartamentDoor", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
