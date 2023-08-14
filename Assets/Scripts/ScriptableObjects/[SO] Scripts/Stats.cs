using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Stats", menuName = "Object Stats")]
public class Stats : ScriptableObject
{
    public new string name;
    public float attack;
    public float health;
    public float speed;
}
