using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerStats stats;

    public Transform attackPoint;
    Animator playerAnim;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        MoveDirection();
    }
     void MoveDirection()
    {
        int velX = Mathf.RoundToInt(Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1, 1));
        int velY = Mathf.RoundToInt(Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1, 1));

        #region Player Rotation
        playerAnim.SetFloat("Horizontal", velX);
        playerAnim.SetFloat("Vertical", velY);

        if (playerAnim.GetFloat("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (playerAnim.GetFloat("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion

        #region Player Movement
        Vector2 movement = Vector2.zero;

        if (Mathf.Abs(velX) > Mathf.Abs(velY))
        {
            attackPoint.localPosition = new Vector3(0.6f, 0, 0);
            movement = new Vector2(velX, 0);
        }
        else
        {
            movement = new Vector2(0, velY);

            if (velY > 0)
                attackPoint.localPosition = new Vector3(0, 0.7f, 0);
            else if (velY < 0)
                attackPoint.localPosition = new Vector3(0, -0.7f, 0);
        }

        rb.velocity = movement * stats.speed;
        #endregion
    }
}
