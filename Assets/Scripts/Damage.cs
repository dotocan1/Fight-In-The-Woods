using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private Combat combatScript;
    private GameObject enemy;

    public void getEnemy()
    {

    }

    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }


    private void OnTriggerEnter(Collider other)
    {
        string gameObjectName = gameObject.name;

        if (gameObjectName.Equals("WaterThrow(Clone)"))
        {
            string enemyTag = other.tag;

            // dohvati tag od charactera koji je upotrijebio ability
            // nakon dohvacanja oba taga usporedujes dal su u istom timu, ako nisu, nanesi damage

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