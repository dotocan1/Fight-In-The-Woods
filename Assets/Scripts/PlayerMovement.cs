using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private bool sprinting;
    private bool jump;
    
    public float speed;

    public CharacterController controller;
    private Animator animator;

    PhotonView view;
    [SerializeField] Camera cam;
    [SerializeField] AudioListener audioListener;



    // 7.6. dodani private na start
    private void Start()
    {
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        
        
        //cam = Camera.main;
        audioListener = cam.GetComponent<AudioListener>(); 

        if (!view.IsMine)
        {
            cam.enabled = false;
            audioListener.enabled = false;
            Debug.Log("why u have to be mad, its only a game.");
        }
        

    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {
        bool pause = Input.GetKeyDown(KeyCode.Escape);
        speed = 12f;

        if (pause)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().TogglePause();
        }

        if (GameManager.paused)
        {
            speed = 0f;
        }

        // 7.6. If View
        if (view.IsMine) // check if this is my player character
        {
            Move();

            bool runningPressed = Input.GetKey(KeyCode.W);
            bool runningLeftPressed = Input.GetKey(KeyCode.A);
            bool runningRightPressed = Input.GetKey(KeyCode.D);
            bool runningBackwardsPressed = Input.GetKey(KeyCode.S);
            bool sprintingPressed = Input.GetKey(KeyCode.LeftShift);
            bool swordAttackingPressed = Input.GetKey(KeyCode.R);

            // animating the movement

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);

            }

            if (!Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", false);

            }

            // animacija maca
 
            if (swordAttackingPressed)
            {
                animator.SetBool("isSwordAttacking", true);

            }

            if (!swordAttackingPressed)
            {
                animator.SetBool("isSwordAttacking", false);
            }

            // sprintanje

            if (runningPressed && sprintingPressed)
            {
                animator.SetBool("isSprinting", true);
                speed = 16f;
                Debug.Log("Trcim bre");
            }

            if (!runningPressed || !sprintingPressed)
            {
                animator.SetBool("isSprinting", false);
            }

            // mijenanje brzine kod prestanka sprinta

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 12f;
            }

            // trcanje ulijevo

            if (runningLeftPressed)
            {
                animator.SetBool("isRunningLeft", true);
            }

            if (!runningLeftPressed)
            {
                animator.SetBool("isRunningLeft", false);
            }

            if (runningBackwardsPressed)
            {
                animator.SetBool("isRunningBackwards", true);
            }

            if (!runningBackwardsPressed)
            {
                animator.SetBool("isRunningBackwards", false);
            }

            if (runningRightPressed)
            {
                animator.SetBool("isRunningRight", true);
            }

            if (!runningRightPressed)
            {
                animator.SetBool("isRunningRight", false);
            }

            // trcanje napred ulijevo

            if (runningPressed && runningLeftPressed)
            {
                animator.SetBool("isRunningForwardLeft", true);
            }

            if (!runningPressed || !runningLeftPressed)
            {
                animator.SetBool("isRunningForwardLeft", false);
            }

            // trcanje napred udesno

            if (runningPressed && runningRightPressed)
            {
                animator.SetBool("isRunningForwardRight", true);
            }

            if (!runningPressed || !runningRightPressed)
            {
                animator.SetBool("isRunningForwardRight", false);
            }

            // trcanje nazad ulijevo

            if (runningBackwardsPressed && runningLeftPressed)
            {
                animator.SetBool("isRunningBackwardsLeft", true);
            }

            if (!runningBackwardsPressed || !runningLeftPressed)
            {
                animator.SetBool("isRunningBackwardsLeft", false);
            }

            // trcanje nazad udesno

            if (runningBackwardsPressed && runningRightPressed)
            {
                animator.SetBool("isRunningBackwardsRight", true);
            }

            if (!runningBackwardsPressed || !runningRightPressed)
            {
                animator.SetBool("isRunningBackwardsRight", false);
            }


        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // moves the character
        controller.Move(move * speed * Time.deltaTime);

    }

   

}
