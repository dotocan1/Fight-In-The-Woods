using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onEnemyTriggerEnter;
    public void EnemyTriggerEnter()
    {
        if(onEnemyTriggerEnter != null)
        {
            onEnemyTriggerEnter();
            Debug.Log("ENEMY TRIGGER ENTER");
        }
    }
}
