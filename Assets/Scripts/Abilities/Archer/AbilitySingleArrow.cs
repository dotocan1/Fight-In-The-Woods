using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySingleArrow : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject instantiatedObj;
    public GameObject followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position + (transform.forward * 1) + (transform.up * 1.5f), followTarget.transform.rotation);
            Destroy(instantiatedObj, 10f);
        }
    }
}
