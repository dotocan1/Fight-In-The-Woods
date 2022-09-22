using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    //rate of fire od cannona
    [SerializeField] float rateOfFire = 1f;
   

    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public void fire()
    {
        object[] customInitData = new object[1];
        customInitData[0] = gameObject.GetPhotonView().ViewID;

        GameObject bullet = PhotonNetwork.Instantiate("HM_cannon_bullet1", transform.position, transform.rotation, data: customInitData);
        bullet.transform.parent = GetComponentInParent<TurretScript>().playerTransform; // u parent transform sam spremila transform od playera (fuš)
    }
}
