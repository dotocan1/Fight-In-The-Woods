using UnityEngine;
using Photon.Pun;

public class Damage : MonoBehaviour, IPunInstantiateMagicCallback
{
    PhotonView view;
    private GameObject enemy;
    private GameObject parent;

    public GameObject getEnemy()
    {
        return enemy;
    }

    public void setEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    private void Start()
    {
        view = GetComponent<PhotonView>();
        Damage damageScript = GetComponent<Damage>();

        if (!view.IsMine)
        {
            damageScript.enabled = false;
        }

        transform.SetParent(gameObject.transform);
    }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        parent = PhotonView.Find((int)instantiationData[0]).gameObject;
    }

    private void OnTriggerEnter(Collider other)
     {

        string gameObjectName = gameObject.name;
        string playerTag = parent.tag;
        string enemyTag = other.tag;

        if (gameObjectName.Equals("WaterThrow(Clone)"))
        {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeWaterThrowDamage();
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }
        else if (gameObjectName.Equals("GoodMageFire(Clone)"))
        {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeGoodMageFire();
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else if (gameObjectName.Equals("ArrowCircle(Clone)"))
         {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeArrowCircleDamage();
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }
         else if (gameObjectName.Equals("Arrow(Clone)"))
         {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                Debug.Log("ENEMY NAME " + other.name);
                enemy.GetComponent<Combat>().takeSingleArrowDamage();
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
         else if (gameObjectName.Equals("PullingCircle(Clone)"))
         {
            // dodaj
        }
         else if (gameObjectName.Equals("HealingRain(Clone)"))
         {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().healPlayer();
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
         }
         else if (gameObjectName.Equals("WavePush(Clone)"))
         {
            string teamNumber = playerTag == "Team_1" ? "A" : "B";

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2" || (enemyTag.Contains("Tower") && !enemyTag.Contains(teamNumber))))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().wavePush();
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
         }
         else if (gameObject.name.Equals("WarriorCharacter(Clone)"))
         {
            // dodaj
        }
    }
 }