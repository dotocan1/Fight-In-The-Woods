using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    static readonly int forwardFloat = Animator.StringToHash("Forward");
    static readonly int jumpTrigger = Animator.StringToHash("Jump");
    static readonly int jumpState = Animator.StringToHash("Jump");

    private Animator animator;


    private bool sprinting;
    private bool jump;
    public float speed = 12f;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // moves the character

        //sprinting = Input.GetButton("Sprint");
        //jump = Input.GetButtonDown("Jump");

        if (jump &&
            animator.GetCurrentAnimatorStateInfo(0).shortNameHash != jumpState &&
            animator.GetNextAnimatorStateInfo(0).shortNameHash != jumpState)
            animator.SetTrigger(jumpTrigger);

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
