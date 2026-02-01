using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPromptInteract : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start()
    {
        mainCamera = Camera.main;
        _uiPanel.SetActive(false);
    }

    void LateUpdate()
    {
        var rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        IsDisplayed = false;
        _uiPanel.SetActive(false);
    }
}
