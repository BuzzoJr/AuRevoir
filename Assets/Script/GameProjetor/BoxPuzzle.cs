using UnityEngine;
using TMPro;

public class BoxPuzzle : MonoBehaviour
{
    public TMP_Text smallBoxText;
    public string[] contentPages;

    private TMP_Text expandedText;
    private TMP_Text pageText;
    private int currentPage;
    private BoxPuzzleController controller;
    private int boxIndex;

    void Start()
    {
        expandedText = BoxPuzzleController.instance.bigPage.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        pageText = BoxPuzzleController.instance.bigPage.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        currentPage = 1;
        controller = BoxPuzzleController.instance;
        boxIndex = controller.GetBoxIndex(gameObject);
        UpdateSmallBoxText();
    }

    public void OnBoxClicked()
    {
        BoxPuzzleController.instance.SetCurrentBox(boxIndex);
        currentPage = controller.GetPageForBox(boxIndex);
        expandedText.text = GetExpandedText(currentPage);
        pageText.text = $"{currentPage}/3";
        AnimateExpandBox();
    }

    void AnimateExpandBox()
    {
        BoxPuzzleController.instance.bigPage.SetActive(true);
    }

    public void OnCloseButtonClicked()
    {
        UpdateSmallBoxText();
        BoxPuzzleController.instance.bigPage.SetActive(false);

        controller.CheckVictory();
    }

    public void OnNextPage()
    {
        if (currentPage < 3)
        {
            currentPage++;
            expandedText.text = GetExpandedText(currentPage);
            pageText.text = $"{currentPage}/3";
            controller.SetPageForBox(boxIndex, currentPage);
        }
    }

    public void OnPreviousPage()
    {
        if (currentPage > 1)
        {
            currentPage--;
            expandedText.text = GetExpandedText(currentPage);
            pageText.text = $"{currentPage}/3";
            controller.SetPageForBox(boxIndex, currentPage);
        }
    }

    void UpdateSmallBoxText()
    {
        string firstWord = GetExpandedText(currentPage).Split(' ')[0];
        smallBoxText.text = firstWord;
    }

    string GetExpandedText(int page)
    {
        return contentPages[page - 1];
    }
}
