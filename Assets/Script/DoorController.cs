using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public SceneRef moveRef = SceneRef.SampleScene;
    public GameObject transObj, globalObj;
    public bool locked = false;

    public enum SceneRef
    {
        C1Bedroom,
        C2Livingroom,
        C3Office,
        C7Beco,
        C8ExteriorLavanderia,
        C9InteriorLavanderia,
        C10Transicao,
        C15ExteriorLab,
        C16Laboratory,
        SampleScene
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!locked && other.CompareTag("Player"))
        {
            Debug.Log(moveRef.ToString());
            if (transObj != null)
                StartCoroutine(delayTransition());
            else
                SceneManager.LoadScene("Scenes/" + moveRef.ToString());
        }
    }

    IEnumerator delayTransition()
    {
        globalObj.SetActive(false);
        transObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scenes/" + moveRef.ToString());
    }
}
