using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Loco_Motion : MonoBehaviour
{
    Input_Manager Input_Manager;
    Vector3 moveDirection;
    Transform CameraObject;
    Rigidbody Player_rigid_body;

    public bool Isrun;

    [Header("Movement speeds")]

    public float rotationspeed = 4;
    public float walkingspeed = 3;
    public float sprintingspeed =10;

    private void Awake()
    {
        Input_Manager = GetComponent<Input_Manager>();
        Player_rigid_body = GetComponent<Rigidbody>();
        CameraObject = Camera.main.transform;
    }

    public void HandleAllmovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = CameraObject.forward * Input_Manager.VerticalInput;
        moveDirection = moveDirection + CameraObject.right * Input_Manager.HorizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (Isrun)
        {
            moveDirection = moveDirection * sprintingspeed;
        }
        else
        {
            moveDirection = moveDirection * walkingspeed;
        }
        
        

        Vector3 movementVelocity = moveDirection;
        Player_rigid_body.velocity = movementVelocity;

    }

    private void HandleRotation()
    {
        Vector3 targetdirection = Vector3.zero;
        targetdirection = CameraObject.forward * Input_Manager.VerticalInput;
        targetdirection = moveDirection + CameraObject .right * Input_Manager.HorizontalInput;
        targetdirection.Normalize();
        targetdirection.y = 0;

        if(targetdirection == Vector3.zero)
        {
            targetdirection = transform.forward;

        }

        Quaternion targetrotation = Quaternion.LookRotation(targetdirection);
        Quaternion playerrotation = Quaternion.Slerp(transform.rotation, targetrotation, rotationspeed * Time.deltaTime);
        transform.rotation = playerrotation;
       


    }
}
