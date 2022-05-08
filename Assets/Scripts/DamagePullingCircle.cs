using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePullingCircle : MonoBehaviour
{
    private Combat combatScript;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Enemy") != null)
        {
            combatScript = GameObject.Find("Enemy").GetComponent<Combat>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("Enemy") != null)
        {
            Debug.Log("Pulling circle works!");
            
            // TODO: ovdje sada ide logika koja povlaci
            // playere u sredinu


        }
    }
}
