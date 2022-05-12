using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePullingCircle : MonoBehaviour
{
    private Combat combatScript;
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Enemy") != null)
        {
            combatScript = GameObject.Find("Enemy").GetComponent<Combat>();
            startPosition = GameObject.Find("Enemy").transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // provjerava postoji li drugi objekt te je li drugi object character
        if (GameObject.Find("Enemy") != null && other.gameObject.GetInstanceID() == GameObject.Find("Enemy").GetInstanceID())
        {
            //other.gameObject.transform.position = transform.position

            // other.gameObject.transform.position = Vector3.Lerp(startPosition, transform.position, 1000f * Time.deltaTime);
            // treba implementirati da se polako primice krugu
        }
    }
}
