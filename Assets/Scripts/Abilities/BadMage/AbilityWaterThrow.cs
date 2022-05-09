using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWaterThrow : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject instantiatedObj;

    public float temp = 1.5f;
    public float temp2 = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position + (transform.forward * 1) + (transform.up * 1.5f), projectilePrefab.transform.rotation);
            Destroy(instantiatedObj, 0.3f);
        }
    }
}
