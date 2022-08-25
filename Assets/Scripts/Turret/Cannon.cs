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
        Instantiate(projectile, transform.position, transform.rotation); 
    }
}
