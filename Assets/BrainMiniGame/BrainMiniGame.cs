using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;

public class BrainMiniGame : MonoBehaviour, IUse
{
    public GameObject camMain;
    public GameObject camMiniGame;
    public GameObject canvas;
    public TMP_Text title;
    public GameObject[] menus;
    public GameObject[] pages;
    public Animator brainAnim;

    void Awake()
    {
        title.text = Locale.Texts[TextGroup.BrainMiniGame][0].Text;

        for (int i = 0; i < menus.Length; i++)
            menus[i].GetComponentInChildren<TMP_Text>().text = Locale.Texts[TextGroup.BrainMiniGame][i + 1].Text;

        for (int i = 1; i < pages.Length; i++)
            pages[i].GetComponentInChildren<TMP_Text>().text = Locale.Texts[TextGroup.BrainMiniGame][i + 6].Text;
    }

    public void Use(GameObject who)
    {
        StartCoroutine(UseBrainMiniGame());
    }

    IEnumerator UseBrainMiniGame()
    {
        PlayerController.navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        canvas.SetActive(true);
        camMain.SetActive(false);
        camMiniGame.SetActive(true);
    }

    public void EndMiniGame()
    {
        camMiniGame.SetActive(false);
        camMain.SetActive(true);
        canvas.SetActive(false);
    }

    public void SelectPage(int page)
    {
        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive((i == page));
    }
}
