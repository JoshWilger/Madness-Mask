using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string Prompt = "Press E to interact";

    [SerializeField] private bool redDoor = false;
    [SerializeField] private bool redKey = false;

    [SerializeField] private Inventory inv = null;

    private KeyDoorController doorObj;

    public string InteractionPrompt => Prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(message:"Interact with " + gameObject.name);




        //switching between specific objects based on tag
        string tag = gameObject.tag;

        switch (tag.ToLower())
        {
            case "redkey":
                if (redKey)
                {
                    inv.HasRedKey = true;
                    Debug.Log("You picked up a Red Key!");
                    Destroy(gameObject);
                }
                break;
            case "reddoor":
                if (redDoor)
                {
                    doorObj = GetComponent<KeyDoorController>();
                    if (inv.HasRedKey)
                    {
                        //doorObj.PlayAnimation(); -- not set up yet
                        Debug.Log("Door Opened");
                    }
                    else
                    {
                        Debug.Log("You need a Key to open this door.");
                    }
                }
                break;
            case "":
                break;
            default:
                break;
        }

        return true;
    }


}
