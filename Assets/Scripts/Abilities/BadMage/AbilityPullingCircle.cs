using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPullingCircle : MonoBehaviour
{
    public GameObject projectilePrefab;
    float delay = 2.0f; //This implies a delay of 2 seconds.
    private GameObject instantiatedObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Launch a projectile

            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            Destroy(instantiatedObj, 2);
        }
    }
}
