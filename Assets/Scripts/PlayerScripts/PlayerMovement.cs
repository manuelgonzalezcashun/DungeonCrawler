using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action<Vector2> onMovement;

    Rigidbody2D rb;
    [SerializeField] PlayerStats stats;

    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotation();
    }
    void PlayerMove()
    {
        #region Player Input
        float velX = Input.GetAxisRaw("Horizontal");
        float velY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(velX, velY);
        #endregion

        rb.velocity = moveDir * stats.speed;
        onMovement?.Invoke(rb.velocity);
    }
    void PlayerRotation()
    {
        if (moveDir.x != 0) transform.localScale = new Vector3(moveDir.x, 1, 1);
    }
}
