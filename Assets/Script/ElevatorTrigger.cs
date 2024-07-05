using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public float triggerDistance = 5f; // Distância para ativar os triggers
    public Animator animator;
    private Transform playerTransform;
    private bool isOpenTriggered = false;
    private bool isCloseTriggered = false;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null && animator != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance <= triggerDistance && !isOpenTriggered)
            {
                isOpenTriggered = true;
                isCloseTriggered = false;
                animator.SetBool("Close", isCloseTriggered);
                animator.SetBool("Open", isOpenTriggered);
            }
            else if (distance > triggerDistance && !isCloseTriggered)
            {
                isCloseTriggered = true;
                isOpenTriggered = false;
                animator.SetBool("Close", isCloseTriggered);
                animator.SetBool("Open", isOpenTriggered);
            }
        }
    }
}