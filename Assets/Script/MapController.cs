using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour {
    public Animator mapAnim;
    public GameObject[] selectLabel;
    public List<int> sceneBuildIndexList; //ALTERAR FUTURAMENTE PARA TER AS ID'S CORRETAS!!
    private int finalDestiny, startDestiny;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
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

    public void SelectDestiny(int point) { //Habilita seleção visual de cada ponto do mapa, da SET na variável que determina o destino
        foreach (GameObject obj in  selectLabel) {
            obj.SetActive(false);
        }

        selectLabel[point].SetActive(true);
        finalDestiny = point;
        PlayerPrefs.SetInt("LastMapSelect", point);
    }

    public void GoToDestiny() { //Vai p/ o destino selecionado
        StartCoroutine(DelayExitMap());
    }

    void OnEnable() { //Garante que nao de LoadScene se clicar no msm lugar
        startDestiny = finalDestiny;
    }

    IEnumerator DelayExitMap()
    {
        mapAnim.SetTrigger("Exit");
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);

        if(startDestiny != finalDestiny)
            SceneManager.LoadScene(sceneBuildIndexList[finalDestiny]);
    }
}
