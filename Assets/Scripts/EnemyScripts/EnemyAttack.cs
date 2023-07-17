using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAttackable
{
    public static event Action<float> OnAttack;
    private Enemy enemy;

    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] Transform enemyAttackPoint;
    [SerializeField] float enemyAttackRange;
    [SerializeField] float attackCooldown;
    private float lastAttackTime = 0.0f;
    void Start()
    {
        enemy = GetComponent<EnemyClass>().enemy;
    }
    void Update()
    {
        Attack(enemy.attack);
    }
    public void Attack(float attackDamage)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayerMask);
        foreach (Collider2D player in hitPlayer)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                Debug.Log("Ping");
                //enemyAnimator.SetBool("isAttacking", true);
                OnAttack?.Invoke(attackDamage);
                lastAttackTime = Time.time;
            }
        }
    }
}
