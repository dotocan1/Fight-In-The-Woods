using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter_1 : MonoBehaviour
{
    public bool PlayerStatus_1;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_1")
        {
            PlayerStatus_1 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_1")
        {
            PlayerStatus_1 = false;
        }
    }
}
