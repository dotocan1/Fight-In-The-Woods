using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] float turretRange = 17f;
    [SerializeField] float turretRotationSpeed = 10f;

    private Transform playerTransform;
    private Cannon currentCannon;
    private float fireRate;
    private float fireRateDelta;
    //PlayerEnter skripta import status
    PlayerEnter_2 playerStatus_2;
    PlayerEnter_1 playerStatus_1;

    
    void Start()
    {
        currentCannon = GetComponentInChildren<Cannon>();
        fireRate = currentCannon.GetRateOfFire();
        playerStatus_2 = GetComponentInParent<PlayerEnter_2>();
        playerStatus_1 = GetComponentInParent<PlayerEnter_1>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;


    }


    void Update()
    {

        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        Vector3 playerGroundPos = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        

        if (playerStatus_1.PlayerStatus_1 == true || playerStatus_2.PlayerStatus_2 == true)
        {
            //Cannon gleda u smjer playera
            Vector3 playerDirection = playerGroundPos - transform.position;
            float turretRotationStep = turretRotationSpeed * Time.deltaTime;
            Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, turretRotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newLookDirection);

            // cannon postavke
            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                currentCannon.fire();
                fireRateDelta = fireRate;
            }
       }

    }
}

