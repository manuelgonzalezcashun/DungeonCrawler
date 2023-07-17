using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private Enemy enemy;

    private float currentHealth;
    private void Start()
    {
        enemy = GetComponent<EnemyClass>().enemy;
        currentHealth = enemy.health;
        PlayerCombat.OnAttack += TakeDamage;
    }
    private void OnDestroy()
    {
        PlayerCombat.OnAttack -= TakeDamage;
    }
    public void TakeDamage(float damage)
    {
        //enemyAnimator.SetBool("isHurt", true);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EnemyDie();
        }
    }
    void EnemyDie()
    {
        Debug.Log(enemy.name + " Died!");
        Destroy(gameObject);
    }
}
