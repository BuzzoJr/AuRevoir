using System.Collections;
using System.Collections.Generic;
using Assets.Script.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InspectPuzzleSewer : MonoBehaviour, ILookSpecial
{
    public GameObject player, exitPuzzle;
    public Transform target;

    public void LookSpecial(GameObject who)
    {
        player.transform.LookAt(target);
        StartCoroutine("Peephole");
    }

    private IEnumerator Peephole()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        exitPuzzle.SetActive(true);
        yield return new WaitUntil(() => IsMouseClickOnObject());
    }

    private bool IsMouseClickOnObject()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se houve clique esquerdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cria um ray a partir da posição do mouse
            if (Physics.Raycast(ray, out RaycastHit hit)) // Verifica se o ray colide com algo
            {
                if (hit.collider.tag == "Finish") // Verifica se o objeto colidido tem a tag específica
                {
                    gameObject.GetComponent<BoxCollider>().enabled = true;
                    exitPuzzle.SetActive(false);
                    GetComponent<LookClose>().CustomExitAnim();
                    return true;
                }
                else if(hit.collider.gameObject.GetComponent<PuzzleLight>() != null) {
                    hit.collider.gameObject.GetComponent<PuzzleLight>().OnClick();
                }
            }
        }
        return false;
    }
}