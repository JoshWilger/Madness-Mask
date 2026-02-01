using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction_System.Interactables
{
    public class InteractableSceneChanger : InteractObject
    {
        [SerializeField] public string transitionText;
        [SerializeField] public Animator transitionAnimator;
        [SerializeField] public TextMeshProUGUI textUi;
        
        private float? interactedTime;
        
        public override bool Interact(Interactor interactor)
        {
            if (interactedTime == null)
            {
                interactedTime = Time.time;
                textUi.text = transitionText;
                transitionAnimator.gameObject.SetActive(true);
                transitionAnimator.Play("SceneTransition", 0, 0f);
                Debug.Log(transitionAnimator.gameObject.name + " fade out has begun at " + interactedTime);
                
                return true;
            }

            return false;
        }

        void LateUpdate()
        {
            if (interactedTime + 2 < Time.time && Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log($"Loading Next Scene at {Time.time}...");
            }
        }
    }
}