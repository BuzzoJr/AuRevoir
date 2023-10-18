using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Linq;
using UnityEngine;

public class InteractionExampleWheel : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsInteractionWheel() => true;

    public void DefaultInteraction(GameObject who)
    {
        Debug.LogError("Essa fun��o n�o deveria ser chamada normalmente, pq essa intera��o tem a roda de intera��o");
    }

    public void LookInteraction(GameObject who)
    {
        Debug.Log(Locale.Texts[TextGroup.Intro].First().Text);
    }

    public void UseInteraction(GameObject who)
    {
        Debug.Log(Locale.Texts[TextGroup.Intro].Last().Text);
    }
}
