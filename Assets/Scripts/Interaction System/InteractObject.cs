using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour, IInteractable
{
    //[SerializeField] private string displayName = "Interactable Object";
    [SerializeField] private string Prompt = "Press E to interact";
    //[SerializeField] private bool isEnabled = true;
    //[SerializeField] private UnityEvent onInteract;

    public string InteractionPrompt => Prompt;

    //public string DisplayName => displayName;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(message:"Interact with " + gameObject.name);
        return true;
    }

    // private Outline outline;
    /* private void Awake()
     {
         outline.gameObject.AddComponent<Outline>();
         outline.OutlineMode = Outline.Mode.OutlineVisible;
         outline.OutlineColor = Color.yellow;
         outline.OutlineWidth = 3f;
         outline.enabled = false;
     }
     /*public void Interact(Interactor interactor)
     {
         onInteract?.Invoke();
     }

     public void OnFocusGained()
     {
         outline.enabled = true;
     }

     public void OnFocusLost()
     {
         outline.enabled = false;
     }*/

}
