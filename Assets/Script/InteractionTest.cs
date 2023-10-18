using Assets.Script.Interaction;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    public GameObject interactable;

    private IInteraction interactionOnHold;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionOnHold is not null)
        {
            if (Input.GetKeyDown(KeyCode.Return))
                interactionOnHold.UseInteraction(gameObject);
            else if (Input.GetKeyDown(KeyCode.Backspace))
                interactionOnHold.LookInteraction(gameObject);

            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Backspace))
                interactionOnHold = null;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && interactable is not null)
        {
            IInteraction interaction = interactable.GetComponentInChildren<IInteraction>();
            if (interaction is null)
            {
                Debug.LogError("Estamos buscando uma interação onde não existe!");
            }
            else
            {
                if (interaction.IsInteractionWheel())
                {
                    Debug.Log("Devemos mostrar roda de interação e esperar o input do player.\nAperte enter (Return) para rodar a interação de usar.\nAperte backspace para rodar a interação de olhar.\nAperte delete para cancelar a roda.");
                    interactionOnHold = interaction;
                }
                else
                {
                    Debug.Log("Como esse interactable não precisa de roda de interação, vamos executar a interação default:");
                    interaction.DefaultInteraction(gameObject);
                }
            }
        }
    }
}
