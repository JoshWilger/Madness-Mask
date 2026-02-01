using TMPro;
using UnityEngine;

namespace Interaction_System.Interactables
{
    public class InteractableTextChanger : InteractObject
    {
        [SerializeField] [Multiline] public string transitionText;
        [SerializeField] public Animator transitionAnimator;
        [SerializeField] public AnimationClip transitionAnimationClip;
        [SerializeField] public TextMeshProUGUI textUi;
        
        private float? interactedTime;
        
        public override bool Interact(Interactor interactor)
        {
            if (interactedTime == null)
            {
                interactedTime = Time.time;
                textUi.text = transitionText;
                transitionAnimator.gameObject.SetActive(true);
                if (transitionAnimationClip)
                {
                    transitionAnimator.Play(transitionAnimationClip.name, 0, 0f);
                }
                Debug.Log(interactor.name + " changed text " + textUi.gameObject.name);
                
                return true;
            }

            return false;
        }

        void LateUpdate()
        {
            if (interactedTime + 0.4 < Time.time && Input.anyKey)
            {
                transitionAnimator.gameObject.SetActive(false);
                interactedTime = null;
                Debug.Log($"Closing Text: {textUi.gameObject.name}...");
            }
        }
    }
}