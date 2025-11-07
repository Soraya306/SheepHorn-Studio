using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float playerSpeed = 5.0f;

    private float gravityValue = -9.81f;

    public  CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 input_data;
    private Inputmaptest map;
    public Info inf;
    public GameObject sonic;
    public GameObject position1;
    //DETECCION CON MAPA DE ACCIONES O COMO SE LLAME
    private void Awake()
    {
       inf= GameObject.FindGameObjectWithTag("Finish").GetComponent<Info>();
       
        if (inf.son1)
        {
            sonic.SetActive(true);
            transform.position = position1.transform.position;
        }
        map = new Inputmaptest();
        input_data = Vector2.zero;
        map.Player.Movement.performed += Context =>

        {
            input_data = Context.ReadValue<Vector2>();


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

        // LEER INPUT

        Vector3 move = new Vector3(input_data.x, 0.0f, input_data.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }



        
        playerVelocity.y += gravityValue * Time.deltaTime;

        // MOVIMIENTO
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);


    }
}
