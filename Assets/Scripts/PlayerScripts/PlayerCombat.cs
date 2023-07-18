using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatSystem
{
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack(stats.attack);
        }
    }
}
