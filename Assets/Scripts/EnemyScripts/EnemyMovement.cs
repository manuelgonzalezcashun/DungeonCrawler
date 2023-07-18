using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static event Action<Vector2> onMovement;
    [SerializeField] Stats enemyStats;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        EnemyFollow();
        EnemyRotation();
    }
    void EnemyFollow()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, enemyStats.speed * Time.deltaTime);
        onMovement?.Invoke(transform.position);
    }
    void EnemyRotation()
    {

    }
}
