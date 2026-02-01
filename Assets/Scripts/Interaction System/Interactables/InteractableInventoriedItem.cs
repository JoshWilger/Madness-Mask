using TMPro;
using UnityEngine;

namespace Interaction_System.Interactables
{
    public class InteractableInventoriedItem : InteractObject
    {
        
        private float? interactedTime;
        
        public override bool Interact(Interactor interactor)
        {
            if (!enabled)
                return false;

            if (interactedTime == null)
            {
                interactedTime = Time.time;
                gameObject.SetActive(false);
                Debug.Log(interactor.name + " inventoried " + gameObject);
                
                return true;
            }

            return false;
        }
    }
}