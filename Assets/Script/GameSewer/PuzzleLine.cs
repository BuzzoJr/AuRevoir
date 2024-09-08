using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLine : MonoBehaviour
{
    public int valorObjetivo; // O valor que essa linha precisa alcançar
    private PuzzleLight[] luzes; // Todas as luzes da linha
    private int somaAtual;

    private void Start()
    {
        luzes = GetComponentsInChildren<PuzzleLight>();
        AtualizarSoma();
    }

    public void AtualizarSoma()
    {
        somaAtual = 0;
        foreach (PuzzleLight luz in luzes)
        {
            if (luz.estaLigada)
            {
                somaAtual += luz.valorLuz;
            }
        }

        PuzzleSewer.instance.VerificarPuzzle();
    }

    public bool EstaCorreta()
    {
        return somaAtual == valorObjetivo;
    }
}
