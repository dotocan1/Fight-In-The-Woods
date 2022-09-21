using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PrimaryAttack : MonoBehaviour
{
    private Animator animator;
    private GameObject instantiatedObj;
    public Camera fpsCam;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        PrimaryAttack primaryAttackScript = GetComponent<PrimaryAttack>();

        if (!view.IsMine)
        {
            primaryAttackScript.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool attacking = Input.GetKeyDown(KeyCode.R);

        if (gameObject.name.Equals("WarriorCharacter(Clone)"))
        {
            if (attacking)
            {
                animator.SetBool("isAttacking", true);
            }
            else if (!attacking)
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else if (gameObject.name.Equals("ArcherCharacter(Clone)"))
        {
            if (attacking)
            {
                animator.SetBool("isAttacking", true);

                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/Archer/Arrow", transform.position, fpsCam.transform.rotation, data: customInitData);
                instantiatedObj.transform.parent = transform;
                instantiatedObj.transform.localPosition = new Vector3(0f, 1.475f, 2.653f);
                instantiatedObj.transform.parent = null;
                StartCoroutine(DestroyAbility(instantiatedObj));

                // TODO: izbrisi ako pogodi playera ili tower
            }
            else if (!attacking)
            {
                animator.SetBool("isAttacking", false);
            }
        }
        else if (gameObject.name.Equals("GoodMageCharacter(Clone)") || gameObject.name.Equals("BadMageCharacter(Clone)"))
        {
            if (attacking)
            {

                animator.SetBool("isAttacking", true);

                object[] customInitData = new object[1];
                customInitData[0] = gameObject.GetPhotonView().ViewID;
                instantiatedObj = PhotonNetwork.Instantiate("Abilities/GoodMage/GoodMageFire", transform.position, fpsCam.transform.rotation, data: customInitData);
                instantiatedObj.transform.parent = transform;
                instantiatedObj.transform.localPosition = new Vector3(0.243f, 1.318f, 0.773f);
                instantiatedObj.transform.parent = null;
                StartCoroutine(DestroyAbility(instantiatedObj));

                // TODO: izbrisi ako pogodi playera ili tower
            }
            else if (!attacking)
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (GameObject.Find("Enemy") != null)
    //    {
    //        //Debug.Log(gameObject.name);
    //        combatScript.takeSwordDamage(character);
    //    }
    //}


    private IEnumerator DestroyAbility(GameObject abilityObject)
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.Destroy(abilityObject);
    }
}
