using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleSewer : MonoBehaviour
{
    public static PuzzleSewer instance;
    private PuzzleLine[] linhas;
    public TMP_Text[] resultadoTMP;
    private int[] valoresPossiveis = { 1, 2, 3, 5, 8 };
    public int[] valoresLinhas;
    private HashSet<int> valoresGerados;
    public AudioClip somConcluir;
    private AudioSource audioSource;

    void Awake() {
        instance = this;
        linhas = GetComponentsInChildren<PuzzleLine>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        SortearValoresParaLinhas();
        AtualizarTMPText();
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

    private void SortearValoresParaLinhas()
    {
        List<int> valoresGerados = new List<int>(); // Lista para armazenar os valores já gerados

        for (int i = 0; i < linhas.Length; i++)
        {
            int valorSorteado = 0;

            do
            {
                valorSorteado = GerarSomaAleatoria();
            } while (valoresGerados.Contains(valorSorteado)); // Garante que não repita

            valoresGerados.Add(valorSorteado); // Adiciona o valor gerado
            valoresLinhas[i] = valorSorteado;
        }
    }

    private int GerarSomaAleatoria()
    {
        int soma = 0;

        for (int i = 0; i < valoresPossiveis.Length; i++)
        {
            if (Random.value > 0.4f) 
            {
                soma += valoresPossiveis[i];
            }
        }

        return soma;
    }

    private void AtualizarTMPText()
    {
        for (int i = 0; i < valoresLinhas.Length; i++)
        {
            linhas[i].valorObjetivo = valoresLinhas[i];
            resultadoTMP[i].text = valoresLinhas[i].ToString();
        }
    }
}
