using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/ASPD")]
public class AttackSpeed : Buff
{
    public int damage;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<AttackArea>(true).damage += damage;
        // target.GetComponentInChildren<Arrow>().damage += damage/2;
    }
}
