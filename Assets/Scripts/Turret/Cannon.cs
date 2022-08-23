using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 1f;
   

    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public void fire()
    {
        Instantiate(projectile, transform.position, transform.rotation); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
