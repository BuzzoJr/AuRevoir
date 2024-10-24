using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasitionFinal : MonoBehaviour
{
    public GameObject anim;
    public GameObject credits;
    public GameObject mainCanvas;
    public GameObject allInteract;
    public float delay = 8.12f;

    public void FinalGame()
    {
        StartCoroutine(NextScene());
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator NextScene()
    {
        anim.SetActive(true);
        Destroy(GameObject.Find("InventoryItems"));
        Destroy(GameObject.Find("InventoryDocs"));
        Destroy(GameObject.Find("InventoryNotes"));
        Destroy(GameObject.Find("InventoryMap"));
        yield return new WaitForSeconds(delay);
        allInteract.SetActive(false);
        credits.SetActive(true);
        mainCanvas.SetActive(false);
    }
}
