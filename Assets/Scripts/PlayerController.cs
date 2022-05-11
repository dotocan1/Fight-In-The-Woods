using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 20.0f;

    public float xRange = 10;

    public GameObject followTarget;

    // Start is called before the first frame update
    void Start()
    {

    }


    private float smooth = 0f;

    // Update is called once per frame
    void Update()
    {

        // moves the character

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        // rotates the player towards where camera is aiming

        Quaternion target = Quaternion.Euler(0, followTarget.transform.localRotation.eulerAngles.y, 0);

        // Dampen towards the target rotation

         transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
