using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityArrowThrow : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject instantiatedObj;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position + (transform.forward) + (transform.up), transform.rotation);
            Destroy(instantiatedObj, 10f);
        }
    }
}
