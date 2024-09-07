using UnityEngine;
using DG.Tweening;

public class NormalMapChanger : MonoBehaviour
{
    public Material material; // Material que você deseja alterar
    public float startValue = 0f; // Valor inicial do normal map
    public float endValue = 1f; // Valor final do normal map
    public float duration = 2f; // Tempo para a transição

    void Start()
    {
        // Definir o valor inicial do normal map
        material.SetFloat("_BumpScale", startValue);

        // Usar DOTween para fazer a transição
        DOTween.To(() => material.GetFloat("_BumpScale"), 
                   x => material.SetFloat("_BumpScale", x), 
                   endValue, 
                   duration);
    }
}
