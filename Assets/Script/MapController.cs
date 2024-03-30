using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour {
    public GameObject[] selectLabel;
    public List<int> sceneBuildIndexList; //ALTERAR FUTURAMENTE PARA TER AS ID'S CORRETAS!!
    private int finalDestiny;

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
        SceneManager.LoadScene(sceneBuildIndexList[finalDestiny]);
    }
}
