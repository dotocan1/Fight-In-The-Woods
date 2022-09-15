using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    /*

        SingleArrow
        PullingCircle
        HealingRain
        WavePush
    
    */
    private Combat combatScript;

    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(gameObject.name, "ArrowCircle"))
        {   
            // ovo je poziv iz Combat skripte
            combatScript.takeArrowCircleDamage();
        }

        else if (string.Equals(gameObject.name, "WaterThrow"))
        {
            combatScript.takeWaterThrowDamage();
        }


    }
}