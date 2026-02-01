using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interaction_System.Interactables
{
    public class InteractableSceneChanger : InteractObject
    {
        [SerializeField] public string sceneName;
        
        public override bool Interact(Interactor interactor)
        {
            Debug.Log("Interacting with scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
            
            return true;
        }
    }
}