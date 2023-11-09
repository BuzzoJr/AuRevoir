using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Interaction;

public class ItemInteraction : MonoBehaviour, IUseItem
{
    private AudioSource m_AudioSource;
    [SerializeField] private Animator animator;
    [SerializeField] private DoorController door;
    public void UseItem(GameObject who)
    {
        Debug.Log("ACHOU USE ITEM");
        Debug.Log(who);
        m_AudioSource.Play();
        door.locked = false;
        animator.SetBool("OpenApartamentDoor", true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
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
