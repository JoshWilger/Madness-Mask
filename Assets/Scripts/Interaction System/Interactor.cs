using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRange = 5f;
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private UIPromptInteract _interactionPromptUi;

    private readonly Collider[] collidersBuffer = new Collider[10];

    public InputActionReference interactAction;

    [SerializeField] private int numCol;
    
    private IInteractable _interactable;

    private void Update()
    {
        numCol = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRange, collidersBuffer, interactableLayerMask);

        if (numCol > 0)
        {
            _interactable = collidersBuffer[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUi.IsDisplayed)
                    _interactionPromptUi.SetUp(_interactable.InteractionPrompt);
                
                if (interactAction.action.WasPerformedThisFrame())
                {
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            if (_interactable != null)
            {
                _interactable = null;
            }

            if (_interactionPromptUi.IsDisplayed)
            {
                _interactionPromptUi.Close();
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (interactionPoint == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }


}
