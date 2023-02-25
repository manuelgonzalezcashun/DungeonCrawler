using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Counter", menuName = "Counter")]
public class LevelCounter : ScriptableObject
{
    public int enemiesKilled = 0;
}
