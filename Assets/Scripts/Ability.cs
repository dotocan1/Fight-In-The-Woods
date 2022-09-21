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
        bool castingE = Input.GetKeyDown(KeyCode.E);

        // kreiranje timera
        gametimer += Time.deltaTime;
        int seconds = (int)(gametimer % 60);
        int minutes = (int)(gametimer / 60);

        // bad mage ability
        if (gameObject.name.Equals("BadMageCharacter(Clone)"))
        {
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 1.0f)
            {
                animator.SetBool("isCastingQ", true);
                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("WaterThrow"));
            }
            else if (!castingQ)
            {
                animator.SetBool("isCastingQ", false);
            }
            if ((castingE && (gametimer - abilityUsed) > 1.0f))
            {
                animator.SetBool("isCastingE", true);
                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("PullingCircle"));
            }
            else if (!castingE)
            {
                animator.SetBool("isCastingE", false);
            }
        }

        // good mage ability

        if (gameObject.name.Equals("GoodMageCharacter(Clone)"))
        {
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 1.0f)
            {
                animator.SetBool("isCastingQ", true);
                
                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("WavePush"));

            }
            else if (!castingQ)
            {
                animator.SetBool("isCastingQ", false);
            }
            if ((castingE && (gametimer - abilityUsed) > 1.0f))
            {
                animator.SetBool("isCastingE", true);
               
                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("HealingRain"));
            }
            else if (!castingE)
            {
                animator.SetBool("isCastingE", false);
            }
        }

        // archer ability

        if (gameObject.name.Equals("ArcherCharacter(Clone)"))
        {
            // zadnji broj u uvjetu oznacava vrijeme cooldowna
            if (castingQ && (gametimer - abilityUsed) > 1.0f)
            {
                animator.SetBool("isCastingQ", true);
                
                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("SingleArrow"));
            }
            else if (!castingQ)
            {
                animator.SetBool("isCastingQ", false);
            }
            if ((castingE && (gametimer - abilityUsed) > 1.0f))
            {
                animator.SetBool("isCastingE", true);

                abilityUsed = gametimer;

                StartCoroutine(InstantiateAbilities("ArrowCircle"));
            }
            else if (!castingE)
            {
                animator.SetBool("isCastingE", false);
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
            }
            else if (!castingQ)
            {
                animator.SetBool("isCastingQ", false);
            }
            if ((castingE && (gametimer - abilityUsed) > 5.0f))
            {
                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                abilityUsed = gametimer;

                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Warrior/", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }
            else if (!castingE)
            {
                animator.SetBool("isCastingE", false);
            }
        }
        IEnumerator InstantiateAbilities(string choice)
        {
            object[] customInitData = new object[1];
            customInitData[0] = gameObject.GetPhotonView().ViewID;
            // uvjet
            if (choice.Equals("WaterThrow"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }else if (choice.Equals("PullingCircle"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/PullingCircle", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }else if (choice.Equals("HealingRain"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/HealingRain", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }else if (choice.Equals("WavePush"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/WavePush", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            }else if (choice.Equals("SingleArrow"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/SingleArrow", transform.position, fpsCam.transform.rotation, data: customInitData);
                StartCoroutine(DestroyAbility(instantiatedObj));
            } else if (choice.Equals("ArrowCircle"))
            {
                yield return new WaitForSeconds(1f);
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/ArrowCircle", transform.position, fpsCam.transform.rotation, data: customInitData);
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
