using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private Transform meshplayer;

    private float inputx;
    private float inputz;
    private float gravity;

    private Vector3 move;
    private float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        meshplayer = tempPlayer.transform.GetChild(0);
        characterController = tempPlayer.GetComponent<CharacterController>();
        animator = meshplayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movespeed = 0.024f;
        gravity = 0.5f;
        inputx = Input.GetAxis("Horizontal");
        inputz = Input.GetAxis("Vertical");

        if (inputx == 0 && inputz == 0)
        {
            animator.SetBool("Isrun", false);
        }
        else
        {
            animator.SetBool("Isrun", true);
            //Debug.Log("x"+inputx);
            //Debug.Log("z"+inputz);
        }

    }

    private void FixedUpdate()
    {
        //gravity
        if (characterController.isGrounded)
        {
            move.y = 0f;

        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }

        //movemet
        move = new Vector3(inputx * movespeed, move.y, inputz * movespeed);
        characterController.Move(move);

        //rotation
        if (inputx != 0 && inputz != 0)
        {
            Vector3 lookdir = new Vector3(move.x, 0, move.z);
            meshplayer.rotation = Quaternion.LookRotation(lookdir);
        }

    }
}
