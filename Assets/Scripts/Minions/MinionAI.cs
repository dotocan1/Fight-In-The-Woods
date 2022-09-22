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
    private GameObject fontana;
    
    private float minionspeed = 5f;
    private Rigidbody rb;

    //TeamSetup
    [SerializeField] string minionTeamNameToAttack;
    [SerializeField] string WhichTowerToAttack;
    [SerializeField] string PlayerTeamTagToAttack;
    [SerializeField] string WhichPhoenixToAttack;
    [SerializeField] string WhichFontanaToAttack;

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
        fontana = GameObject.FindWithTag(WhichFontanaToAttack);

    }

    void Update()
    {
        if(player != null)
        {
            if (Distance(player))
            {
                playerInSightRange = true;
            }
            else playerInSightRange = false;
        }
        else if (minion != null)
        {
            if (Distance(minion))
            {
                playerInSightRange = true;
            }
            else playerInSightRange = false;
        }

        if (tower != null)
        {
            if (player != null && playerInSightRange)
            {
                if (Distance(player))
                {
                    playerInSightRange = true;

                    if (playerInSightRange && !StopDistance(player) == true)
                    {
                        Movement(player);
                    }

                    if (AttackDistance(player))
                    {              
                        playerInAttackRange = true;
                        AttackPlayer(player);
                    }
                    else playerInAttackRange = false;   
                }
                else playerInSightRange = false;
            }

            else if (minion != null && playerInSightRange)
            {
                if (Distance(minion))
                {
                    playerInSightRange = true;

                    if(playerInSightRange && !StopDistance(minion) == true)
                    {
                        Movement(minion);
                    }
                    
                    if (AttackDistance(minion))
                    {
                        playerInAttackRange = true;
                        AttackPlayer(minion);
                    }

                    else playerInAttackRange = false;
                }
                else playerInSightRange = false;
            }
            else
            {
                Movement(tower);
            }

        }
        /*
        else if (phoenix != null)
        {
            if (player != null && playerInSightRange)
            {
                if (Distance(player))
                {
                    playerInSightRange = true;

                    if (playerInSightRange && !StopDistance(player) == true)
                    {
                        Movement(player);
                    }

                    if (AttackDistance(player))
                    {
                        playerInAttackRange = true;
                        AttackPlayer(player);
                    }
                    else playerInAttackRange = false;
                }
                else playerInSightRange = false;
            }

            else if (minion != null && playerInSightRange)
            {
                if (Distance(minion))
                {
                    playerInSightRange = true;

                    if (playerInSightRange && !StopDistance(minion) == true)
                    {
                        Movement(minion);
                    }

                    if (AttackDistance(minion))
                    {
                        playerInAttackRange = true;
                        AttackPlayer(minion);
                    }

                    else playerInAttackRange = false;
                }
                else playerInSightRange = false;
            }
            else
            {
                Movement(phoenix);
            }
        }

        else if (fontana != null)
        {
            if (player != null && playerInSightRange)
            {
                if (Distance(player))
                {
                    playerInSightRange = true;

                    if (playerInSightRange && !StopDistance(player) == true)
                    {
                        Movement(player);
                    }

                    if (AttackDistance(player))
                    {
                        playerInAttackRange = true;
                        AttackPlayer(player);
                    }
                    else playerInAttackRange = false;
                }
                else playerInSightRange = false;
            }

            else if (minion != null && playerInSightRange)
            {
                if (Distance(minion))
                {
                    playerInSightRange = true;

                    if (playerInSightRange && !StopDistance(minion) == true)
                    {
                        Movement(minion);
                    }

                    if (AttackDistance(minion))
                    {
                        playerInAttackRange = true;
                        AttackPlayer(minion);
                    }

                    else playerInAttackRange = false;
                }
                else playerInSightRange = false;
            }
            else
            {
                Movement(fontana);
            }
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
            //Debug.Log("Attacking " + target2 + " !");
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
        if (distanc <= 15)
        {
            return true;
        }
        else return false;
        
    }

    private bool AttackDistance(GameObject attackobjekt)
    {
        float distance = Vector3.Distance(attackobjekt.transform.position, transform.position);
        if (distance <= 10)
        {
            return true;
        }
        else return false;
    }

    private bool StopDistance(GameObject objekt)
    {
        float distance = Vector3.Distance(objekt.transform.position, transform.position);
        if (distance <= 3)
        {
            return true;
        }
        else return false;
    }

}
