using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private PlayerInputController playerControls;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        playerControls = new PlayerInputController();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
           playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetMovementInput()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetLookInput()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerInteract()
    {
        return playerControls.Player.Interact.triggered;
    }

}
