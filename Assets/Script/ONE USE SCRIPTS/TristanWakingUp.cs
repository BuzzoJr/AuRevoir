using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TristanWakingUp : MonoBehaviour
{
    public GameObject playableTristan; // Assign this in the Inspector
    public bool wakeUpScare = false;
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        if(wakeUpScare)
            StartCoroutine(ChangeSpeedTemporarily());
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

    private IEnumerator ChangeSpeedTemporarily()
    {
        float originalSpeed = animator.speed;
        animator.speed = 3f;
        yield return new WaitForSeconds(0.8f);
        animator.speed = 0.05f;
        yield return new WaitForSeconds(1f);
        animator.speed = 0.5f;
        yield return new WaitForSeconds(3f);
        animator.speed = originalSpeed;
    }
}
