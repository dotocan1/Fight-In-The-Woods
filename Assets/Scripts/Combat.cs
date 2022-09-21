using System.Collections;
using UnityEngine;
using Photon.Pun;

public class Combat : MonoBehaviour
{
    //public float health = 100f;
    Rigidbody rbEnemy;
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

        animator = GetComponent<Animator>();
        
        rbEnemy = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<PhotonPlayer>().health <= 0)
        {
            
            if (gameObject.tag == "Team_1" || gameObject.tag == "Team_2")
            {
                StartCoroutine(DestroyObject(gameObject));
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
            } else
            {
                PhotonNetwork.Destroy(gameObject);
            }
           
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 300f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeGoodMageFire()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 50f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeArrowCircleDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 150f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void takeSingleArrowDamage()
    {
        gameObject.GetComponent<PhotonPlayer>().health -= 400f;
        Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
    }

    public void healPlayer()
    {
        gameObject.GetComponent<PhotonPlayer>().health += 300.0f;
        Debug.Log("Healing! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);

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
            gameObject.GetComponent<PhotonPlayer>().health -= 50f;
            Debug.Log("Taking damage! Enemy health is now:" + gameObject.GetComponent<PhotonPlayer>().health);
        } 
    }

    private IEnumerator DestroyObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.Destroy(gameObject);
    }

}
