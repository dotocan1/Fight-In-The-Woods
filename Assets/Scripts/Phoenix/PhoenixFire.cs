using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PhoenixFire : MonoBehaviour
{
    [SerializeField] VisualEffect effect; 

    public void PlayEffect()
    {
        effect.Play();
    }

}
