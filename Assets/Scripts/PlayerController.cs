using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 125.0f;

    public GameObject followTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    private float smooth = 0.5f;

    // Update is called once per frame
    void Update()
    {

        // moves the character

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
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



        // rotates the player towards where camera is aiming

        Quaternion target = Quaternion.Euler(0, followTarget.transform.localRotation.eulerAngles.y, 0);

        // Dampen towards the target rotation

        // transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
