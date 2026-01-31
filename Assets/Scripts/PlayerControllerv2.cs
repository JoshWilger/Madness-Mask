using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerv2: MonoBehaviour
{
    public CharacterController controller;
    private Transform cameraTransform;

    [Header("Variables")]
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 1.5f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private bool interacted;

    //[SerializeField]; didnt actually need
    //private InputManager inputManager; didnt actually need

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference interactAction;
    public InputActionReference jumpAction;

    private void Start() //Get the CharacterController component
    {
        controller = gameObject.GetComponent<CharacterController>();
        //inputManager = InputManager.Instance; didnt actually need
        cameraTransform = Camera.main.transform;
    }

    private void OnEnable() //Enable the input actions
    {
        moveAction.action.Enable();
        interactAction.action.Enable();
    }

    private void OnDisable() //Disable the input actions
    {
        moveAction.action.Disable();
        interactAction.action.Disable();
    }

    void Update() //Handle movement, jumping and interacting
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f; // Keep movement horizontal
        move = Vector3.ClampMagnitude(move, 1f);

        /*if (move != Vector3.zero)
            transform.forward = move;*/

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }
}