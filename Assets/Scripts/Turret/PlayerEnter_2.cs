using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//Skripta detektira ulazak playera u Turret range

public class PlayerEnter_2 : MonoBehaviour
{
    
    public bool PlayerStatus_2;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_2")
        {
            PlayerStatus_2 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_2")
        {
            PlayerStatus_2 = false;
        }
    }



}
