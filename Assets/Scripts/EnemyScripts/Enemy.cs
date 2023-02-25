using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public new string name;
    public float attack;
    public float health;
    public float speed;
    public AnimationClip enemyWalkAnim;
    public AnimationClip enemyAttackAnim;
}
