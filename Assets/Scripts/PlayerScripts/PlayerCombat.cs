using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IAttackable
{
    public static event Action<float> OnAttack;

    [Header("Attacking")]
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask attackMask;
    [SerializeField] float attackRange = 0.2f;

    [Header("Player")]
    [SerializeField] PlayerStats stats;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack(stats.attack);
        }
    }
    public void Attack(float attackDamge)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackMask);
        foreach (Collider2D enemy in hitEnemies)
        {
            OnAttack?.Invoke(attackDamge);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
