using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerStats stats;
    private float currentHealth;

    private void Start()
    {
        EnemyAttack.OnAttack += TakeDamage;
        currentHealth = stats.health;
    }
    private void OnDestroy()
    {
        EnemyAttack.OnAttack -= TakeDamage;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player is taking damage. Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            //GameManagement.GetInstance().GameOver();
            //gameObject.SetActive(false);
        }
    }
}
