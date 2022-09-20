using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private Combat combatScript;
    private GameObject enemy;

    public GameObject getEnemy()
    {
        return enemy;
    }

    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    public void Update()
    {
        if (combatScript == null)
        {
            combatScript = gameObject.transform.parent.gameObject.GetComponent<Combat>();
            Debug.Log("COMBAT SCRIPT " + combatScript);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(combatScript);
        string gameObjectName = gameObject.name;
        string playerTag = gameObject.transform.parent.tag;

        Debug.Log("NAMEEEE: " + gameObjectName);
        string enemyTag = other.tag;

        Debug.Log("ENEMY NAME: " + other.name);
        Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

        if (gameObjectName.Equals("WaterThrow(Clone)"))
        {
            
            if(playerTag != enemyTag)
            {
                Debug.Log("PLAYER'S TAG: " + playerTag);
                Debug.Log("ENEMY'S TAG; " + enemyTag);

                Debug.Log(combatScript);
                combatScript.takeWaterThrowDamage();
            } else
            {
                Debug.Log("TAGOVI SE NE POKLAPAJU");
            }
        }
        else if (gameObjectName.Equals("ArrowCircle(Clone)"))
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

        }
    }
}