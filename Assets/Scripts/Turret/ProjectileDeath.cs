using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    //fixati collider (Sphere collider Destroya cannon kuglu instantly
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Team_1" || other.tag == "Team_2" || other.tag == "Player" || other.tag == "MinionTeam_1" || other.tag == "MinionTeam_2")
        {
            Destroy(gameObject);
        }
    }


}
