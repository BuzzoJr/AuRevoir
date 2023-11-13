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
        PlayerController.navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        password.text = "";
        canvas.SetActive(true);
    }

    private void AddCharToPassword(string c)
    {
        if (password.text.Length < 5) {
            password.text += c;
            click.Play();
        }
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
        else {
            wrong.Play();
        }

        password.text = "";
    }

    public void PressButton(string c)
    {
        if (c != ">")
            AddCharToPassword(c);
        else
            CheckPassword();
    }
}
