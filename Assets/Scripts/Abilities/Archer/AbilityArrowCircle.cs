using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AbilityArrowCircle : MonoBehaviour
{
    private GameObject instantiatedObj;
    public Camera fpsCam;

    public bool IsAvailable = true;
    public float CooldownDuration = 10.0f;

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

            instantiatedObj = PhotonNetwork.Instantiate("ArrowCircle", transform.position, transform.rotation);
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
