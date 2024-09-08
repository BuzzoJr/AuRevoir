using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLight : MonoBehaviour
{
    public int valorLuz; // O valor da luz (1, 2, 3, 5, 8) definido no inspector
    public Material materialLigada; // Material da luz ligada
    public Material materialDesligada; // Material da luz desligada
    public bool estaLigada; // Estado atual da luz
    private Renderer rendererLuz;
    
    public AudioClip somAcender;
    private AudioSource audioSource;

    private void Start()
    {
        rendererLuz = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        AtualizarLuz();
    }

    public void OnClick()
    {
        AlternarLuz();
    }

    public void AlternarLuz()
    {
        estaLigada = !estaLigada;
        AtualizarLuz();

        if(somAcender != null)
            audioSource.PlayOneShot(somAcender);

        transform.parent.gameObject.GetComponentInParent<PuzzleLine>().AtualizarSoma();
    }

    private void AtualizarLuz()
    {
        rendererLuz.material = estaLigada ? materialLigada : materialDesligada;
    }
}
