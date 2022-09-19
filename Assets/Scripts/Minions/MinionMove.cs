using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMove : MonoBehaviour
{
    [SerializeField] public GameObject tower;
    //minionspeed
    private float minionspeed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        tower = GameObject.FindWithTag("Tower_2A");
    }


    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        Movement();
    }
    private void Movement()
    {
        Vector3 MinionDirection = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z);
        Vector3 vector3 = tower.transform.position - MinionDirection;
        transform.LookAt(tower.transform.position);
        transform.Translate(new Vector3(0f,0f, minionspeed * Time.deltaTime));
    }

}    
    



