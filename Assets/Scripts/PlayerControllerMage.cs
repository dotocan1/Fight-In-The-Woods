using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMage : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 20.0f;

    public float xRange = 10;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    

        if (Input.GetKey(KeyCode.E))
        {
            // Launch a projectile

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        // moves the character

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
    }
}
