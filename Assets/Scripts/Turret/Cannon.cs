using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    //rate of fire od cannona
    [SerializeField] float rateOfFire = 1f;
   

    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public void fire()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.transform.parent = GetComponentInParent<TurretScript>().playerTransform; // u parent transform sam spremila transform od playera (fuš)
    }
}
