using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    Player_Controls PlayerControl;
    public Vector2 Movement_input;
    public float VerticalInput;
    public float HorizontalInput;
    private float moveamount;
    Animator_manager Animator_Manager;

    private void Awake()
    {
        Animator_Manager = GetComponent<Animator_manager>();
    }

    private void OnEnable()
    {
        if (PlayerControl == null)
        {
            PlayerControl = new Player_Controls();
            PlayerControl.Player_Movement.Movement.performed += i => Movement_input = i.ReadValue<Vector2>();

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

    }
    private void HandleMovementInput()
    {
        VerticalInput = Movement_input.y;
        HorizontalInput = Movement_input.x;
        moveamount = Mathf.Clamp01(Mathf.Abs(HorizontalInput) +Mathf.Abs(VerticalInput));
        Animator_Manager.UpdateAnimatorValues(0,moveamount);
    }
}
