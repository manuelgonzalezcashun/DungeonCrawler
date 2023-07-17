using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerMovement.onMovement += HandlePlayerMovement;
    }
    private void OnDestroy()
    {
        PlayerMovement.onMovement -= HandlePlayerMovement;
    }
    void HandlePlayerMovement(Vector2 movement)
    {
        bool isMoving = movement != Vector2.zero;
        animator.SetBool("PlayerMove", isMoving);
    }
}
