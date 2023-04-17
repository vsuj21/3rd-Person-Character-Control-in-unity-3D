using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    Player_Controls PlayerControl;
    public Vector2 Movement_input;
    public Vector2 Camera_input;

    public float camerainputX;
    public float camerainputY;
    
    public float VerticalInput;
    public float HorizontalInput;
    public float moveamount;
    public bool b_input;
    Animator_manager Animator_Manager;
    Player_Loco_Motion playerLoco_Motion;

    private void Awake()
    {
        Animator_Manager = GetComponent<Animator_manager>();
        playerLoco_Motion = GetComponent<Player_Loco_Motion>();
    }

    private void OnEnable()
    {
        if (PlayerControl == null)
        {
            PlayerControl = new Player_Controls();
            PlayerControl.Player_Movement.Movement.performed += i => Movement_input = i.ReadValue<Vector2>();
            PlayerControl.Player_Movement.Camera.performed += i => Camera_input = i.ReadValue<Vector2>();
            PlayerControl.Player_Actions.B.performed += i => b_input = true;
            PlayerControl.Player_Actions.B.canceled += i => b_input = false;
        }
        PlayerControl.Enable(); 
    }
    private void OnDisable()
    {
        PlayerControl.Disable();    
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprinting();

    }
    private void HandleMovementInput()
    {

        VerticalInput = Movement_input.y;
        HorizontalInput = Movement_input.x;

        camerainputY = Camera_input.y;
        camerainputX = Camera_input.x;
      

        moveamount = Mathf.Clamp01(Mathf.Abs(HorizontalInput) +Mathf.Abs(VerticalInput));
        Animator_Manager.UpdateAnimatorValues(0,moveamount,playerLoco_Motion.Isrun);
    }
    private void HandleSprinting()
    {
        if(b_input)
        {
            playerLoco_Motion.Isrun = true;
        }
        else
        {
            playerLoco_Motion.Isrun = false;
        }
    }
}
