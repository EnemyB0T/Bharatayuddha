using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/Damage")]
public class DamageBuff : Buff
{
    public int damage;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<AttackArea>(true).damage += damage;
    }
}
