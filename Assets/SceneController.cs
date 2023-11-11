using Assets.Script.Locale;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerData playerData;
    public Transform playerPos;
    public List<GameObject> spawnPosition = new List<GameObject>();
    [Header("FIRST TIME IN SCENE")]
    [SerializeField] private bool HasText = false;
    public TextGroup textGroup = TextGroup.DialogWakeUpCall;
    [SerializeField] private GameObject dialogBox;
    private TMP_Text dialogText;
    private void Awake()
    {
        dialogText = dialogBox.GetComponentInChildren<TMP_Text>();
        if (playerData.previousScene != null)
        {
            foreach (GameObject spawnPos in spawnPosition)
            {
                if (spawnPos.name == playerData.previousScene)
                {
                    playerPos.position = new Vector3(spawnPos.transform.position.x, playerPos.position.y, spawnPos.transform.position.z);
                    playerPos.rotation = Quaternion.Euler(0f, spawnPos.transform.rotation.eulerAngles.y, 0f);

                    break;
                }
            }
        }
        playerData.previousScene = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        if (GameManager.Instance.IsFirstTimeInScene(gameObject.scene.name) && HasText)
        {
            StartCoroutine(DoFirstTimeAction());
        }
    }

    IEnumerator DoFirstTimeAction()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        dialogBox.SetActive(true);
        foreach (TextData data in Locale.Texts[textGroup])
        {
            dialogText.color = TextColorManager.textTypeColors[data.Type];
            dialogText.text = data.Type != TextType.Player ? data.Type + ": " + data.Text : data.Text;

            bool clicked = false;
            float delayTime = data.Delay > 0 ? data.Delay : 120f;
            float elapsedTime = 0;

            while (elapsedTime < delayTime && !clicked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clicked = true;
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        dialogBox.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
