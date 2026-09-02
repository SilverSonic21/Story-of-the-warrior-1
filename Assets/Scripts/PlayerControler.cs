using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControler : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;
    private bool isRunning = false;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

         if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
        }
        
        float speed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0f;


        float curSpeedX = 0f;
        float curSpeedY = 0f;

        // ⭐ Individual WASD key checks
        if (Input.GetKey(KeyCode.S)) curSpeedX = speed;
        if (Input.GetKey(KeyCode.W)) curSpeedX = -speed;
        if (Input.GetKey(KeyCode.A)) curSpeedY = speed;
        if (Input.GetKey(KeyCode.D)) curSpeedY = -speed;

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Jump
        if (Input.GetKey(KeyCode.LeftShift) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Crouch
        if (Input.GetButton("Jump") && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime);

        // Mouse look
        if (canMove)
        {
            rotationX -= -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, -Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
