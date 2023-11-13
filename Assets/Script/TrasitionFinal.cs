using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasitionFinal : MonoBehaviour {
    public GameObject anim;
    public GameObject credits;
    public GameObject mainCanvas;
    public float delay = 8.12f;

    public void FinalGame() {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene() {
        anim.SetActive(true);
        yield return new WaitForSeconds(delay);
        credits.SetActive(true);
        mainCanvas.SetActive(false);
    }
}
