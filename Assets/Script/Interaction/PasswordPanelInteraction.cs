using Assets.Script.Interaction;
using System.Collections;
using TMPro;
using UnityEngine;

public class PasswordPanelInteraction : MonoBehaviour, IUse
{
    public DoorController door;
    public Light alertLight;
    public GameObject canvas;
    public TMP_Text password;
    public AudioSource click, confirm, wrong;

    public void Use(GameObject who)
    {
        if (door.locked)
            StartCoroutine(UsePanel());
    }

    IEnumerator UsePanel()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().GoTo(new Vector3(transform.position.x, transform.position.y, transform.position.z), null);

        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk") && !PlayerController.anim.GetBool("Run"));


        // Action cancelled
        if (GameManager.Instance.State != GameManager.GameState.Interacting)
            yield break;

        password.text = "#----";
        canvas.SetActive(true);
    }

    private void AddCharToPassword(string c)
    {
        for (int i = 1; i < password.text.Length; i++)
        {
            if (password.text[i] == '-')
            {
                password.text = password.text.Remove(i, c.Length).Insert(i, c);
                break;
            }
        }
        click.Play();
    }

    private void EraseCharFromPassword()
    {
        for (int i = password.text.Length - 1; i > 0; i--)
        {
            if (password.text[i] != '-')
            {
                password.text = password.text.Remove(i, 1).Insert(i, "-");
                break;
            }
        }
        click.Play();
    }

    private void CheckPassword()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
        canvas.SetActive(false);

        if (password.text == "#0000")
        {
            door.SetLock(false);
            alertLight.color = Color.green;
            confirm.Play();
            Destroy(this);
            return;
        }
        else
        {
            wrong.Play();
        }

        password.text = "#----";
    }

    public void PressButton(string c)
    {
        if (c == ">")
            CheckPassword();
        else if (c == "-")
            EraseCharFromPassword();
        else
            AddCharToPassword(c);
    }
}
