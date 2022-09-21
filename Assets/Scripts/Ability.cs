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
        if(gameObject.name.Equals("BadMageCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/PullingCircle", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }
        
        // good mage ability

         if(gameObject.name.Equals("GoodMageCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/HealingRain", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/WavePush", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }

        // archer ability

         if(gameObject.name.Equals("ArcherCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/SingleArrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/ArrowCircle", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj);
            }
        }

        // warrior ability
    }

    private IEnumerator DestroyAbility(GameObject abilityObject)
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(abilityObject);
    }
}
