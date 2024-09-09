using UnityEngine;
using TMPro;
using DG.Tweening;

public class BoxPuzzle : MonoBehaviour
{
    public TMP_Text smallBoxText;
    public TMP_Text expandedText;
    public TMP_Text pageText;
    public GameObject closeButton, nextButton, prevButton;

    private int currentPage;
    private bool isBoxExpanded = false;
    private BoxPuzzleController controller;
    private int boxIndex;

    void Start()
    {
        currentPage = 1;
        controller = BoxPuzzleController.Instance;
        boxIndex = controller.GetBoxIndex(gameObject);
        UpdateSmallBoxText();
    }

    public void OnBoxClicked()
    {
        if (isBoxExpanded) return;

        currentPage = controller.GetPageForBox(boxIndex);
        expandedText.text = GetExpandedText(currentPage);
        pageText.text = $"{currentPage}/3";
        AnimateExpandBox();
    }

    void AnimateExpandBox()
    {
        isBoxExpanded = true;
        transform.DOScale(Vector3.one * 1.5f, 0.5f).OnComplete(() => ShowExpandedView());
    }

    void ShowExpandedView()
    {
        closeButton.SetActive(true);
        nextButton.SetActive(true);
        prevButton.SetActive(true);
    }

    public void OnCloseButtonClicked()
    {
        closeButton.SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        UpdateSmallBoxText();
        transform.DOScale(Vector3.one, 0.5f).OnComplete(() => isBoxExpanded = false);

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
        switch (page)
        {
            case 1: return "Page 1 large text content...";
            case 2: return "Page 2 large text content...";
            case 3: return "Page 3 large text content...";
            default: return "";
        }
    }
}
