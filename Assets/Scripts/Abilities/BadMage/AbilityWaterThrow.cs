using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AbilityWaterThrow : MonoBehaviour
{

    private GameObject instantiatedObj;
    public Camera fpsCam;
    PhotonView view;

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

            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
    }
}
