using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Attacking")]
    public Transform attackPoint;
    public LayerMask attackMask;
    public float attackRange = 1f;

    [Header("Player")]
    [SerializeField] PlayerStats stats;
    Animator playerAnim;
    Rigidbody2D rb;

    void Start()
    {
        stats.health = 10f;
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            Attack();
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackMask);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player attacked " + enemy);
            //FindObjectOfType<SoundManager>().Play("PlayerAttack");
            enemy.GetComponent<EnemyBehavior>().TakeDamage(stats.attack);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
