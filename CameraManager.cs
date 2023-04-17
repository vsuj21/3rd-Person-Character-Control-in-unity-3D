using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Input_Manager inputManager;
    public Transform targetTransform;// object the camera follow
    public Transform Camerapivot; //The object the camera uses to pivot(look up and down)
    private Vector3 camerafollowvelocity = Vector3.zero;
    public float camerafollowspeed = 0.2f;
    public float lookangle; //camera up and down
    public float pivotangle; // camera left and right

    public float minimumpivotangle = -35;
    public float maximumpivotangle = 30;
    public float cameralookspeed = 2;
    public float camerapivotspeed = 2;

    private void Awake()
    {
        inputManager = FindObjectOfType<Input_Manager>();
        targetTransform = FindObjectOfType<Player_Manager>().transform;
    }

    public void Allcameramovementcontrol()
    {
        followPlayer();
        RotateCamera();
    }

    private void followPlayer()
    {
        Vector3 targetposition = 
            Vector3.SmoothDamp(transform.position, targetTransform.position,ref camerafollowvelocity,camerafollowspeed);
        transform.position = targetposition;
    }

    private void RotateCamera()
    {
        lookangle = lookangle + (inputManager.camerainputX * cameralookspeed);
        pivotangle = pivotangle - (inputManager.camerainputY * camerapivotspeed);
        pivotangle = Mathf.Clamp(pivotangle, minimumpivotangle, maximumpivotangle);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookangle;
        Quaternion targetrotation = Quaternion.Euler(rotation);
        transform.rotation = targetrotation;

        rotation = Vector3.zero;
        rotation.x = pivotangle;
        targetrotation = Quaternion.Euler(rotation);
        Camerapivot.localRotation = targetrotation;


    }
}
