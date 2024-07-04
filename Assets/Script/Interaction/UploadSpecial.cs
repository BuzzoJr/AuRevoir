using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;
using Assets.Script.Interaction;
using UnityEngine.UI;

public class UploadSpecial : MonoBehaviour, IUseSpecial
{
    public Image btnImg;
    public Sprite newImgBtn;
    public GameObject allCanvasUpload, blackScreen;
    public Volume analogGlitchVolume;  // Referência ao Volume que possui os efeitos de glitch analógico
    public Volume digitalGlitchVolume; // Referência ao Volume que possui os efeitos de glitch digital

    public AnalogGlitchVolume analogGlitch;
    public DigitalGlitchVolume digitalGlitch;

    private void Start()
    {
        analogGlitchVolume.profile.TryGet(out analogGlitch);
        digitalGlitchVolume.profile.TryGet(out digitalGlitch);
    }

    public void UseSpecial(GameObject who)
    {
        StartCoroutine(DelayScreen());
        //Invoke("GetUp", 5f);
    }

    void GetUp()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        PlayerController.anim.SetBool("Sit", false);
        PlayerController.anim.SetBool("SitIdle2", false);
    }

    private IEnumerator DelayScreen()
    {
        yield return new WaitForSeconds(3f);
        allCanvasUpload.SetActive(true);
    }

    private IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(10f);

        float duration = 5f; // Duração da transição
        float elapsedTime = 0f;

        float startScanLineJitter = analogGlitch.scanLineJitter.value;
        float endScanLineJitter = 0.5f;

        float startVerticalJump = analogGlitch.verticalJump.value;
        float endVerticalJump = 0.5f;

        float startHorizontalShake = analogGlitch.horizontalShake.value;
        float endHorizontalShake = 0.5f;

        float startColorDrift = analogGlitch.colorDrift.value;
        float endColorDrift = 0.5f;

        float startIntensity = digitalGlitch.intensity.value;
        float endIntensity = 0.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            analogGlitch.scanLineJitter.value = Mathf.Lerp(startScanLineJitter, endScanLineJitter, t);
            analogGlitch.verticalJump.value = Mathf.Lerp(startVerticalJump, endVerticalJump, t);
            analogGlitch.horizontalShake.value = Mathf.Lerp(startHorizontalShake, endHorizontalShake, t);
            analogGlitch.colorDrift.value = Mathf.Lerp(startColorDrift, endColorDrift, t);

            digitalGlitch.intensity.value = Mathf.Lerp(startIntensity, endIntensity, t);

            yield return null;
        }

        analogGlitch.scanLineJitter.value = endScanLineJitter;
        analogGlitch.verticalJump.value = endVerticalJump;
        analogGlitch.horizontalShake.value = endHorizontalShake;
        analogGlitch.colorDrift.value = endColorDrift;

        digitalGlitch.intensity.value = endIntensity;

        yield return new WaitForSeconds(1f);
        //Aqui parar som de glitch
        blackScreen.SetActive(true);
        allCanvasUpload.SetActive(false);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        SceneManager.LoadScene("C0Bedroom");
    }

    public void LoadingFunc()
    {
        StartCoroutine(DelayLoading());
    }

    public void SelectSubject() {
        btnImg.sprite = newImgBtn;
    }
}
