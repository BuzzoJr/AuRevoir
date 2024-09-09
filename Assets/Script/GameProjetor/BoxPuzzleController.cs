using UnityEngine;

public class BoxPuzzleController : MonoBehaviour
{
    public static BoxPuzzleController instance;
    public BoxPuzzle[] boxes;
    public int[] correctPages;
    public GameObject bigPage;
    public int currentBox;

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
