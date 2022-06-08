using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{

    public float speed = 12f;

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

        if(!view.IsMine)
        {
            //Destroy(cam);
            cam.enabled = false;
            audioListener.enabled = false;
            Debug.Log("AAAAAAAAAAAAA");
        }
    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // 7.6. If View
        if (view.IsMine) // check if this is my player character
        {
            Move();   
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

            // moves the character

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);
            }

            if (!Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", false);
            }

            // sprinting

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12.0f;
            }
            else { speed = 10.0f; }
    }
}
