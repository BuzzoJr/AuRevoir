using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public Animator mapAnim;
    public GameObject labelsCanvas;
    public GameObject videoTransition1, videoTransition0;
    public GameObject[] selectLabel;
    public List<SceneRef> sceneBuildList;
    public AudioSource audioOn, audioOff;

    [Header("Hide/Show elements")]
    public PlayerData playerData;
    public List<GameSteps> elementsSteps;
    public List<GameObject> elementsCanvas;
    public List<GameObject> elements3D;
    public GameObject travelVisual;
    public GameObject travelBtn;

    private int finalDestiny;
    private GameObject mainCam;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("LastMapSelect"))
        {
            PlayerPrefs.SetInt("LastMapSelect", 0);
            SelectDestiny(0);
        }
        else
        {
            SelectDestiny(PlayerPrefs.GetInt("LastMapSelect"));
        }
    }

    void OnEnable()
    { //Garante que nao de LoadScene se clicar no msm lugar
        mainCam = GameObject.FindWithTag("MainCamera");
        labelsCanvas.SetActive(true);
        audioOn.Play();

        for (int i = 0; i < Mathf.Min(elementsSteps.Count, elementsCanvas.Count, elements3D.Count); i++)
        {
            bool active = true;
            if (elementsSteps[i] != GameSteps.None && !playerData.HasStep(elementsSteps[i]))
                active = false;

            elementsCanvas[i].SetActive(active);
            elements3D[i].SetActive(active);
        }
    }

    public void SelectDestiny(int point)
    {
        foreach (GameObject obj in selectLabel)
        {
            obj.SetActive(false);
        }

        selectLabel[point].SetActive(true);
        finalDestiny = point;
        checkTravel();
    }

    public void GoToDestiny()
    {
        StartCoroutine(DelayExitMap(false));
    }

    IEnumerator DelayExitMap(bool exit)
    {
        labelsCanvas.SetActive(false);
        mapAnim.SetTrigger("Exit");
        audioOff.Play();
        yield return new WaitForSeconds(0.3f);

        string curScene = SceneManager.GetActiveScene().name;
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        if (!exit && curScene != sceneBuildList[finalDestiny].ToString())
        {
            PlayerPrefs.SetInt("LastMapSelect", finalDestiny);

            //Provavelmente vai ter q add o esquema do almas para carregar corretamente o video antes de dar play, para n aparecer o video anterior
            if(finalDestiny == 1) {
                videoTransition1.SetActive(true);
                yield return new WaitForSeconds(4f);
            }
            else {
                videoTransition0.SetActive(true);
                yield return new WaitForSeconds(4f);
            }

            SceneManager.LoadScene(sceneBuildList[finalDestiny].ToString());
        }
        else
        {
            mainCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void ExitMap()
    {
        StartCoroutine(DelayExitMap(true));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        videoTransition1.SetActive(false);
        videoTransition0.SetActive(false);
        labelsCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    void checkTravel()
    {
        string curScene = SceneManager.GetActiveScene().name;
        if (curScene == sceneBuildList[finalDestiny].ToString())
        {
            travelVisual.SetActive(false);
            travelBtn.SetActive(false);
        }
        else
        {
            travelVisual.SetActive(true);
            travelBtn.SetActive(true);
        }

    }
}
