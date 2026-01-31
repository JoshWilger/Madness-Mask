using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    //Variable for setting camera
    public Camera playerCamera;

    //Variables for speed and jumping
    public float walk = 6f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    //sprinting variable; OPTIONAL
    public float sprint = 12f;

    //Variables for camera movement
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    //Variables for movement direction and rotation
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    //Boolean to toggle movement
    public bool canMove = true;

    //Variable for setting character controller
    CharacterController playerController;

    //Runs upon startup; sets player controller to connected asset; hides and locks the cursor
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //
    private void Update()
    {
        //Handles Basic Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Handles Sprinting; uses left shift; OPTIONAL
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpdX = canMove ? (isRunning ? sprint : walk) * Input.GetAxis("Vertical") : 0;
        float curSpdY = canMove ? (isRunning ? sprint : walk) * Input.GetAxis("Horizontal") : 0;

        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curSpdX) + (right * curSpdY);
        //End Sprinting

        //Handles Jumping
        if (Input.GetButton("Jump") && canMove && playerController.isGrounded)
        {
            moveDirection.y = jumpPower;
        } else
        {
            moveDirection.y = moveDirectionY;
        }

        if (!playerController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //End Jumping

        //Handles Rotation
        playerController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        //End Rotation
    }

}
