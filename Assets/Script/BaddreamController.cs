using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BaddreamController : MonoBehaviour
{
    public Volume volume;
    public GameObject phatom;
    private Vignette vignette;
    private FilmGrain filmGrain;

    private void Start()
    {
        // Verifica se o volume e o Vignette foram atribuídos
        if (volume == null || !volume.profile.TryGet(out vignette) || !volume.profile.TryGet(out filmGrain))
        {
            Debug.LogError("Volume ou Vignette não configurado corretamente.");
            return;
        }

        // Inicia a transição
        StartCoroutine(ChangeVignette(9.6f));
    }

    private IEnumerator ChangeVignette(float duration)
    {
        float time = 0f;

        // Salva os valores iniciais e finais
        float initialIntensity = vignette.intensity.value;
        float finalIntensity = 0.7f;

        float initialSmoothness = vignette.smoothness.value;
        float finalSmoothness = 0.7f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            // Interpola os valores de Intensity e Smoothness
            vignette.intensity.value = Mathf.Lerp(initialIntensity, finalIntensity, t);
            vignette.smoothness.value = Mathf.Lerp(initialSmoothness, finalSmoothness, t);

            filmGrain.intensity.value = Mathf.Lerp(initialSmoothness, finalSmoothness, t);

            yield return null; // Espera até o próximo frame
        }

        // Assegura que os valores finais são exatamente os desejados
        phatom.GetComponent<Animator>().enabled = false;
        vignette.intensity.value = finalIntensity;
        vignette.smoothness.value = finalSmoothness;
        filmGrain.intensity.value = finalIntensity;
    }
}
