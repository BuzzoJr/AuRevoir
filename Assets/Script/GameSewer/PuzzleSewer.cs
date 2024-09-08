using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSewer : MonoBehaviour
{
    public static PuzzleSewer instance;
    private PuzzleLine[] linhas;
    public AudioClip somConcluir;
    private AudioSource audioSource;

    void Awake() {
        instance = this;
        linhas = GetComponentsInChildren<PuzzleLine>();
        audioSource = GetComponent<AudioSource>();
    }

    public void VerificarPuzzle()
    {
        foreach (PuzzleLine linha in linhas)
        {
            if (!linha.EstaCorreta())
            {
                return;
            }
        }

        PuzzleResolvido();
    }

    private void PuzzleResolvido()
    {
        Debug.Log("Puzzle resolvido!");
        GetComponent<LookClose>().CustomExitAnim();
        gameObject.tag = "Untagged";

        if(somConcluir != null)
            audioSource.PlayOneShot(somConcluir);
    }
}
