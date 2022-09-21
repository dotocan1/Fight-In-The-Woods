using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Damage : MonoBehaviour
{
    private GameObject enemy;

    public GameObject getEnemy()
    {
        return enemy;
    }

    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("OTHER NAME " + other.name);
        string gameObjectName = gameObject.name;
        Debug.Log("GAME OBJ " + gameObject.transform.parent.name);

        /*if (gameObjectName.Equals("WaterThrow(Clone)"))
        {
            string playerTag = gameObject.transform.parent.tag;
            string enemyTag = other.tag;

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeWaterThrowDamage();
                //combatScript.takeWaterThrowDamage();
            }
            else
            {
                return;
            }
        }
        /*else if (gameObjectName.Equals("ArrowCircle(Clone)"))
        {
            if (playerTag != enemyTag)
            {
                //combatScript.takeArrowCircleDamage();
            }
        }
        else if (gameObjectName.Equals("SingleArrow(Clone)"))
        {
            if (playerTag != enemyTag)
            {
                //combatScript.takeSingleArrowDamage();
            }
        }
        else if (gameObjectName.Equals("PullingCircle(Clone)"))
        {

        }
        else if (gameObjectName.Equals("HealingRain(Clone)"))
        {
            if (playerTag != enemyTag)
            {
                //combatScript.healPlayer();
            }
        }
        else if (gameObjectName.Equals("WavePush(Clone)"))
        {
            if (playerTag != enemyTag)
            {
                //combatScript.wavePush();
            }
        }
        else if (gameObject.name.Equals("WarriorCharacter(Clone)"))
        {

        }*/
    }
}