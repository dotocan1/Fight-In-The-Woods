using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 12f;
    private Transform playerTransform;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Impulse();
        playerTransform = gameObject.transform.parent;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            return;
        }
        Vector3 playerGroundPos = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        Vector3 vector3 = playerTransform.position - playerGroundPos;
        transform.LookAt(playerTransform.position);
        transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));

    }

    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }


}
