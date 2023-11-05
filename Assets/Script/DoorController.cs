using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public SceneRef moveRef = SceneRef.SampleScene;
    public GameObject transObj, globalObj;
    public bool locked = false;

    private Animator anim;

    public enum SceneRef
    {
        C1Bedroom,
        C2Livingroom,
        C3Office,
        C4GuardedWall,
        C5SewersAccess,
        C6Sewers,
        C7Alley,
        C8ExteriorLavanderia,
        C9InteriorLavanderia,
        C10Transicao,
        C15ExteriorLab,
        C16Laboratory,
        SampleScene
    }

    void Start()
    {
        if (transform.parent.TryGetComponent(out anim))
            anim.SetBool("Locked", locked);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!locked && other.CompareTag("Player"))
        {
            Debug.Log(moveRef.ToString());
            if (transObj != null)
                StartCoroutine(DelayTransition());
            else
                SceneManager.LoadScene("Scenes/" + moveRef.ToString());
        }
    }

    IEnumerator DelayTransition()
    {
        globalObj.SetActive(false);
        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/" + moveRef.ToString());
    }

    public void SetLock(bool value)
    {
        locked = value;
        if (anim)
            anim.SetBool("Locked", locked);
    }
}
