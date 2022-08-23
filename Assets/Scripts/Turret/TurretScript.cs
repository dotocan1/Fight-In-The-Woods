using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] float turretRange = 10f;
    [SerializeField] float turretRotationSpeed = 5f;

    private Transform playerTransform;
    private Cannon currentCannon;
    private float fireRate;
    private float fireRateDelta;

    
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        currentCannon = GetComponentInChildren<Cannon>();
        fireRate = currentCannon.GetRateOfFire();
    }

    
    void Update()
    {
       Vector3 playerGroundPos = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        //provjeri ako je player u range-u
        if (Vector3.Distance(transform.position, playerGroundPos) > turretRange)
        {
            return; 
        }
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

    //test
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
