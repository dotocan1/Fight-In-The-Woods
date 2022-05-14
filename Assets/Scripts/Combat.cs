using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private float health = 1000;
    Rigidbody rbEnemy;
    public float m_Thrust = 20f;
    public float timer = 0.0001f;
    public bool timerRunning = false;
    int i;


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

        // wave throw

        if (timerRunning)
        {
            timer-= Time.smoothDeltaTime;
            if (timer >= 0)
            {
                Debug.Log(i++);
            }
            else
            {
                rbEnemy.velocity = Vector3.zero;
                rbEnemy.angularVelocity = Vector3.zero;
                timerRunning = false;
            }
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
        Vector3 moveBackwards = Vector3.forward * 2.0f;
        rbEnemy.AddForce(moveBackwards * m_Thrust);
        timerRunning = true;
    }
}
