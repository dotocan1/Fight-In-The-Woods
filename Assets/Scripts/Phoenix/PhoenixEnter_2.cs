using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixEnter_2 : MonoBehaviour
{
    public bool PhoenixStatus_2;
    public GameObject PlayerAvatar_2;
    Transform child;

    private void Start()
    {
        PhoenixStatus_2 = false;
        child = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_2")
        {
            PhoenixStatus_2 = true;
            PlayerAvatar_2 = other.gameObject;
            child.GetComponent<Phoenix>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_2")
        {
            PhoenixStatus_2 = false;
            PlayerAvatar_2 = null;
            child.GetComponent<Phoenix>().enabled = false;
        }

    }

}
