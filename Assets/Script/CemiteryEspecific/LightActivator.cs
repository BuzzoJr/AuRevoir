using UnityEngine;

public class LightActivator : MonoBehaviour
{
    public Transform player; // Posição do jogador
    public GameObject[] lightsLeft;  // Array de luzes à esquerda
    public GameObject[] lightsRight; // Array de luzes à direita
    public float activationDistance = 5f; // Distância mínima para ativar as luzes

    private bool[] lightsActivated; // Controle para ver quais luzes já foram ativadas

    void Start()
    {
        lightsActivated = new bool[lightsLeft.Length];
    }

    void Update()
    {
        for (int i = 0; i < lightsLeft.Length; i++)
        {
            if (!lightsActivated[i] && Vector3.Distance(player.position, lightsLeft[i].transform.position) <= activationDistance)
            {
                ActivateLights(i);
            }
        }
    }

    void ActivateLights(int index)
    {
        lightsLeft[index].SetActive(true);
        lightsRight[index].SetActive(true);
        lightsActivated[index] = true;
    }
}
