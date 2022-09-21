using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ability : MonoBehaviour
{

    private GameObject instantiatedObj;
    public Camera fpsCam;
    PhotonView view;
    private Animator animator;

    // timer

    private float gametimer = 0f;
    // private float coolDownTime;
    private float abilityUsed;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        Ability abilityScript = GetComponent<Ability>();
        animator = GetComponent<Animator>();

        if (!view.IsMine)
        {
            abilityScript.enabled = false;
        }
    }

    void Update()
    {

        bool castingQ = Input.GetKeyDown(KeyCode.Q);

        // kreiranje timera
        gametimer += Time.deltaTime;
        int seconds = (int)(gametimer % 60);
        int minutes = (int)(gametimer / 60);

        // bad mage ability
        if(gameObject.name.Equals("BadMageCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/PullingCircle", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }
        
        // good mage ability

         if(gameObject.name.Equals("GoodMageCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/HealingRain", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/WavePush", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }

        // archer ability

         if(gameObject.name.Equals("ArcherCharacter(Clone)")){
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 5.0f)
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/SingleArrow", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f)){
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/ArrowCircle", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }

        // warrior ability

        if (gameObject.name.Equals("WarriorCharacter(Clone)"))
        {
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 1.0f)
            {
                animator.SetBool("isCastingQ", true);

                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Warrior/GroundSlash", transform.position, transform.rotation, data: customInitData);
                instantiatedObj.transform.parent = transform;
                instantiatedObj.transform.localPosition = new Vector3(-0.05716324f, -3.12f, 1.4599f);
                instantiatedObj.transform.parent = null;
                StartCoroutine(DestroyAbility(instantiatedObj));
            } else if (!castingQ)
            {
                animator.SetBool("isCastingQ", false);
            }
            else if ((Input.GetKeyDown(KeyCode.E) && (gametimer - abilityUsed) > 5.0f))
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Warrior/", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
        }
    }

    private IEnumerator DestroyAbility(GameObject abilityObject)
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(abilityObject);
    }
}
