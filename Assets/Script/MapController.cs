using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public Animator mapAnim;
    public GameObject labelsCanvas;
    public GameObject[] selectLabel;
    public List<int> sceneBuildIndexList; //ALTERAR FUTURAMENTE PARA TER AS ID'S CORRETAS!!

    [Header("Hide/Show elements")]
    public PlayerData playerData;
    public List<GameSteps> elementsSteps;
    public List<GameObject> elementsCanvas;
    public List<GameObject> elements3D;
    private int finalDestiny, startDestiny;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("LastMapSelect"))
        {
            PlayerPrefs.SetInt("LastMapSelect", 0);
        }
        else
        {
            SelectDestiny(PlayerPrefs.GetInt("LastMapSelect"));
        }

        startDestiny = finalDestiny;
    }

    void OnEnable()
    { //Garante que nao de LoadScene se clicar no msm lugar
        Debug.Log("TESTE NO OnEnable");

        startDestiny = finalDestiny;

        for (int i = 0; i < Mathf.Min(elementsSteps.Count, elementsCanvas.Count, elements3D.Count); i++)
        {
            bool active = true;
            if (elementsSteps[i] != GameSteps.None && !playerData.steps.Contains(elementsSteps[i]))
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
    }

    public void GoToDestiny()
    {
        PlayerPrefs.SetInt("LastMapSelect", finalDestiny);
        StartCoroutine(DelayExitMap());
    }

    IEnumerator DelayExitMap()
    {
        labelsCanvas.SetActive(false);
        mapAnim.SetTrigger("Exit");
        yield return new WaitForSeconds(0.3f);

        if (startDestiny != finalDestiny)
            SceneManager.LoadScene(sceneBuildIndexList[finalDestiny]);

        labelsCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitMap()
    {
        finalDestiny = startDestiny;
        StartCoroutine(DelayExitMap());
    }
}
