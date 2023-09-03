using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    Input_Manager Input_Manager;
    Player_Loco_Motion Player_Loco_Motion;
    CameraManager CameraManager;

    private void Awake()
    {
        Input_Manager = GetComponent<Input_Manager>();
        CameraManager = FindObjectOfType<CameraManager>();
        Player_Loco_Motion = GetComponent<Player_Loco_Motion>();
    }

    private void Update()
    {
        Input_Manager.HandleAllInput();

    }

    private void FixedUpdate()
    {
        Player_Loco_Motion.HandleAllmovement();
    }

    private void LateUpdate()
    {
        CameraManager.Allcameramovementcontrol();
    }
}
