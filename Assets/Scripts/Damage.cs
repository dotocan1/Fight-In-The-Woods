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
        string gameObjectName = gameObject.name;

        if (gameObjectName.Equals("WaterThrow(Clone)"))
        {
            // ovo je poziv iz Combat skripte

            // ovo funkcionira ali je pod komentarom iz razloga sto kad pogodis zid il nes
            // baca error jer zid nema health tako da makni iz komentara tek kad si rjesila provjeru
            // za taggove

            //combatScript.takeWaterThrowDamage();
        }
        else if (gameObjectName.Equals("ArrowCircle(Clone)"))
        {

        }
        else if (gameObjectName.Equals("SingleArrow(Clone)"))
        {

        }
        else if (gameObjectName.Equals("PullingCircle(Clone)"))
        {

        }
        else if (gameObjectName.Equals("HealingRain(Clone)"))
        {

        }
        else if (gameObjectName.Equals("WavePush(Clone)"))
        {

        }
    }
}