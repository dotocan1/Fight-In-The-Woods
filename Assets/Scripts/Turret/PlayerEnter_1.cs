using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//Skripta detektira ulazak playera u Turret range

public class PlayerEnter_1 : MonoBehaviour
{
    public bool PlayerStatus_1;
    public GameObject PlayerAvatar_1;
    Transform child;

    private void Start()
    {
        PlayerStatus_1 = false;
        child = transform.GetChild(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_1" || other.tag == "MinionTeam_1")
        {
            PlayerStatus_1 = true;
            PlayerAvatar_1 = other.gameObject;
            child.GetComponent<TurretScript>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Team_1" || other.tag == "MinionTeam_1")
        {
            PlayerStatus_1 = false;
            PlayerAvatar_1 = null;
            child.GetComponent<TurretScript>().enabled = false;
        }
    }



}


/*using Unity.VisualScripting;
using UnityEngine;

    public class CodeTriggerCustomEvent : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //Trigger the previously created Custom Scripting Event MyCustomEvent with the integer value 2.
            EventBus.Trigger(EventNames.MyCustomEvent, 2);
        }
    }
}*/
