using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    public Enemy enemy;
    public LevelCounter count;
    private Animator enemyAnimator;
    private float currentHealth;

    public PlayerStats stats;
    public LayerMask playerLayerMask;
    public Transform enemyAttackPoint;
    public float enemyAttackRange;
    public float attackCooldown = 5.0f;
    private float lastAttackTime = 0.0f;


    void Start()
    {
        //StartCoroutine(GoblinMumble());
        this.gameObject.name = enemy.name;
        currentHealth = enemy.health;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();
    }
    void EnemyAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayerMask);
        foreach (Collider2D player in hitPlayer)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                enemyAnimator.SetBool("isAttacking", true);
                player.GetComponent<PlayerHealth>().TakeDamage(enemy.attack);
                lastAttackTime = Time.time;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        enemyAnimator.SetBool("isHurt", true);
        currentHealth -= damage;
        Debug.Log("Player has hit " + enemy.name + ". Current Health: " + currentHealth.ToString());

        if (currentHealth <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        Debug.Log(enemy.name + " Died!");
        count.enemiesKilled += 1;
        Destroy(gameObject);
    }

    void EnemyFollow()
    {

        if (!enemyAnimator.GetBool("isHurt"))
        {
            enemyAnimator.Play(enemy.enemyWalkAnim.name);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, enemy.speed * Time.deltaTime);
        }
        else if (enemyAnimator.GetBool("isHurt"))
        {
            StartCoroutine(enemyIsHurt());
        }
        else if (enemyAnimator.GetBool("isAttacking"))
        {
            StartCoroutine(enemyIsAttacking());
        }
    }
    IEnumerator enemyIsHurt()
    {
        yield return new WaitForSeconds(1f);
        enemyAnimator.SetBool("isHurt", false);
    }
    IEnumerator enemyIsAttacking()
    {
        yield return new WaitForSeconds(1f);
        enemyAnimator.SetBool("isAttacking", false);
    }

    void FixedUpdate()
    {
        EnemyFollow();
    }
    void Update()
    {
        EnemyAttack();
    }
    IEnumerator GoblinMumble()
    {
        int i = Random.Range(0, 101);
        int randomIndex = Random.Range(3, FindObjectOfType<SoundManager>().sounds.Length);
        if (i % 5 == 0)
        {
            FindObjectOfType<SoundManager>().Play(FindObjectOfType<SoundManager>().sounds[randomIndex].name);
        }
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(GoblinMumble());
    }
}
