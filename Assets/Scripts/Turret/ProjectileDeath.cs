using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    //fixati collider (Sphere collider Destroya cannon kuglu instantly
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
