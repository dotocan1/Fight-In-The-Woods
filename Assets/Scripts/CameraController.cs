using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f;

    // This script is attached to the FollowTarget game object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // control the camera view

        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-mouseY * sensitivity, 0, 0));

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * sensitivity, 0));
    }
}
