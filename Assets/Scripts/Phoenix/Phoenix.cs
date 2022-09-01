using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    [SerializeField] float PhoenixRange = 17f;
    [SerializeField] float PhoenixRotationSpeed = 10f;
    
    private float RateOfFire = 1.5f;
    private float RateOfFireDelta; 

    //Ubacujemo skriptu is PhoenixFire
    private PhoenixFire Fire;

    private Transform playerTransform;

    void Start()
    {
        //playerTransform = FindObjectOfType<PlayerMovement>().transform;
        Fire = GetComponentInChildren<PhoenixFire>();
        
    }
    void Update()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;

        Vector3 playerGroundPos = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);


        //provjeri ako je player u range-u
        if (Vector3.Distance(transform.position, playerGroundPos) > PhoenixRange)
        {
            return;
        }

        Vector3 playerDirection = playerGroundPos - transform.position;
        float PhoenixRotationStep = PhoenixRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, PhoenixRotationStep, 0f);
        transform.rotation = Quaternion.LookRotation(newLookDirection);

        RateOfFireDelta -= Time.deltaTime;
        if (RateOfFireDelta <= 0)
        {
            Fire.PlayEffect();
            RateOfFireDelta = RateOfFire;
        }

    }
}
