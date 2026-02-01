using UnityEngine;

public interface IInteractable
{
  public string InteractionPrompt { get; }

    //Transform transform { get; }

    //string DisplayName { get; }

    //bool CanInteract();

    // void OnFocusGained();
    // void OnFocusLost();
    public bool Interact(Interactor interactor);

}
