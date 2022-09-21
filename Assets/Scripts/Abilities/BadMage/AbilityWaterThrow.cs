using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AbilityWaterThrow : MonoBehaviour
{

    private GameObject instantiatedObj;
    public Camera fpsCam;
    PhotonView view;
    // timer

    float gametimer = 0f;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        AbilityWaterThrow abilityWaterThrow = GetComponent<AbilityWaterThrow>();

        if (!view.IsMine)
        {
            abilityWaterThrow.enabled = false;
            Debug.Log("Uspjesno unistena skripta");
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            object[] customInitData = new object[1];
            customInitData[0] = gameObject.GetPhotonView().ViewID;
            
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation, data: customInitData);
            StartCoroutine(DestroyAbility());
        }
    }

    private IEnumerator DestroyAbility()
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(instantiatedObj);
    }
}
