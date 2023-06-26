using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff/Potion")]
public class PotionHeal : Buff
{
    public int hp;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().Heal(hp);
    }
}
