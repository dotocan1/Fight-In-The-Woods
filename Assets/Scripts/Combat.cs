using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private float health = 1000f;
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
            Destroy(gameObject);
            animator.SetBool("isDead", true);
        }
    }

    // ove funkcije su pozvane u skripti koja detektira kolizije

    public void takeWaterThrowDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + health);
        health -= 1f;
    }

    public void takeArrowCircleDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + health);
        health -= 100f;
    }

    public void takeSingleArrowDamage()
    {
        health -= 1000f;
    }

    public void healPlayer()
    {
        health += 100.0f;
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

    public void takeSwordDamage()
    {
        health -= 500f;
        Debug.Log("Taking damage! Enemy health is now:" + health);
    }
}
