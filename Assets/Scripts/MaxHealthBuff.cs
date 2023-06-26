using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/MaxHealthBuff")]
public class MaxHealthBuff : Buff
{
    public int healthUpgrade;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().buffedHealth += healthUpgrade;
        target.GetComponent<PlayerHealth>().Heal(healthUpgrade);
        
    }
}
