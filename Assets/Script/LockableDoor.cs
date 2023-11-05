using UnityEngine;

public class LockableDoor : MonoBehaviour
{
    public bool locked = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetLock(bool value)
    {
        locked = value;
        if (anim)
            anim.SetBool("Locked", locked);
    }
}
