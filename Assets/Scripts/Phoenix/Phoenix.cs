using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Phoenix : MonoBehaviour
{
    [SerializeField] float PhoenixRange = 17f;
    [SerializeField] float PhoenixRotationSpeed = 10f;

    PlayerEnter_2 playerStatus_2;
    PlayerEnter_1 playerStatus_1;

    private float RateOfFire = 2f;
    private float RateOfFireDelta; 

    //Ubacujemo skriptu is PhoenixFire
    private PhoenixFire Fire;

    private Transform playerTransform;

    void Start()
    {
        //playerTransform = FindObjectOfType<PlayerMovement>().transform;
        Fire = GetComponentInChildren<PhoenixFire>();
        playerStatus_2 = GetComponentInParent<PlayerEnter_2>();
        playerStatus_1 = GetComponentInParent<PlayerEnter_1>();

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

        if (playerStatus_1.PlayerStatus_1 == true || playerStatus_2.PlayerStatus_2 == true)
        {

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
}
