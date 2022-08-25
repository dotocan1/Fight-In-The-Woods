using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    //fixati collider (Sphere collider Destroya cannon kuglu instantly
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
