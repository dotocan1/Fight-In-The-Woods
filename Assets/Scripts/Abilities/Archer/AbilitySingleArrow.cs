using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySingleArrow : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject instantiatedObj;
    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position + (transform.forward) + (transform.up), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 10f);
        }
    }
}
