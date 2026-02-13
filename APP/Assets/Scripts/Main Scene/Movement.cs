using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Scripts")] 
    public InputMap InputMap;
    public CharacterController Controller;
    public CharacterController Pivote;
    public RaycastSystem Raycast;
    public InfoBetweenScenes Info;
    public Animator Animations;
    [Header("Data")]
    public float PlayerSpeed;
    public Vector3 PlayerVelocity;
    public Vector2 Input_Data;

    private void Awake()
    {
        Info=GameObject.FindGameObjectWithTag("InfoSaved").GetComponent<InfoBetweenScenes>();
        InputMap=new InputMap();
        if (Info.change)
        {
            if (Info.carnerobatalla)
            {
                Info.carnerobatalla = false;
                Controller.enabled = false;
                transform.position = Raycast.carni.transform.position;

            }
            if (Info.posicioncerdo)
            {
                Info.cerdobatallaactiva = false;
                Controller.enabled = false;
                transform.position = Raycast.intcerdo.transform.position;
                Info.cascerd = false;

            }
            if (Info.posicionvaca)
            {
                Info.vacabatallaactiva = false;
                Controller.enabled = false;
                transform.position = Raycast.intvaca.transform.position;
                Info.casvaca = false;
            }
            if (Info.posiciongallina)
            {
                Info.gallinabatallaactiva = false;
                Controller.enabled = false;
                transform.position = Raycast.intgall.transform.position;
                Info.casgall = false;
            }
        }
        
        if (Info.returning&&Info.casserp)
        {
            Controller.enabled = false;
            transform.position = Raycast.CasaSerpiente.transform.position;
            Info.returning = false;
            Info.casserp = false;
        }
        if (Info.returning&&Info.casvaca)
        {
            Controller.enabled=false;
            transform.position=Raycast.CasaVaca.transform.position;
            Info.returning = false;
            Info.casvaca = false;
        }
        if (Info.returning&&Info.casgall)
        {
            Controller.enabled=false ;
            transform.position=Raycast.CasaGallina.transform.position;
            Info.returning = false;
            Info.casgall = false;
        }
        if (Info.returning&&Info.cascerd)
        {
            Controller.enabled=false;
            transform.position=Raycast.CasaCerdo.transform.position;
            Info.returning = false;
            Info.cascerd = false;
        }
        Input_Data=Vector2.zero;
        Controller.enabled=true;
        InputMap.Player.Movement.performed += Movimiento =>
        {
            Input_Data = Movimiento.ReadValue<Vector2>();
            Animations.SetBool("WalkChange", true);
        };
        InputMap.Player.Movement.canceled += Movimiento =>
        {
            Input_Data = Movimiento.ReadValue<Vector2>();
            Animations.SetBool("WalkChange", false);
        };

    }
    private void OnEnable()
    {
        InputMap.Enable();
    }
    private void OnDisable()
    {
        InputMap.Disable();
    }
    private void Update()
    {
        if (Raycast.MenuDesact)
        {
            Controller.enabled = false;
        }
        else
        {
            Controller.enabled = true;
        }
        if (Controller.enabled)
        {
            Vector3 move = new Vector3(Input_Data.x, 0.0f, Input_Data.y);
            move = Vector3.ClampMagnitude(move, 1f);
            if (move != Vector3.zero)
            {
                transform.forward = move;
            }
            Vector3 finalMove = (move * PlayerSpeed) + (PlayerVelocity.y * Vector3.up);
            Controller.Move(finalMove * Time.deltaTime);
        }
            
    }
}
