using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPromptInteract : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }
}
