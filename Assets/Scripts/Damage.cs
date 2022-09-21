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

        if (!view.IsMine && gameObject.name.Equals("Sword"))
        {
            damageScript.enabled = false;
        }

        transform.SetParent(gameObject.transform);
    }
    private void Update()
    {
        if (gameObject.name.Equals("PullingCircle(Clone)"))
        {
            GameObject enemyy = getEnemy();
            string playerTag = parent.tag;
            string enemyTag = enemyy.tag;

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
            {
                {
                    float speed = 0.1f;
                    var step = speed * Time.deltaTime;
                    Debug.Log("Ovo je enemy tag : " + enemyy.tag + " i ime: " + enemy.name);

                    enemyy.transform.position = Vector3.MoveTowards(transform.position, transform.position, step);
                }
            }
        }
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        parent = PhotonView.Find((int)instantiationData[0]).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(parent == null)
        {
            return;
        }
        string gameObjectName = gameObject.name;
        string playerTag = parent.tag;
        string enemyTag = other.tag;

        if (gameObjectName.Equals("WaterThrow(Clone)"))
        {

            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeWaterThrowDamage();
                gameObject.GetComponent<SphereCollider>().enabled = false;
                PhotonNetwork.Destroy(gameObject);
            }
        }
        else if (gameObjectName.Equals("GoodMageFire(Clone)"))
        {
            if (playerTag != enemyTag)
            {
                if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
                {
                    Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                    setEnemy(other.gameObject);
                    enemy.GetComponent<Combat>().takeGoodMageFire();
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }
        else if (gameObjectName.Equals("ArrowCircle(Clone)"))
        {
            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeArrowCircleDamage();
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }
        else if (gameObjectName.Equals("Arrow(Clone)"))
        {
            if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
            {
                Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeSingleArrowDamage();
                gameObject.GetComponent<BoxCollider>().enabled = false;

            }
        }
        else if (gameObjectName.Equals("PullingCircle(Clone)"))
        {
            setEnemy(other.gameObject);
        }
        else if (gameObjectName.Equals("HealingRain(Clone)"))
        {
            if (playerTag == enemyTag)
            {

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().healPlayer();
                gameObject.GetComponent<SphereCollider>().enabled = false;

            }
        }

        else if (gameObjectName.Equals("GroundSlash(Clone)"))
        {
            if (playerTag == enemyTag)
            {

                setEnemy(other.gameObject);
                enemy.GetComponent<Combat>().takeGroundSlashDamage();
                gameObject.GetComponent<SphereCollider>().enabled = false;

            }
        }
        else if (gameObjectName.Equals("Sword"))
        {
            if (playerTag != enemyTag)
            {
                if (playerTag != enemyTag && (enemyTag == "Team_1" || enemyTag == "Team_2"))
                {
                    Debug.Log("PLAYER: " + playerTag + " ENEMY: " + enemyTag);

                    setEnemy(other.gameObject);
                    enemy.GetComponent<Combat>().takeSwordDamage();
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }
    }
}