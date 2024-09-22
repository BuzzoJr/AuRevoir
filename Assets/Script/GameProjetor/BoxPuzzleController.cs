using UnityEngine;

public class BoxPuzzleController : MonoBehaviour
{
    public static BoxPuzzleController instance;
    public BoxPuzzle[] boxes;
    public int[] correctPages;
    public GameObject bigPage;
    public int currentBox;
    public LookClose lookCloseScrpt;
    public BoxCollider lookCollider;

    private int[] currentPages;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentPages = new int[boxes.Length];
        for (int i = 0; i < currentPages.Length; i++)
        {
            currentPages[i] = 1;
        }
    }

    void Update() {
        if(lookCollider.enabled)
            return;

        if (Input.GetMouseButtonDown(0)) // Verifica se houve clique esquerdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cria um ray a partir da posição do mouse
            if (Physics.Raycast(ray, out RaycastHit hit)) // Verifica se o ray colide com algo
            {
                if(hit.collider.gameObject.GetComponent<BoxPuzzle>() != null)
                    hit.collider.gameObject.GetComponent<BoxPuzzle>().OnBoxClicked();
                else if(hit.collider.gameObject.name == "Close")
                    boxes[currentBox].OnCloseButtonClicked();
                else if(hit.collider.gameObject.name == "Next")
                    boxes[currentBox].OnNextPage();
                else if(hit.collider.gameObject.name == "Prev")
                    boxes[currentBox].OnPreviousPage();
                else if(!bigPage.activeSelf) {
                    lookCollider.enabled = true;
                    lookCloseScrpt.CustomExitAnim();
                }
            }
        }
    }

    public void SetCurrentBox(int index) {
        currentBox = index;
    }

    public void SetPageForBox(int boxIndex, int page)
    {
        currentPages[boxIndex] = page;
    }

    public int GetPageForBox(int boxIndex)
    {
        return currentPages[boxIndex];
    }

    public int GetBoxIndex(GameObject box)
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].gameObject == box)
            {
                return i;
            }
        }
        return -1;
    }

    public void CheckVictory()
    {
        bool allCorrect = true;
        for (int i = 0; i < correctPages.Length; i++)
        {
            if (currentPages[i] != correctPages[i])
            {
                allCorrect = false;
                break;
            }
        }
        if (allCorrect)
        {
            Debug.Log("You won the puzzle!");
        }
    }
}
