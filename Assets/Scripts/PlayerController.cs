using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    static readonly int forwardFloat = Animator.StringToHash("Forward");
    static readonly int jumpTrigger = Animator.StringToHash("Jump");
    static readonly int jumpState = Animator.StringToHash("Jump");

    private Animator anim;

    public float horizontalInput;
    public float verticalInput;
    private bool sprinting;
    private bool jump;
    public float speed = 10.0f;
    public float rotationSpeed = 125.0f;

    public GameObject followTarget;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {

        // moves the character

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);
        sprinting = Input.GetButton("Sprint");
        jump = Input.GetButtonDown("Jump");

        if (jump && 
            anim.GetCurrentAnimatorStateInfo(0).shortNameHash != jumpState && 
            anim.GetNextAnimatorStateInfo(0).shortNameHash != jumpState) 
                anim.SetTrigger(jumpTrigger);

        if (Input.GetKey(KeyCode.W))
        {
            if (sprinting) verticalInput *= 2;
            //transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            anim.SetFloat(forwardFloat, verticalInput, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }

        // sprinting

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12.0f;
        }
        else { speed = 10.0f; }
    }
}
