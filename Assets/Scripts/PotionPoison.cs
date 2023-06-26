using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/Poison")]
public class PotionPoison : Buff
{
    public int damage;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().Damage(damage);
    }
}
