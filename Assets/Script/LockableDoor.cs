using UnityEngine;

public class C16Door : MonoBehaviour
{
    private DoorController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponentInChildren<DoorController>();
        anim = GetComponent<Animator>();
    }

    public void Close()
    {
        controller.locked = true;
        // TODO: play close anim
    }

    public void Open()
    {
        // TODO: play open anim
        controller.locked = false;
    }
}
