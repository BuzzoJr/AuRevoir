using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TristanWakingUp : MonoBehaviour
{
    public GameObject playableTristan; // Assign this in the Inspector
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the animator is currently playing the "Idle" animation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Invoke("ChangePlayer", 0.3f);
        }
    }

    void ChangePlayer()
    {
        // Activate the playableTristan GameObject
        playableTristan.SetActive(true);
        // Destroy this GameObject
        Destroy(this.gameObject);
    }
}
