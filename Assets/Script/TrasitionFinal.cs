using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasitionFinal : MonoBehaviour {
    public GameObject anim;

    public void FinalGame() {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene() {
        anim.SetActive(true);
        yield return new WaitForSeconds(8.2f);
        SceneManager.LoadScene("Credits");
    }
}
