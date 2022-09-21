using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//Skripta detektira ulazak playera u Turret range

public class PlayerEnter_2 : MonoBehaviour
{
    public bool PlayerStatus_2;
    public GameObject PlayerAvatar_2;
    Transform child;

    private void Start()
    {
        PlayerStatus_2 = false;
        child = transform.GetChild(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_2" || other.tag == "MinionTeam_2")
        {
            PlayerStatus_2 = true;
            PlayerAvatar_2 = other.gameObject;
            child.GetComponent<TurretScript>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_2" || other.tag == "MinionTeam_2")
        {
            PlayerStatus_2 = false;
            PlayerAvatar_2 = null;
            child.GetComponent<TurretScript>().enabled = false;
        }
    }



}