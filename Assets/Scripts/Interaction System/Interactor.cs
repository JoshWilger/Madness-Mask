using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRange = 5f;
    [SerializeField] private LayerMask interactableLayerMask;

    private readonly Collider[] collidersBuffer = new Collider[10];

    public InputActionReference interactAction;

    [SerializeField] private int numCol;

    private void Update()
    {
        numCol = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRange, collidersBuffer, interactableLayerMask);

        if (numCol > 0)
        {
            var interactable = collidersBuffer[0].GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (interactAction.action.WasPerformedThisFrame())
                {
                    interactable.Interact(this);
                }
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
