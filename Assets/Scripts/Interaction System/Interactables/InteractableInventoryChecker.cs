using TMPro;
using UnityEngine;

namespace Interaction_System.Interactables
{
    public class InteractableInventoryChecker : InteractObject
    {
        [SerializeField] public string uninteractableText = "It's locked!";
        [SerializeField] public TextMeshProUGUI textUi;
        [SerializeField] public GameObject inventoriedItem;
        [SerializeField] public InteractObject interactableToEnable;
        [SerializeField] public Animator transitionAnimator;
        [SerializeField] public AnimationClip transitionAnimationClip;

        private float? interactedTime;
        
        public override bool Interact(Interactor interactor)
        {
            if (!enabled)
                return false;
            
            if (interactedTime == null)
            {
                interactedTime = Time.time;
                if (!inventoriedItem.activeSelf)
                {
                    if (interactableToEnable != null)
                        interactableToEnable.enabled = true;
                    
                    if (transitionAnimator != null && transitionAnimationClip != null)
                        transitionAnimator.Play(transitionAnimationClip.name);
                    textUi.SetText("Success!");
                }
                else
                {
                    textUi.SetText(uninteractableText);
                }
                Debug.Log(interactor.name + " changed text " + textUi.gameObject.name);
                
                return true;
            }

            return false;
        }

        void LateUpdate()
        {
            if (interactedTime != null && interactedTime + 2 < Time.time)
            {
                if (textUi.text == uninteractableText)
                {
                    textUi.text = null;
                }
                interactedTime = null;
                Debug.Log($"Closing uninteractable text: {textUi.gameObject.name}...");
            }
        }
    }
}