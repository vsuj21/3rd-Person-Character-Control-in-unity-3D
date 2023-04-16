using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 camerafollowvelocity = Vector3.zero;
    public float camerafollowspeed = 0.2f;
    public float lookangle; //camera up and down
    public float pivotangle; // camera left and right

    private void Awake()
    {
        targetTransform = FindObjectOfType<Player_Manager>().transform;
    }
    public void followPlayer()
    {
        Vector3 targetposition = 
            Vector3.SmoothDamp(transform.position, targetTransform.position,ref camerafollowvelocity,camerafollowspeed);
        transform.position = targetposition;
    }
    public void OnRenderObject()
    {
        //lookangle = lookangle + (mouseXinput + cameralookspeed);
        //pivotangle = pivotangle - (mouseyinput + camerapivotspeed);
    }
}
