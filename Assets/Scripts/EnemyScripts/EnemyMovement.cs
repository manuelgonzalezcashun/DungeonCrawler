using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static event Action<Vector2> onMovement;

    [SerializeField] Stats enemyStats;
    private GameObject player;
    Rigidbody2D enemyRB;
    private Vector2 enemyMovement;

    private bool flip;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        EnemyFollow();
        EnemyRotation();
    }
    void EnemyFollow()
    {
        enemyMovement = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, enemyStats.speed * Time.deltaTime);
        enemyRB.MovePosition(enemyMovement);
        onMovement?.Invoke(enemyMovement);
    }
    void EnemyRotation()
    {
        Vector3 enemyScale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            enemyScale.x = Mathf.Abs(enemyScale.x) * (flip ? -1 : 1);
        }
        else
        {
            enemyScale.x = Mathf.Abs(enemyScale.x) * -1 * (flip ? -1 : 1);
        }

        transform.localScale = enemyScale;
    }
}
