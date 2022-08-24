using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skripta detektira ulazak playera u Turret range

public class PlayerEnter : MonoBehaviour
{
    
    public bool PlayerStatus;
    public void OnTriggerEnter(Collider other)
    {

        PlayerStatus = true;
        
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerStatus = false;
        
    }



}
