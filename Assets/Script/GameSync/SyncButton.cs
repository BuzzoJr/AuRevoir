using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SyncButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public SyncWave syncEditLine;
    public float valorMinimo = 0f;
    public float valorMaximo = 1f;
    public float valorAtual = 0.5f; // Valor inicial
    public float suavizacao = 50f; // Fator de suavização

    private float anguloInicial;
    private float valorIntervalo;
    private Quaternion rotacaoInicial;

    private bool arrastando = false;

    private void Start()
    {
        // Armazena a rotação inicial do botão e calcula o intervalo de valores
        rotacaoInicial = transform.rotation;
        anguloInicial = AnguloNormalizado(rotacaoInicial);
        valorIntervalo = valorMaximo - valorMinimo;
    }

    private void Update()
    {
        if (arrastando)
        {
            // Atualiza a rotação do botão enquanto está sendo arrastado
            AtualizarRotacao(Input.mousePosition);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        arrastando = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        arrastando = false;
    }

    private void AtualizarRotacao(Vector3 posicaoMouse)
    {
        // Converte a posição do mouse em coordenadas locais do botão
        Vector3 posicaoLocal = transform.InverseTransformPoint(posicaoMouse);

        // Calcula o ângulo atual do botão em relação à sua posição inicial
        float angulo = Mathf.Atan2(posicaoLocal.y, posicaoLocal.x) * Mathf.Rad2Deg;

        // Aplica a suavização do movimento
        angulo = Mathf.Lerp(AnguloNormalizado(transform.rotation), angulo + anguloInicial, Time.deltaTime * suavizacao);

        // Aplica a rotação
        transform.rotation = Quaternion.Euler(0, 0, angulo);

        // Calcula o valor atual com base no ângulo
        float percentual = (angulo + 180f) / 360f;
        valorAtual = Mathf.Clamp(valorMinimo + percentual * valorIntervalo, valorMinimo, valorMaximo);
        syncEditLine.frequency = valorAtual;
    }

    // Função auxiliar para normalizar o ângulo para o intervalo [-180, 180]
    private float AnguloNormalizado(Quaternion rotacao)
    {
        float angulo = rotacao.eulerAngles.z;
        if (angulo > 180f)
            angulo -= 360f;

        return angulo;
    }
}
