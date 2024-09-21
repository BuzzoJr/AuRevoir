using Assets.Script.Locale;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecorderController : MonoBehaviour, ILangConsumer
{
    public GameObject openRecorder;
    public GameObject ui;
    public Transform sliders;
    public int symbolsCount = 5;
    public Transform display;
    public float displayLerpDelay = 0.5f;

    [Header("Recording List")]
    public GameObject prefab;
    public List<Recording> recordings;
    private List<GameObject> recordingDisplayInstances = new();

    [Header("Noise List")]
    public List<AudioClip> noises;

    private AudioSource audioSource;
    private int current = 0;

    private float displayLastPosition;
    private float displayDistanceToNext;
    private float displayLerpTimer = 0f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        GridLayoutGroup grid = display.GetComponent<GridLayoutGroup>();
        displayDistanceToNext = grid.cellSize.y + grid.spacing.y;
        displayLastPosition = display.position.y;

        foreach (Recording recording in recordings)
        {
            GameObject recordingDisplay = Instantiate(prefab, display);
            recordingDisplayInstances.Add(recordingDisplay);
            recordingDisplay.GetComponentInChildren<TMP_Text>().text = Locale.Texts[recording.textGroup][recording.textIndex].Text;
        }

        foreach (RecorderSliderSnap snapper in sliders.GetComponentsInChildren<RecorderSliderSnap>())
            snapper.divisions = symbolsCount;

        Locale.RegisterConsumer(this);
    }

    private void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    public void UpdateLangTexts()
    {
        // File name
        for (int i = 0; i < recordings.Count; i++)
            recordingDisplayInstances[i].GetComponent<TMP_Text>().text = Locale.Texts[recordings[i].textGroup][recordings[i].textIndex].Text;
    }

    void Update()
    {
        LerpDisplay();
    }

    private void LerpDisplay()
    {
        float dest = current * displayDistanceToNext;
        if (display.position.y == dest)
        {
            displayLerpTimer = 0f;
            return;
        }

        Vector3 pos = display.position;

        displayLerpTimer -= Time.deltaTime;
        if (displayLerpTimer <= 0f)
        {
            pos.y = current * displayDistanceToNext;
            displayLerpTimer = 0f;
        }
        else
        {
            pos.y = Mathf.Lerp(dest, displayLastPosition, displayLerpTimer / displayLerpDelay);
        }

        display.position = pos;
    }

    public void UpPressed()
    {
        if (current <= 0)
            return;

        current--;

        displayLastPosition = display.position.y;
        displayLerpTimer = displayLerpDelay;
    }

    public void DownPressed()
    {
        if (current >= recordings.Count - 1)
            return;

        current++;

        displayLastPosition = display.position.y;
        displayLerpTimer = displayLerpDelay;
    }

    public void StopPressed()
    {
        audioSource.Stop();
    }

    public void PlayPressed()
    {
        audioSource.Stop();
        if (CompareSymbols())
            audioSource.PlayOneShot(recordings[current].clip);
        else
            audioSource.PlayOneShot(noises[Random.Range(0, noises.Count)]); // Random noise
    }

    public bool CompareSymbols()
    {
        int index = 0;
        foreach (Slider slider in sliders.GetComponentsInChildren<Slider>())
        {
            if (Mathf.Round(slider.value * (symbolsCount - 1)) != recordings[current].symbols[index])
                return false;

            index++;
        }

        return true;
    }
}
