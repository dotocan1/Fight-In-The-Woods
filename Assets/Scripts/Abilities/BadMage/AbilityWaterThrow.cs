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

    private float gametimer = 0f;
    // private float coolDownTime;
    private float abilityUsed;


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

        gametimer += Time.deltaTime;
        int seconds = (int)(gametimer % 60);
        int minutes = (int)(gametimer / 60);

        // zadnji broj u uvjetu oznacava vrijeme cooldowna
        if (Input.GetKeyDown(KeyCode.Q) && (gametimer - abilityUsed) > 5.0f)
        {   
            abilityUsed = gametimer;
            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 0.5f);
        }
    }
}
