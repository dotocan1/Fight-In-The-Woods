using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private int health = 1000;

    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log(health);
        health--;
    }
}
