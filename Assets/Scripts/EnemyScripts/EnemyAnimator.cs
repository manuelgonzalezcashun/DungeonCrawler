using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Enemy enemy;
    void Start()
    {
        EnemyMovement.onMovement += HandleEnemyMovement;

        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyClass>().enemy;
    }
    private void OnDestroy()
    {
        EnemyMovement.onMovement -= HandleEnemyMovement;
    }
    void Update()
    {
        
    }
    IEnumerator enemyIsHurt()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isHurt", false);
    }
    IEnumerator enemyIsAttacking()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isAttacking", false);
    }
    void HandleEnemyMovement(Vector2 movement)
    {
        bool isMoving = movement != Vector2.zero;
        if (isMoving)
        {
            animator.Play(enemy.enemyWalkAnim.name);
        }
    }
    //else if (enemyAnimator.GetBool("isHurt"))
    //{
    //    StartCoroutine(enemyIsHurt());
    //}
    //else if (enemyAnimator.GetBool("isAttacking"))
    //{
    //    StartCoroutine(enemyIsAttacking());
    //}
}
