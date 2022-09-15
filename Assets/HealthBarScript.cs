using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    Combat combatScript;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        combatScript = FindObjectOfType<Combat>();
    }

    private void Update()
    {
        CurrentHealth = combatScript.health;
        HealthBar.fillAmount = CurrentHealth/MaxHealth;
    }
}
