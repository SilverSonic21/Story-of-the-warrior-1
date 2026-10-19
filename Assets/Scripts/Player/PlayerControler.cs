using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;

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
    public float Health = 100f;
    public TMP_Text healthText;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
   
    private bool canMove = true;
    public bool isRunning = false;

    public UnityEngine.UI.Image damageFlash;
    public float flashSpeed = 2f;
    private float flashAlpha = 0f;
    public DeathScreen deathScreen;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateHealthUI();
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

         if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isRunning = !isRunning;
        }
        
        float speed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0f;


        float curSpeedX = 0f;
        float curSpeedY = 0f;

        
        if (Input.GetKey(KeyCode.S)) curSpeedX = speed;
        if (Input.GetKey(KeyCode.W)) curSpeedX = -speed;
        if (Input.GetKey(KeyCode.A)) curSpeedY = speed;
        if (Input.GetKey(KeyCode.D)) curSpeedY = -speed;

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        
        if (Input.GetKey(KeyCode.LeftShift) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

       
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        
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

        
        characterController.Move(moveDirection * Time.deltaTime);

        
        if (canMove)
        {
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if (damageFlash != null)
        {
            flashAlpha = Mathf.Lerp(flashAlpha, 0f, Time.deltaTime * flashSpeed);
            damageFlash.color = new Color(1, 0, 0, flashAlpha);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player trigger hit: " + other.name);
        CannonBall ball = other.GetComponent<CannonBall>();
        if (ball != null)
        {
            Debug.Log("CannonBall detected! Damage: " + ball.damage);
            TakeDamage(ball.damage);
            Destroy(ball.gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        Debug.Log("Player took damage. Current health: " + Health);
        flashAlpha = 1f;

        UpdateHealthUI();

        if (Health <= 0)
        {
           
            Die();
            
        }
    }
    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + Health.ToString("0");
    }

    void Die()
    {
        //Debug.Log("Player has died.");
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DeathScreen screen = FindAnyObjectByType<DeathScreen>();
        if (screen != null)
            screen.ShowDeathScreen();

        Time.timeScale = 0f;
    }

}
