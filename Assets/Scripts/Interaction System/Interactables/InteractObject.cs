using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string Prompt = "Press E to interact";

    [SerializeField] private Inventory inv = null;

    private InteractDoor doorControl;


    public string InteractionPrompt => Prompt;

    public virtual bool Interact(Interactor interactor)
    {
        Debug.Log(message: "Interact with " + gameObject.name);

        //switching between specific objects based on tag
        string tag = gameObject.tag;

        switch (tag.ToLower())
        {
            case "key":
                inv.hasKey = true;
                Debug.Log("You picked up a Red Key!");
                Prompt = "You have picked up the Key.";
                Destroy(gameObject);
                break;

            case "mask":
                inv.hasMask = true;
                Debug.Log("You picked up a Mask!");
                Prompt = "You have picked up the Mask.";
                Destroy(gameObject);
                break;

            case "door":
                doorControl = GetComponent<InteractDoor>();
                doorControl.DoorTest(inv, Prompt);
                break;

            default:
                break;
        }

        return true;
    }
}
