using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ui.SetActive(!ui.activeSelf);
    }
}
