using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Script;

public class PuzzleSewer : MonoBehaviour
{
    public static PuzzleSewer instance;
    public PlayerData playerData;
    public GameSteps steps1, steps2;
    public NormalMapChanger doorSewer;

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

        if (playerData.steps.Contains(steps1))
        {
            GetComponent<LookClose>().enabled = false;
            GetComponent<PuzzleSewer>().enabled = false;
            GetComponent<InspectPuzzleSewer>().enabled = false;
            gameObject.tag = "Untagged";
        }
    }

    void Start() {
        AttValores();
    }

    public void AttValores() {
        if (playerData.steps.Contains(steps2)) {
            LoadValoresLinhas();
        }
        else {
            SortearValoresParaLinhas();
        }

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
        doorSewer.CleanDoor();
        GetComponent<LookClose>().CustomExitAnim();
        gameObject.tag = "Untagged";
        playerData.AddStep(GameSteps.PuzzleSewerResolved);

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

        SalvarValoresLinhas(); // Salva os valores gerados
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

    private void SalvarValoresLinhas()
    {
        for (int i = 0; i < valoresLinhas.Length; i++)
        {
            PlayerPrefs.SetInt("ValorLinha_" + i, valoresLinhas[i]);
        }
        PlayerPrefs.Save(); // Salva todos os valores no PlayerPrefs
    }

    private void LoadValoresLinhas()
    {
        valoresLinhas = new int[linhas.Length];
        bool valoresCarregados = false;

        for (int i = 0; i < valoresLinhas.Length; i++)
        {
            if (PlayerPrefs.HasKey("ValorLinha_" + i))
            {
                valoresLinhas[i] = PlayerPrefs.GetInt("ValorLinha_" + i);
                valoresCarregados = true;
            }
        }

        if (!valoresCarregados)
        {
            SortearValoresParaLinhas(); // Se não houver valores salvos, sortear novos
        }
    }
}
