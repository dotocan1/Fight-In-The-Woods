using UnityEngine;
using Photon.Pun;

public class Combat : MonoBehaviour
{
    //public float health = 100f;
    Rigidbody rbEnemy;
    GameObject enemy;
    private float enemyHealth;
    public float m_Thrust = 20f;
    private float pushForce = 5.0f;

    PhotonView view;
    private Animator animator;
    private Damage damageScript;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        Combat combatScript = GetComponent<Combat>();

        if (!view.IsMine)
        {
            combatScript.enabled = false;
        }

        Debug.Log("PLAYER COMBAT: " + gameObject.name);
        animator = GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<PhotonPlayer>().health;
        //rbEnemy = damageScript.getEnemy().GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("isDead", true);
            Destroy(gameObject, 5f);
            //enemy.GetComponent<Animator>().SetBool("isDead", true);
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        view.RPC("RPC_Take_Damage", RpcTarget.All, 300f);
    }

    public void takeArrowCircleDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + enemyHealth);
        enemyHealth -= 150f;
    }

    public void takeSingleArrowDamage()
    {
        enemyHealth -= 400f;
    }

    public void healPlayer()
    {
        enemyHealth += 300.0f;
        Debug.Log("Healing! Enemy health is now:" + enemyHealth);

    }

    public void wavePush()
    {

        Vector3 moveBackwards = Vector3.forward * pushForce;
        rbEnemy.AddForce(moveBackwards * m_Thrust);

        // stops force

        // rbEnemy.velocity = Vector3.zero;
        //  rbEnemy.angularVelocity = Vector3.zero;

    }

    public void takeSwordDamage(GameObject character)
    {
        // ovo ce se koristit za provjeru ako je u animaciji
        Animator a_animator = character.GetComponent<Animator>();
        if (a_animator.GetBool("isSwordAttacking"))
        {
            enemyHealth -= 50f;
            Debug.Log("Taking damage! Enemy health is now:" + enemyHealth);
        } 
    }

    [PunRPC]
    void RPC_Take_Damage(float damage)
    {
        Debug.Log("ENEMY'S HEALTH BEFORE DAMGE: " + enemyHealth);

        enemyHealth -= damage;
        Debug.Log("Taking damage! Enemy health is now:" + enemyHealth);
    }
}
