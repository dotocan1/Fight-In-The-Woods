using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePullingCircle : MonoBehaviour
{
    private Combat combatScript;
    bool isAbility = false;
    private float speed = 8.0f;

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
        if(isAbility == true)
        {
            GameObject.Find("Enemy").transform.position = Vector3.MoveTowards(GameObject.Find("Enemy").transform.position, transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // provjerava postoji li drugi objekt te je li drugi object character
        if (GameObject.Find("Enemy") != null && other.gameObject.GetInstanceID() == GameObject.Find("Enemy").GetInstanceID())
        {   
            isAbility = true;
        }
    }
}
