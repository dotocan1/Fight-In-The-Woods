using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{


    // 7.6. Photon view



    private bool sprinting;
    private bool jump;
    private bool isMoving;

    public float speed;

    public CharacterController controller;
    private Animator animator;

    //footsteps sound 
    private AudioSource SoundPlayer;
    public AudioClip[] clips;
    



    PhotonView view;
    [SerializeField] Camera cam;
    [SerializeField] AudioListener audioListener;


    // 7.6. dodani private na start
    private void Start()
    {
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        SoundPlayer = GetComponent<AudioSource>();
        
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
            bool sprintingPressed = Input.GetKey(KeyCode.LeftShift);
            bool swordAttackingPressed = Input.GetKey(KeyCode.R);

            // animating the movement

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", true);
                if (!SoundPlayer.isPlaying) PlayerFootstepForward();

            }

            if (!Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isRunning", false);
                if(SoundPlayer.isPlaying) SoundPlayer.Stop();

            }

            if (swordAttackingPressed)
            {
                animator.SetBool("isSwordAttacking", true);
            }

            if (!swordAttackingPressed)
            {
                animator.SetBool("isSwordAttacking", false);
            }

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

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isRunningLeft", true);
            }
 

            if (!Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isRunningLeft", false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkingBackwards", true);
            }

            if (!Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkingBackwards", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalkingLeft", true);
            }

            if (!Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalkingLeft", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalkingRight", true);
            }

            if (!Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalkingRight", false);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 12f;
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

    private void PlayerFootstepForward()
    {
        
        SoundPlayer.pitch = Random.Range(0.90f, 1.05f);
        SoundPlayer.volume = 0.02f;
        if (Input.GetKeyDown(KeyCode.W))
        {
            SoundPlayer.PlayDelayed(0.18f);
        }
        else SoundPlayer.Play();
    }

}
