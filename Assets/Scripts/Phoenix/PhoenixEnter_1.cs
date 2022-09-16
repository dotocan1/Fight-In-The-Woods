using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixEnter_1 : MonoBehaviour
{
    public bool PhoenixStatus_1;
    public GameObject PlayerAvatar_1;
    Transform child;

    private void Start()
    {
        PhoenixStatus_1 = false;
        child = transform.GetChild(0);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_1")
        {
            PhoenixStatus_1 = true;
            PlayerAvatar_1 = other.gameObject;
            child.GetComponent<Phoenix>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_1")
        {
            PhoenixStatus_1 = false;
            PlayerAvatar_1 = null;
            child.GetComponent<Phoenix>().enabled = false;
        }

    }



}
