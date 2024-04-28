using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DoT/FireAoEFriendly")]
public class FireAoEFriendly : DamageOverTime
{
 
    public override void Apply(GameObject target)
    {
        target.GetComponent<EnemyHealth>().Damage(damageOverTime);
    }
    public void IncreaseDamage(int amount)
{
    damageOverTime += amount;
}
}
