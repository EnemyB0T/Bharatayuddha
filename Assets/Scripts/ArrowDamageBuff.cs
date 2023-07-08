using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/ArrowDamage")]
public class ArrowDamageBuff : BowBuff
{
    public int damage;

    public override void Apply(ArrowData arrow)
    {
        arrow.damage += this.damage;
    }
}
