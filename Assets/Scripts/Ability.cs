using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ability : MonoBehaviour
{

    private GameObject instantiatedObj;
    public Camera fpsCam;
    PhotonView view;

    // timer

    private float gametimer = 0f;
    // private float coolDownTime;
    private float abilityUsed;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        Ability abilityScript = GetComponent<Ability>();

        if (!view.IsMine)
        {
            abilityScript.enabled = false;
        }
    }

    void Update()
    {

        // kreiranje timera
        gametimer += Time.deltaTime;
        int seconds = (int)(gametimer % 60);
        int minutes = (int)(gametimer / 60);

        // bad mage ability
        if(gameObject.name.Equals("BadMage(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
        {   
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/PullingCircle", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }else if((Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)){
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/PullingCircle", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
        }
        
        // good mage ability

         if(gameObject.name.Equals("GoodMage(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
        {   
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/HealingRain", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }else if((Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)){
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/WavePush", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
        }

        // archer ability

         if(gameObject.name.Equals("Archer(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
        {   
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/SingleArrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }else if((Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)){
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/ArrowCircle", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
        }

        // warrior ability
    }
}
