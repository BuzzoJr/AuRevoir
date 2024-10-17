using UnityEngine;

public class LightActivator : MonoBehaviour
{
    public Transform player; // Posição do jogador
    public GameObject[] lightsLeft;  // Array de luzes à esquerda
    public GameObject[] lightsRight; // Array de luzes à direita
    public float activationDistance = 20f; // Distância mínima para ativar as luzes
    public float extinguishTime = 20f; // Tempo para apagar as luzes se o jogador ficar longe

    private bool[] lightsActivated;  // Controle para ver quais luzes já foram ativadas
    private float[] timeSinceLastClose; // Contador de tempo desde que o jogador ficou longe de cada luz

    void Start()
    {
        lightsActivated = new bool[lightsLeft.Length];
        timeSinceLastClose = new float[lightsLeft.Length];
    }

    void Update()
    {
        for (int i = 0; i < lightsLeft.Length; i++)
        {
            float distance = Vector3.Distance(player.position, lightsLeft[i].transform.position);

            if (distance <= activationDistance && !lightsActivated[i])
            {
                ActivateLights(i); // Ativa as luzes quando o jogador se aproxima
            }
            else if (distance > activationDistance && lightsActivated[i])
            {
                timeSinceLastClose[i] += Time.deltaTime; // Conta o tempo que o jogador está longe
                if (timeSinceLastClose[i] >= extinguishTime)
                {
                    DeactivateLights(i); // Apaga as luzes se o tempo longe for maior que `extinguishTime`
                }
            }
            else
            {
                timeSinceLastClose[i] = 0f; // Reseta o tempo caso o jogador esteja próximo
            }
        }
    }

    void ActivateLights(int index)
    {
        lightsLeft[index].SetActive(true);
        lightsRight[index].SetActive(true);
        lightsActivated[index] = true;
        timeSinceLastClose[index] = 0f; // Reseta o contador de tempo
    }

    void DeactivateLights(int index)
    {
        lightsLeft[index].SetActive(false);
        lightsRight[index].SetActive(false);
        lightsActivated[index] = false;
    }
}
