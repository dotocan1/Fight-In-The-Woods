using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MinionAI : MonoBehaviour
{
    //gameobjectivi na mapi
    private GameObject tower;
    public GameObject player;
    private GameObject minion;
    private GameObject phoenix;

    [SerializeField] private GameObject projectile;
    
    private float minionspeed = 5f;
    private Rigidbody rb;

    //TeamSetup
    [SerializeField] string minionTeamNameToAttack;
    [SerializeField] string WhichTowerToAttack;
    [SerializeField] string PlayerTeamTagToAttack;
    [SerializeField] string WhichPhoenixToAttack;

    //Attacking
    public float timeBetweenAttacks;
    bool AlreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInSightRange = false;
        playerInAttackRange = false;
    }
    private void Start()
    {
        minion = GameObject.FindWithTag(minionTeamNameToAttack);
        tower = GameObject.FindWithTag(WhichTowerToAttack);
        phoenix = GameObject.FindWithTag(WhichPhoenixToAttack);
        player = GameObject.FindWithTag(PlayerTeamTagToAttack);

    }

    void Update()
    {

        //napad izmedju playera i miniona
        if (player != null)
        {
            playerInSightRange = Distance(player);
            playerInAttackRange = AttackDistance(player);

            if (!playerInSightRange && !playerInAttackRange)
            {
                Debug.Log("not in range!");
                Movement(tower);
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                FindPlayer(player);
            }
            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer(player);
            }
        }
        //napad izmedju miniona i miniona
        else if (minion != null)
        {
            
            playerInSightRange = Distance(minion);
            playerInAttackRange = AttackDistance(minion);

            if (!playerInSightRange && !playerInAttackRange)
            {
                Movement(tower);
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                FindPlayer(minion);
            }
            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer(minion);
            }

        }
        else if (tower != null)
        {
            playerInSightRange = Distance(tower);
            playerInAttackRange = Distance(tower);
            Movement(tower);
            if (playerInSightRange && playerInAttackRange)
            {
                AttackPlayer(tower);
            }

        } 
        /*else if (phoenix != null)
        {
            Movement(phoenix);
            AttackPlayer(phoenix);
        }*/
        /*else
        {
            Movement(fontana);
            AttackPlayer(fontana);
            
        }*/
      
    }
    private void Movement(GameObject target)
    {
        Vector3 MinionDirection = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 vector3 = target.transform.position - MinionDirection;
        transform.LookAt(target.transform.position);
        transform.Translate(new Vector3(0f, 0f, minionspeed * Time.deltaTime));
    }

    private void FindPlayer(GameObject target1)
    {
        target1 = GameObject.FindWithTag(PlayerTeamTagToAttack);
    }

    private void AttackPlayer(GameObject target2)
    {

        if (!AlreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);

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

    private bool AttackDistance(GameObject attackobjekt)
    {
        float distance = Vector3.Distance(attackobjekt.transform.position, transform.position);
        if (distance <= 4)
        {
            return true;
        }
        else return false;
    }

}
