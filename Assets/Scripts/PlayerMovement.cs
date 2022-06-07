using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{


    private Animator animator;
    PhotonView view;


    public float speed = 12f;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {

        //bool isRunning = animator.GetBool("isRunning");

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (view.IsMine)
        {
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
}
