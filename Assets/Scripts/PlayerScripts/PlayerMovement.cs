using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] PlayerStats stats;
    private Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotation();
    }
    private void Update()
    {
        if (moveDir != Vector2.zero) 
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    void PlayerMove()
    {
        #region Player Input
        float velX = Input.GetAxisRaw("Horizontal");
        float velY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(velX, velY);
        #endregion
        rb.velocity = moveDir * stats.speed;
    }

    void PlayerRotation()
    {
        if (moveDir.x != 0) transform.localScale = new Vector3(moveDir.x, 1, 1);
    }
}
