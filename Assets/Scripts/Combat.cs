using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private float health = 1000;
    Rigidbody rbEnemy;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Enemy") != null)
        {
            rbEnemy = GameObject.Find("Enemy").GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    // ovo je pozvano u skripti koja detektira koliziju
    // izmedu vode i enemya
    public void takeDamage()
    {
        Debug.Log("Taking damage! Enemy health is now:" + health);
        health = health - 0.1f;
    }

    public void healPlayer()
    {
        health += 100.0f;
        Debug.Log("Healing! Enemy health is now:" + health);

    }

    public void waveThrow()
    {
        rbEnemy.AddForce(transform.forward * m_Thrust);
    }
}
