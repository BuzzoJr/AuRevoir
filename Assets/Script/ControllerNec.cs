using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllerNec : MonoBehaviour, ILangConsumer
{
    //Controle do painel do necrotério
    public GameObject cameraScene;
    public GameObject allBody;
    public GameObject target;
    public GameObject floorGlass;
    public GameObject wall;
    public GameObject panelObj;
    public GameObject finger;
    public GameObject[] bodies;
    public AudioSource soundDirection, soundRed, soundDoor;
    public Animator glassDoor;
    public PanelNec panelScrpt;
    public TMP_Text nameTxt;
    public TMP_Text dataTxt;
    public TMP_Text localDesc;
    public TMP_Text causaDesc;
    public TMP_Text localTitle;
    public TMP_Text causaTitle;
    public Image photoIcon;
    public Sprite[] photos;
    public float speed = 5f;
    private int pos = 0;
    private bool panelClick, delayToMove = true;

    public void UpdateLangTexts()
    {
        localTitle.text = Locale.Texts[TextGroup.MorgueHUD][0].Text;
        causaTitle.text = Locale.Texts[TextGroup.MorgueHUD][1].Text;

        UpdateCorpseText(pos);
    }

    private void UpdateCorpseText(int pos)
    {
        int index = pos * 4;

        nameTxt.text = Locale.Texts[TextGroup.MorgueCorpses][index].Text;
        dataTxt.text = Locale.Texts[TextGroup.MorgueCorpses][index + 1].Text;
        localDesc.text = Locale.Texts[TextGroup.MorgueCorpses][index + 2].Text;
        causaDesc.text = Locale.Texts[TextGroup.MorgueCorpses][index + 3].Text;
    }

    void Awake()
    {
        Locale.RegisterConsumer(this);
        UpdateLangTexts();
        UpdateCorpse(pos);
    }

    void OnDestroy()
    {
        Locale.UnregisterConsumer(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var viewportPos = new Vector2((Input.mousePosition.x * 1920) / Screen.width, (Input.mousePosition.y * 1080) / Screen.height);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(viewportPos), out RaycastHit raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }

        Vector3 currentPosition = allBody.transform.position;
        Vector3 targetPosition = new Vector3(target.transform.position.x, currentPosition.y, currentPosition.z);
        allBody.transform.position = Vector3.Lerp(currentPosition, targetPosition, speed * Time.deltaTime);
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Left" && delayToMove)
        {
            if (pos > 0)
            {
                StartCoroutine(DelayMove());
                MoveBody(5f);
                pos--;
                UpdateCorpse(pos);
            }
        }
        else if (gameObject.name == "Right" && delayToMove)
        {
            if (pos < 7)
            {
                StartCoroutine(DelayMove());
                MoveBody(-5f);
                pos++;
                UpdateCorpse(pos);
            }
        }
        else if (gameObject.name == "RedButton")
        {
            ILook look = bodies[pos].GetComponentInChildren<ILook>();
            if (look is not null)
            {
                look.Look(null);
            }

            if (pos == 5)
            { //Corpo correto
                glassDoor.SetBool("Open", true);
                floorGlass.tag = "Floor";
                wall.SetActive(false);
                panelObj.SetActive(false);
                panelScrpt.exitPanel(true);
                finger.SetActive(true);
                soundDoor.Play();
            }

            soundRed.Play();
        }
        else if (gameObject.name == "Panel")
        {
            if (panelClick)
            {
                cameraScene.transform.rotation = Quaternion.Euler(24, 360, 0);
                cameraScene.GetComponent<Camera>().fieldOfView = 30;
            }
            else
            {
                cameraScene.transform.rotation = Quaternion.Euler(8, 360, 0);
                cameraScene.GetComponent<Camera>().fieldOfView = 75;
            }

            panelClick = !panelClick;
        }
        else if (gameObject.name == "Exit")
        {
            panelScrpt.exitPanel(false);
        }
    }

    public void MoveBody(float qtd)
    {
        Vector3 currentPosition = target.transform.position;
        currentPosition.x += qtd;
        target.transform.position = currentPosition;
        soundDirection.Play();
    }

    void UpdateCorpse(int pos)
    {
        photoIcon.sprite = photos[pos];
        UpdateCorpseText(pos);
    }

    private IEnumerator DelayMove()
    {
        delayToMove = false;
        yield return new WaitForSeconds(2.1f);
        delayToMove = true;
    }
}
