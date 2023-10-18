using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using System.Linq;
using UnityEngine;

public class InteractionExampleWithWheel : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsInteractionWheel() => false;

    public void DefaultInteraction(GameObject who)
    {
        StartCoroutine(CoroutineExample());
    }

    public void LookInteraction(GameObject who) => DefaultInteraction(who);

    public void UseInteraction(GameObject who) => DefaultInteraction(who);

    IEnumerator CoroutineExample()
    {
        Debug.Log(Locale.Texts[TextGroup.Intro].First().Text);
        yield return new WaitForSeconds(1.5f);
        Debug.Log(Locale.Texts[TextGroup.Intro].Last().Text);
    }
}
