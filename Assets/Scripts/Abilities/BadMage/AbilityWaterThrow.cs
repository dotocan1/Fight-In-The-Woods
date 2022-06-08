using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AbilityWaterThrow : MonoBehaviour
{
    private GameObject instantiatedObj;
    public Camera fpsCam;

    public bool IsAvailable = true;
    public float CooldownDuration = 10.0f;

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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // if not available to use (still cooling down) just exit
            if (IsAvailable == false)
            {
                return;
            }

            // made it here then ability is available to use...
            // UseAbilityCode goes here

            instantiatedObj = PhotonNetwork.Instantiate("Abilities/BadMage/WaterThrow", transform.position + (transform.forward * 1) + (transform.up * 1.5f), fpsCam.transform.rotation);
            Destroy(instantiatedObj, 10f);

            // start the cooldown timer
            StartCoroutine(StartCooldown());
        }
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }
}
