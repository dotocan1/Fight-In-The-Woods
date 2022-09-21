using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class MinionAI : MonoBehaviour
{
    //gameobjectivi na mapi
    private GameObject tower;
    public GameObject player;
    private GameObject minion;
    private GameObject phoenix;
    private GameObject fontana;
    bool parent;

    [SerializeField] private GameObject projectile;
    
    private float minionspeed = 10f;
    private Rigidbody rb;

    //TeamSetup
    [SerializeField] string minionTeamNameToAttack;
    [SerializeField] string WhichTowerToAttack;
    [SerializeField] string PlayerTeamTagToAttack;
    [SerializeField] string WhichPhoenixToAttack;
    //[SerializeField] string WhichFontanaToAttack;

    //Attacking
    public float timeBetweenAttacks;
    bool AlreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, minionInSightRange, minionInAttackRange;
    public bool TurretInSight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInSightRange = false;
        playerInAttackRange = false;


    }
    private void Start()
    {
        //fontana = GameObject.FindWithTag(WhichFontanaToAttack);
        minion = GameObject.FindWithTag(minionTeamNameToAttack);
        tower = GameObject.FindWithTag(WhichTowerToAttack);

        phoenix = GameObject.FindWithTag(WhichPhoenixToAttack);
        player = GameObject.FindWithTag(PlayerTeamTagToAttack);

    }

    void Update()
    {
        if (player != null && PlayerDistance())
        {
            playerInSightRange = true;
            Action(player);
        }
        if (minion != null && MinionDistance())
        {
            minionInSightRange = true;
            Debug.Log("Found a minion");
            Action(minion);
        }
        if (tower != null || TurretRange())
        {
            TurretInSight = true;
            Action(tower);
        }



    }
    private void Movement(GameObject target)
    {
        if (target != null)
        {
            Vector3 MinionDirection = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            Vector3 vector3 = target.transform.position - MinionDirection;
            transform.LookAt(target.transform.position);
            transform.Translate(new Vector3(0f, 0f, minionspeed * Time.deltaTime));
        }
    }

    private void FindPlayer(GameObject target1)
    {
        target1 = GameObject.FindWithTag(PlayerTeamTagToAttack);
    }

    private void AttackPlayer(GameObject target2)
    {
        Movement(null);
        if (!AlreadyAttacked)
        {
            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        AlreadyAttacked = false;    
    }

    public void TakeDamage()
    {
        //kod za damage + DestroyEnemy()
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
    private bool Distance(GameObject objekt)
    {
        float distanc = Vector3.Distance(objekt.transform.position, transform.position);
        if (distanc <= 6)
        {
            return true;
        }
        else return false;
        
    }

    private bool TurretRange()
    {
        float distance = Vector3.Distance(tower.transform.position, transform.position);
        if (distance <= 6)
        {
            return true;
        }
        else return false;

    }

    private bool AttackDistance(GameObject attackobjekt)
    {
        float distance = Vector3.Distance(attackobjekt.transform.position, transform.position);
        if (distance <= 4)
        {
            return true;
        }
        else return false;
    }

    private bool PlayerDistance()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 6)
        {
            return true;
        }
        else return false;
    }

    private bool MinionDistance()
    {
        float distance = Vector3.Distance(minion.transform.position, transform.position);
        if (distance <= 6)
        {
            return true;
        }
        else return false;
    }

    void Distanca()
    {
        float distance = Vector3.Distance(minion.transform.position, transform.position);
        Debug.Log(distance);
    }


    private void Action(GameObject entry)
    {
       if (AttackDistance(entry))
        {
            AttackPlayer(entry);
        }
        else
        {
            Movement(entry);
        }
    }

}
