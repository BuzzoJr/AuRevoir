using Assets.Script.Interaction;
using System.Collections;
using TMPro;
using UnityEngine;

public class PasswordPanelInteraction : MonoBehaviour, IUse
{
    public DoorController door;
    public Light light;
    public GameObject canvas;
    public TMP_Text password;

    public void Use(GameObject who)
    {
        if (door.locked)
            StartCoroutine(UsePanel());
    }

    IEnumerator UsePanel()
    {
        PlayerController.navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        yield return null;
        yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        password.text = "";
        canvas.SetActive(true);
    }

    private void AddCharToPassword(string c)
    {
        if (password.text.Length < 5)
            password.text += c;
    }

    private void CheckPassword()
    {
        canvas.SetActive(false);

        if (password.text == "#0000")
        {
            door.SetLock(false);
            light.color = Color.green;
            Destroy(this);
            return;
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

    public void QuitPanel()
    {
        canvas.SetActive(false);
        password.text = "";
    }
}
