using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float health = 3000f;
    Rigidbody rbEnemy;
    public float m_Thrust = 20f;
    private float pushForce = 5.0f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Enemy") != null)
        {
            animator = GetComponent<Animator>();
            rbEnemy = GameObject.Find("Enemy").GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject,5f);
            animator.SetBool("isDead", true);
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + health);
        health -= 300f;
    }

    public void takeArrowCircleDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + health);
        health -= 150f;
    }

    public void takeSingleArrowDamage()
    {
        health -= 400f;
    }

    public void healPlayer()
    {
        health += 300.0f;
        Debug.Log("Healing! Enemy health is now:" + health);

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
            health -= 50f;
            Debug.Log("Taking damage! Enemy health is now:" + health);
        } 
    }
}
