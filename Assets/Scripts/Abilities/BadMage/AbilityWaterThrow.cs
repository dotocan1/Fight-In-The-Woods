using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWaterThrow : MonoBehaviour
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
        if (Input.GetKey(KeyCode.Q))
        {
            instantiatedObj = (GameObject)Instantiate(projectilePrefab, transform.position, transform.rotation);
            Destroy(instantiatedObj, 0.3f);
        }
    }
}
