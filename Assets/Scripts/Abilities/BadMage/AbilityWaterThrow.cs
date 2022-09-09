using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.Timers;

public class AbilityWaterThrow : MonoBehaviour
{

    private GameObject instantiatedObj;
    public Camera fpsCam;

    public bool IsAvailable = true;

    PhotonView view;

    private float cooldownDuration = 8f;
    [SerializeField]
    private float fireDelay = 20f;

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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
    }
}
