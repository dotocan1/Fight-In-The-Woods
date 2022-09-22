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

    public Transform playerTransform;
    private Cannon currentCannon;
    private float fireRate;
    private float fireRateDelta;
    //PlayerEnter skripta import status
    PlayerEnter_2 playerEnter_2;
    PlayerEnter_1 playerEnter_1;

    
    void Start()
    {
        currentCannon = GetComponentInChildren<Cannon>();
        fireRate = currentCannon.GetRateOfFire();

        playerEnter_2 = GetComponentInParent<PlayerEnter_2>();
        playerEnter_1 = GetComponentInParent<PlayerEnter_1>();
    }

    private void Update()
    {
        if (playerEnter_1 != null) {
            if (playerEnter_1.PlayerAvatar_1 != null) 
            {
                playerTransform = playerEnter_1.PlayerAvatar_1.transform;
                Fire(playerTransform);
            }
        } 
        else if (playerEnter_2 != null) {
            if (playerEnter_2.PlayerAvatar_2 != null)
            {
                playerTransform = playerEnter_2.PlayerAvatar_2.transform;
                Fire(playerTransform);
            }
        }
        
    }

    private void Fire(Transform playerAvatar)
    {
        Vector3 playerGroundPos = new Vector3(playerAvatar.position.x, playerAvatar.position.y, playerAvatar.position.z);

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

