using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Phoenix : MonoBehaviour
{
    [SerializeField] float PhoenixRange = 17f;
    [SerializeField] float PhoenixRotationSpeed = 10f;

    public Transform playerTransform;
    private float RateOfFire = 1.5f;
    private float RateOfFireDelta;
    //Ubacujemo skriptu is PhoenixFire
    private PhoenixFire Fire;
    //ubacujemo player status
    PhoenixEnter_1 phoenixEnter_1;
    PhoenixEnter_2 phoenixEnter_2;
    


    void Start()
    {
        Fire = GetComponentInChildren<PhoenixFire>();

        phoenixEnter_1 = GetComponentInParent<PhoenixEnter_1>();
        phoenixEnter_2 = GetComponentInParent<PhoenixEnter_2>();

    }
    void Update()
    {
        if (phoenixEnter_1 != null)
        {
            playerTransform = phoenixEnter_1.PlayerAvatar_1.transform;
            FireBall(playerTransform);
        }
        else if (phoenixEnter_2 != null)
        {
            playerTransform = phoenixEnter_2.PlayerAvatar_2.transform;
            FireBall(playerTransform);
        }
    }


        private void FireBall(Transform playerAvatar)
    {
        Vector3 playerGroundPos = new Vector3(playerAvatar.position.x, playerAvatar.position.y, playerAvatar.position.z);

        //Cannon gleda u smjer playera
        Vector3 playerDirection = playerGroundPos - transform.position;
        float turretRotationStep = PhoenixRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, turretRotationStep, 0f);
        transform.rotation = Quaternion.LookRotation(newLookDirection);

        RateOfFireDelta -= Time.deltaTime;
        if (RateOfFireDelta <= 0)
        {
            Fire.PlayEffect();
            RateOfFireDelta = RateOfFire;
        }
    }

}
