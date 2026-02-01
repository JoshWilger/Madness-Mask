using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public bool HasKey = false;
    public InputActionReference unlockAction;


    private void Update()
    {
        if (unlockAction.action.WasPerformedThisFrame())
        {
            HasKey = !HasKey;
            Debug.Log("HasKey: " + HasKey);
        }
    }
}
