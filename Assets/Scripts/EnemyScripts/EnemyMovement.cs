using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static event Action<Vector2> onMovement;

    private Enemy enemy;
    private GameObject player;
    void Start()
    {
        enemy = GetComponent<EnemyClass>().enemy;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        EnemyFollow();
    }
    void EnemyFollow()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, enemy.speed * Time.deltaTime);
        onMovement?.Invoke(transform.position);
    }
}
