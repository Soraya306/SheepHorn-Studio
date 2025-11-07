using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class movementtest : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 input_data;
    private Inputmaptest map; 
  

    private void Awake()
    {

        map= new Inputmaptest();
        input_data=Vector2.zero;
        map.Player.Movement.performed += Context =>
        
        {
            input_data=Context.ReadValue<Vector2>();
       

        };
        map.Player.Movement.canceled += Context =>

        {
            input_data = Context.ReadValue<Vector2>();


        };

        controller = gameObject.AddComponent<CharacterController>();
    }

    private void OnEnable()
    {
        map.Enable();
    
    
    }
       

    private void OnDisable()
    {
       map.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0f;
        }

        // Read input
       
        Vector3 move = new Vector3(input_data.x, 0.0f, input_data.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

       

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
