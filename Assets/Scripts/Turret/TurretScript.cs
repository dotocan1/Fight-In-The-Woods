using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    PlayerEnter playerStatus;
    


    
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        currentCannon = GetComponentInChildren<Cannon>();
        fireRate = currentCannon.GetRateOfFire();
        playerStatus = GetComponentInParent<PlayerEnter>();
    }


    void Update()
    {
        
       Vector3 playerGroundPos = new Vector3(playerTransform.position.x, playerTransform.position.y-1, playerTransform.position.z);

        //provjeri ako je player u range-u
        if (Vector3.Distance(transform.position, playerGroundPos) > turretRange)
        {
            return; 
        }
        if (playerStatus.PlayerStatus)
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

