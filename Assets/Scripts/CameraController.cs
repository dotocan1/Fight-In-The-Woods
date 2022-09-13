using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Object;
using Cinemachine;

public class CameraController : NetworkBehaviour
{

    //public Vector2 turn;
    //public float sensitivity = .5f;

    //// Update is called once per frame
    //void Update()
    //{
    //    turn.y += Input.GetAxis("Mouse Y") * sensitivity;
    //    turn.x += Input.GetAxis("Mouse X") * sensitivity;
    //    transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    //}

    public GameObject followTarget;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            Camera c = Camera.main;
            CinemachineVirtualCamera vc = c.GetComponent<CinemachineVirtualCamera>();
            vc.Follow = followTarget.transform;
            vc.LookAt = followTarget.transform;
        }
    }
}

